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
        public Vector2 direction { get; protected set; }
        public Vector2 destination { get; protected set; }
        public float speed { get; set; }
        public Vector2 fdirection { get; set; }
        public float fspeed { get; set; }
        public Vector2 lastPosition { get; protected set; }
        public delegate Vector2[] MoveHandler(Vector2 pos, Vector2 dir, float speed, double time);
        public MoveHandler moveHandler { get; set; }
        protected static MoveHandler basicMoveHandler = new MoveHandler((Vector2 pos, Vector2 dir, float sp, double time) => {
            return new Vector2[] { pos + dir * sp, dir };
        } );

        public MoveableSprite(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale)
            : base(image, position, parts, nbFrames, scale)
        {
            this.destination = Vector2.Zero;
            this.direction = Vector2.Zero;
            this.speed = 0f;
            this.moveHandler = basicMoveHandler;
            this.lastPosition = position;
        }

        public void setMoveHandler(MoveHandler moveHandler, float speed)
        {
            this.moveHandler = moveHandler;
            this.speed = speed;
        }

        public void setMoveHandler(MoveHandler moveHandler)
        {
            this.moveHandler = moveHandler;
        }

        public void resetMoveHandler()
        {
            this.moveHandler = basicMoveHandler;
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
            this.direction = Vector2.Normalize(direction);
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
            this.fdirection = Vector2.Normalize(fdirection);
            this.fspeed = fspeed;
            if(destination == Vector2.Zero && direction == Vector2.Zero)
            {
                this.direction = fdirection;
                this.speed = fspeed;
            }
        }

        public void updatePosition(double time)
        {
            lastPosition = position;
            Vector2[] vectors = moveHandler(position, direction, speed, time);
            position = vectors[0];
            direction = vectors[1];

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
