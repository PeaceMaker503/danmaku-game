using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;
using System;

namespace gameLIB.components.characters
{
    public sealed class Player : Character
    {
        public int lifes { get; set; }
        private int initLifes;
        public Vector2 particleP1 { get; set; }
        public Vector2 particleP2 { get; set; }
        public int particleDamage { get; set; }

        public Player(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale, int lifes)
            : base(image, position, parts, nbFrames, scale)
        {
            this.lifes = lifes;
            this.initLifes = lifes;
        }

        public override void initialize()
        {
            base.initialize();
            this.lifes = this.initLifes;
            isAlive = true;
        }

        public void move(Vector2 value)
        {
            this.position += value;
        }
    }
}
