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
    public partial class iParticleForm : Form
    {
        private object lastCellValue;
        public long particleId { get; set; }

        public iParticleForm()
        {
            InitializeComponent();
            particleId = 0;
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(this.cellEndEdit_handler);
            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(this.cellBeginEdit_handler);
        }

        public DataGridView getGrid()
        {
            return this.dataGridView1;
        }

        private void addNewParticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(JsonFloat.Zero, particleId++, DataGridViewHelper.LONG_DEFAULT, DataGridViewHelper.EMPTY, JsonVector2.Zero, DataGridViewHelper.EMPTY, JsonFloat.Zero, DataGridViewHelper.STRING_DEFAULT);
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
                        if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ShootGridColumnsName.DESTINATION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ShootGridColumnsName.DIRECTION].Value = DataGridViewHelper.EMPTY;
                        }
                        else if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ShootGridColumnsName.DIRECTION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ShootGridColumnsName.DESTINATION].Value = DataGridViewHelper.EMPTY;
                        }

                        if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ShootGridColumnsName.TARGET_ID)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ShootGridColumnsName.POSITION].Value = DataGridViewHelper.EMPTY;
                        }
                        else if (grid.Columns[args.ColumnIndex].Name == DataGridViewHelper.ShootGridColumnsName.POSITION)
                        {
                            grid.Rows[args.RowIndex].Cells[DataGridViewHelper.ShootGridColumnsName.TARGET_ID].Value = DataGridViewHelper.EMPTY;
                        }
                    }
                    else
                        grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
                }
            }
            else
                grid.Rows[args.RowIndex].Cells[args.ColumnIndex].Value = this.lastCellValue;
        }
    }
}
