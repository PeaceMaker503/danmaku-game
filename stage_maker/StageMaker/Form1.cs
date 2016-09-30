using Microsoft.Xna.Framework;
using Newtonsoft.Json;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StageMaker
{
    public partial class StageMaker : Form
    {
        private enum DataType { ULONG, FLOAT, VECTOR2, STRING };
        private object lastCellValue;
        public static readonly ulong ULONG_ZERO = 0;
        public static readonly string NO_TYPE = "-";

        public sealed class EnemiesGridColumnsName
        {
            public static readonly string ID = "ID_ENEMIES";
            public static readonly string TYPE = "TYPE_ENEMIES";
            public static readonly string HEALTH = "HEALTH_ENEMIES";
            public static readonly string POSITION = "POSITION_ENEMIES";
            public static readonly string DESTINATION = "DESTINATION_ENEMIES";
            public static readonly string DIRECTION = "DIRECTION_ENEMIES";
            public static readonly string SPEED = "SPEED_ENEMIES";
            public static readonly string FINAL_DIRECTION = "FINAL_DIRECTION_ENEMIES";
            public static readonly string FINAL_SPEED = "FINAL_SPEED_ENEMIES";
        }

        public sealed class CreateGridColumnsName
        {
            public static readonly string TIME = "TIME_CREATE";
            public static readonly string TARGET_ID = "TARGET_ID_CREATE";
        }

        public sealed class ShootGridColumnsName
        {
            public static readonly string TIME = "TIME_SHOOT";
            public static readonly string TARGET_ID = "TARGET_ID_SHOOT";
            public static readonly string DESTINATION = "DESTINATION_SHOOT";
            public static readonly string DIRECTION = "DIRECTION_SHOOT";
            public static readonly string SPEED = "SPEED_SHOOT";
            public static readonly string PARTICLE_TYPE = "PARTICLE_TYPE_SHOOT";
            public static readonly string PARTICLE_ID = "PARTICLE_ID_SHOOT";
        }

        public sealed class MoveGridColumnsName
        {
            public static readonly string TIME = "TIME_MOVE";
            public static readonly string TARGET_ID = "TARGET_ID_MOVE";
            public static readonly string DESTINATION = "DESTINATION_MOVE";
            public static readonly string DIRECTION = "DIRECTION_MOVE";
            public static readonly string SPEED = "SPEED_MOVE";
            public static readonly string FINAL_DIRECTION = "FINAL_DIRECTION_MOVE";
            public static readonly string FINAL_SPEED = "FINAL_SPEED_MOVE";
        }

        private readonly Dictionary<string, DataType> COLUMNS_TYPE = new Dictionary<string, DataType> {

            { EnemiesGridColumnsName.ID, DataType.ULONG },
            { EnemiesGridColumnsName.TYPE, DataType.STRING },
            { EnemiesGridColumnsName.HEALTH, DataType.ULONG },
            { EnemiesGridColumnsName.POSITION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.DIRECTION,  DataType.VECTOR2},
            { EnemiesGridColumnsName.SPEED, DataType.FLOAT },
            { EnemiesGridColumnsName.FINAL_DIRECTION, DataType.VECTOR2 },
            { EnemiesGridColumnsName.FINAL_SPEED, DataType.FLOAT },
            { CreateGridColumnsName.TIME, DataType.FLOAT },
            { CreateGridColumnsName.TARGET_ID, DataType.ULONG },
            { ShootGridColumnsName.TIME, DataType.FLOAT },
            { ShootGridColumnsName.TARGET_ID, DataType.ULONG },
            { ShootGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { ShootGridColumnsName.DIRECTION, DataType.VECTOR2 },
            { ShootGridColumnsName.SPEED, DataType.FLOAT },
            { ShootGridColumnsName.PARTICLE_TYPE, DataType.STRING },
            { ShootGridColumnsName.PARTICLE_ID, DataType.ULONG },
            { MoveGridColumnsName.TIME, DataType.FLOAT },
            { MoveGridColumnsName.TARGET_ID, DataType.ULONG },
            { MoveGridColumnsName.DESTINATION, DataType.VECTOR2 },
            { MoveGridColumnsName.DIRECTION, DataType.VECTOR2 },
            { MoveGridColumnsName.SPEED, DataType.FLOAT },
            { MoveGridColumnsName.FINAL_DIRECTION, DataType.VECTOR2 },
            { MoveGridColumnsName.FINAL_SPEED, DataType.FLOAT },

        };

        private ulong _idEnemy;

        public StageMaker()
        {
            InitializeComponent();
            _idEnemy = 0;

            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView2.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView3.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView4.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView2.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView3.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
            this.dataGridView4.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
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

            if(grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value == null)
            {
                grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = defaultField(columnName);
            }
            else if(grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value is string)
            {
                string value = (string)grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
                object newFormattedValue = formatField(columnName, value);
                if (newFormattedValue != null)
                    grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = newFormattedValue;
                else
                    grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
            }
        }

        private object defaultField(string column)
        {
            object result = null;
            if (COLUMNS_TYPE[column] == DataType.ULONG)
            {
                result = ULONG_ZERO;
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
                result = NO_TYPE;
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
                    if (COLUMNS_TYPE[column] == DataType.ULONG)
                    {
                        ulong ul;
                        if (ulong.TryParse(value, out ul))
                            result = ul;
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
                            result = JsonConvert.DeserializeObject<JsonVector2>(value);
                    }
                    else if (COLUMNS_TYPE[column] == DataType.STRING)
                    {
                        result = value;
                    }
                }
                catch (Exception)
                {
                    
                }
            }

            return result;
        }

        private void createNewEnemyRow()
        {
            this.dataGridView1.Rows.Add(this._idEnemy, NO_TYPE, ULONG_ZERO, JsonVector2.Zero, JsonVector2.Zero, JsonVector2.Zero, JsonFloat.Zero, JsonVector2.Zero, JsonFloat.Zero);
            this._idEnemy++;
        }

        private void createNewCreateEvent()
        {
            this.dataGridView2.Rows.Add(JsonFloat.Zero, ULONG_ZERO);
        }

        private void createNewShootEvent()
        {
            this.dataGridView3.Rows.Add(JsonFloat.Zero, ULONG_ZERO, ULONG_ZERO, JsonVector2.Zero, JsonVector2.Zero, JsonFloat.Zero, NO_TYPE);
        }

        private void createNewMoveEvent()
        {
            this.dataGridView4.Rows.Add(JsonFloat.Zero, ULONG_ZERO, JsonVector2.Zero, JsonVector2.Zero, JsonFloat.Zero, JsonVector2.Zero, JsonFloat.Zero);
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
                    this._idEnemy = JsonGridConverter.importJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, openFileDialog1.FileName);
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
                    JsonGridConverter.exportJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, saveFileDialog1.FileName);
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
        }

        private void deleteRows(DataGridView grid)
        {
            foreach (DataGridViewCell oneCell in grid.SelectedCells)
            {
                if (oneCell.Selected)
                    grid.Rows.RemoveAt(oneCell.RowIndex);
            }
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
                    JsonGridConverter.saveJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, saveFileDialog1.FileName);
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
                    this._idEnemy = JsonGridConverter.openJson(this.dataGridView1, this.dataGridView2, this.dataGridView3, this.dataGridView4, openFileDialog1.FileName);
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
    }
}
