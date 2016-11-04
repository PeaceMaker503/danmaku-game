using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker.evaluators
{
    public class SpellEvaluatorHelper
    {
        public sealed class Command
        {
            public static readonly string ARGS = "args";
            public static readonly string COMMENT = "#";
            public static readonly string OPEN = "{";
            public static readonly string CLOSE = "}";
            public static readonly string BEHAVIOR = "behavior";
            public static readonly string MAKE = "make";
            public static readonly string LOOP = "loop";
            public static readonly string INDEX = "INDEX";
            public static readonly string TIMESET = "timeset";
            public static readonly string DIMOVE = "dimove";
            public static readonly string DMOVE = "dmove";
            public static readonly string CALL = "call";
            public static readonly string LET = "let";
            public static readonly string ADD = "add";
            public static readonly string SUB = "sub";
            public static readonly string MOD = "mod";
            public static readonly string MUL = "mul";
            public static readonly string DIV = "div";
            public static readonly string VMUL = "vmul";
            public static readonly string SET = "set";
            public static readonly string FREE = "free";
            public static readonly string DELAY = "delay";
            public static readonly string WITH = "with";
            public static readonly string POSITION = "position";
            public static readonly string DESTINATION = "destination";
            public static readonly string DIRECTION = "direction";
            public static readonly string SPEED = "speed";
            public static readonly string TYPE = "type";
            public static readonly string ANGLE = "angle";
            public static readonly string COMPARE = "compare";
            public static readonly string CASE = "case";
        }

        public sealed class Operator
        {
            public static readonly string EQUALS = "==";
            public static readonly string DIFFERENT = "!=";
            public static readonly string SUPERIOR = ">";
            public static readonly string INFERIOR = "<";
            public static readonly string INFERIOR_EQUALS = "<=";
            public static readonly string SUPERIOR_EQUALS = ">=";
        }
    }
}
