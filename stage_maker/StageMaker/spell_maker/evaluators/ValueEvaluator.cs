using Microsoft.Xna.Framework;
using StageMaker.models;
using StageMaker.spell_maker.models;
using StageMaker.spell_maker.parser;
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
        private VarsManager varsManager;
        private long behaviorIdParticle;

        public ValueEvaluator(long behaviorIdParticle=-1)
        {
            this.behaviorIdParticle = behaviorIdParticle;
        }

        public void initializeVarsManager(VarsManager varsManager)
        {
            this.varsManager = varsManager;
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
            Value vv1 = this.varsManager.getValue(v1);
            Value vv2 = this.varsManager.getValue(v2);
            bool result = false;
            if (vv1 != null && vv2 != null)
            {
                if(vv1.type == vv2.type)
                {
                    Types t = vv1.type;
                    if (t == Types.FLOAT)
                    {
                        if(op != "==" && op != "<" && op != ">" && op != "<=" && op != ">=" && op != "!=")
                            throw new Exception("Invalid boolean operator");

                        float fv1 = (float)vv1.value;
                        float fv2 = (float)vv2.value;

                        if (op == "==" && fv1 == fv2)
                            result = true;
                        else if (op == "<" && fv1 < fv2)
                            result = true;
                        else if (op == ">" && fv1 > fv2)
                            result = true;
                        else if (op == "<=" && fv1 <= fv2)
                            result = true;
                        else if (op == ">=" && fv1 >= fv2)
                            result = true;
                        else if (op == "!=" && fv1 != fv2)
                            result = true;
                    }
                    else if(t == Types.STRING)
                    {
                        if (op != "==")
                            throw new Exception("Boolean operator not supported for strings.");

                        string sv1 = (string)vv1.value;
                        string sv2 = (string)vv2.value;
                        if (op == "==" && sv1 == sv2)
                            result = true;
                    }
                    else if(t == Types.VECTOR)
                    {
                        if (op != "==")
                            throw new Exception("Boolean operator not supported for vectors.");

                        string sv1 = (string)vv1.value;
                        string sv2 = (string)vv2.value;
                        if (op == "==" && sv1 == sv2)
                            result = true;
                    }
                }
                else
                {
                    throw new Exception("Can't compare values of different types.");
                }
            }
            else
            {
                throw new Exception("Invalid code.");
            }
            return result;
        }

        public Dictionary<string, Types> evaluateDeclarationArgs(string declArgs)
        {
            if (declArgs.Trim() == "[]")
                return new Dictionary<string, Types>(); 

            Dictionary<string, Types> args = new Dictionary<string, Types>();
            string[] splittedArgs = declArgs.Trim(new char[] { ' ', '[', ']' }).Split(';');
            for(int i=0;i<splittedArgs.Length;i++)
            {
                string[] pair = splittedArgs[i].Trim(new char[] { ' ', '(', ')' }).Split(':');
                string id = pair[0];
                string type = pair[1];
                args[id] = StringHelper.StringToTypesEnum(type);
            }
            return args;
        }

        public Dictionary<string, Value> evaluateCallArgs(Dictionary<string, Types> declarationArgs, string argsCallValues)
        {
            if (argsCallValues.Trim() == "[]")
                return new Dictionary<string, Value>();

            string[] splittedArgs = argsCallValues.Substring(1, argsCallValues.Length - 2).Split(';');
            return evaluateCallArgs(declarationArgs, splittedArgs);
        }

        public Dictionary<string, Value> evaluateCallArgs(Dictionary<string, Types> behaviorDeclarationArgs, string[] splittedArgs)
        {
            Dictionary<string, Value> values = new Dictionary<string, Value>();
            if (behaviorDeclarationArgs.Keys.Count != splittedArgs.Length)
                throw new Exception("Bad args length.");
            else if (behaviorDeclarationArgs.Count == 0)
                return new Dictionary<string, Value>();
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

            Value var = this.varsManager.getValue(value);
            if (var != null && var.type == Types.STRING)
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
                Value var = this.varsManager.getValue(value);
                if (var != null && var.type == Value.Types.VECTOR)
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
            else if(value.StartsWith("COS") || value.StartsWith("SIN") || value.StartsWith("TAN"))
            {
                string op = value.substring(0, 2);
                value = value.Substring(4, value.Length-5);
                float fValue = evaluateArithmeticOperation(value);
                if (op == "COS")
                    result = (float)Math.Cos(MathHelper.ToRadians(fValue));
                else if (op == "SIN")
                    result = -(float)Math.Sin(MathHelper.ToRadians(fValue));
                else if (op == "TAN")
                    result = -(float)Math.Tan(MathHelper.ToRadians(fValue));
            }
            else
                result = evaluateFloat(value);

            return result;
        }

        public float evaluateFloat(string value)
        {
            float result = float.NaN;
            float fValue;
            bool statusParse = float.TryParse(value.Replace(".", ","), out fValue);
            if (statusParse)
                result = fValue;

            Value var = this.varsManager.getValue(value);
            if (var != null && var.type == Value.Types.FLOAT)
                result = (float)var.value;

            return result;
        }
    }
}
