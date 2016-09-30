using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class MoveEvent
    {
        public float time { get; set; }
        public ulong targetId { get; set; }
        public JsonVector2 direction { get; set; }
        public JsonVector2 destination { get; set; }
        public JsonVector2 fdirection { get; set; }
        public float fspeed { get; set; }
        public float speed { get; set; }
    }
}
