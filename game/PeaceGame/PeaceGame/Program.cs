using System;
using System.IO;

namespace PeaceGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            string scriptData = Environment.GetEnvironmentVariable("scriptData");
            if (scriptData != null)
            {
                //File.WriteAllText(@"test", scriptData);
                using (Game1 game = new Game1(scriptData))
                {
                    game.Run();
                }
            }
            else
            {
                using (Game1 game = new Game1())
                {
                    game.Run();
                }
            }
        }
    }
#endif
}

