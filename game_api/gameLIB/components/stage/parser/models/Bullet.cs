using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public sealed class Bullet
    {
        public string type { get; set; }
        public int id { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 destination { get; set; }
        public float speed { get; set; }
    }
}
