using gameLIB.components.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gameLIB.components.characters
{
    public sealed class Enemy : Character
    {
        public long health { get; set; }
        public long initHealth { get; set; }

        public Enemy(Image image, Rectangle[] part, int nbFrames, float scale)
            : base(image, Vector2.Zero, part, nbFrames, scale)
        {
            this.health = 0;
            this.initHealth = this.health;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
                base.draw(spriteBatch);
        }

        public override void initialize()
        {
            base.initialize();
            this.health = this.initHealth;
        }
    }
}
