using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage.instructions
{
    public sealed class InstructionMove : Instruction
    {
        public float speed { get; set; }
        public string direction { get; set; }
        public String particleType { get; set; }
        public string destination { get; set; }
        public string fdirection { get; set; }
        public float fspeed { get; set; }
        public long id { get; set; }

        public InstructionMove(long id, string destination, string direction, float speed, string fdirection, float fspeed)
        {
            this.id = id;
            this.direction = direction;
            this.speed = speed;
            this.destination = destination;
            this.fspeed = fspeed;
            this.fdirection = fdirection;
        }

        public override void run(Stage s)
        {
            s.orderToMove(id, destination, direction, speed, fdirection, fspeed);
        }
    }
}
