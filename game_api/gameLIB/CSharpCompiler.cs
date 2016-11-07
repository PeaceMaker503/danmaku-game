using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLIB.main.engines
{
    public class CSharpCompiler
    {
        public static CompilerResults compileCSharp(string path, List<string> referencedAssemblies)
        {
            string source = File.ReadAllText(path);

            Dictionary<string, string> providerOptions = new Dictionary<string, string>
            {
                    {"CompilerVersion", "v3.5"}
            };

            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;

            foreach(string referencedAssembly in referencedAssemblies)
                cp.ReferencedAssemblies.Add(referencedAssembly);

            cp.CompilerOptions = "/optimize";
            CompilerResults results = provider.CompileAssemblyFromSource(cp, source);
            return results;
        }

        public static CompilerResults compileCSharp(string path)
        {
            return compileCSharp(path, new List<string> { "System.dll" });
        }
    }
}
