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
        private Dictionary<CompilerResults, Dictionary<string, MethodInfo>> cpBehavs;
        private Dictionary<CompilerResults, Dictionary<string, MethodInfo>> cpConds;
        private List<ScriptInfo> scripts;
        private List<ScriptInfo> behaviorsToAdd;

        private long playerParticlesId;
        private long idEnemy;
        private long idParticle;
        private StageApi stageApi;
        private object[] methodArgs;
        public object Arg { get; private set; }
        public ScriptInfo Si { get; private set; }

        public Stage()
        {
            enemies = new Dictionary<string, Dictionary<long, Enemy>>();
            particlesPrototypes = new Dictionary<string, Particle>();
            enemiesPrototypes = new Dictionary<string, Enemy>();
            particles = new Dictionary<string, Dictionary<long, Particle>>();
            scripts = new List<ScriptInfo>();
            cpBehavs = new Dictionary<CompilerResults, Dictionary<string, MethodInfo>>();
            cpConds = new Dictionary<CompilerResults, Dictionary<string, MethodInfo>>();
            behaviorsToAdd = new List<ScriptInfo>();
            time = 0;
            this.idEnemy = 0;
            this.idParticle = 0;
            timerPlayerRespawn = 0;
            playerParticlesId = 0;
            stageApi = new StageApi(this);
            methodArgs = new object[] { stageApi };
        }

        public void addBehavior(string behavior, object value)
        {
            CompilerResults cp = Si.cp;
            Dictionary<string, MethodInfo> mBehavs = cpBehavs[cp];
            Dictionary<string, MethodInfo> mConds = cpConds[cp];
            MethodInfo mBehav = mBehavs[behavior];
            object[] attributes = mBehav.GetCustomAttributes(typeof(Params), false);
            if (attributes.Length == 1)
            {
                ScriptInfo si = new ScriptInfo();
                object attribute = attributes[0];
                Params p = (Params)attribute;
                checkParams(p, mConds);
                p.Begin = time + p.Begin;
                si.p = p;
                si.returnValue = value;
                si.count = 0;
                si.mScript = mBehav;
                if (p.Condition != null)
                    si.mCond = mConds[p.Condition];

                si.cp = cp;
                behaviorsToAdd.Add(si);
            }
        }

        public void addNewParticlePrototype(String name, Particle part)
        {
            particlesPrototypes[name] = part;
            particles[part.image.name] = new Dictionary<long, Particle>();
        }

        public void setScript(CompilerResults cp)
        {
            Type tScript = cp.CompiledAssembly.GetType("Game.Script");
            Dictionary<string, MethodInfo> mConds = new Dictionary<string, MethodInfo>();
            Dictionary<string, MethodInfo> mBehavs = new Dictionary<string, MethodInfo>();

            MethodInfo[] mis = tScript.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < mis.Length; i++)
            {
                MethodInfo mi = mis[i];
                object[] attributes = mi.GetCustomAttributes(false);
                if (attributes.Length > 0)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        object attribute = attributes[j];
                        if (attribute.GetType() == typeof(Condition))
                        {
                            Condition c = (Condition)attribute;
                            mConds[c.Name] = mi;
                        }
                        else if(attribute.GetType() == typeof(Behavior))
                        {
                            Behavior b = (Behavior)attribute;
                            mBehavs[b.Name] = mi;
                        }
                    }
                }
            }
            cpBehavs[cp] = mBehavs;
            cpConds[cp] = mConds;

            for (int i = 0; i < mis.Length; i++)
            {
                MethodInfo mi = mis[i];
                object[] attributes = mi.GetCustomAttributes(false);
                if (attributes.Length == 1)
                {
                    ScriptInfo si = new ScriptInfo();
                    object attribute = attributes[0];
                    if(attribute.GetType() == typeof(Params))
                    {
                        Params p = (Params)attribute;
                        checkParams(p, mConds);
                        si.p = p;
                        si.returnValue = null;
                        si.count = 0;

                        if (p.Condition != null)
                            si.mCond = mConds[p.Condition];

                        si.cp = cp;
                        si.mScript = mi;
                        scripts.Add(si);
                    }
                }
            }
        }

        private void checkParams(Params p, Dictionary<string, MethodInfo> mConds)
        {
            if (p.Condition != null)
            {
                if (!mConds.ContainsKey(p.Condition))
                    throw new Exception("Condition does not exist.");
            }

            if (p.Begin < 0)
                throw new Exception("Begin time cannot be negative.");

            if (!p.OnlyOnce && p.Count <= 0 && p.Each <= 0)
                p.OnlyOnce = true;
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

            foreach (ScriptInfo si in scripts)
            {
                MethodInfo mi = si.mScript;
                if (si.p.OnlyOnce)
                {
                    if (time >= si.p.Begin)
                    {
                        if(si.mCond == null || (bool)si.mCond.Invoke(null, methodArgs))
                        {
                            if (mi.ReturnType != typeof(void))
                            {
                                object arg = si.returnValue;
                                Arg = arg;
                            }

                            Si = si;
                            object o = mi.Invoke(null, methodArgs);

                            if (mi.ReturnType != typeof(void))
                                si.returnValue = o;

                            Arg = null;
                        }
                    }
                }
                else
                {
                    if (time >= si.p.Begin && time <= si.p.Begin + (si.p.Count*si.p.Each))
                    {
                        long count = si.count;
                        double nextTime = si.p.Begin + (count * si.p.Each);
                        if (Math.Abs(time - nextTime) <= 0.01)
                        {
                            if (si.mCond == null || (bool)si.mCond.Invoke(null, methodArgs))
                            {
                                if (mi.ReturnType != typeof(void))
                                {
                                    object arg = si.returnValue;
                                    Arg = arg;
                                }

                                Si = si;
                                object o = mi.Invoke(null, methodArgs);

                                if(mi.ReturnType != typeof(void))
                                    si.returnValue = o;

                                Arg = null;
                            }
                            si.count++;
                        }
                    }
                }
            }

            scripts.RemoveAll(item => (item.p.OnlyOnce && time >= item.p.Begin) ||  (!item.p.OnlyOnce && time >= item.p.Begin + (item.p.Count * item.p.Each)));

            if(behaviorsToAdd.Count > 0)
            {
                foreach (ScriptInfo si in behaviorsToAdd)
                    scripts.Add(si);

                behaviorsToAdd.Clear();
            }
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

        public long instantiateParticle(String particleType, Enemy e, out Particle pout)
        {
            if (e.isAlive)
                return instantiateParticle(particleType, e.position, out pout);
            else
            {
                pout = null;
                return -1;
            }
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
