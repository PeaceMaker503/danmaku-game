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
using static StageMaker.spell_maker.models.Value;

namespace StageMaker
{
    public partial class NewSpellForm : Form
    {
        private DataGridView shoot;
        private DataGridView particleMove;
        public long particleId { get; set; }
        private Dictionary<string, string> spells;

        public NewSpellForm(DataGridView shoot, DataGridView particleMove, long particleId, List<SpellLine> jsonSpells)
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
                    string spellName = comboBox1.Text;
                    string spellPath = spells[spellName];
                    if (File.Exists(spellPath))
                    {
                        SpellCompiler.clearCompiledSpells();
                        SpellEvaluator spellEvaluator = new SpellEvaluator(time, targetId, particleId);
                        spellEvaluator.initializeGrids(shoot, particleMove);
                        spellEvaluator.initializeSpells(spells);
                        string[] compiledSpellLines = SpellCompiler.compileSpell(spellPath);
                        Dictionary<string, Types> declarationArgs = spellEvaluator.evaluate_declaration_args(compiledSpellLines[0]);
                        if (declarationArgs.Count > 0)
                        {
                            SetArgsDeclarationForm f = new SetArgsDeclarationForm(declarationArgs);
                            f.ShowDialog();
                            if(f.DialogResult == DialogResult.OK)
                            {
                                spellEvaluator.setArgs(declarationArgs, f.args);
                            }
                            else
                            {
                                MessageBox.Show(@"Les arguments n'ont pas pas pu être pris en compte.", "Erreur.");
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                return;
                            }
                        }
                        spellEvaluator.evaluate(compiledSpellLines);
                        particleId += SpellEvaluator.getParticleId();
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
