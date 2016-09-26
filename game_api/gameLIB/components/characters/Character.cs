using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.particles;
using gameLIB.components.sprites;

namespace gameLIB.components.characters
{
    public abstract class Character : DynamicSprite
    {
        private bool _isAlive;
        private int _idPart;

        public Character(Image image, Vector2 position, Rectangle[] part, int nbFrame, float scale) //pour le prototype et position uniquement à cause du player
            : base(image, position, part, nbFrame, scale)
        {
            _isAlive = true;
        }

        public Character(Image image, Vector2 position, Vector2 direction, Vector2 destination, Rectangle[] part, float speed, int nbFrame, float scale)
            : base(image, position, direction, destination, part, speed, nbFrame, scale)
        {
            _isAlive = true;
        }

        public void drawCharacter(SpriteBatch spriteBatch)
        {
            if (_isAlive == true)
            {
                spriteBatch.Draw(image.texture, position, part[indexFrame / nbFrames], Color.White, 0f, this.positionCollision - this.position, scale, SpriteEffects.None, 1f);
                indexFrame = (indexFrame+1)%(part.Length * nbFrames);
            }
        }


        public override void init()
        {
            base.init();
        }

        public bool isAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }
    }
}