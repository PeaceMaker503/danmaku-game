using StageMaker.models;
using StageMaker.spell_maker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker.spell_maker.evaluators
{
    public class ValueEvaluator
    {
        private Dictionary<string, Value> vars;
        private long behaviorIdParticle;

        public ValueEvaluator(Dictionary<string, Value> vars, long behaviorIdParticle)
        {
            this.vars = vars;
            this.behaviorIdParticle = behaviorIdParticle;
        }

        public static bool isRuntimeValue(string value)
        {
            if (value.StartsWith("%") && value.EndsWith("%"))
            {
                value = value.Replace("%", String.Empty);
                if (value == "PLAYER_POSITION")
                    return true;

                if (value.StartsWith("PARTICLE_POSITION_"))
                {
                    value = value.Replace("PARTICLE_POSITION_", String.Empty);
                    ulong ul;
                    return ulong.TryParse(value, out ul);
                }
            }

            return false;
        }

        public string evaluateRuntimeValue(string value)
        {
            string result = null;

            if (value.StartsWith("%") && value.EndsWith("%"))
            {
                value = value.Replace("%", String.Empty);
                if (value == "PLAYER_POSITION")
                    result = "%PLAYER_POSITION%";
                else if (behaviorIdParticle != -1 && value == "PARTICLE_POSITION")
                 result = string.Format("%PARTICLE_POSITION_{0}%", behaviorIdParticle);
            }

            return result;
        }

        public bool evaluateCase(string v1, string v2, string op)
        {
            float fV1 = this.evaluateArithmeticOperation(v1);
            float fV2 = this.evaluateArithmeticOperation(v2);

            bool result = false;
            if (op == "==" && fV1 == fV2)
                result = true;
            else if (op == "!=" && fV1 != fV2)
                result = true;
            else if (op == ">" && fV1 > fV2)
                result = true;
            else if (op == "<" && fV1 < fV2)
                result = true;
            else if (op == ">=" && fV1 >= fV2)
                result = true;
            else if (op == "<=" && fV1 <= fV2)
                result = true;

            return result;
        }

        public Dictionary<string, Types> evaluateBehaviorDeclarationArgs(string behaviorArgs)
        {
            Dictionary<string, Types> args = new Dictionary<string, Types>();
            string[] splittedArgs = behaviorArgs.Trim(new char[] { ' ', '[', ']' }).Split('|');
            for(int i=0;i<splittedArgs.Length;i++)
            {
                string[] pair = splittedArgs[i].Trim(new char[] { ' ', '(', ')' }).Split(':');
                string id = pair[0];
                string type = pair[1];
                args[id] = StringHelper.StringToTypesEnum(type);
            }
            return args;
        }

        public Dictionary<string, Value> evaluateBehaviorCallArgs(Dictionary<string, Types> behaviorDeclarationArgs, string behaviorCallArgs)
        {
            Dictionary<string, Value> values = new Dictionary<string, Value>();
            string[] splittedArgs = behaviorCallArgs.Substring(1, behaviorCallArgs.Length - 2).Split('|');
            if (behaviorDeclarationArgs.Keys.Count != splittedArgs.Length)
                throw new Exception("Bad args length.");
            else
            {
                int i = 0;
                foreach(string key in behaviorDeclarationArgs.Keys)
                {
                    Types type = behaviorDeclarationArgs[key];
                    string value = splittedArgs[i];
                    object result = null;

                    if (type == Types.FLOAT)
                    {
                        float f = evaluateArithmeticOperation(value);
                        if (float.IsNaN(f))
                            result = null;
                        else
                            result = f;
                    }
                    else if (type == Types.VECTOR)
                        result = evaluateVector(value);
                    else if (type == Types.STRING)
                        result = evaluateString(value);
                    else
                        throw new Exception("Type error.");

                    if (result != null)
                        values[key] = new Value(result, type);
                    else
                        throw new Exception("Value-Type error.");

                    i++;
                }
            }
            return values;
        }

        public string evaluateString(string value)
        {
            string result = null;
            value = value.Trim();
            if (value.StartsWith("\"") && value.EndsWith("\""))
                result = value.Replace("\"", String.Empty);

            Value var;
            if (vars.TryGetValue(value, out var) && var.type == Value.Types.STRING)
                result = (string)var.value;

            return result;
        }

        public string evaluateVector(string value)
        {
            string result = null;
            value = value.Trim();
            if (value.StartsWith("[") && value.EndsWith("]"))
            {
                string left = value.Substring(1, value.IndexOf(";")-1);
                string right = value.Substring(value.IndexOf(";") + 1, value.IndexOf("]") - value.IndexOf(";") - 1);
                float fLeft = evaluateArithmeticOperation(left);
                float fRight = evaluateArithmeticOperation(right);
                result = new JsonVector2(fLeft, fRight).ToString();
            }
            else
            {
                Value var;
                if (vars.TryGetValue(value, out var) && var.type == Value.Types.VECTOR)
                    result = (string)var.value;

                string rv = evaluateRuntimeValue(value);
                if (rv != null)
                    result = rv;
            }
            return result;
        }
        
        public float evaluateArithmeticOperation(string value)
        {
            float result = float.NaN;
            value = value.Trim();

            if (value.StartsWith("ADD") || value.StartsWith("MUL") || value.StartsWith("SUB") || value.StartsWith("DIV") || value.StartsWith("MOD"))
            {
                string op = value.substring(0, 2);
                value = value.Substring(3);
                value = value.Substring(1, value.Length - 2);
                string left = value.Substring(0, value.IndexOf(";"));
                string right = value.Substring(value.IndexOf(";") + 1);
                float fLeft = evaluateArithmeticOperation(left);
                float fRight = evaluateArithmeticOperation(right);

                if (op == "ADD")
                    result = fLeft + fRight;
                else if (op == "SUB")
                    result = fLeft - fRight;
                else if (op == "MUL")
                    result = fLeft * fRight;
                else if (op == "DIV")
                    result = fLeft / fRight;
                else if (op == "MOD")
                    result = fLeft % fRight;
            }
            else
                result = evaluateFloat(value);

            return result;
        }

        public float evaluateFloat(string arg)
        {
            float result = float.NaN;
            float value;
            bool statusParse = float.TryParse(arg.Replace(".", ","), out value);
            if (statusParse)
                result = value;

            Value var;
            if (vars.TryGetValue(arg, out var) && var.type == Value.Types.FLOAT)
                result = (float)var.value;

            return result;
        }
    }
}
