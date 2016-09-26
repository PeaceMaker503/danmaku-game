using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;
using System;

namespace gameLIB.components.characters
{
    public sealed class Player : Character
    {
        private int _lifes;
        private int _lifesInit;
        private String _shootSound;
        private String _diesSound;
        private string _particleName;
        private string _particleImageName;
        private Vector2 _particleOffset1;
        private Vector2 _particleOffset2;
        private int _particleDamage;
        public Player(Image image, Vector2 position, Rectangle[] part, int lifes, int nbFrame, float scale)
            : base(image, position, part, nbFrame, scale)
        {
            _lifes = lifes;
            _lifesInit = lifes;
        }

        public new void drawCharacter(SpriteBatch spriteBatch)
        {
            if (this.isAlive == true)
            {
                spriteBatch.Draw(this.image.texture, this.position, this.part[this.indexFrame / 4], Color.White, 0f, this.positionCollision - this.position, 1f, SpriteEffects.None, 1f);
            }
            else
            {
                spriteBatch.Draw(this.image.texture, this.position, new Rectangle(0, 0, 32, 50), Color.White * 0.5f, 0f, this.positionCollision - this.position, 1f, SpriteEffects.None, 1f);
            }
            this.indexFrame = (this.indexFrame+1)%(nbFrames * this.part.Length);
        }

        public void initPlayer()
        {
            this.init();
            _lifes = _lifesInit;
            isAlive = true;
        }

        public int lifes
        {
            get { return _lifes; }
            set { _lifes = value; }
        }

        public override Vector2 positionCollision
        {
            get { return new Vector2(position.X + (31f / 2f), position.Y + (47f / 2f)); }
        }

        public string ShootSound
        {
            get
            {
                return _shootSound;
            }

            set
            {
                _shootSound = value;
            }
        }

        public string DiesSound
        {
            get
            {
                return _diesSound;
            }

            set
            {
                _diesSound = value;
            }
        }

        public string ParticleName
        {
            get
            {
                return _particleName;
            }

            set
            {
                _particleName = value;
            }
        }

        public Vector2 ParticleOffset1
        {
            get
            {
                return _particleOffset1;
            }

            set
            {
                _particleOffset1 = value;
            }
        }

        public Vector2 ParticleOffset2
        {
            get
            {
                return _particleOffset2;
            }

            set
            {
                _particleOffset2 = value;
            }
        }

        public string ParticleImageName
        {
            get
            {
                return _particleImageName;
            }

            set
            {
                _particleImageName = value;
            }
        }

        public int ParticleDamage
        {
            get
            {
                return _particleDamage;
            }

            set
            {
                _particleDamage = value;
            }
        }
    }
}
