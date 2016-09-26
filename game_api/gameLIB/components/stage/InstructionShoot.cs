using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage
{
    public class InstructionShoot : Instruction
    {
        private float _speed;
        private Vector2 _direction;
        private String _particleType;
        private Vector2 _destination;

        public InstructionShoot(String id, String particleType, Vector2 destination, Vector2 direction, float speed)
            : base(String.Empty, id)
        {
            _direction = direction;
            _speed = speed;
            ParticleType = particleType;
            _destination = destination;
        }

        public override void run(Stage s)
        {
            s.orderToShoot(Id, ParticleType, Destination, Direction, Speed);
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
