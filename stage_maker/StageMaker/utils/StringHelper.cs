using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.utils
{
    public class StringHelper
    {
        public static string[] FormatLine(string s)
        {
            string result = string.Join(String.Empty, s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join("\r\n", result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(" ", result.Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(",", result.Split(new string[] { ", ", }, StringSplitOptions.None));
            result = string.Join(",", result.Split(new string[] { " ,", }, StringSplitOptions.None));
            result = string.Join("[", result.Split(new string[] { "[ ", }, StringSplitOptions.None));
            result = string.Join("]", result.Split(new string[] { " ]", }, StringSplitOptions.None));
            result = string.Join("(", result.Split(new string[] { "( ", }, StringSplitOptions.None));
            result = string.Join(")", result.Split(new string[] { " )", }, StringSplitOptions.None));
            return result.Split(' ');
        }

        public static string[] FormatAllText(string s)
        {
            string result = string.Join(String.Empty, s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join("\r\n", result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(" ", result.Split(new char[] { ' ', }, StringSplitOptions.RemoveEmptyEntries));
            result = string.Join(",", result.Split(new string[] { ", ", }, StringSplitOptions.None));
            result = string.Join(",", result.Split(new string[] { " ,", }, StringSplitOptions.None));
            result = string.Join("[", result.Split(new string[] { "[ ", }, StringSplitOptions.None));
            result = string.Join("]", result.Split(new string[] { " ]", }, StringSplitOptions.None));
            result = string.Join("(", result.Split(new string[] { "( ", }, StringSplitOptions.None));
            result = string.Join(")", result.Split(new string[] { " )", }, StringSplitOptions.None));
            return result.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public static string FormatFloat(float f)
        {
            return f.ToString().Replace(",", ".");
        }
    }
}
