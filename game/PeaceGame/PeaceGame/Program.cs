using gameLIB.components.stage.models;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
            string[] fileNames = Directory.GetFiles(@"scripts");
            List<string> scriptPaths = new List<string>();
            for (int i = 0; i < fileNames.Length; i++)
                scriptPaths.Add(Path.GetFullPath(fileNames[i]));

            using (Game1 game = new Game1(scriptPaths))
            {
                game.Run();
            }
        }
    }
#endif
}

