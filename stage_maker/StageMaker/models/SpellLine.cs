using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    public class SpellLine
    {
        public SpellLine(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public string name { get; set; }
        public string path { get; set; }
    }
}
