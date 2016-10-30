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
        private Dictionary<string, Value> vars;
        private Dictionary<string, Types> argsDeclaration;

        public VarsManager()
        {
            vars = new Dictionary<string, Value>();
            this.valueEvaluator = new ValueEvaluator(vars);
        }

        public void setValue(string name, string value, Types type)
        {
            this.setValue(name, value, type, false);
        }

        public void setValue(string name, string value, Types type, bool isDeclaration)
        {
            if (type == Types.FLOAT)
            {
                float pValue = valueEvaluator.parseFloat(value, isDeclaration);
                vars[name] = new Value(pValue, Types.FLOAT);
            }
            else if (type == Types.NUMBER)
            {
                long pValue = valueEvaluator.parseLong(value, isDeclaration);
                vars[name] = new Value(pValue, Types.NUMBER);
            }
            else if (type == Types.VECTOR2)
            {
                string pValue = valueEvaluator.parseVector(value, isDeclaration);
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

        public void specifyArgs(string[] argsDeclarationValues)
        {
            int i = 0;
            foreach (string key in argsDeclaration.Keys)
            {
                this.setValue(key, argsDeclarationValues[i], vars[key].type, true);
                i++;
            }
        }
        
        public void declareArgs(Dictionary<string, Types> argsDeclaration)
        {
            foreach(string key in argsDeclaration.Keys)
            {
                vars[key] = new Value(null, argsDeclaration[key]);
            }
            this.argsDeclaration = argsDeclaration;
        }

        public Dictionary<string, Types> getArgsDeclaration()
        {
            return this.argsDeclaration;
        }

        public void removeValue(string name)
        {
            vars.Remove(name);
        }

        public object getValue(string name)
        {
            Value value = null;
            vars.TryGetValue(name, out value);
            return value;
        }

        public Types getType(string name)
        {
            return vars[name].type;
        }

    }
}
