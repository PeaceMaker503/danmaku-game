using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker.models
{
    public sealed class Value
    {
        public Value(object value, Types type)
        {
            this.type = type;
            this.value = value;
        }

        public enum Types { NULL, FLOAT, NUMBER, STRING, VECTOR };
        public Types type { get; set; }
        public object value { get; set; }
    }
}
