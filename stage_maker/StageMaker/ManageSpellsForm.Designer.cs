namespace StageMaker
{
    partial class ManageSpellsForm
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NAME_SPELL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATH_SPELL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewRowToolStripMenuItem,
            this.copySelectedRowsToolStripMenuItem,
            this.deleteSelectedRowsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 70);
            // 
            // addNewRowToolStripMenuItem
            // 
            this.addNewRowToolStripMenuItem.Name = "addNewRowToolStripMenuItem";
            this.addNewRowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.addNewRowToolStripMenuItem.Text = "Add new row";
            this.addNewRowToolStripMenuItem.Click += new System.EventHandler(this.addNewRowToolStripMenuItem_Click);
            // 
            // copySelectedRowsToolStripMenuItem
            // 
            this.copySelectedRowsToolStripMenuItem.Name = "copySelectedRowsToolStripMenuItem";
            this.copySelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.copySelectedRowsToolStripMenuItem.Text = "Copy selected rows";
            this.copySelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.copySelectedRowsToolStripMenuItem_Click);
            // 
            // deleteSelectedRowsToolStripMenuItem
            // 
            this.deleteSelectedRowsToolStripMenuItem.Name = "deleteSelectedRowsToolStripMenuItem";
            this.deleteSelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteSelectedRowsToolStripMenuItem.Text = "Delete selected rows";
            this.deleteSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedRowsToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NAME_SPELL,
            this.PATH_SPELL});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(8, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(537, 333);
            this.dataGridView1.TabIndex = 5;
            // 
            // NAME_SPELL
            // 
            this.NAME_SPELL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAME_SPELL.HeaderText = "Name";
            this.NAME_SPELL.Name = "NAME_SPELL";
            // 
            // PATH_SPELL
            // 
            this.PATH_SPELL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATH_SPELL.HeaderText = "Path";
            this.PATH_SPELL.Name = "PATH_SPELL";
            // 
            // ManageSpellsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 386);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ManageSpellsForm";
            this.Text = "Manage spells...";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedRowsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_SPELL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATH_SPELL;
    }
}