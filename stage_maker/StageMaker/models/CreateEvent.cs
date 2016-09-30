using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StageMaker.models
{
    public sealed class CreateEvent
    {
        public float time { get; set; }
        public Target target { get; set; }
    }
}
