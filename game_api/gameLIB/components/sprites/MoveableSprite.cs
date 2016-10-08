using gameLIB.utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.sprites
{
    public abstract class MoveableSprite : AnimatedSprite
    {
        public Vector2 direction { get; private set; }
        public Vector2 destination { get; private set; }
        public float speed { get; set; }
        public Vector2 fdirection { get; set; }
        public float fspeed { get; set; }

        public MoveableSprite(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale)
            : base(image, position, parts, nbFrames, scale)
        {
            this.destination = Vector2.Zero;
            this.direction = Vector2.Zero;
            this.speed = 0f;
        }

        public void setDestination(Vector2 destination, float speed)
        {
            this.destination = destination;
            this.direction = Vector2Extension.calculateDirection(position, destination);
            this.speed = speed;
        }

        public void setDestination(Vector2 destination)
        {
            this.setDestination(destination, this.speed);
        }

        public void setDirection(Vector2 direction, float speed)
        {
            this.direction = direction;
            this.destination = Vector2.Zero;
            this.speed = speed;
        }

        public void setDirection(Vector2 direction)
        {
            this.setDestination(direction, this.speed);
        }

        public void setFinalDirection(Vector2 fdirection)
        {
            this.setFinalDirection(fdirection, speed);
        }

        public void setFinalDirection(Vector2 fdirection, float fspeed)
        {
            this.fdirection = fdirection;
            this.fspeed = fspeed;
        }

        public void updatePosition()
        {
            position += direction * speed;
            if(Math.Abs(this.position.X - destination.X) < speed + 1 && Math.Abs(this.position.Y - destination.Y) < speed + 1)
            {
                if (Vector2Extension.isNaN(fdirection))
                {
                    this.direction = Vector2.Zero;
                    this.speed = 0f;
                }
                else
                {
                    this.direction = this.fdirection;
                    this.speed = this.fspeed;
                }
            }
        }

        public Vector2 positionCollision
        {
            get { return position + origin; }
        }
    }
}
