using gameLIB.components.characters;
using gameLIB.components.particles;
using gameLIB.components.stage;
using Microsoft.Xna.Framework;
using gameLIB.components.sprites;
using System;
using gameLIB.utils;

namespace Game
{
    public class Script
    {
        private static Vector2 playerLastPosition;
        private static MoveableSprite.MoveHandler basicMoveHandler(StageApi api, double timeToSub, Enemy boss, float amp, int sens)
        {
            return new gameLIB.components.sprites.MoveableSprite.MoveHandler(
            (Vector2 pos, Vector2 dir, float sp, double time) =>
            {
                double rad = time - timeToSub;
                Vector2 newPos = new Vector2(pos.X, pos.Y);
                newPos += new Vector2(amp * sens * (float)Math.Cos(rad), sp);
                Vector2 newDir = Vector2Extension.calculateDirection(pos, newPos);
                return new Vector2[] { newPos, newDir };
            });
        }
        [Params(Begin = 2)]
        public static void I1(StageApi api)
        {
            Enemy boss;
            api.InstantiateEnemy("FAIRIES", 10000, new Vector2(300, 100), out boss);
            api.AddBehavior("spellB", null);
        }

        [Behavior(Name = "spellB")]
        [Params(Begin = 2, Each = 1, Count = 50)]
        public static Particle[] B2(StageApi api)
        {
            Particle[] p2 = new Particle[20];
            float angle = MathHelper.ToRadians(api.GetRand(0, 360));
            string type;
            int t = api.GetRand(0, 3);

            if (t == 0)
                type = "RED_KNIFE";
            else if (t == 1)
                type = "BLUE_KNIFE";
            else 
                type = "GREEN_KNIFE";

            for (int i = 0;i<p2.Length; i++)
            {
                api.InstantiateParticle(type, api.GetPlayer().position + 100*new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), out p2[i]);
                p2[i].setDestination(api.GetPlayer().position, 0);
                angle += MathHelper.TwoPi / p2.Length;
            }

            if (api.GetArg() != null)
            {
                Console.WriteLine(api.GetArg());
                Particle[] p = (Particle[])api.GetArg();
                for (int i = 0; i < p.Length; i++)
                    p[i].speed = 0.5f;
            }
            return p2;
        }

        /*[Behavior(Name = "spellA")]
        [Params(Begin = 2, Each = 0.2, Count = 500)]
        public static Enemy B1(StageApi api)
        {
            Enemy boss = (Enemy)api.GetArg();
            Particle p;
            api.InstantiateParticle("RED_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 0.5f, 1), 1);
            api.InstantiateParticle("RED_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 0.5f, -1), 1);
            api.InstantiateParticle("BLUE_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 1, 1), 1);
            api.InstantiateParticle("BLUE_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 1, -1), 1);
            api.InstantiateParticle("GREEN_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 2, 1), 1);
            api.InstantiateParticle("GREEN_KNIFE", boss, out p);
            p.setMoveHandler(basicMoveHandler(api, api.GetTime(), boss, 2, -1), 1);
            return boss;
        }
        */

        /* [Behavior(Name = "MoveAll")]
         [Params(Begin = 2)]
         private static object B2(StageApi api)
         {
             Particle[] p = (Particle[])api.GetArg();
             for (int i = 0; i < p.Length; i++)
             {
                 p[i].speed = 1;
             }
             return p;
         */

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
