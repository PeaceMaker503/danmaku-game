using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public sealed class MoveEvent
    {
        public float time { get; set; }
        public long targetId { get; set; }
        public string direction { get; set; }
        public string destination { get; set; }
        public string fdirection { get; set; }
        public float fspeed { get; set; }
        public float speed { get; set; }
    }
}
