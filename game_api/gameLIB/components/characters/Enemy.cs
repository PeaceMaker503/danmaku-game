using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using gameLIB.components.sprites;
using gameLIB.components.particles;

namespace gameLIB.components.characters
{
    public class Enemy : Character
    {
        private int _health;
        private List<Vector2> _trajectoire;
        private List<float> _speeds;
        private Vector2 _finishDir;
        private float _finishSpeed;
        private bool _timeToFinish;
        private String _enemyDamageSound;
        private String _enemyDiesSound;

        public Enemy(Image image, String enemyDiesSound, String enemyDamageSound, Vector2 position, Rectangle[] part, int nbFrame, float scale) //pour créer le prototype Enemy
            : base(image, position, part, nbFrame, scale)
        {
            _health = 0;
            _trajectoire = new List<Vector2>();
            _speeds = new List<float>();
            EnemyDiesSound = enemyDiesSound;
            EnemyDamageSound = enemyDamageSound;
        }

        public Enemy(Enemy e)
            : base(e.image, e.position, e.direction, e.destination, e.part, e.speed, e.nbFrames, e.scale)
        {
            _health = 0;
            _trajectoire = new List<Vector2>();
            _speeds = new List<float>();
            EnemyDamageSound = e.EnemyDamageSound;
            _enemyDiesSound = e.EnemyDiesSound;
        }

        public void addTraj(Vector2 dest)
        {
            if (_trajectoire.Count == 0)
            {
                _trajectoire.Add(dest);
                _speeds.Add(this.speed);
                setDestination(dest, this.speed);
            }
            else
            {
                _trajectoire.Add(dest);
                _speeds.Add(this.speed);
            }
        }

        public void addTraj(Vector2 dest, float speed)
        {
            if (_trajectoire.Count == 0)
            {
                _trajectoire.Add(dest);
                _speeds.Add(speed);
                setDestination(dest, speed);
            }
            else
            {
                _trajectoire.Add(dest);
                _speeds.Add(speed);
            }
        }

        public new void move()
        {
            if (isAlive)
            {
                if (direction != Vector2.Zero)
                {
                    position += direction * speed;
                    if (!_timeToFinish && Math.Abs(this.position.X - destination.X) < speed + 1 && Math.Abs(this.position.Y - destination.Y) < speed + 1)
                    {
                        _trajectoire.RemoveAt(0);
                        _speeds.RemoveAt(0);
                        if (_trajectoire.Count == 0)
                        {
                            if (_finishDir != Vector2.Zero)
                            {
                                this.direction = _finishDir;
                                this.speed = _finishSpeed;
                                _timeToFinish = true;
                            }
                            else
                            {
                                this.direction = Vector2.Zero;
                            }
                        }
                        else
                        {
                            setDestination(_trajectoire.ElementAt(0), _speeds.ElementAt(0));
                        }
                    }
                }
                else if(_trajectoire.Count == 0 && _finishDir!=Vector2.Zero)
                {
                    this.direction = _finishDir;
                    this.speed = _finishSpeed;
                    _timeToFinish = true;
                }
            }
        }
        

        public override void init()
        {
            base.init();
            _health = 500;
        }

        public void kill()
        {
            this.health = 0;
        }

        public int health
        {
            get { return _health; }

            set
            {
                _health = value;
            }
        }

        public override Vector2 positionCollision
        {
            get { return new Vector2(position.X + 15, position.Y + 15); }
        }

        public List<Vector2> trajectoire
        {
            get { return _trajectoire; }
        }

        public Vector2 finishDir
        {
            get { return _finishDir; }
            set { _finishDir = value; }
        }

        public float finishSpeed
        {
            get { return _finishSpeed; }
            set { _finishSpeed = value; }
        }

        protected bool stop
        {
            get { return _timeToFinish; }
            set { _timeToFinish = true; }
        }

        public string EnemyDamageSound
        {
            get
            {
                return _enemyDamageSound;
            }

            set
            {
                _enemyDamageSound = value;
            }
        }

        public string EnemyDiesSound
        {
            get
            {
                return _enemyDiesSound;
            }

            set
            {
                _enemyDiesSound = value;
            }
        }
    }
}
