using gameLIB.utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    public abstract class DynamicSprite : Sprite
    {
        public Vector2 direction { get; set; }
        public Vector2 destination { get; set; }
        public float speed { get; set; }
        public int indexFrame { get; set; }
        public int nbFrames { get; set; }
        public float scale { get; set; }
        public Rectangle[] parts { get; set; }

        public DynamicSprite(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale) //pour le player
            : base(image, position)
        {
            this.destination = Vector2.Zero;
            this.direction = Vector2.Zero;
            this.speed = 0;
            this.nbFrames = nbFrames;
            this.scale = scale;
            this.parts = parts;
        }

        public DynamicSprite(Image image, Vector2 position, Vector2 direction, Vector2 destination, Rectangle[] parts, float speed, int nbFrames, float scale) 
            : base(image, position)
        {
            if(direction != Vector2.Zero)
            {
                this.direction = direction;
                this.destination = Vector2.Zero;
            }
            else
            {
                this.destination = destination;
                this.direction = Vector2Extension.calculateDirection(position, destination);
            }
            this.speed = speed;
            this.nbFrames = nbFrames;
            this.scale = scale;
            this.parts = parts;
        }
        
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image.texture, position, parts[indexFrame/nbFrames], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 1f);
            indexFrame = (indexFrame+1) % (parts.Length * nbFrames);
        }

        public virtual void init()
        {
            this.position = this.initPosition;
            this.destination = Vector2.Zero;
            this.direction = Vector2.Zero;
        }

        public void move()
        {
            this.position += direction * speed;
        }

        public void moveOf(Vector2 value)
        {
            this.position += value;
        }

        public void setDestination(Vector2 destination, float speed)
        {
            this.destination = destination;
            this.direction = Vector2Extension.calculateDirection(position, destination);
            this.speed = speed;
        }

        public abstract Vector2 positionCollision
        {
            get;
        }
    }
}
