using gameLIB.components.characters;
using gameLIB.components.particles;
using gameLIB.components.stage;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    public class Script
    {
        [Params(Begin = 2)]
        public static void I1(StageApi api)
        {
            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(400, 0), out e);
            e.setDestination(new Vector2(400, 75), 0.2f);
            e.setFinalDirection(new Vector2(-1, 1));
            api.AddBehavior("shoot", e);
        }

        [Params(Begin = 3)]
        public static void I2(StageApi api)
        {
            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(400, 0), out e);
            e.setDestination(new Vector2(400, 75), 0.2f);
            e.setFinalDirection(new Vector2(-1, 1));
            api.AddBehavior("shoot", e);
        }

        [Behavior(Name = "shoot")]
        [Params(Begin = 2, Each = 0.2, Count = 50, Condition = "isPlayerAlive")]
        private static object B1(StageApi api)
        {
            Enemy e = (Enemy)api.GetArg();
            Particle p;
            api.InstantiateParticle("RED_KNIFE", e, out p);
            p.setDestination(api.GetPlayer().position, 5f);
            return e;
        }

        [Condition(Name = "isPlayerAlive")]
        private static bool C1(StageApi api)
        {
            return api.GetPlayer().isAlive;
        }

        /*[Params(Begin = 4, Each = 0.3, End = 5.5)]
        public static void I2(StageApi api)
        {
            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(200, 0), out e);
            e.setDestination(new Vector2(200, 75), 2f);
            e.setFinalDirection(new Vector2(1, 1));
        }

        [Params(Begin = 7, Each = 0.3, End = 10)]
        public static float I3(StageApi api)
        {
            float arg;
            if (api.GetArg() == null)
                arg = 0f;
            else
                arg = (float)api.GetArg() + 20;

            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(85 + arg, 0), out e);
            e.setFinalDirection(new Vector2(0, 1), 2f);

            api.InstantiateEnemy("FAIRIES", 50, new Vector2(485 - arg, 0), out e);
            e.setFinalDirection(new Vector2(0, 1), 2f);

            return arg;
        }

        [Params(Begin = 12, Each = 1, End = 20)]
        public static void I4(StageApi api)
        {
            float randX = api.GetRand(85, 485);

            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(randX, 0), out e);
            e.setDestination(new Vector2(randX, 75), 2f);
        }*/
    }
}
