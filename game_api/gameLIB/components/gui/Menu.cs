using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;

namespace gameLIB.components.gui
{
    public abstract class Menu
    {
        private List<String> _options;
        private SpriteFont _spriteFont;
        private int _selected;
        private Vector2 _marginMenu;
        private StaticSprite _background;
        private String _selectSound;

        public Menu()
        {
            _options = new List<String>();
            _selected = 0;
        }

        public void drawMenu(SpriteBatch spriteBatch)
        {
            float x = MarginMenu.X;
            float y = MarginMenu.Y;
            _background.draw(spriteBatch);
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
            _selected = 0;
        }

        public int selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public SpriteFont spriteFont
        {
            set { _spriteFont = value; }
        }

        public StaticSprite background
        {
            set { _background = value; }
        }
        
        public List<String> options
        {
            get { return _options; }
            set { _options = value; }
        }

        public Vector2 MarginMenu
        {
            get
            {
                return _marginMenu;
            }

            set
            {
                _marginMenu = value;
            }
        }

        public string SelectSound
        {
            get
            {
                return _selectSound;
            }

            set
            {
                _selectSound = value;
            }
        }
    }
}
