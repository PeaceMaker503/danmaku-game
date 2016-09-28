using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public class Target
    {
        public string type { get; set; }
        public Vector2 position { get; set; }
        public Vector2 destination { get; set; }
        public float speed { get; set; }
        public int health { get; set; }
        public Vector2 fdirection { get; set; }
        public Vector2 direction { get; set; }
        public float fspeed { get; set; }
        public int id { get; set; }
    }
}
