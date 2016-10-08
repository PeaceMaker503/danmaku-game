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

namespace gameLIB.components.stage.instructions
{
    public sealed class InstructionCreate : Instruction
    {
        public long health { get; set; }
        public float speed { get; set; }
        public string position { get; set; }
        public string destination { get; set; }
        public string direction { get; set; }
        public string fdirection { get; set; }
        public float fspeed { get; set; }
        public string type { get; set; }
        public long id { get; set; }

        public InstructionCreate(string type, long id, long health, string position, string destination, string direction, string finishDirection, float speed, float finishSpeed)
        {
            this.type = type;
            this.id = id;
            this.direction = direction;
            this.health = health;
            this.speed = speed;
            this.position = position;
            this.destination = destination;
            this.fdirection = finishDirection;
            this.fspeed = finishSpeed;
        }

        public override void run(Stage s)
        {
            s.instantiateEnemy(type, id, position, direction, destination, fdirection, health, speed, fspeed);
        }
    }
}
