using System;
using System.Collections.Generic;
using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;
using gameLIB.main;
using gameLIB.utils;
using Newtonsoft.Json;
using System.Linq;
using System.CodeDom.Compiler;
using System.Reflection;
using gameLIB.components.stage.models;

namespace gameLIB.components.stage
{
    public class Stage
    {
        public double time;
        public Player player { get; set; }
        private double timerPlayerRespawn;
        public Dictionary<string, Particle> particlesPrototypes { get; set; }
        public Dictionary<string, Enemy> enemiesPrototypes { get; set; }
        public Dictionary<string, Dictionary<long, Enemy>> enemies { get; set; }
        public Dictionary<string, Dictionary<long, Particle>> particles { get; set; }
        private Dictionary<MethodInfo, Params> scripts;
        private Dictionary<MethodInfo, long> scriptsCount;
        private Dictionary<MethodInfo, MethodInfo> scriptsConditions;
        private long playerParticlesId;
        private long idEnemy;
        private long idParticle;
        private StageApi stageApi;
        private object[] methodArgs;

        public Stage()
        {
            enemies = new Dictionary<string, Dictionary<long, Enemy>>();
            particlesPrototypes = new Dictionary<string, Particle>();
            enemiesPrototypes = new Dictionary<string, Enemy>();
            particles = new Dictionary<string, Dictionary<long, Particle>>();
            scriptsCount = new Dictionary<MethodInfo, long>();
            scriptsConditions = new Dictionary<MethodInfo, MethodInfo>();
            time = 0;
            scripts = new Dictionary<MethodInfo, Params>();
            this.idEnemy = 0;
            this.idParticle = 0;
            timerPlayerRespawn = 0;
            playerParticlesId = 0;
            stageApi = new StageApi(this);
            methodArgs = new object[] { stageApi };
        }

        public void addNewParticlePrototype(String name, Particle part)
        {
            particlesPrototypes[name] = part;
            particles[part.image.name] = new Dictionary<long, Particle>();
        }

        public void setScript(CompilerResults cp)
        {
            Type tScript = cp.CompiledAssembly.GetType("Game.Script");
            MethodInfo[] mis = tScript.GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
            Dictionary<string, MethodInfo> misConds = new Dictionary<string, MethodInfo>();
            for(int i=0;i<mis.Length;i++)
            {
                object[] o = mis[i].GetCustomAttributes(typeof(Condition), false);
                if (o.Length == 1)
                    misConds[((Condition)o[0]).Name] = mis[i];
            }

            mis = tScript.GetMethods(BindingFlags.Public | BindingFlags.Static);
            for(int i=0;i<mis.Length;i++)
            {
                MethodInfo mi = mis[i];
                Params p = (Params)mi.GetCustomAttributes(typeof(Params), false)[0];

                if (p.Condition != null)
                {
                    MethodInfo mCond;
                    if (misConds.TryGetValue(p.Condition, out mCond))
                        scriptsConditions[mi] = mCond;
                    else
                        throw new Exception("Condition does not exist.");
                }

                if (p.Begin < 0)
                    throw new Exception("Begin time cannot be negative.");

                if (p.End <= 0 || p.Each <= 0)
                    throw new Exception("Cadence or end time cannot be equal to zero nor negative.");

                if(p.End > 0 && p.Each > 0 && !p.OnlyOnce)
                    scriptsCount[mi] = 0;

                scripts[mi] = p;
            }
        }

        public void addNewEnemyPrototype(String name, Enemy enemy)
        {
            enemiesPrototypes[name] = enemy;
            enemies[enemy.image.name] = new Dictionary<long, Enemy>();
        }

        public void run()
        {
            if (timerPlayerRespawn == 0 && player.isAlive == false) //player vient de mourir
            {
                timerPlayerRespawn = time;
            }
            else if (player.isAlive == false && time - timerPlayerRespawn > 1.5) //on sait que le player deja mort et il est temps de le ressusciter
            {
                player.isAlive = true;
                timerPlayerRespawn = 0;
            }

            foreach (MethodInfo mi in scripts.Keys)
            {
                MethodInfo mCond;
                bool conditionExists = scriptsConditions.TryGetValue(mi, out mCond);
                Params p = scripts[mi];

                if (p.OnlyOnce)
                {
                    if (time >= p.Begin)
                    {
                        if(!conditionExists || (bool)mCond.Invoke(null, methodArgs))
                            mi.Invoke(null, methodArgs);
                    }
                }
                else
                {
                    if (time >= p.Begin && time <= p.End)
                    {
                        long count = scriptsCount[mi];
                        double nextTime = p.Begin + (count * p.Each);
                        if (Math.Abs(time - nextTime) <= 0.01)
                        {
                            if (!conditionExists || (bool)mCond.Invoke(null, methodArgs))
                                mi.Invoke(null, methodArgs);

                            scriptsCount[mi]++;
                        }
                    }
                }
            }

            IEnumerable<KeyValuePair<MethodInfo, Params>> newScripts = scripts.Where(item => !((item.Value.OnlyOnce && time >= item.Value.Begin) ||  (!item.Value.OnlyOnce && time >= item.Value.Begin && time >= item.Value.End)));
            scripts = newScripts.ToDictionary(item => item.Key, item => item.Value);
            IEnumerable<KeyValuePair<MethodInfo, long>> newScriptsCount = scriptsCount.Where(item => scripts.ContainsKey(item.Key));
            scriptsCount = newScriptsCount.ToDictionary(item => item.Key, item => item.Value);
        }

        public void initialize()
        {
            foreach (string key in enemies.Keys)
                enemies[key].Clear();

            foreach (string key in particles.Keys)
                particles[key].Clear();

            player.initialize();
            time = 0;
            timerPlayerRespawn = 0;
        }

        private Particle findParticle(long particleId)
        {
            Particle p;
            foreach (string key in particles.Keys)
            {
                if (particles[key].TryGetValue(particleId, out p))
                    return p;
            }

            return null;
        }

        private Enemy findEnemy(long enemyId)
        {
            Enemy e;
            foreach (string key in enemies.Keys)
            {
                if (enemies[key].TryGetValue(enemyId, out e))
                    return e;
            }

            return null;
        }

        public long instantiateEnemy(String enemyType, long health, Vector2 position, out Enemy eout)
        {
            Enemy e = this.getEnemyInstanceOf(enemyType);
            e.health = health;
            e.position = position;
            e.speed = 0;
            enemies[e.image.name].Add(idEnemy++, e);
            eout = e;
            return idEnemy-1;
        }

        public long instantiateParticle(String particleType, Vector2 position, out Particle pout)
        {
            Particle p = this.getParticleInstanceOf(particleType);
            p.position = position;
            p.speed = 0;
            particles[p.image.name].Add(idParticle++, p);
            pout = p;
            return idParticle - 1;
        }

        public long instantiateParticle(String particleType, long enemyId, out Particle pout)
        {
            Enemy e = this.findEnemy(enemyId);
            if(e != null)
            {
                Particle p = this.getParticleInstanceOf(particleType);
                p.position = e.position;
                p.speed = 0;
                particles[p.image.name].Add(idParticle++, p);
                pout = p;
                return idParticle - 1;
            }
            else
            {
                pout = null;
                return -1;
            }
        }

        public Particle getParticleInstanceOf(String name)
        {
            Particle originalParticle = particlesPrototypes[name];
            return new Particle(originalParticle.image, originalParticle.parts, originalParticle.scale);
        }

        public Enemy getEnemyInstanceOf(String name)
        {
            Enemy originalEnemy = enemiesPrototypes[name];
            return new Enemy(originalEnemy.image, originalEnemy.parts, originalEnemy.nbFrames, originalEnemy.scale);
        }

        public void playerShoot()
        {
            Particle p1 = this.getParticleInstanceOf(GameApi.LoadHelper.MISSILE_TEXTURE);
            p1.position = player.position + player.particleP1;
            Particle p2 = this.getParticleInstanceOf(GameApi.LoadHelper.MISSILE_TEXTURE);
            p2.position = player.position + player.particleP2;
            p1.setDirection(new Vector2(0, -1), 15);
            p2.setDirection(new Vector2(0, -1), 15);
            particles[GameApi.LoadHelper.MISSILE_TEXTURE].Add(++playerParticlesId, p1);
            particles[GameApi.LoadHelper.MISSILE_TEXTURE].Add(++playerParticlesId, p2);
        }

        public void updateEnemiesPositions()
        {
            foreach (string key in enemies.Keys)
            {
                foreach (Enemy enemy in this.enemies[key].Values)
                {
                    enemy.updatePosition();
                }
            }
        }

        public void updateParticlesPositions()
        {
            foreach(string key in particles.Keys)
            {
                foreach (Particle particle in particles[key].Values)
                {
                    particle.updatePosition();
                }
            }
        }
    }
}
