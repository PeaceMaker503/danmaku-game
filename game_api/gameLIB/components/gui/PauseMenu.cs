using Microsoft.Xna.Framework;
using gameLIB.components.sprites;
namespace gameLIB.components.gui
{
    public sealed class PauseMenu : Menu
    {
        public enum Options { Resume, Options, Return, Exit } ;
        
        public PauseMenu()
            : base()
        {
            this.options.Add("Resume");
            this.options.Add("Options");
            this.options.Add("Return to screen menu");
            this.options.Add("Exit");
        }
    }
}
