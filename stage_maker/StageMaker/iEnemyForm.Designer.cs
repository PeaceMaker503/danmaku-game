namespace StageMaker
{
    partial class iEnemyForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewEnemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TIME_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEALTH_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_DIRECTION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_SPEED_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_ENEMIES,
            this.ID_ENEMIES,
            this.TYPE_ENEMIES,
            this.HEALTH_ENEMIES,
            this.POSITION_ENEMIES,
            this.DESTINATION_ENEMIES,
            this.DIRECTION_ENEMIES,
            this.SPEED_ENEMIES,
            this.FINAL_DIRECTION_ENEMIES,
            this.FINAL_SPEED_ENEMIES});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(833, 467);
            this.dataGridView1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEnemyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 26);
            // 
            // addNewEnemyToolStripMenuItem
            // 
            this.addNewEnemyToolStripMenuItem.Name = "addNewEnemyToolStripMenuItem";
            this.addNewEnemyToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addNewEnemyToolStripMenuItem.Text = "Add new enemy...";
            this.addNewEnemyToolStripMenuItem.Click += new System.EventHandler(this.addNewEnemyToolStripMenuItem_Click);
            // 
            // TIME_ENEMIES
            // 
            this.TIME_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_ENEMIES.HeaderText = "Time";
            this.TIME_ENEMIES.Name = "TIME_ENEMIES";
            // 
            // ID_ENEMIES
            // 
            this.ID_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_ENEMIES.HeaderText = "EnemyId";
            this.ID_ENEMIES.Name = "ID_ENEMIES";
            this.ID_ENEMIES.ReadOnly = true;
            // 
            // TYPE_ENEMIES
            // 
            this.TYPE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TYPE_ENEMIES.HeaderText = "Type";
            this.TYPE_ENEMIES.Name = "TYPE_ENEMIES";
            this.TYPE_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HEALTH_ENEMIES
            // 
            this.HEALTH_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HEALTH_ENEMIES.HeaderText = "Health";
            this.HEALTH_ENEMIES.Name = "HEALTH_ENEMIES";
            this.HEALTH_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // POSITION_ENEMIES
            // 
            this.POSITION_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POSITION_ENEMIES.HeaderText = "Position";
            this.POSITION_ENEMIES.Name = "POSITION_ENEMIES";
            this.POSITION_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DESTINATION_ENEMIES
            // 
            this.DESTINATION_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DESTINATION_ENEMIES.HeaderText = "Destination";
            this.DESTINATION_ENEMIES.Name = "DESTINATION_ENEMIES";
            this.DESTINATION_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DIRECTION_ENEMIES
            // 
            this.DIRECTION_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DIRECTION_ENEMIES.HeaderText = "Direction";
            this.DIRECTION_ENEMIES.Name = "DIRECTION_ENEMIES";
            // 
            // SPEED_ENEMIES
            // 
            this.SPEED_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEED_ENEMIES.HeaderText = "Speed";
            this.SPEED_ENEMIES.Name = "SPEED_ENEMIES";
            this.SPEED_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FINAL_DIRECTION_ENEMIES
            // 
            this.FINAL_DIRECTION_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_DIRECTION_ENEMIES.HeaderText = "FDirection";
            this.FINAL_DIRECTION_ENEMIES.Name = "FINAL_DIRECTION_ENEMIES";
            this.FINAL_DIRECTION_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FINAL_SPEED_ENEMIES
            // 
            this.FINAL_SPEED_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_SPEED_ENEMIES.HeaderText = "FSpeed";
            this.FINAL_SPEED_ENEMIES.Name = "FINAL_SPEED_ENEMIES";
            this.FINAL_SPEED_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // iEnemyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 467);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Name = "iEnemyForm";
            this.Text = "Instantiate enemies";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewEnemyToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEALTH_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_DIRECTION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_SPEED_ENEMIES;
    }
}