using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage
{
    public class InstructionMove : Instruction
    {
        private float _speed;
        private Vector2 _direction;
        private String _particleType;
        private Vector2 _destination;
        private Vector2 _fdirection;
        private float _fspeed;

        public InstructionMove(String id, Vector2 destination, Vector2 direction, Vector2 fdirection, float speed, float fspeed)
            : base(String.Empty, id)
        {
            _direction = direction;
            _speed = speed;
            _destination = destination;
            _fspeed = fspeed;
            _fdirection = fdirection;
        }

        public override void run(Stage s)
        {
            s.orderToMove(Id, _destination, _direction, _fdirection, _speed, _fspeed);
        }

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public string ParticleType
        {
            get
            {
                return _particleType;
            }

            set
            {
                _particleType = value;
            }
        }

        public Vector2 Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }
    }
}
