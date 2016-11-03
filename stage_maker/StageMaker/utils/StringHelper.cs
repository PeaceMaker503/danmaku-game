using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker.utils
{
    public class StringHelper
    {
        public static string[] FormatLine(string s)
        {
            string result = string.Join(String.Empty, s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join("\r\n", result.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(" ", result.Split(new string[] { " ", }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(",", result.Split(new string[] { ", ", }, StringSplitOptions.None));
            result = string.Join(",", result.Split(new string[] { " ,", }, StringSplitOptions.None));
            result = string.Join("[", result.Split(new string[] { "[ ", }, StringSplitOptions.None));
            result = string.Join("]", result.Split(new string[] { " ]", }, StringSplitOptions.None));
            result = string.Join("(", result.Split(new string[] { "( ", }, StringSplitOptions.None));
            result = string.Join(")", result.Split(new string[] { " )", }, StringSplitOptions.None));
            result = string.Join(":", result.Split(new string[] { " :", }, StringSplitOptions.None));
            result = string.Join(":", result.Split(new string[] { ": ", }, StringSplitOptions.None));
            return result.Split(' ');
        }

        public static string FormatFloat(float f)
        {
            return f.ToString().Replace(",", ".");
        }

        public static string TypesEnumToString(Types t)
        {
            if (t == Types.FLOAT)
                return "float";
            else if (t == Types.NUMBER)
                return "number";
            else if (t == Types.VECTOR)
                return "vector";
            else if (t == Types.STRING)
                return "string";

            return null;
        }

        public static Types StringToTypesEnum(string s)
        {
            s = s.ToLower();
            if (s == "float")
                return Types.FLOAT;
            else if (s == "number")
                return Types.NUMBER;
            else if (s == "vector")
                return Types.VECTOR;
            else if (s == "string")
                return Types.STRING;

            return Types.NULL;
        }
    }
}
