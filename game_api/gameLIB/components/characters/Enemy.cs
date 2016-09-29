using gameLIB.components.sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gameLIB.components.characters
{
    public sealed class Enemy : Character
    {
        public int health { get; set; }
        public List<Vector2> path { get; private set; }
        public String enemyDamageSound { get; set; }
        public String enemyDiesSound { get; set; }
        public Vector2 finishDir { get; set; }
        public float finishSpeed { get; set; }
        public bool stop { get; set; }
        private List<float> _speeds;

        public Enemy(Image image, String enemyDiesSound, String enemyDamageSound, Vector2 position, Rectangle[] part, int nbFrame, float scale) //pour créer le prototype Enemy
            : base(image, position, part, nbFrame, scale)
        {
            this.health = 0;
            path = new List<Vector2>();
            _speeds = new List<float>();
            this.enemyDiesSound = enemyDiesSound;
            this.enemyDamageSound = enemyDamageSound;
        }

        public Enemy(Enemy e)
            : base(e.image, e.position, e.direction, e.destination, e.parts, e.speed, e.nbFrames, e.scale)
        {
            health = 0;
            path = new List<Vector2>();
            _speeds = new List<float>();
            this.enemyDamageSound = e.enemyDamageSound;
            this.enemyDiesSound = e.enemyDiesSound;
        }

        public void addNewDestination(Vector2 dest)
        {
            if (path.Count == 0)
            {
                path.Add(dest);
                _speeds.Add(this.speed);
                setDestination(dest, this.speed);
            }
            else
            {
                path.Add(dest);
                _speeds.Add(this.speed);
            }
        }

        public void addNewDestination(Vector2 dest, float speed)
        {
            if (path.Count == 0)
            {
                path.Add(dest);
                _speeds.Add(speed);
                setDestination(dest, speed);
            }
            else
            {
                path.Add(dest);
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
                    if (path.Count > 0 && Math.Abs(this.position.X - destination.X) < speed + 1 && Math.Abs(this.position.Y - destination.Y) < speed + 1)
                    {
                        path.RemoveAt(0);
                        _speeds.RemoveAt(0);
                        if (path.Count == 0)
                        {
                            this.direction = Vector2.Zero;
                            this.destination = Vector2.Zero;
                            this.speed = 0;
                        }
                        else
                        {
                            setDestination(path.ElementAt(0), _speeds.ElementAt(0));
                        }
                    }
                }
                else if(path.Count == 0)
                {
                    this.direction = finishDir;
                    this.speed = finishSpeed;
                }
            }
        }
        

        public override void init()
        {
            base.init();
            health = 500;
        }

        public void kill()
        {
            this.health = 0;
        }

        public override Vector2 positionCollision
        {
            get { return new Vector2(position.X + 15, position.Y + 15); }
        }
    }
}
