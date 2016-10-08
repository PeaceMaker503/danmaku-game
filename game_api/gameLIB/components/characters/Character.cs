using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.particles;
using gameLIB.components.sprites;

namespace gameLIB.components.characters
{
    public abstract class Character : MoveableSprite
    {
        public bool isAlive { get; set; }

        public Character(Image image, Vector2 position, Rectangle[] parts, int nbFrames, float scale)
            : base(image, position, parts, nbFrames, scale)
        {
            isAlive = true;
        }

        public override void initialize()
        {
            base.initialize();
            this.isAlive = true;
        }
    }
}