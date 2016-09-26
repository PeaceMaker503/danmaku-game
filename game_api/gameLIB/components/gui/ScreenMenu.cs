using Microsoft.Xna.Framework;
using gameLIB.components.sprites;
namespace gameLIB.components.gui
{
    public sealed class ScreenMenu : Menu
    {
        public enum Options { Play, Options, Exit } ;

        public ScreenMenu()
            : base()
        {
            this.options.Add("Play");
            this.options.Add("Options");
            this.options.Add("Exit");
        }
    }
}
