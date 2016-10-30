using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StageMaker.spell_maker.evaluators.SpellEvaluator;
using static StageMaker.spell_maker.models.Value;

namespace StageMaker.utils
{
    public class FileHelper
    {
        public static Dictionary<string, Types> getArgsDeclaration(string path)
        {
            Dictionary<string, Types> argsDeclaration = new Dictionary<string, Types>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] args = StringHelper.FormatLine(line);
                    if (args[0] == Command.ARGS)
                    {
                        string[] decl = args[1].Split(':');
                        if (decl[1] == "string")
                            argsDeclaration[decl[0]] = Types.STRING;
                        else if(decl[1] == "float")
                            argsDeclaration[decl[0]] = Types.FLOAT;
                        else if(decl[1] == "vector")
                            argsDeclaration[decl[0]] = Types.VECTOR2;
                        else if (decl[1] == "number")
                            argsDeclaration[decl[0]] = Types.NUMBER;
                    }
                    else
                        break;
                }
            }
            return argsDeclaration;
        }
    }
}
