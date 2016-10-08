using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public sealed class Script
    {
        public List<CreateEvent> create { get; set; }
        public List<ShootEvent> shoot { get; set; }
        public List<MoveEvent> move { get; set; }
        public List<ParticleMoveEvent> particleMove { get; set; }
    }
}
