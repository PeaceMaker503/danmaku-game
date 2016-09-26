using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;

namespace gameLIB.components.particles
{
    public sealed class Particle : DynamicSprite
    {
        private bool _hit;

        public Particle(Image image, Rectangle[] part, Vector2 direction, float speed, float scale) 
            : base(image, Vector2.Zero, direction, Vector2.Zero, part, speed, 0, scale) //pour créer l'instance originale de la particule du player qui sera ensuite clonée à souhait
        {

        }
        
        public Particle(Particle p)
            : base(p.image, p.position, p.direction, p.destination, p.part, p.speed, p.nbFrames, p.scale) //pour créer un clone en se basant sur la particule originale
        {

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            float angle = (float)Math.Floor(MathHelper.ToDegrees((float)Math.Atan2(this.direction.Y, this.direction.X))) - 90;
            float anglerad = MathHelper.ToRadians(angle);
            spriteBatch.Draw(this.image.texture, this.position, this.part[0], Color.White, anglerad, this.positionCollision, this.scale, SpriteEffects.None, 1f);
        }

        public bool Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }

        public override Vector2 positionCollision
        {
            get { return new Vector2(part[0].Width / 2f, part[0].Height); }
        }
    }
}
