namespace StageMaker
{
    partial class iParticleForm
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
            this.addNewParticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TIME_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTICLE_ID_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTICLE_TYPE_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_SHOOT,
            this.PARTICLE_ID_SHOOT,
            this.TARGET_ID_SHOOT,
            this.POSITION_SHOOT,
            this.DESTINATION_SHOOT,
            this.DIRECTION_SHOOT,
            this.SPEED_SHOOT,
            this.PARTICLE_TYPE_SHOOT});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(725, 443);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewParticleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // addNewParticleToolStripMenuItem
            // 
            this.addNewParticleToolStripMenuItem.Name = "addNewParticleToolStripMenuItem";
            this.addNewParticleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addNewParticleToolStripMenuItem.Text = "Add new particle...";
            this.addNewParticleToolStripMenuItem.Click += new System.EventHandler(this.addNewParticleToolStripMenuItem_Click);
            // 
            // TIME_SHOOT
            // 
            this.TIME_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_SHOOT.HeaderText = "Time";
            this.TIME_SHOOT.Name = "TIME_SHOOT";
            // 
            // PARTICLE_ID_SHOOT
            // 
            this.PARTICLE_ID_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PARTICLE_ID_SHOOT.HeaderText = "ParticleId";
            this.PARTICLE_ID_SHOOT.Name = "PARTICLE_ID_SHOOT";
            this.PARTICLE_ID_SHOOT.ReadOnly = true;
            // 
            // TARGET_ID_SHOOT
            // 
            this.TARGET_ID_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TARGET_ID_SHOOT.HeaderText = "EnemyId";
            this.TARGET_ID_SHOOT.Name = "TARGET_ID_SHOOT";
            // 
            // POSITION_SHOOT
            // 
            this.POSITION_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POSITION_SHOOT.HeaderText = "Position";
            this.POSITION_SHOOT.Name = "POSITION_SHOOT";
            // 
            // DESTINATION_SHOOT
            // 
            this.DESTINATION_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DESTINATION_SHOOT.HeaderText = "Destination";
            this.DESTINATION_SHOOT.Name = "DESTINATION_SHOOT";
            // 
            // DIRECTION_SHOOT
            // 
            this.DIRECTION_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DIRECTION_SHOOT.HeaderText = "Direction";
            this.DIRECTION_SHOOT.Name = "DIRECTION_SHOOT";
            // 
            // SPEED_SHOOT
            // 
            this.SPEED_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEED_SHOOT.HeaderText = "Speed";
            this.SPEED_SHOOT.Name = "SPEED_SHOOT";
            // 
            // PARTICLE_TYPE_SHOOT
            // 
            this.PARTICLE_TYPE_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PARTICLE_TYPE_SHOOT.HeaderText = "ParticleType";
            this.PARTICLE_TYPE_SHOOT.Name = "PARTICLE_TYPE_SHOOT";
            // 
            // iParticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 443);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Name = "iParticleForm";
            this.Text = "Instantiate particles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewParticleToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTICLE_ID_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTICLE_TYPE_SHOOT;
    }
}