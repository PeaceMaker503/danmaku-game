using gameLIB.components.characters;
using gameLIB.components.particles;
using gameLIB.components.stage;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    public class Script
    {
        [Params(Begin = 2, Each = 0.3, End = 3.5)]
        public static void I1(StageApi api)
        {
            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(400, 0), out e);
            e.setDestination(new Vector2(400, 50), 2f);
            e.setFinalDirection(new Vector2(-1, 1));
        }

        [Params(Begin = 4, Each = 0.3, End = 5.5)]
        public static void I3(StageApi api)
        {
            Enemy e;
            api.InstantiateEnemy("FAIRIES", 50, new Vector2(200, 0), out e);
            e.setDestination(new Vector2(200,50), 2f);
            e.setFinalDirection(new Vector2(1, 1));
        }



        /*		[type = Fairies; position = (200, -170); destination = (200, 50) ; speed = 2; health = 50; fdirection = (1,1); fspeed = 2;]
		[type = Fairies; position = (190, -140); destination = (190, 80) ; speed = 2; health = 50; fdirection = (1,1); fspeed = 2;]
		[type = Fairies; position = (180, -110); destination = (180, 110) ; speed = 2; health = 50; fdirection = (1,1); fspeed = 2;]
		[type = Fairies; position = (170, -80); destination = (170, 140) ; speed = 2; health = 50; fdirection = (1,1); fspeed = 2;]
		[type = Fairies; position = (160, -50); destination = (160, 170) ; speed = 2; health = 50; fdirection = (1,1); fspeed = 2;]*/

    }
}
