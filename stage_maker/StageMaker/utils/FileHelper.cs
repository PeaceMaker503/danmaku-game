using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageMaker.utils
{
    public class FileHelper
    {
        public static string getFirstLine(string path)
        {
            string firstLine;
            using (StreamReader sr = new StreamReader(path))
            {
                firstLine = sr.ReadLine();
            }

            return firstLine;
        }

        public static string[] getFirstLineArgs(string path)
        {
            string line = getFirstLine(path);
            return StringHelper.FormatLine(line);
        }
    }
}
