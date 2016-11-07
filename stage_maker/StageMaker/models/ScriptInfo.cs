using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.models
{
    class ScriptInfo
    {
        public ScriptInfo(float begin, float end, string path)
        {
            this.begin = begin;
            this.end = end;
            this.path = path;
        }

        public float begin { get; set; }
        public float end { get; set; }
        public string path { get; set; }
    }
}
