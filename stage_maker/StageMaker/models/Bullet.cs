using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class Bullet
    {

        public Bullet()
        {
            speed = float.NaN;
        }

        public string type { get; set; }
        public long id { get; set; }
        public string direction { get; set; }
        public string destination { get; set; }
        public float speed { get; set; }
        public string position { get; set; }
    }
}
