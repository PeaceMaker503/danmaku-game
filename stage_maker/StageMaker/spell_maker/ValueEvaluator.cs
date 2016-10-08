using StageMaker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.spell_maker
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

        public ValueEvaluator(Dictionary<string, Value> vars)
        {
            this.vars = vars;
        }

        public float parseFloat(string arg)
        {
            float value = float.NaN;
            bool statusParse = float.TryParse(arg.Replace(".", ","), out value);
            if (!statusParse)
            {
                Value var;
                if (vars.TryGetValue(arg, out var))
                    value = (float)var.value;
            }

            return value;
        }

        public float[] parseArgsValues(string[] args, int offset)
        {
            float[] argsV = new float[args.Length - offset];
            for (int j = 0; j < argsV.Length; j++)
            {
                argsV[j] = parseFloat(args[j + offset]);
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
            if (arg.StartsWith("[") && arg.EndsWith("]"))
            {
                string sx = arg.substring(1, arg.IndexOf(",") - 1);
                string sy = arg.substring(arg.IndexOf(",") + 1, arg.Length - 2);
                float x = parseFloat(sx);
                float y = parseFloat(sy);
                return new JsonVector2(x, y).ToString();
            }

            if (ValueEvaluator.isRuntimeValue(arg))
                return arg;

            return null;
        }

        public string parseVector(string arg, long particleId)
        {
            if (particleId == -1)
                return parseVector(arg);
            else
            {
                if (arg.StartsWith("%") && arg.EndsWith("%"))
                {
                    arg = arg.Replace("%", String.Empty);

                    if (arg == "PARTICLE_POSITION")
                        return "%PARTICLE_POSITION_" + particleId + "%";
                }
                return null;
            }
        }

        public string parseBehaviorName(string arg)
        {
            return arg.substring(0, arg.IndexOf("(") - 1);
        }

        public string[] parseBehaviorArgsName(string arg)
        {
            arg = arg.Substring(arg.IndexOf("("));
            arg = arg.Replace(")", String.Empty);
            arg = arg.Replace("(", String.Empty);
            arg = arg.Trim();
            return this.parseArgsNames(arg.Split(','), 0);
        }

        public float[] parseBehaviorArgsValues(string arg)
        {
            arg = arg.Substring(arg.IndexOf("("));
            arg = arg.Replace(")", String.Empty);
            arg = arg.Replace("(", String.Empty);
            arg = arg.Trim();
            return this.parseArgsValues(arg.Split(','), 0);
        }

        public long parseLong(string arg)
        {
            long value;
            bool statusParse = long.TryParse(arg.Replace(".", ","), out value);
            if (!statusParse)
            {
                Value var;
                if (vars.TryGetValue(arg, out var))
                    return new long();
            }

            return -1;
        }
    }
}
