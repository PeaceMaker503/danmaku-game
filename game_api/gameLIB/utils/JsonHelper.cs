using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLIB.utils
{
    public class JsonHelper
    {
        public static string JsonSerializeWithoutQuoteInNames(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var writer = new JsonTextWriter(stringWriter) { QuoteName = false })
                    new JsonSerializer().Serialize(writer, obj);
                return stringWriter.ToString();
            }
        }
    }
}
