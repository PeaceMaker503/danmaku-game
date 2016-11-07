using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace gameLIB.components.stage.models
{
    public class ScriptResult
    {
        public ScriptResult(float begin, float end, MethodInfo mi)
        {
            this.begin = begin;
            this.end = end;
            this.mi = mi;
        }

        public float begin { get; set; }
        public float end { get; set; }
        public MethodInfo mi { get; set; }
    }
}
