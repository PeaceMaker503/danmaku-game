using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StageMaker.spell_maker.parser
{
    public class Tokenizer
    {
        private string pattern;
        private Dictionary<string, string> tokens;
        public List<string> values { get; private set; }
        public List<string> tValues { get; set; }

        public void parseConf(string path)
        {
            string text = File.ReadAllText(path);
            string[] blocks = text.Split(new string[] { "%%" }, StringSplitOptions.RemoveEmptyEntries);
            string[] tokenConf = blocks[0].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<tokenConf.Length;i++)
            {
                string[] param = tokenConf[i].Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string token = param[1].Trim(new char[] { ' ', '\r', '\n' });
                string regex = param[0].Trim(new char[] { ' ', '\r', '\n' });
                this.addToken(regex, token);
            }
            string[] tokenValues = blocks[1].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for(int j=0;j<tokenValues.Length;j++)
            {
                string token = tokenValues[j].Trim(new char[] { ' ', '\r', '\n' });
                this.tValues.Add(token);
            }
        }

        public Tokenizer()
        {
            this.pattern = String.Empty;
            this.tokens = new Dictionary<string, string>();
            this.values = new List<string>();
            this.tValues = new List<string>();
            this.parseConf(@"conf/tokenizer.conf");
        }

        public void addToken(string p, string t)
        {
            if (pattern.Length > 0)
                pattern += "|";

            pattern += "(" + p + ")";
            tokens[p] = t;
        }

        public string[] tokenize(string s)
        {
            string[] tokens = Regex.Split(s, pattern)
                                   .Select(str => str.Trim(new char[] { '\r', '\n', ' ', '\t' }))
                                   .Where(str => str != String.Empty)
                                   .ToArray();

            string[] result = new string[tokens.Length];
            for(int i=0;i<result.Length;i++)
            {
                string token = tokens[i];
                bool found = false;
                foreach (string pattern in this.tokens.Keys)
                {
                    Regex r = new Regex(pattern);
                    if (r.IsMatch(token))
                    {
                        result[i] = this.tokens[pattern];
                        found = true;

                        if (this.tValues.Contains(result[i]))
                            values.Add(token);

                        break;
                    }
                }


                if (!found)
                        throw new Exception("Token is unspecified.");
                }

            return result;
        }
    }
}
