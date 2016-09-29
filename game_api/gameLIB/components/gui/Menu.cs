using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;

namespace gameLIB.components.gui
{
    public abstract class Menu
    {
        public List<String> options { get; protected set; }
        public int selected { get; set; }
        public Vector2 marginMenu { get; protected set; }
        public StaticSprite background { get; protected set; }
        public String selectSound { get; protected set; }
        private SpriteFont _spriteFont;

        public Menu(Vector2 marginMenu, String selectSound, SpriteFont spriteFont, StaticSprite background)
        {
            this.marginMenu = marginMenu;
            this.selectSound = selectSound;
            this._spriteFont = spriteFont;
            this.background = background;
            options = new List<String>();
            this.selected = 0;
        }

        public void drawMenu(SpriteBatch spriteBatch)
        {
            float x = this.marginMenu.X;
            float y = this.marginMenu.Y;
            this.background.draw(spriteBatch);
            foreach (String text in this.options)
            {
                if (options.IndexOf(text) == selected)
                {
                    spriteBatch.DrawString(_spriteFont, text, new Vector2(x, y), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(_spriteFont, text, new Vector2(x, y), Color.White);
                }
                y += 40;
            }
        }

        public void initialize()
        {
            this.selected = 0;
        }
    }
}
