using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker.spell_maker.evaluators
{
    class SpellCompiler
    {
        private static Dictionary<string, string> compiledSpells = new Dictionary<string, string>();
        
        public static string[] compileSpell(string spellPath)
        {
            string tempFile = Path.GetTempFileName();
            ProcessStartInfo info = new ProcessStartInfo();
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.FileName = "launcher.bat";
            info.Arguments = string.Format("{0} {1}", tempFile, spellPath);
            info.WorkingDirectory = Directory.GetCurrentDirectory();
            Process p = Process.Start(info);
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                compiledSpells[spellPath] = tempFile;
                return File.ReadAllLines(tempFile);
            }
            else
            {
                MessageBox.Show("Could not compile " + spellPath + ".", "Error");
                return null;
            }
                
        }

        public static bool isSpellCompiled(string spellPath)
        {
            return compiledSpells.ContainsKey(spellPath);
        }

        public static string[] getCompiledSpell(string spellPath)
        {
            return File.ReadAllLines(compiledSpells[spellPath]);
        }

        public static void clearCompiledSpells()
        {
            compiledSpells.Clear();
        }
    }
}
