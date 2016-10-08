using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker
{
    public sealed class Value
    {
        public Value(object value, Types type)
        {
            this.type = type;
            this.value = value;
        }

        public enum Types { FLOAT, LONG, STRING, VECTOR2 };
        public Types type { get; set; }
        public object value { get; set; }
    }
}
