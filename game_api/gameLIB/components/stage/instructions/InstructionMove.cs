using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage.instructions
{
    public class InstructionMove : Instruction
    {
        public float speed { get; set; }
        public Vector2 direction { get; set; }
        public String particleType { get; set; }
        public Vector2 destination { get; set; }
        public Vector2 fdirection { get; set; }
        public float fspeed { get; set; }

        public InstructionMove(int _id, Vector2 _destination, Vector2 _direction, Vector2 _fdirection, float _speed, float _fspeed)
            : base(String.Empty, _id)
        {
            direction = _direction;
            speed = _speed;
            destination = _destination;
            fspeed = _fspeed;
            fdirection = _fdirection;
        }

        public override void run(Stage s)
        {
            s.orderToMove(id, destination, direction, fdirection, speed, fspeed);
        }
    }
}
