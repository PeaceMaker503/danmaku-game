using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace StageMaker.models
{
    public sealed class Script
    {
        public List<CreateEvent> create { get; set; }
        public List<ShootEvent> shoot { get; set; }
        public List<MoveEvent> move { get; set; }
    }
}
