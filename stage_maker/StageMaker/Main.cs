using Newtonsoft.Json;
using StageMaker.models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            
        }

        private void addNewScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewScript form = new AddNewScript();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                this.dataGridView1.Rows.Add(form.begin, form.end, Path.GetFullPath(form.path));
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ScriptInfo> compiledScripts = new List<ScriptInfo>();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                decimal begin = (decimal)row.Cells[0].Value;
                decimal end = (decimal)row.Cells[1].Value;
                string path = (string)row.Cells[2].Value;
                compiledScripts.Add(new ScriptInfo((float)begin, (float)end, path));
            }
            string data = JsonConvert.SerializeObject(compiledScripts);
            string exePath = Path.Combine(Directory.GetCurrentDirectory(), "game\\PeaceGame.exe");
            this.ControlBox = false;
            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = Path.GetDirectoryName(exePath);
            info.EnvironmentVariables["scriptData"] = data;
            info.FileName = exePath;
            info.UseShellExecute = false;
            Process p = Process.Start(info);
            p.WaitForExit();
            MessageBox.Show(@"Le processus s'est correctement terminé.", "Information");
            this.ControlBox = true;
        }
    }
}
