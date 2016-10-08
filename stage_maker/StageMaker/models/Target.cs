using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class Target
    {

        public Target()
        {

        }

        public Target(long _id, Target t)
        {
            this.type = t.type;
            this.position = t.position;
            this.destination = t.destination;
            this.speed = t.speed;
            this.fspeed = t.fspeed;
            this.health = t.health;
            this.fdirection = t.fdirection;
            this.direction = t.direction;
            this.id = _id;
        }

        public string type { get; set; }
        public string position { get; set; }
        public string destination { get; set; }
        public float speed { get; set; }
        public long health { get; set; }
        public string fdirection { get; set; }
        public string direction { get; set; }
        public float fspeed { get; set; }
        public long id { get; set; }
    }
}
