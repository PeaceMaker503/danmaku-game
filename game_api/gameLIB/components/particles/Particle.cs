using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;
using gameLIB.utils;

namespace gameLIB.components.particles
{
    public sealed class Particle : MoveableSprite
    {
        public bool hit { get; set; }
        
        public Particle(Image image, Rectangle[] parts, float scale)
            : base (image, Vector2.Zero, parts, 0, scale)
        {

        }

        public override void draw(SpriteBatch spriteBatch)
        {
            float angle = (float)Math.Floor(MathHelper.ToDegrees((float)Math.Atan2(this.direction.Y, this.direction.X))) - 90;
            float anglerad = MathHelper.ToRadians(angle);
            spriteBatch.Draw(this.image.texture, this.position, this.parts[0], Color.White, anglerad, new Vector2(parts[0].Width/2, parts[0].Height/2), this.scale, SpriteEffects.None, 1f);
        }

        public new void updatePosition(double time)
        {
            lastPosition = position;
            Vector2[] vectors = moveHandler(position, direction, speed, time);
            position = vectors[0];
            direction = vectors[1];
        }

        public override void initialize()
        {
            base.initialize();
            this.hit = false;
        }
    }
}
