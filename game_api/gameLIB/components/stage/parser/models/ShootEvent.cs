using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public sealed class ShootEvent
    {
        public float time { get; set; }
        public ulong targetId { get; set; }
        public Bullet bullet { get; set; }
    }
}
