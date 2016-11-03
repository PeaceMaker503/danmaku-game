namespace StageMaker
{
    partial class StageMaker
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEnemiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSpellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSpellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(377, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // launchToolStripMenuItem
            // 
            this.launchToolStripMenuItem.Name = "launchToolStripMenuItem";
            this.launchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.launchToolStripMenuItem.Text = "Launch...";
            this.launchToolStripMenuItem.Click += new System.EventHandler(this.launchToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jsonToolStripMenuItem1});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // jsonToolStripMenuItem1
            // 
            this.jsonToolStripMenuItem1.Name = "jsonToolStripMenuItem1";
            this.jsonToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.jsonToolStripMenuItem1.Text = ".json";
            this.jsonToolStripMenuItem1.Click += new System.EventHandler(this.jsonToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jsonToolStripMenuItem,
            this.configjsonToolStripMenuItem,
            this.allToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // jsonToolStripMenuItem
            // 
            this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            this.jsonToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.jsonToolStripMenuItem.Text = "script.json";
            this.jsonToolStripMenuItem.Click += new System.EventHandler(this.jsonToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageEnemiesToolStripMenuItem,
            this.manageSpellsToolStripMenuItem,
            this.addNewSpellToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // manageEnemiesToolStripMenuItem
            // 
            this.manageEnemiesToolStripMenuItem.Name = "manageEnemiesToolStripMenuItem";
            this.manageEnemiesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.manageEnemiesToolStripMenuItem.Text = "Manage enemies...";
            this.manageEnemiesToolStripMenuItem.Click += new System.EventHandler(this.manageEnemiesToolStripMenuItem_Click);
            // 
            // manageSpellsToolStripMenuItem
            // 
            this.manageSpellsToolStripMenuItem.Name = "manageSpellsToolStripMenuItem";
            this.manageSpellsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.manageSpellsToolStripMenuItem.Text = "Manage spells...";
            this.manageSpellsToolStripMenuItem.Click += new System.EventHandler(this.manageSpellsToolStripMenuItem_Click);
            // 
            // addNewSpellToolStripMenuItem
            // 
            this.addNewSpellToolStripMenuItem.Name = "addNewSpellToolStripMenuItem";
            this.addNewSpellToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addNewSpellToolStripMenuItem.Text = "Instantiate new spell...";
            this.addNewSpellToolStripMenuItem.Click += new System.EventHandler(this.addNewSpellToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRowToolStripMenuItem,
            this.copySelectedRowsToolStripMenuItem,
            this.deleteRowsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 70);
            // 
            // newRowToolStripMenuItem
            // 
            this.newRowToolStripMenuItem.Name = "newRowToolStripMenuItem";
            this.newRowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newRowToolStripMenuItem.Text = "Add new row";
            // 
            // copySelectedRowsToolStripMenuItem
            // 
            this.copySelectedRowsToolStripMenuItem.Name = "copySelectedRowsToolStripMenuItem";
            this.copySelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.copySelectedRowsToolStripMenuItem.Text = "Copy selected rows";
            // 
            // deleteRowsToolStripMenuItem
            // 
            this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
            this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteRowsToolStripMenuItem.Text = "Delete selected rows";
            // 
            // configjsonToolStripMenuItem
            // 
            this.configjsonToolStripMenuItem.Name = "configjsonToolStripMenuItem";
            this.configjsonToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configjsonToolStripMenuItem.Text = "config.json";
            this.configjsonToolStripMenuItem.Click += new System.EventHandler(this.configjsonToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allToolStripMenuItem.Text = "all files";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // StageMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 180);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StageMaker";
            this.Text = "StageMaker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSpellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSpellsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageEnemiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configjsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
    }
}

