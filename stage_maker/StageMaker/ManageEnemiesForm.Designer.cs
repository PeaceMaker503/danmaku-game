namespace StageMaker
{
    partial class ManageEnemiesForm
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
            this.andNewEnemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TYPE_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WIDTH_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEIGHT_MANAGE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TYPE_MANAGE_ENEMIES,
            this.IMAGE_MANAGE_ENEMIES,
            this.X_MANAGE_ENEMIES,
            this.Y_MANAGE_ENEMIES,
            this.WIDTH_MANAGE_ENEMIES,
            this.HEIGHT_MANAGE_ENEMIES});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(8, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 297);
            this.dataGridView1.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.andNewEnemyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 26);
            // 
            // andNewEnemyToolStripMenuItem
            // 
            this.andNewEnemyToolStripMenuItem.Name = "andNewEnemyToolStripMenuItem";
            this.andNewEnemyToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.andNewEnemyToolStripMenuItem.Text = "Add new enemy type...";
            this.andNewEnemyToolStripMenuItem.Click += new System.EventHandler(this.addNewEnemyToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TYPE_MANAGE_ENEMIES
            // 
            this.TYPE_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TYPE_MANAGE_ENEMIES.HeaderText = "Type";
            this.TYPE_MANAGE_ENEMIES.Name = "TYPE_MANAGE_ENEMIES";
            this.TYPE_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // IMAGE_MANAGE_ENEMIES
            // 
            this.IMAGE_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMAGE_MANAGE_ENEMIES.HeaderText = "Image";
            this.IMAGE_MANAGE_ENEMIES.Name = "IMAGE_MANAGE_ENEMIES";
            this.IMAGE_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // X_MANAGE_ENEMIES
            // 
            this.X_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X_MANAGE_ENEMIES.HeaderText = "X";
            this.X_MANAGE_ENEMIES.Name = "X_MANAGE_ENEMIES";
            this.X_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // Y_MANAGE_ENEMIES
            // 
            this.Y_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y_MANAGE_ENEMIES.HeaderText = "Y";
            this.Y_MANAGE_ENEMIES.Name = "Y_MANAGE_ENEMIES";
            this.Y_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // WIDTH_MANAGE_ENEMIES
            // 
            this.WIDTH_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WIDTH_MANAGE_ENEMIES.HeaderText = "Width";
            this.WIDTH_MANAGE_ENEMIES.Name = "WIDTH_MANAGE_ENEMIES";
            this.WIDTH_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // HEIGHT_MANAGE_ENEMIES
            // 
            this.HEIGHT_MANAGE_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HEIGHT_MANAGE_ENEMIES.HeaderText = "Height";
            this.HEIGHT_MANAGE_ENEMIES.Name = "HEIGHT_MANAGE_ENEMIES";
            this.HEIGHT_MANAGE_ENEMIES.ReadOnly = true;
            // 
            // ManageEnemiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 343);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManageEnemiesForm";
            this.Text = "ManageEnemiesForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem andNewEnemyToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_MANAGE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_MANAGE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_MANAGE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_MANAGE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIDTH_MANAGE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEIGHT_MANAGE_ENEMIES;
    }
}