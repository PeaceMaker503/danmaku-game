using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace gameLIB.components.stage
{
    public class ScriptInfo
    {
        public CompilerResults cp { get; set; }
        public Params p { get; set; }
        public long count { get; set; }
        public MethodInfo mCond { get; set; }
        public object returnValue { get; set; }
        public MethodInfo mScript { get; set; }
    }
}
