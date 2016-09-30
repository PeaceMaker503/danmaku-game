﻿using System;
using System.Collections.Generic;
using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage
{
    public class Stage
    {
        public double time;
        private List<Task> _tasks;
        public Player player { get; set; }
        private double _timerPlayerRespawn;
        public Dictionary<string, Particle> particlesPrototypes { get; set; }
        public Dictionary<string, Enemy> enemiesPrototypes { get; set; }
        public Dictionary<ulong, Enemy> enemies { get; set; }
        public Dictionary<ulong, Particle> particles { get; set; }
        private List<Task> _tasksInit;
        private ulong _playerParticlesId;

        public Stage()
        {
            enemies = new Dictionary<ulong, Enemy>();
            particlesPrototypes = new Dictionary<string, Particle>();
            enemiesPrototypes = new Dictionary<string, Enemy>();
            particles = new Dictionary<ulong, Particle>();
            _tasks = new List<Task>();
            time = 0;
            _timerPlayerRespawn = 0;
            _playerParticlesId = 0;
        }

        public void addTask(Task task)
        {
            _tasks.Add(task);
        }

        public void addNewParticlePrototype(String name, Particle part)
        {
            particlesPrototypes[name] = part;
        }

        public void addNewEnemyPrototype(String name, Enemy enemy)
        {
            enemiesPrototypes[name] = enemy;
        }

        public void run()
        {
            foreach (Task task in _tasks)
            {
                if (time >= task.time)
                {
                    task.run(this);
                }
            }
            _tasks.RemoveAll(item => item.hasRun == true);
            if (_timerPlayerRespawn == 0 && player.isAlive == false) //player vient de mourir
            {
                _timerPlayerRespawn = time;
            }
            else if (player.isAlive == false && time - _timerPlayerRespawn > 1.5) //on sait que le player deja mort et il est temps de le ressusciter
            {
                player.isAlive = true;
                _timerPlayerRespawn = 0;
            }
        }

        public void initialize()
        {
            enemies.Clear();
            particles.Clear();
            player.initPlayer();
            time = 0;
            _timerPlayerRespawn = 0;
            if(_tasksInit == null)
            {
                _tasksInit = new List<Task>(_tasks);
            }
            else
            {
                _tasks = new List<Task>(_tasksInit);
                foreach (Task task in _tasks)
                {
                    task.hasRun = false;
                }
            }
        }

        public void instantiateEnemy(String enemyType, ulong id, Vector2 position, Vector2 direction, Vector2 destination, Vector2 fdirection, ulong health, float speed, float fspeed)
        {
            Enemy e = this.getEnemyInstanceOf(enemyType);
            e.health = health;
            e.speed = speed;
            e.position = position;
            e.finishDir = fdirection;
            e.finishSpeed = fspeed;
            if (direction==Vector2.Zero)
            {
                e.addNewDestination(destination);
            }
            else
            {
                e.direction = direction;
            }
            enemies.Add(id, e);
        }

        public void orderToMove(ulong id, Vector2 destination, Vector2 direction, float speed, Vector2 fdirection, float fspeed)
        {
            Enemy e;
            if (enemies.TryGetValue(id, out e) && e.isAlive)
            {
                if (direction == Vector2.Zero)
                {
                    e.addNewDestination(destination, speed);
                }
                else
                {
                    e.direction = direction;
                    e.speed = speed;
                }

                if(fdirection != Vector2.Zero)
                {
                    e.finishDir = fdirection;
                    if(fspeed<=0)
                    {
                        e.finishSpeed = e.speed;
                    }
                    else
                    {
                        e.finishSpeed = fspeed;
                    }
                }
            }
        }

        public void orderToShoot(ulong enemyId, String particleType, ulong particleId, Vector2 destination, Vector2 direction, float speed)
        {
            Enemy e;
            if (enemies.TryGetValue(enemyId, out e) && e.isAlive)
            {
                Particle p = this.getParticleInstanceOf(particleType);
                p.position = e.positionCollision;
                if(direction==Vector2.Zero)
                {
                    p.destination = destination;
                }
                else
                {
                    p.direction = direction;
                }
                p.speed = speed;
                particles.Add(particleId, p);
            }
        }

        public Particle getParticleInstanceOf(String name)
        {
            Particle originalParticle = particlesPrototypes[name];
            return (Particle)Activator.CreateInstance(originalParticle.GetType(), originalParticle);
        }

        public Enemy getEnemyInstanceOf(String name)
        {
            Enemy originalEnemy = enemiesPrototypes[name];
            return (Enemy)Activator.CreateInstance(originalEnemy.GetType(), originalEnemy);
        }

        public void playerShoot()
        {
            Particle p1 = this.getParticleInstanceOf(player.particleName);
            p1.position = player.position + player.particleOffset1;
            Particle p2 = this.getParticleInstanceOf(player.particleName);
            p2.position = player.position + player.particleOffset2;
            particles.Add(++_playerParticlesId, p1);
            particles.Add(++_playerParticlesId, p2);
        }

        public void updateEnemiesPositions()
        {
            foreach (Enemy enemy in this.enemies.Values)
            {
                enemy.move();
            }
        }

        public void updateParticlesPositions()
        {
            foreach(Particle particle in particles.Values)
            {
                particle.move();
            }
        }
    }
}
