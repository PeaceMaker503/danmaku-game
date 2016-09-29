using Microsoft.Xna.Framework;
using gameLIB.components.sprites;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.gui
{
    public sealed class PauseMenu : Menu
    {
        public enum Options { Resume, Options, Return, Exit } ;
        
        public PauseMenu(Vector2 marginMenu, String selectSound, SpriteFont spriteFont, StaticSprite background)
            : base(marginMenu, selectSound, spriteFont, background)
        {
            this.options.Add("Resume");
            this.options.Add("Options");
            this.options.Add("Return to screen menu");
            this.options.Add("Exit");
        }
    }
}
