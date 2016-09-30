using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class Bullet
    {
        public string type { get; set; }
        public ulong id { get; set; }
        public JsonVector2 direction { get; set; }
        public JsonVector2 destination { get; set; }
        public float speed { get; set; }
    }
}
