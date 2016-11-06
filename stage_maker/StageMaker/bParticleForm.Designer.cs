namespace StageMaker
{
    partial class bParticleForm
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
            this.addNewBehaviorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TIME_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTICLE_ID_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_PARTICLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_PARTICLE,
            this.PARTICLE_ID_PARTICLE,
            this.POSITION_PARTICLE,
            this.DESTINATION_PARTICLE,
            this.DIRECTION_PARTICLE,
            this.SPEED_PARTICLE});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(763, 542);
            this.dataGridView1.TabIndex = 2;
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
            // TIME_PARTICLE
            // 
            this.TIME_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_PARTICLE.HeaderText = "Time";
            this.TIME_PARTICLE.Name = "TIME_PARTICLE";
            // 
            // PARTICLE_ID_PARTICLE
            // 
            this.PARTICLE_ID_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PARTICLE_ID_PARTICLE.HeaderText = "ParticleId";
            this.PARTICLE_ID_PARTICLE.Name = "PARTICLE_ID_PARTICLE";
            // 
            // POSITION_PARTICLE
            // 
            this.POSITION_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POSITION_PARTICLE.HeaderText = "Position";
            this.POSITION_PARTICLE.Name = "POSITION_PARTICLE";
            // 
            // DESTINATION_PARTICLE
            // 
            this.DESTINATION_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DESTINATION_PARTICLE.HeaderText = "Destination";
            this.DESTINATION_PARTICLE.Name = "DESTINATION_PARTICLE";
            // 
            // DIRECTION_PARTICLE
            // 
            this.DIRECTION_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DIRECTION_PARTICLE.HeaderText = "Direction";
            this.DIRECTION_PARTICLE.Name = "DIRECTION_PARTICLE";
            // 
            // SPEED_PARTICLE
            // 
            this.SPEED_PARTICLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SPEED_PARTICLE.HeaderText = "Speed";
            this.SPEED_PARTICLE.Name = "SPEED_PARTICLE";
            // 
            // bParticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 542);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Name = "bParticleForm";
            this.Text = "Particle behaviors";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewBehaviorToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_PARTICLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTICLE_ID_PARTICLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION_PARTICLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_PARTICLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_PARTICLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_PARTICLE;
    }
}