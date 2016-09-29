using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    public class StaticSprite : Sprite
    {
        private Vector2 dimension;
        private Rectangle destinationRectangle;

        public StaticSprite(Image image, Vector2 position, Vector2 dimension)
          : base(image, position)
        {
            this.dimension = dimension;
            this.destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y);
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image.texture, this.destinationRectangle, Color.White);
        }
    }
}
