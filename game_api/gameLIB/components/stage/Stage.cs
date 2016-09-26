using System;
using System.Collections.Generic;
using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage
{
    public sealed class Stage
    {
        private double _time;
        private List<Task> _tasks;
        private Player _player;
        private double _timerPlayerRespawn;
        private Dictionary<String, Particle> _particlesPrototypes;
        private Dictionary<String, Enemy> _enemiesPrototypes;
        private Dictionary<String, Enemy> _enemies;
        private Dictionary<String, Particle> _particles;
        private List<Task> _tasksInit;

        private static int _particlesID;
        public Stage()
        {
            Enemies = new Dictionary<String, Enemy>();
            ParticlesPrototypes = new Dictionary<String, Particle>();
            EnemiesPrototypes = new Dictionary<string, Enemy>();
            Particles = new Dictionary<string, Particle>();
            _tasks = new List<Task>();
            _time = 0;
            _timerPlayerRespawn = 0;
            _particlesID = 0;
        }

        public void addTask(Task task)
        {
            _tasks.Add(task);
        }

        public void addNewParticlePrototype(String name, Particle part)
        {
            ParticlesPrototypes[name] = part;
        }

        public void addNewEnemyPrototype(String name, Enemy enemy)
        {
            EnemiesPrototypes[name] = enemy;
        }

        public void run()
        {
            foreach (Task task in _tasks)
            {
                if (Time >= task.Time)
                {
                    task.run(this);
                }
            }
            _tasks.RemoveAll(item => item.hasRun == true);
            if (_timerPlayerRespawn == 0 && Player.isAlive == false) //player vient de mourir
            {
                _timerPlayerRespawn = _time;
            }
            else if (Player.isAlive == false && _time - _timerPlayerRespawn > 1.5) //on sait que le player deja mort et il est temps de le ressusciter
            {
                Player.isAlive = true;
                _timerPlayerRespawn = 0;
            }
        }

        public void initialize()
        {
            Enemies.Clear();
            Particles.Clear();
            _player.initPlayer();
            _time = 0;
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

        public void instantiateEnemy(String enemyType, String id, Vector2 position, Vector2 direction, Vector2 destination, Vector2 fdirection, int health, float speed, float fspeed)
        {
            Enemy e = this.getEnemyInstanceOf(enemyType);
            e.health = health;
            e.speed = speed;
            e.position = position;
            e.finishDir = fdirection;
            e.finishSpeed = fspeed;
            if (direction==Vector2.Zero)
            {
                e.addTraj(destination);
            }
            else
            {
                e.direction = direction;
            }
            Enemies.Add(id, e);
        }

        public void orderToMove(String id, Vector2 destination, Vector2 direction, Vector2 fdirection, float speed, float fspeed)
        {
            Enemy e;
            if (_enemies.TryGetValue(id, out e) && e.isAlive)
            {
                if (direction == Vector2.Zero)
                {
                    e.addTraj(destination, speed);
                    e.finishDir = fdirection;
                    e.finishSpeed = fspeed;
                }
                else
                {
                    e.direction = direction;
                    e.speed = speed;
                }
            }
        }

        public void orderToShoot(String id, String particleType, Vector2 destination, Vector2 direction, float speed)
        {
            Enemy e;
            if (_enemies.TryGetValue(id, out e) && e.isAlive)
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
                _particles.Add(_particlesID.ToString(), p);
                _particlesID++;
            }
        }

        public void move()
        {
           /* String enemyName = args.enemyName;
            Vector2 destination = args.destination;

            Enemy e;
            if (_enemies.TryGetValue(enemyName, out e))
            {
                if (e.isAlive)
                {
                    e.addTraj(destination);
                }
            }*/
        }

        public Particle getParticleInstanceOf(String name)
        {
            Particle originalParticle = ParticlesPrototypes[name];
            return (Particle)Activator.CreateInstance(originalParticle.GetType(), originalParticle);
        }

        public Enemy getEnemyInstanceOf(String name)
        {
            Enemy originalEnemy = EnemiesPrototypes[name];
            return (Enemy)Activator.CreateInstance(originalEnemy.GetType(), originalEnemy);
        }

        public void playerShoot()
        {
            Particle p1 = this.getParticleInstanceOf(Player.ParticleName);
            p1.position = _player.position + Player.ParticleOffset1;
            Particle p2 = this.getParticleInstanceOf(Player.ParticleName);
            p2.position = _player.position + Player.ParticleOffset2;
            Particles.Add(Player.ParticleName+ _particlesID, p1);
            _particlesID++;
            Particles.Add(Player.ParticleName+ _particlesID, p2);
            _particlesID++;
        }

        public void updateEnemiesPositions()
        {
            foreach (Enemy enemy in this.Enemies.Values)
            {
                enemy.move();
            }
        }

        public void updateParticlesPositions()
        {
            foreach(Particle particle in Particles.Values)
            {
                particle.move();
            }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public Dictionary<string, Enemy> EnemiesPrototypes
        {
            get
            {
                return _enemiesPrototypes;
            }

            set
            {
                _enemiesPrototypes = value;
            }
        }

        public Dictionary<string, Particle> ParticlesPrototypes
        {
            get
            {
                return _particlesPrototypes;
            }

            set
            {
                _particlesPrototypes = value;
            }
        }

        public Dictionary<string, Particle> Particles
        {
            get
            {
                return _particles;
            }

            set
            {
                _particles = value;
            }
        }

        public Dictionary<string, Enemy> Enemies
        {
            get
            {
                return _enemies;
            }

            set
            {
                _enemies = value;
            }
        }
    }
}
