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
    public partial class bParticleForm : Form
    {
        private object lastCellValue;

        public bParticleForm()
        {
            InitializeComponent();
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
        }

        public DataGridView getGrid()
        {
            return this.dataGridView1;
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
                        if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ParticleMoveColumnsName.DESTINATION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ParticleMoveColumnsName.DIRECTION].Value = DataGridViewHelper.EMPTY;
                        }
                        else if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ParticleMoveColumnsName.DIRECTION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ParticleMoveColumnsName.DESTINATION].Value = DataGridViewHelper.EMPTY;
                        }
                    }
                    else
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
                }
                else
                    grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
            }
        }
        
        private void addNewBehaviorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(JsonFloat.Zero, DataGridViewHelper.LONG_DEFAULT, JsonVector2.Zero, DataGridViewHelper.EMPTY, JsonFloat.Zero);
        }
    }
}
