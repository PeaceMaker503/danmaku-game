using Microsoft.Xna.Framework;
using gameLIB.components.sprites;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.gui
{
    public sealed class ScreenMenu : Menu
    {
        public enum Options { Play, Options, Exit } ;

        public ScreenMenu(Vector2 marginMenu, String selectSound, SpriteFont spriteFont, StaticSprite background)
            : base(marginMenu, selectSound, spriteFont, background)
        {
            this.options.Add("Play");
            this.options.Add("Options");
            this.options.Add("Exit");
        }
    }
}
