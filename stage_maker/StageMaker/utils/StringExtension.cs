using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.utils
{
    public static class StringExtension
    {
        public static string substring(this string s, int begin, int end)
        {
            return s.Substring(begin, end - begin + 1);
        }

        public static int NthIndexOf(this string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n-1].Index;
            else
                return -1;
        }
    }
}
