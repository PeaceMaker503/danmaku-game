using Newtonsoft.Json;
using StageMaker.models;
using StageMaker.spell_maker;
using StageMaker.spell_maker.evaluators;
using StageMaker.utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static StageMaker.utils.DataGridViewHelper;

namespace StageMaker
{
    public partial class StageMaker : Form
    {
        private object lastCellValue;
        private long enemyId;
        private long particleId;
        private List<SpellLine> SPELLS_PATH = new List<SpellLine> {
            new SpellLine("CIRCLE", @"spells\circle.sp"),
            new SpellLine("SPELL_TEST", @"spells\spell.sp")
        };

        public StageMaker()
        {
            InitializeComponent();
            enemyId = 0;
            particleId = 0;

            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView2.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView3.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView4.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView5.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView2.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView3.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView4.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView5.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);


        }

        private void cellBeginEdit_handler(object sender, DataGridViewCellCancelEventArgs args)
        {
            DataGridView grid = sender as DataGridView;
            this.lastCellValue = grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
        }

        private void cellEndEdit_handler(object sender, DataGridViewCellEventArgs args)
        {
            DataGridView grid = sender as DataGridView;
            string columnName = grid.Columns[args.ColumnIndex].Name;

            if (grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value != null)
            {
                if (grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value is string)
                {
                    string value = (string)grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
                    object newFormattedValue = formatField(columnName, value);
                    if (newFormattedValue != null)
                    {
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = newFormattedValue;
                        if (grid == dataGridView1)
                        {
                            if (grid.Columns[args.ColumnIndex].Name == EnemiesGridColumnsName.DESTINATION)
                            {
                                grid.Rows[args.RowIndex].Cells[EnemiesGridColumnsName.DIRECTION].Value = null;
                            }
                            else if (grid.Columns[args.ColumnIndex].Name == EnemiesGridColumnsName.DIRECTION)
                            {
                                grid.Rows[args.RowIndex].Cells[EnemiesGridColumnsName.DESTINATION].Value = null;
                            }
                        }
                        else if (grid == dataGridView3)
                        {
                            if (grid.Columns[args.ColumnIndex].Name == ShootGridColumnsName.DESTINATION)
                            {
                                grid.Rows[args.RowIndex].Cells[ShootGridColumnsName.DIRECTION].Value = null;
                            }
                            else if (grid.Columns[args.ColumnIndex].Name == ShootGridColumnsName.DIRECTION)
                            {
                                grid.Rows[args.RowIndex].Cells[ShootGridColumnsName.DESTINATION].Value = null;
                            }

                            if (grid.Columns[args.ColumnIndex].Name == ShootGridColumnsName.TARGET_ID)
                            {
                                grid.Rows[args.RowIndex].Cells[ShootGridColumnsName.POSITION].Value = null;
                            }
                            else if (grid.Columns[args.ColumnIndex].Name == ShootGridColumnsName.POSITION)
                            {
                                grid.Rows[args.RowIndex].Cells[ShootGridColumnsName.TARGET_ID].Value = null;
                            }
                        }
                        else if (grid == dataGridView4)
                        {
                            if (grid.Columns[args.ColumnIndex].Name == MoveGridColumnsName.DESTINATION)
                            {
                                grid.Rows[args.RowIndex].Cells[MoveGridColumnsName.DIRECTION].Value = null;
                            }
                            else if (grid.Columns[args.ColumnIndex].Name == MoveGridColumnsName.DIRECTION)
                            {
                                grid.Rows[args.RowIndex].Cells[MoveGridColumnsName.DESTINATION].Value = null;
                            }
                        }
                        else if (grid == dataGridView5)
                        {
                            if (grid.Columns[args.ColumnIndex].Name == ParticleMoveColumnsName.DESTINATION)
                            {
                                grid.Rows[args.RowIndex].Cells[ParticleMoveColumnsName.DIRECTION].Value = null;
                            }
                            else if (grid.Columns[args.ColumnIndex].Name == ParticleMoveColumnsName.DIRECTION)
                            {
                                grid.Rows[args.RowIndex].Cells[ParticleMoveColumnsName.DESTINATION].Value = null;
                            }
                        }
                    }
                    else
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
                }
            }
            else
                grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
        }

        private object defaultField(string column)
        {
            object result = null;
            if (COLUMNS_TYPE[column] == DataType.ID)
            {
                result = LONG_DEFAULT;
            }
            else if (COLUMNS_TYPE[column] == DataType.FLOAT)
            {
                result = JsonFloat.Zero;
            }
            else if (COLUMNS_TYPE[column] == DataType.VECTOR2)
            {
                result = JsonVector2.Zero;
            }
            else if (COLUMNS_TYPE[column] == DataType.STRING)
            {
                result = STRING_DEFAULT;
            }
            return result;
        }

        private object formatField(string column, string value)
        {
            object result = null;
            if (value != null)
            {
                value = value.Trim();
                try
                {
                    if (COLUMNS_TYPE[column] == DataType.ID)
                    {
                        long l;
                        if (long.TryParse(value, out l) && l >= 0)
                            result = l;
                    }
                    else if (COLUMNS_TYPE[column] == DataType.FLOAT)
                    {
                        float f = JsonConvert.DeserializeObject<float>(value);
                        if (f >= 0f)
                            result = new JsonFloat(f);
                    }
                    else if (COLUMNS_TYPE[column] == DataType.VECTOR2)
                    {
                        if (value.StartsWith("{") && value.EndsWith("}"))
                        {
                            result = JsonVector2.convertString(value).ToString();
                        }
                        else
                            throw new Exception();
                    }
                    else if (COLUMNS_TYPE[column] == DataType.STRING)
                    {
                        result = value;
                    }
                }
                catch (Exception)
                {
                    if (COLUMNS_TYPE[column] == DataType.VECTOR2)
                    {
                        if (ValueEvaluator.isRuntimeValue(value))
                        {
                            result = value;
                        }
                    }
                }
            }

            return result;
        }

        private void createNewEnemyRow()
        {
            this.dataGridView1.Rows.Add(this.enemyId, STRING_DEFAULT, LONG_DEFAULT, JsonVector2.Zero, JsonVector2.Zero, null, JsonFloat.Zero, null, null);
            this.enemyId++;
        }

        private void createNewCreateEvent()
        {
            this.dataGridView2.Rows.Add(JsonFloat.Zero, LONG_DEFAULT);
        }

        private void createNewShootEvent()
        {
            this.dataGridView3.Rows.Add(JsonFloat.Zero, particleId++, LONG_DEFAULT, null, JsonVector2.Zero, null, JsonFloat.Zero, STRING_DEFAULT);
        }

        private void createNewMoveEvent()
        {
            this.dataGridView4.Rows.Add(JsonFloat.Zero, LONG_DEFAULT, JsonVector2.Zero, null, JsonFloat.Zero, null, null);
        }

        private void createNewParticleMoveEvent()
        {
            this.dataGridView5.Rows.Add(JsonFloat.Zero, LONG_DEFAULT, JsonVector2.Zero, null, JsonFloat.Zero);
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
                    this.enemyId = JsonGridConverter.importJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, this.dataGridView5, openFileDialog1.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement importé", "Erreur");
                }
            }
        }

        
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e) //export
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JsonGridConverter.exportJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, this.dataGridView5, saveFileDialog1.FileName);
                    MessageBox.Show("The file has been successfully exported.", "Export to json.");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement exporté", "Erreur");
                }
            }
        }

        private void newRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    this.addRow(sourceControl as DataGridView);
                }
            }
        }

        private void addNewRowToolStripMenuItem_Click(object sender, EventArgs e) //edit menu
        {
            this.addRow(dataGridView1);
        }

        private void deleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e) //edit menu
        {
            this.deleteRows(dataGridView1);
        }

        private void addRow(DataGridView grid)
        {
            if(grid == dataGridView1)
            {
                this.createNewEnemyRow();
            }
            else if(grid == dataGridView2)
            {
                this.createNewCreateEvent();
            }
            else if(grid == dataGridView3)
            {
                this.createNewShootEvent();
            }
            else if(grid == dataGridView4)
            {
                this.createNewMoveEvent();
            }
            else if(grid == dataGridView5)
            {
                this.createNewParticleMoveEvent();
            }
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
                    if (grid == dataGridView1)
                        newRow.Cells[0].Value = this.enemyId++;
                    else if (grid == dataGridView3)
                        newRow.Cells[1].Value = this.particleId++;

                    rows.Add(newRow);
                }
            }

            if(grid != dataGridView1)
                rows.Reverse();

            foreach (DataGridViewRow row in rows)
                grid.Rows.Add(row);


        }

        private void savreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "c:\\";
            saveFileDialog1.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JsonGridConverter.saveJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, this.dataGridView5, this.SPELLS_PATH, saveFileDialog1.FileName);
                    MessageBox.Show("The file has been successfully saved.", "Save file.");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement sauvegardé", "Erreur");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
                    OpenJsonResults results = JsonGridConverter.openJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, this.dataGridView5, openFileDialog1.FileName);
                    this.enemyId = results.idEnemy;
                    this.SPELLS_PATH = results.spells;
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Le fichier n'a pas pu être correctement ouvert", "Erreur");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void copySelectedEnemiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyRows(sender as DataGridView);
        }

        private void addNewSpellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(dataGridView3, dataGridView5, particleId, this.SPELLS_PATH);
            DialogResult r = f.ShowDialog();

            if(r == DialogResult.OK)
            {
                particleId = f.particleId;
                MessageBox.Show(@"Le spell a été correctement instancié.", "Message.");
            }
            else
            {
                MessageBox.Show(@"Le spell n'a pas pu être correctement instancié.", "Message.");
            }
        }

        private void manageSpellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(this.SPELLS_PATH);
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                this.SPELLS_PATH = f.jsonSpells;
                MessageBox.Show(@"Les modifications ont bien été sauvegardées.", "Message.");
            }
            else
            {
                MessageBox.Show(@"Les modifications n'ont pas été sauvegardées.", "Message.");
            }
        }
    }
}
