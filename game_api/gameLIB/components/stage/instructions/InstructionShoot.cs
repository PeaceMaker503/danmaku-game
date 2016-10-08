using System;
using Microsoft.Xna.Framework;

namespace gameLIB.components.stage.instructions
{
    public sealed class InstructionShoot : Instruction
    {
        public float speed { get; set; }
        public string direction { get; set; }
        public String particleType { get; set; }
        public string destination { get; set; }
        public long particleId { get; set; }
        public string position { get; set; }
        public long id { get; set; }

        public InstructionShoot(long id, String particleType, long particleId, string position, string destination, string direction, float speed)
        {
            this.id = id;
            this.direction = direction;
            this.speed = speed;
            this.particleType = particleType;
            this.destination = destination;
            this.particleId = particleId;
            this.position = position;
        }

        public override void run(Stage s)
        {
            s.orderToShoot(id, particleType, particleId, position, destination, direction, speed);
        }
    }
}
