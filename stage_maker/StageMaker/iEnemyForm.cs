using StageMaker.models;
using StageMaker.utils;
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
    public partial class iEnemyForm : Form
    {
        private object lastCellValue;
        public long enemyId { get; set; }
        
        public DataGridView getGrid()
        {
            return this.dataGridView1;
        }

        public iEnemyForm()
        {
            InitializeComponent();
            this.enemyId = 0;
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
        }

        private void addNewEnemyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(JsonFloat.Zero, this.enemyId++, DataGridViewHelper.STRING_DEFAULT, DataGridViewHelper.LONG_DEFAULT, JsonVector2.Zero, JsonVector2.Zero, DataGridViewHelper.EMPTY, JsonFloat.Zero, DataGridViewHelper.EMPTY, DataGridViewHelper.EMPTY);
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

            if (grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value != DataGridViewHelper.EMPTY)
            {
                if (grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value is string)
                {
                    string value = (string)grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value;
                    object newFormattedValue = DataGridViewHelper.formatField(columnName, value);
                    if (newFormattedValue != DataGridViewHelper.BAD_FORMAT)
                    {
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = newFormattedValue;
                        if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.EnemiesGridColumnsName.DESTINATION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.EnemiesGridColumnsName.DIRECTION].Value = DataGridViewHelper.EMPTY;
                        }
                        else if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.EnemiesGridColumnsName.DIRECTION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.EnemiesGridColumnsName.DESTINATION].Value = DataGridViewHelper.EMPTY;
                        }
                    }
                    else
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
                }
                else
                    grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
            }
        }
    }
}
