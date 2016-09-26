using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;

namespace gameLIB.components.gui
{
    public class InGameBackground
    {
        private StaticSprite _background;
        private StaticSprite _left;
        private StaticSprite _right;
        private StaticSprite _up;
        private StaticSprite _down;

        public void drawInGameBackground(SpriteBatch spriteBatch)
        {
            _background.draw(spriteBatch);
        }

        public void drawInGameUI(SpriteBatch spriteBatch)
        {
            _left.draw(spriteBatch);
            _up.draw(spriteBatch);
            _right.draw(spriteBatch);
            _down.draw(spriteBatch);
        }

        public StaticSprite background
        {
            set { _background = value; }
        }

        public StaticSprite left
        {
            set { _left = value; }
        }

        public StaticSprite right
        {
            set { _right = value; }
        }

        public StaticSprite up
        {
            set { _up = value; }
        }

        public StaticSprite down
        {
            set { _down = value; }
        }
    }
}
