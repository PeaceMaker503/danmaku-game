using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    abstract public class Sprite
    {
        public Image image { get; set; }
        public Vector2 position { get; set; }
        public Vector2 initPosition { get; set; }

        public Sprite(Image image, Vector2 position) //pour tout le reste (clonage)
        {
            this.image = image;
            this.position = position;
            this.initPosition = new Vector2(position.X, position.Y);
        }

        public virtual void initialize()
        {
            this.position = new Vector2(initPosition.X, initPosition.Y);
        }

        public abstract void draw(SpriteBatch spriteBatch);
    }
}
