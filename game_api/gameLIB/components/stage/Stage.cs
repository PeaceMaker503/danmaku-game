using System;
using System.Collections.Generic;
using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;
using gameLIB.main;
using gameLIB.utils;
using gameLIB.components.stage.parser.models;
using Newtonsoft.Json;

namespace gameLIB.components.stage
{
    public class Stage
    {
        public double time;
        private List<Task> tasks;
        public Player player { get; set; }
        private double timerPlayerRespawn;
        public Dictionary<string, Particle> particlesPrototypes { get; set; }
        public Dictionary<string, Enemy> enemiesPrototypes { get; set; }
        public Dictionary<string, Dictionary<long, Enemy>> enemies { get; set; }
        public Dictionary<string, Dictionary<long, Particle>> particles { get; set; }
        private List<Task> initTasks;
        private long playerParticlesId;

        public Stage()
        {
            enemies = new Dictionary<string, Dictionary<long, Enemy>>();
            particlesPrototypes = new Dictionary<string, Particle>();
            enemiesPrototypes = new Dictionary<string, Enemy>();
            particles = new Dictionary<string, Dictionary<long, Particle>>();
            tasks = new List<Task>();
            time = 0;
            timerPlayerRespawn = 0;
            playerParticlesId = 0;
        }

        public void addTask(Task task)
        {
            tasks.Add(task);
        }

        public void addNewParticlePrototype(String name, Particle part)
        {
            particlesPrototypes[name] = part;
            particles[part.image.name] = new Dictionary<long, Particle>();
        }

        public void addNewEnemyPrototype(String name, Enemy enemy)
        {
            enemiesPrototypes[name] = enemy;
            enemies[enemy.image.name] = new Dictionary<long, Enemy>();
        }

        public void run()
        {
            foreach (Task task in tasks)
            {
                if (time >= task.time)
                {
                    task.run(this);
                }
            }
            tasks.RemoveAll(item => item.hasRun == true);
            if (timerPlayerRespawn == 0 && player.isAlive == false) //player vient de mourir
            {
                timerPlayerRespawn = time;
            }
            else if (player.isAlive == false && time - timerPlayerRespawn > 1.5) //on sait que le player deja mort et il est temps de le ressusciter
            {
                player.isAlive = true;
                timerPlayerRespawn = 0;
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
            if(initTasks == null)
            {
                initTasks = new List<Task>(tasks);
            }
            else
            {
                tasks = new List<Task>(initTasks);
                foreach (Task task in tasks)
                {
                    task.hasRun = false;
                }
            }
        }

        public Vector2 parseValueV(string value)
        {
            if (value == null)
            {
                return new Vector2(float.NaN, float.NaN);
            }

            if (value.StartsWith("%") && value.EndsWith("%"))
            {
                value = value.Replace("%", String.Empty);
                if(value == "PLAYER_POSITION")
                    return new Vector2(player.position.X, player.position.Y);

                if(value.StartsWith("PARTICLE_POSITION_"))
                {
                    value = value.Replace("PARTICLE_POSITION_", String.Empty);
                    long id = long.Parse(value);
                    Particle p = findParticle(id);
                    if (p != null)
                        return new Vector2(p.position.X, p.position.Y);
                    else
                        return new Vector2(float.NaN, float.NaN);
                }
            }

            JsonVector2 v = JsonConvert.DeserializeObject<JsonVector2>(value);
            return new Vector2(v.X, v.Y);
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

        public void instantiateEnemy(String enemyType, long id, string position, string direction, string destination, string fdirection, long health, float speed, float fspeed)
        {
            Enemy e = this.getEnemyInstanceOf(enemyType);
            e.health = health;
            e.speed = speed;

            Vector2 vPosition = parseValueV(position);
            Vector2 vDirection = parseValueV(direction);
            Vector2 vDestination = parseValueV(destination);
            Vector2 vFDirection = parseValueV(fdirection);

            if (Vector2Extension.isNaN(vPosition))
                vPosition = Vector2.Zero ;

            if (float.IsNaN(speed))
                speed = 0f;

            if (float.IsNaN(fspeed))
                fspeed = 0f;

            e.position = vPosition;

            if (Vector2Extension.isNaN(vDirection) && !Vector2Extension.isNaN(vDestination))
                e.setDestination(vDestination, speed);
            else if (Vector2Extension.isNaN(vDestination) && !Vector2Extension.isNaN(vDirection))
                e.setDirection(vDirection, speed);
            else
                e.setDestination(Vector2.Zero, speed);

            e.fdirection = vFDirection;
            e.fspeed = fspeed;

            enemies[e.image.name].Add(id, e);
        }

        public void orderToMove(long id, string destination, string direction, float speed, string fdirection, float fspeed)
        {
            Enemy e = findEnemy(id);
            if (e != null)
            {
                if (float.IsNaN(speed))
                    speed = 0f;

                if (float.IsNaN(fspeed))
                    fspeed = 0f;

                Vector2 vDirection = parseValueV(direction);
                Vector2 vDestination = parseValueV(destination);
                Vector2 vFDirection = parseValueV(fdirection);

                if (Vector2Extension.isNaN(vDirection) && !Vector2Extension.isNaN(vDestination))
                    e.setDestination(vDestination, speed);
                else if (Vector2Extension.isNaN(vDestination) && !Vector2Extension.isNaN(vDirection))
                    e.setDirection(vDirection, speed);
                else
                    e.setDestination(Vector2.Zero, speed);

                e.fdirection = vFDirection;
                e.fspeed = fspeed;
            }
        }

        public void orderToParticleMove(long id, string position, string destination, string direction, float speed)
        {
            Particle p = findParticle(id);
            if(p!= null)
            {
                if (!float.IsNaN(speed))
                    p.speed = speed;
                else
                    speed = p.speed;

                Vector2 vPosition = parseValueV(position);

                if (!Vector2Extension.isNaN(vPosition))
                    p.position = vPosition;

                Vector2 vDirection = parseValueV(direction);
                Vector2 vDestination = parseValueV(destination);

                if (Vector2Extension.isNaN(vDirection) && !Vector2Extension.isNaN(vDestination))
                    p.setDestination(vDestination, speed);
                else if (Vector2Extension.isNaN(vDestination) && !Vector2Extension.isNaN(vDirection))
                    p.setDirection(vDirection, speed);
            }
        }

        public void orderToShoot(long enemyId, string particleType, long particleId, string position, string destination, string direction, float speed)
        {
            Particle p = null;

            Vector2 vDirection = parseValueV(direction);
            Vector2 vDestination = parseValueV(destination);

            if (enemyId < 0)
            {
                p = this.getParticleInstanceOf(particleType);

                Vector2 vPosition = parseValueV(position);

                if (Vector2Extension.isNaN(vPosition))
                    vPosition = Vector2.Zero;

                p.position = vPosition;
            }
            else
            {
                Enemy e = findEnemy(enemyId);
                if (e != null && e.isAlive)
                {
                    p = this.getParticleInstanceOf(particleType);
                    p.position = e.position;
                }
            }

            if (p != null)
            {
                if (float.IsNaN(speed))
                    speed = 0f;

                if (Vector2Extension.isNaN(vDirection) && !Vector2Extension.isNaN(vDestination))
                    p.setDestination(vDestination, speed);
                else if (Vector2Extension.isNaN(vDestination) && !Vector2Extension.isNaN(vDirection))
                    p.setDirection(vDirection, speed);
                else
                    p.setDestination(Vector2.Zero, speed);

                particles[p.image.name].Add(particleId, p);
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
