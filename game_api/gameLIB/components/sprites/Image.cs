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

//tout le monde partage la meme référence sur l'image mais l'utilise a sa maniere

namespace gameLIB.components.sprites
{
    public class Image
    {
        private Texture2D _texture;
        private Texture2D _alpha;
        private String _name;

        public Image(String name, Texture2D texture, Texture2D alpha)
        {
            _texture = texture;
            _alpha = alpha;
            _name = name;
        }

        public Texture2D texture
        {
            get { return _texture; }
        }

        public Texture2D alpha
        {
            get { return _alpha; }
        }

        public string name
        {
            get
            {
                return _name;
            }
        }
    }
}
