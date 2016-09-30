using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class ScriptSave
    {
        public List<Target> enemies { get; set; }
        public List<CreateEventSave> create { get; set; }
        public List<ShootEvent> shoot { get; set; }
        public List<MoveEvent> move { get; set; }
    }
}
