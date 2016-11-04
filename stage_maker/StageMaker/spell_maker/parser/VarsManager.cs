using StageMaker.spell_maker.evaluators;
using StageMaker.spell_maker.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker.spell_maker.parser
{
    public class VarsManager
    {
        public ValueEvaluator valueEvaluator { get; private set; }
        public Dictionary<string, Value> vars { get; private set; }

        public VarsManager(ValueEvaluator valueEvaluator)
        {
            vars = new Dictionary<string, Value>();
            this.valueEvaluator = valueEvaluator;
        }

        public void setValue(string name, string value, string type)
        {
            if (type == "FLOAT")
                setValue(name, value, Types.FLOAT);
            else if (type == "VECTOR")
                setValue(name, value, Types.VECTOR);
            else if (type == "STRING")
                setValue(name, value, Types.STRING);
            else
                throw new Exception("Type error.");
        }

        public void setValues(Dictionary<string, Value> values)
        {
            foreach(string key in values.Keys)
            {
                vars[key] = values[key];
            }
        }

        public void setValue(string name, string value, Types type)
        {
            object result = null;

            if (type == Types.FLOAT)
            {
                float f = valueEvaluator.evaluateArithmeticOperation(value);
                if (float.IsNaN(f))
                    result = null;
                else
                    result = f;
            }
            else if (type == Types.VECTOR)
                result = valueEvaluator.evaluateVector(value);
            else if (type == Types.STRING)
                result = valueEvaluator.evaluateString(value);
            else
                throw new Exception("Type error.");

            if (result != null)
                vars[name] = new Value(result, type);
            else
                throw new Exception("Value-Type error.");
        }

        public void updateValue(string name, string value)
        {
            Value var = getValue(name);
            if (var != null)
                setValue(name, value, var.type);
            else
                throw new Exception("Var doesn't exist.");
        }
        public void removeValue(string name)
        {
            vars.Remove(name);
        }

        public Value getValue(string name)
        {
            Value value = null;
            vars.TryGetValue(name, out value);
            return value;
        }
    }
}
