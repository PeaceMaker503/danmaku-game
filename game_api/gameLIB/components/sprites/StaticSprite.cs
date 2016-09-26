using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    public class StaticSprite : Sprite
    {
        private Vector2 _dimension;

        public StaticSprite(Image image, Vector2 position, Vector2 dimension)
          : base(image, position)
        {
            _dimension = dimension;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image.texture, new Rectangle((int)this.position.X, (int)this.position.Y, (int)_dimension.X, (int)_dimension.Y), Color.White);
        }
    }
}
