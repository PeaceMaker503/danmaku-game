using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker
{
    public partial class AddNewScript : Form
    {
        public string path { get; private set; }
        public decimal begin { get; private set; }
        public decimal end { get; private set; }

        public AddNewScript()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox3.Text;
            begin = numericUpDown1.Value;
            end = numericUpDown2.Value;
            CompilerResults scriptResults = CSharpCompiler.compileCSharp(path, new List<string> { "System.dll", "Microsoft.Xna.Framework.dll", "gameLIB.dll" });

            if (scriptResults.Errors.Count > 0)
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show("Script could not be compiled.", "Error.");
                this.Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                MessageBox.Show("Script has been successfully compiled.", "Success.");
                this.Close();
            }
        }
    }
}
