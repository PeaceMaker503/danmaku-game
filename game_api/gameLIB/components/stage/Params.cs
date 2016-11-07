using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameLIB.components.stage
{
    public class Params : System.Attribute
    {
        public double Begin { get; set; }
        public long Count { get; set; }
        public bool OnlyOnce { get; set; }
        public double Each { get; set; }
        public string Condition { get; set; }
    }
}
