using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace gameLIB.components.sprites
{
    abstract public class Sprite
    {
        private Image _image;
        private Vector2 _position;
        private Vector2 _positionInit;

        public Sprite(Image image, Vector2 position) //pour tout le reste (clonage)
        {
            _image = image;
            _position = position;
            _positionInit = position;
        }

        public abstract void draw(SpriteBatch spriteBatch);

        public Vector2 position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 initPosition
        {
            get { return _positionInit; }
            set { _positionInit = value; }
        }

        public Image image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
