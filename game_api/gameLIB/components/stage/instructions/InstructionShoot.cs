using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage.instructions
{
    public sealed class InstructionShoot : Instruction
    {
        public float speed { get; set; }
        public Vector2 direction { get; set; }
        public String particleType { get; set; }
        public Vector2 destination { get; set; }
        public int particleId { get; set; }

        public InstructionShoot(int _id, String _particleType, int _particleId, Vector2 _destination, Vector2 _direction, float _speed)
            : base(String.Empty, _id)
        {
            direction = _direction;
            speed = _speed;
            particleType = _particleType;
            destination = _destination;
        }

        public override void run(Stage s)
        {
            s.orderToShoot(id, particleType, particleId, destination, direction, speed);
        }
    }
}
