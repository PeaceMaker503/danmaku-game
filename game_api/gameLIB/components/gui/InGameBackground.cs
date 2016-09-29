using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;

namespace gameLIB.components.gui
{
    public class InGameBackground
    {
        public StaticSprite background { get; private set; }
        public StaticSprite left { get; private set; }
        public StaticSprite right { get; private set; }
        public StaticSprite up { get; private set; }
        public StaticSprite down { get; private set; }


        public InGameBackground(StaticSprite left, StaticSprite up, StaticSprite down, StaticSprite right, StaticSprite background)
        {
            this.background = background;
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
        }

        public void drawInGameBackground(SpriteBatch spriteBatch)
        {
            this.background.draw(spriteBatch);
        }

        public void drawInGameUI(SpriteBatch spriteBatch)
        {
            this.left.draw(spriteBatch);
            this.up.draw(spriteBatch);
            this.right.draw(spriteBatch);
            this.down.draw(spriteBatch);
        }
    }
}
