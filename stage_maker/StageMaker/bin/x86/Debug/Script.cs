using gameLIB.components.characters;
using gameLIB.components.stage;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    public class Script
    {
        public static class Enemies
        {
            private static Enemy e;
            public static void instantiate(float begin, float end, float time, StageApi stage)
            {
                stage.instantiateEnemy("FAIRIES", new Vector2(200, 200), out e);
            }
        }

        public static class Particles
        {
            public static void instantiate(float begin, float end, float time, StageApi stage)
            {

            }
        }
    }
}
