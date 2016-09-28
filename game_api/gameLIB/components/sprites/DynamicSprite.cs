using gameLIB.utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace gameLIB.components.sprites
{
    public abstract class DynamicSprite : Sprite
    {
        private Vector2 _direction;
        private Vector2 _destination;
        private float _speed;
        private int _indexFrame;
        private int _nbFrames;
        private float _scale;
        private Rectangle[] _part;

        public DynamicSprite(Image image, Vector2 position, Rectangle[] part, int nbFrames, float scale) //pour le player
            : base(image, position)
        {
            _destination = Vector2.Zero;
            _direction = Vector2.Zero;
            _speed = 0;
            _nbFrames = nbFrames;
            _scale = scale;
            _part = part;
        }

        public DynamicSprite(Image image, Vector2 position, Vector2 direction, Vector2 destination, Rectangle[] part, float speed, int nbFrames, float scale) 
            : base(image, position)
        {
            if(direction != Vector2.Zero)
            {
                _direction = direction;
                _destination = Vector2.Zero;
            }
            else
            {
                _destination = destination;
                _direction = Vector2Math.calculateDirection(position, destination);
            }
            _speed = speed;
            _nbFrames = nbFrames;
            _scale = scale;
            _part = part;
        }
        
        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image.texture, position, _part[_indexFrame/_nbFrames], Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 1f);
            _indexFrame++;
            _indexFrame = (_indexFrame + 1) % (_part.Length * _nbFrames);
        }

        public virtual void init()
        {
            this.position = this.initPosition;
        }

        public void move()
        {
            this.position += _direction * _speed;
        }

        public void moveOf(Vector2 value)
        {
            this.position += value;
        }

        public void setDestination(Vector2 destination, float speed)
        {
            _destination = destination;
            _direction = Vector2Math.calculateDirection(position, destination);
            _speed = speed;
        }

        public Vector2 direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector2 destination
        {
            get { return _destination; }
            set { _destination = value; direction = Vector2Math.calculateDirection(position, _destination); }
        }

        public abstract Vector2 positionCollision
        {
            get;
        }

        public float speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int nbFrames
        {
            get { return _nbFrames; }
            set { _nbFrames = value; }
        }

        public int indexFrame
        {
            get { return _indexFrame; }
            set { _indexFrame = value; }
        }

        public float scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        public Rectangle[] part
        {
            get { return _part; }
            set { _part = part; }
        }
    }
}
