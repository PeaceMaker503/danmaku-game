using StageMaker.models;
using System;
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
    public partial class ManageEnemiesForm : Form
    {
        public Dictionary<string, List<EnemyType>> jsonEnemyTypes { get; private set; }

        public ManageEnemiesForm(Dictionary<string, List<EnemyType>> jsonEnemyTypes)
        {
            InitializeComponent();
            if (jsonEnemyTypes == null)
                this.jsonEnemyTypes = new Dictionary<string, List<EnemyType>>();
            else
            {
                this.jsonEnemyTypes = jsonEnemyTypes;
                foreach(string key in jsonEnemyTypes.Keys)
                {
                    foreach(EnemyType e in jsonEnemyTypes[key])
                    {
                        this.dataGridView1.Rows.Add(e.type, e.imagePath, e.x, e.y, e.width, e.height);
                    }
                }
            }
        }

        private void addNewEnemyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageCutterForm f = new ImageCutterForm();
            DialogResult r = f.ShowDialog();
            if(r == DialogResult.OK)
            {
                this.dataGridView1.Rows.Add(f.type, f.imagePath, f.x, f.y, f.width, f.height);
            }
        }

        private void button1_Click(object sender, EventArgs e) //save
        {
            DialogResult = DialogResult.OK;
            jsonEnemyTypes = new Dictionary<string, List<EnemyType>>();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                string type = (string)row.Cells[0].Value;
                string imagePath = (string)row.Cells[1].Value;
                int x = (int)row.Cells[2].Value;
                int y = (int)row.Cells[3].Value;
                int width = (int)row.Cells[4].Value;
                int height = (int)row.Cells[5].Value;

                if (jsonEnemyTypes.ContainsKey(type))
                {
                    jsonEnemyTypes[type].Add(new EnemyType(type, imagePath, x, y, width, height));
                }
                else
                {
                    jsonEnemyTypes[type] = new List<EnemyType> { new EnemyType(type, imagePath, x, y, width, height) };
                }
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //cancel
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
