using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage.parser.models
{
    public class Script
    {
        public List<CreateEvent> create { get; set; }
        public List<ShootEvent> shoot { get; set; }
    }
}
