using StageMaker.models;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker
{
    public partial class ManageSpellsForm : Form
    {
        private string lastPath;
        public List<SpellLine> jsonSpells { get; private set; }
        public ManageSpellsForm(List<SpellLine> jsonCurrentSpells)
        {
            InitializeComponent();
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            if(jsonCurrentSpells != null)
            {
                foreach (SpellLine sl in jsonCurrentSpells)
                {
                    this.dataGridView1.Rows.Add(sl.name, sl.path);
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs args)
        {
            if(args.ColumnIndex == 1) //path
            {
                this.lastPath = this.dataGridView1.Rows[args.RowIndex].Cells[1].Value.ToString();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "text files (*.txt)|*.text|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.dataGridView1.Rows[args.RowIndex].Cells[1].Value = openFileDialog1.FileName;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs args)
        {
            if (args.ColumnIndex == 1) //path
            {
                if (!File.Exists(this.dataGridView1.Rows[args.RowIndex].Cells[1].Value.ToString()))
                {
                    this.dataGridView1.Rows[args.RowIndex].Cells[1].Value = this.lastPath;
                }
            }
        }

        private void createNewSpellRow()
        {
            this.dataGridView1.Rows.Add(DataGridViewHelper.STRING_DEFAULT, "C:\\");
        }

        private void deleteRows(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                if (row.Selected)
                    grid.Rows.RemoveAt(row.Index);
            }
        }

        private void copyRows(DataGridView grid)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                if (row.Selected)
                {
                    DataGridViewRow newRow = DataGridViewHelper.CloneRowWithValues(row);
                    rows.Add(newRow);
                }
            }

            foreach (DataGridViewRow row in rows)
                grid.Rows.Add(row);
        }

        private void addNewRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.createNewSpellRow();
        }

        private void copySelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    this.copyRows(sourceControl as DataGridView);
                }
            }
        }

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    this.deleteRows(sourceControl as DataGridView);
                }
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            List<SpellLine> spells = new List<SpellLine>();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                string name = row.Cells[0].Value.ToString();
                string path = row.Cells[1].Value.ToString();
                spells.Add(new SpellLine(name, path));
            }
            jsonSpells = spells;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
