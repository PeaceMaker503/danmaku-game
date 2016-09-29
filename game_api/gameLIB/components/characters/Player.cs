using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gameLIB.components.sprites;
using System;

namespace gameLIB.components.characters
{
    public sealed class Player : Character
    {
        public int lifes { get; set; }
        private int _lifesInit;
        public String shootSound { get; private set; }
        public String diesSound { get; private set; }
        public string particleName { get; set; }
        public string particleImageName { get; set; }
        public Vector2 particleOffset1 { get; set; }
        public Vector2 particleOffset2 { get; set; }
        public int particleDamage { get; set; }

        public Player(Image image, Vector2 position, Rectangle[] part, int lifes, int nbFrame, float scale, string soundPlayerDies, string soundPlayerShoot)
            : base(image, position, part, nbFrame, scale)
        {
            this.lifes = lifes;
            _lifesInit = lifes;
            this.shootSound = soundPlayerShoot;
            this.diesSound = soundPlayerDies;
        }

        public new void drawCharacter(SpriteBatch spriteBatch)
        {
            if (isAlive == true)
            {
                spriteBatch.Draw(this.image.texture, this.position, this.parts[this.indexFrame / 4], Color.White, 0f, this.positionCollision - this.position, 1f, SpriteEffects.None, 1f);
            }
            else
            {
                spriteBatch.Draw(this.image.texture, this.position, new Rectangle(0, 0, 32, 50), Color.White * 0.5f, 0f, this.positionCollision - this.position, 1f, SpriteEffects.None, 1f);
            }
            indexFrame++;
            this.indexFrame = (this.indexFrame+1)%(this.nbFrames * this.parts.Length);
        }

        public void initPlayer()
        {
            this.init();
            lifes = _lifesInit;
            isAlive = true;
        }

        public override Vector2 positionCollision
        {
            get { return new Vector2(position.X + (31f / 2f), position.Y + (47f / 2f)); }
        }
    }
}
