using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StageMaker.spell_maker.Value;

namespace StageMaker.spell_maker
{
    public class VarsManager
    {
        public ValueEvaluator valueEvaluator { get; private set; }
        private Dictionary<string, Value> vars;

        public VarsManager()
        {
            vars = new Dictionary<string, Value>();
            this.valueEvaluator = new ValueEvaluator(vars);
        }

        public void setValue(string name, string value, Types type)
        {
            if(type == Types.FLOAT)
            {
                float pValue = valueEvaluator.parseFloat(value);
                vars[name] = new Value(pValue, Types.FLOAT);
            }
            else if (type == Types.LONG)
            {
                float pValue = valueEvaluator.parseFloat(value);
                vars[name] = new Value(pValue, Types.LONG);
            }
            else if (type == Types.VECTOR2)
            {
                string pValue = valueEvaluator.parseVector(value);
                vars[name] = new Value(pValue, Types.VECTOR2);
            }
            else
            {
                vars[name] = new Value(value, Types.STRING);
            }
        }

        public bool empty()
        {
            return vars.Count == 0;
        }

        public string[] getAllArgsNames()
        {
            string[] names = new string[vars.Count];
            int i = 0;
            foreach(string name in vars.Keys)
            {
                names[i] = name;
                i++;
            }
            return names;
        }

        public void removeValue(string name)
        {
            vars.Remove(name);
        }
        public object getValue(string name)
        {
            return vars[name].value;
        }

        public Types getType(string name)
        {
            return vars[name].type;
        }

    }
}
