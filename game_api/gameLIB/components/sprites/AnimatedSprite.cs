using gameLIB.utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    public abstract class AnimatedSprite : Sprite
    {
        public int indexFrame { get; set; }
        public int nbFrames { get; set; }
        public float scale { get; set; }
        public Rectangle[] parts { get; set; }
        public Vector2 origin { get; private set; }

        public AnimatedSprite(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale) //pour le player
            : base(image, position)
        {
            this.nbFrames = nbFrames;
            this.scale = scale;
            this.parts = parts;
            this.origin = new Vector2(parts[0].Width / 2, parts[0].Height / 2);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image.texture, position, parts[indexFrame/nbFrames], Color.White, 0f, origin, scale, SpriteEffects.None, 1f);
            indexFrame = (indexFrame+1) % (parts.Length * nbFrames);
        }
    }
}
