using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StageMaker.utils;
using System.IO;
using StageMaker.models;
using StageMaker.spell_maker;
using StageMaker.spell_maker.evaluators;

namespace StageMaker
{
    public partial class Form2 : Form
    {
        private DataGridView shoot;
        private DataGridView particleMove;
        public long particleId { get; set; }
        private Dictionary<string, string> spells;

        public Form2(DataGridView shoot, DataGridView particleMove, long particleId, List<SpellLine> jsonSpells)
        {
            InitializeComponent();
            this.shoot = shoot;
            this.particleMove = particleMove;
            this.particleId = particleId;
            this.spells = new Dictionary<string, string>();

            if(jsonSpells != null)
            {
                foreach (SpellLine sl in jsonSpells)
                {
                    comboBox1.Items.Add(sl.name);
                    this.spells[sl.name] = sl.path;
                }
                this.comboBox1.SelectedIndex = 0;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float time;
            if (float.TryParse(textBox1.Text.Replace(".", ","), out time))
            {
                long targetId = -1;
                if (textBox2.Text == String.Empty || long.TryParse(textBox2.Text, out targetId))
                {
                    string path = spells[comboBox1.Text];
                    if (File.Exists(path))
                    {
                        SpellEvaluator spellEvaluator = new SpellEvaluator(comboBox1.Text, time, targetId, particleId, this.spells);
                        spellEvaluator.initializeGrids(shoot, particleMove);

                        if (spellEvaluator.mustSpecifyArgs())
                        {
                            Form4 f = new Form4(spellEvaluator.getArgsDeclaration());
                            f.ShowDialog();
                            if(f.DialogResult == DialogResult.OK)
                            {
                                spellEvaluator.specifyArgs(f.args);
                            }
                            else
                            {
                                MessageBox.Show(@"Les arguments n'ont pas pas pu être pris en compte.", "Erreur.");
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                return;
                            }
                        }
                        particleId = spellEvaluator.evaluate();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(@"Le chemin spécifié n'existe pas.", "Erreur.");
                    }
                }
                else
                {
                    MessageBox.Show(@"TargetId n'est pas un nombre.", "Erreur.");
                }
            }
            else
            {
                MessageBox.Show(@"Time n'est pas un décimal.", "Erreur.");
            }
        }
    }
}
