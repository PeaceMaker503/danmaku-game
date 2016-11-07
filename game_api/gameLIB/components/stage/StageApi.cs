using gameLIB.components.characters;
using gameLIB.components.particles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage
{
    public class StageApi
    {
        private Stage stage;

        public StageApi(Stage stage)
        {
            this.stage = stage;
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

        public long InstantiateParticle(string type, Vector2 position)
        {
            Particle p;
            long id = stage.instantiateParticle(type, position, out p);
            return id;
        }
    }
}
