using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace gameLIB.components.stage
{
    public class StageApi
    {
        private Stage stage;
        private Random r;

        public StageApi(Stage stage)
        {
            this.stage = stage;
            this.r = new Random();
        }

        public void AddBehavior(string behavior, object value)
        {
            stage.addBehavior(behavior, value);
        }

        public int GetRand(int min, int max)
        {
            return r.Next(min, max);
        }

        public object GetArg()
        {
            return stage.Arg;
        }

        public Player GetPlayer()
        {
            return stage.player;
        }

        public float GetTime()
        {
            return (float)stage.time;
        }

        public long InstantiateEnemy(string type, long health, Vector2 position, out Enemy eout)
        {
            Enemy e;
            long id = stage.instantiateEnemy(type, health, position, out e);
            eout = e;
            return id;
        }

        public long InstantiateEnemy(string type, long health, Vector2 position)
        {
            Enemy e;
            long id = stage.instantiateEnemy(type, health, position, out e);
            return id;
        }

        public long InstantiateParticle(string type, Vector2 position, out Particle pout)
        {
            Particle p;
            long id = stage.instantiateParticle(type, position, out p);
            pout = p;
            return id;
        }

        public long InstantiateParticle(string type, long enemyId, out Particle pout)
        {
            Particle p;
            long id = stage.instantiateParticle(type, enemyId, out p);
            pout = p;
            return id;
        }

        public long InstantiateParticle(string type, long enemyId)
        {
            Particle p;
            long id = stage.instantiateParticle(type, enemyId, out p);
            return id;
        }

        public long InstantiateParticle(string type, Enemy e, out Particle pout)
        {
            Particle p;
            long id = stage.instantiateParticle(type, e, out p);
            pout = p;
            return id;
        }

        public long InstantiateParticle(string type, Enemy e)
        {
            Particle p;
            long id = stage.instantiateParticle(type, e, out p);
            return id;
        }

        public long InstantiateParticle(string type, Vector2 position)
        {
            Particle p;
            long id = stage.instantiateParticle(type, position, out p);
            return id;
        }
    }
}
