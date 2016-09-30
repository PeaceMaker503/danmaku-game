using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class Target
    {
        public string type { get; set; }
        public JsonVector2 position { get; set; }
        public JsonVector2 destination { get; set; }
        public float speed { get; set; }
        public ulong health { get; set; }
        public JsonVector2 fdirection { get; set; }
        public JsonVector2 direction { get; set; }
        public float fspeed { get; set; }
        public ulong id { get; set; }
    }
}
