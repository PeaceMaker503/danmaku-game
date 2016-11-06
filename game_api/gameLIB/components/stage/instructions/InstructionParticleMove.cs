using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage.instructions
{
    public sealed class InstructionParticleMove : Instruction
    {
        public float speed { get; set; }
        public string direction { get; set; }
        public string destination { get; set; }
        public string position { get; set; }

        public long id { get; set; }

        public InstructionParticleMove(long id, string position, string destination, string direction, float speed)
        {
            this.id = id;
            this.position = position;
            this.direction = direction;
            this.speed = speed;
            this.destination = destination;
        }

        public override void run(Stage s)
        {
            s.orderToParticleMove(id, position, destination, direction, speed);
        }
    }
}
