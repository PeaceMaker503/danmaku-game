using Newtonsoft.Json;
using StageMaker.models;
using StageMaker.spell_maker;
using StageMaker.spell_maker.evaluators;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static StageMaker.utils.DataGridViewHelper;

namespace StageMaker
{
    public partial class StageMaker : Form
    {

        private iEnemyForm iEnemiesForm;
        private bEnemyForm bEnemiesForm;
        private iParticleForm iParticlesForm;
        private bParticleForm bParticlesForm;

        private List<SpellLine> spellsPath = new List<SpellLine> {
            new SpellLine("circle", Path.GetFullPath(@"spells\circle.sp")),
            new SpellLine("spell", Path.GetFullPath(@"spells\spell.sp"))
        };

        private Dictionary<string, List<EnemyType>> enemyTypes = new Dictionary<string, List<EnemyType>>();

        public StageMaker()
        {
            InitializeComponent();
            iEnemiesForm = new iEnemyForm();
            bEnemiesForm = new bEnemyForm();
            iParticlesForm = new iParticleForm();
            bParticlesForm = new bParticleForm();
            iEnemiesForm.Show();
            iParticlesForm.Show();
            bEnemiesForm.Show();
            bParticlesForm.Show();
            this.FormClosing += new FormClosingEventHandler(form_closing);
            this.KeyDown += StageMaker_KeyDown;
        }

        private void StageMaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F8)
                launchToolStripMenuItem_Click(sender, e);
        }

        private void form_closing(object sender, FormClosingEventArgs args)
        {
            DialogResult r = MessageBox.Show(@"Voulez-vous enregistrer vos modifications ?", "Attention", MessageBoxButtons.YesNoCancel);
            if (r == DialogResult.Yes)
                jsonToolStripMenuItem_Click(sender, args);
            else if (r == DialogResult.Cancel)
                args.Cancel = true;
        }

        private void jsonToolStripMenuItem1_Click(object sender, EventArgs e) //import
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iEnemiesForm.enemyId = JsonGridConverter.importJson(iEnemiesForm.getGrid(), iParticlesForm.getGrid(), bEnemiesForm.getGrid(), bParticlesForm.getGrid(), openFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement importé", "Erreur");
                }
            }
        }
        
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e) //export
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string data = JsonGridConverter.exportJson(iEnemiesForm.getGrid(), iParticlesForm.getGrid(), bEnemiesForm.getGrid(), bParticlesForm.getGrid(), true);
                    File.WriteAllText(Path.Combine(folderBrowserDialog1.SelectedPath, "script.json"), data, Encoding.UTF8);
                    MessageBox.Show("The file has been successfully exported in " + folderBrowserDialog1.SelectedPath + ".", "Export to json.");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement exporté", "Erreur");
                }
            }
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void addNewSpellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewSpellForm f = new NewSpellForm(iParticlesForm.getGrid(), bParticlesForm.getGrid(), iParticlesForm.particleId, this.spellsPath);
            DialogResult r = f.ShowDialog();

            if(r == DialogResult.OK)
            {
                iParticlesForm.particleId = f.particleId;
                MessageBox.Show(@"Le spell a été correctement instancié.", "Message.");
            }
            else
            {
                MessageBox.Show(@"Le spell n'a pas pu être correctement instancié.", "Message.");
            }
        }

        private void manageSpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageSpellsForm f = new ManageSpellsForm(this.spellsPath);
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                this.spellsPath = f.jsonSpells;
                MessageBox.Show(@"Les modifications ont bien été sauvegardées.", "Message.");
            }
            else
            {
                MessageBox.Show(@"Les modifications n'ont pas été sauvegardées.", "Message.");
            }
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string exePath = string.Empty;

            if (File.Exists("game\\PeaceGame.exe"))
            {
                exePath = Path.Combine(Directory.GetCurrentDirectory(), "game\\PeaceGame.exe");
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "executable files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    exePath = openFileDialog1.FileName;
                }
            }

            if(exePath != string.Empty)
            {
                try
                {
                    string data = JsonGridConverter.exportJson(iEnemiesForm.getGrid(), iParticlesForm.getGrid(), bEnemiesForm.getGrid(), bParticlesForm.getGrid(), false);
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
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement exporté ou lu", "Erreur");
                }
            }
        }

        private void manageEnemiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageEnemiesForm f = new ManageEnemiesForm(enemyTypes);
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
                enemyTypes = f.jsonEnemyTypes;
        }

        private void configjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string data = JsonGridConverter.exportConfigJson(enemyTypes, spellsPath, true);
                    File.WriteAllText(Path.Combine(folderBrowserDialog1.SelectedPath, "config.json"), data, Encoding.UTF8);
                    MessageBox.Show("The file has been successfully exported in " + folderBrowserDialog1.SelectedPath + ".", "Export to json.");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement exporté", "Erreur");
                }
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string data = JsonGridConverter.exportJson(iEnemiesForm.getGrid(), iParticlesForm.getGrid(), bEnemiesForm.getGrid(), bParticlesForm.getGrid(), true);
                    File.WriteAllText(Path.Combine(folderBrowserDialog1.SelectedPath, "script.json"), data, Encoding.UTF8);
                    data = JsonGridConverter.exportConfigJson(enemyTypes, spellsPath, true);
                    File.WriteAllText(Path.Combine(folderBrowserDialog1.SelectedPath, "config.json"), data, Encoding.UTF8);
                    MessageBox.Show("The files have been successfully exported in " + folderBrowserDialog1.SelectedPath + ".", "Export to json.");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement exporté", "Erreur");
                }
            }
        }
    }
}
