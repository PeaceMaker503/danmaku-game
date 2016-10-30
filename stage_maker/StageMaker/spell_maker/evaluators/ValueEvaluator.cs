using StageMaker.models;
using StageMaker.spell_maker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker.evaluators
{
    public class ValueEvaluator
    {
        private Dictionary<string, Value> vars;

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

        public bool isFloat(string arg)
        {
            return parseFloat(arg) != float.NaN;
        }

        public bool isLong(string arg)
        {
            return parseLong(arg) != -1;
        }

        public bool isVector(string arg)
        {
            return parseVector(arg) != null;
        }

        public ValueEvaluator(Dictionary<string, Value> vars)
        {
            this.vars = vars;
        }

        public float parseFloat(string arg)
        {
            return parseFloat(arg, false);
        }

        public float parseFloat(string arg, bool isDeclaration)
        {
            float value;
            bool statusParse = float.TryParse(arg.Replace(".", ","), out value);
            if (statusParse)
                return value;

            Value var;
            if (!isDeclaration && vars.TryGetValue(arg, out var) && var.type == Value.Types.FLOAT)
                return (float)var.value;

            return float.NaN;
        }

        public string[] parseArgsValues(string[] args, int offset)
        {
            string[] argsV = new string[args.Length - offset];
            for (int j = 0; j < argsV.Length; j++)
            {
                argsV[j] = args[j + offset];
            }
            return argsV;
        }

        public string[] parseArgsNames(string[] args, int offset)
        {
            string[] argsN = new string[args.Length - offset];
            for (int j = 0; j < argsN.Length; j++)
            {
                argsN[j] = args[j + offset];
            }
            return argsN;
        }

        public string parseVector(string arg)
        {
            return parseVector(arg, false);
        }

        public string parseVector(string arg, bool isDeclaration)
        {
            if (arg.StartsWith("[") && arg.EndsWith("]"))
            {
                string sx = arg.substring(1, arg.IndexOf(",") - 1);
                string sy = arg.substring(arg.IndexOf(",") + 1, arg.Length - 2);
                float x = parseFloat(sx);
                float y = parseFloat(sy);
                return new JsonVector2(x, y).ToString();
            }

            Value var;
            if (!isDeclaration && vars.TryGetValue(arg, out var) && var.type == Value.Types.VECTOR2)
                return (string)var.value;

            if (ValueEvaluator.isRuntimeValue(arg))
                return arg;

            return null;
        }

        public string parseString(string arg)
        {
            if (arg.StartsWith("'") && arg.EndsWith("'"))
                return arg.Replace("'", String.Empty);

                Value var;
            if (vars.TryGetValue(arg, out var) && var.type == Value.Types.STRING)
                return (string)var.value;

            if (ValueEvaluator.isRuntimeValue(arg))
                return arg;

            return null;
        }

        public string parseVector(string arg, long particleId)
        {
            if (particleId == -1)
                return parseVector(arg);

            if (ValueEvaluator.isRuntimeValue(arg))
                return arg;

            if (arg.StartsWith("%") && arg.EndsWith("%"))
            {
                arg = arg.Replace("%", String.Empty);
                if (arg == "PARTICLE_POSITION")
                    return "%PARTICLE_POSITION_" + particleId + "%";
            }

            return null;
        }

        public string parseBehaviorName(string arg)
        {
            return arg.substring(0, arg.IndexOf("(") - 1);
        }

        public Dictionary<string, Value.Types> parseBehaviorArgsName(string arg)
        {
            arg = arg.Substring(arg.IndexOf("("));
            arg = arg.Replace(")", String.Empty);
            arg = arg.Replace("(", String.Empty);
            arg = arg.Trim();
            if (arg != String.Empty)
            {
                string[] args = arg.Split(',');
                Dictionary<string, Value.Types> argsDeclarationsBehaviors = new Dictionary<string, Value.Types>();
                for (int i = 0; i < args.Length; i++)
                {
                    string[] decl = args[i].Split(':');
                    if (decl[1] == "string")
                        argsDeclarationsBehaviors[decl[0]] = Value.Types.STRING;
                    else if (decl[1] == "float")
                        argsDeclarationsBehaviors[decl[0]] = Value.Types.FLOAT;
                    else if (decl[1] == "vector")
                        argsDeclarationsBehaviors[decl[0]] = Value.Types.VECTOR2;
                    else if (decl[1] == "number")
                        argsDeclarationsBehaviors[decl[0]] = Value.Types.NUMBER;
                }
                return argsDeclarationsBehaviors;
            }
            else
                return new Dictionary<string, Value.Types>();
        }

        public object[] parseBehaviorArgsValues(string arg)
        {
            arg = arg.Substring(arg.IndexOf("("));
            arg = arg.Replace(")", String.Empty);
            arg = arg.Replace("(", String.Empty);
            arg = arg.Trim();
            string[] args = arg.Split(',');
            object[] values = new object[args.Length];
            for(int i=0;i<values.Length;i++)
            {
                Value v;
                if(this.vars.TryGetValue(args[i], out v))
                {
                    values[i] = v.value;
                }
                else
                {
                    if (isFloat(arg))
                        values[i] = parseFloat(arg);
                    else if (isVector(arg))
                        values[i] = parseVector(arg);
                    else if (isLong(arg))
                        values[i] = parseFloat(arg);
                    else
                        values[i] = arg;
                }
            }
            return values;
        }

        public long parseLong(string arg, bool isDeclaration)
        {
            long value;
            bool statusParse = long.TryParse(arg, out value);
            if (statusParse)
                return value;

            Value var;
            if (!isDeclaration && vars.TryGetValue(arg, out var) && var.type == Value.Types.NUMBER)
                return (long)var.value;

            return -1;
        }

        public long parseLong(string arg)
        {
            return parseLong(arg, false);
        }
    }
}
