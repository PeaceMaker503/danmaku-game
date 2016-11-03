namespace StageMaker
{
    partial class bEnemyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TIME_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_DIRECTION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_SPEED_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewBehaviorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_MOVE,
            this.TARGET_ID_MOVE,
            this.DESTINATION_MOVE,
            this.DIRECTION_MOVE,
            this.SPEED_MOVE,
            this.FINAL_DIRECTION_MOVE,
            this.FINAL_SPEED_MOVE});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(695, 507);
            this.dataGridView1.TabIndex = 1;
            // 
            // TIME_MOVE
            // 
            this.TIME_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_MOVE.HeaderText = "Time";
            this.TIME_MOVE.Name = "TIME_MOVE";
            // 
            // TARGET_ID_MOVE
            // 
            this.TARGET_ID_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TARGET_ID_MOVE.HeaderText = "EnemyId";
            this.TARGET_ID_MOVE.Name = "TARGET_ID_MOVE";
            // 
            // DESTINATION_MOVE
            // 
            this.DESTINATION_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DESTINATION_MOVE.HeaderText = "Destination";
            this.DESTINATION_MOVE.Name = "DESTINATION_MOVE";
            // 
            // DIRECTION_MOVE
            // 
            this.DIRECTION_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DIRECTION_MOVE.HeaderText = "Direction";
            this.DIRECTION_MOVE.Name = "DIRECTION_MOVE";
            // 
            // SPEED_MOVE
            // 
            this.SPEED_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEED_MOVE.HeaderText = "Speed";
            this.SPEED_MOVE.Name = "SPEED_MOVE";
            // 
            // FINAL_DIRECTION_MOVE
            // 
            this.FINAL_DIRECTION_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_DIRECTION_MOVE.HeaderText = "FDirection";
            this.FINAL_DIRECTION_MOVE.Name = "FINAL_DIRECTION_MOVE";
            // 
            // FINAL_SPEED_MOVE
            // 
            this.FINAL_SPEED_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_SPEED_MOVE.HeaderText = "FSpeed";
            this.FINAL_SPEED_MOVE.Name = "FINAL_SPEED_MOVE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBehaviorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 26);
            // 
            // addNewBehaviorToolStripMenuItem
            // 
            this.addNewBehaviorToolStripMenuItem.Name = "addNewBehaviorToolStripMenuItem";
            this.addNewBehaviorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addNewBehaviorToolStripMenuItem.Text = "Add new behavior...";
            this.addNewBehaviorToolStripMenuItem.Click += new System.EventHandler(this.addNewBehaviorToolStripMenuItem_Click);
            // 
            // bEnemyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 507);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Name = "bEnemyForm";
            this.Text = "Enemy behaviors";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewBehaviorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_DIRECTION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_SPEED_MOVE;
    }
}