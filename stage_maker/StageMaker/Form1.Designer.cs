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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TIME_CREATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID_CREATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ID_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEALTH_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_DIRECTION_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_SPEED_ENEMIES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTICLE_ID_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTICLE_TYPE_SHOOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGET_ID_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESTINATION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SPEED_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_DIRECTION_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_SPEED_MOVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1434, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.savreToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // savreToolStripMenuItem
            // 
            this.savreToolStripMenuItem.Name = "savreToolStripMenuItem";
            this.savreToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.savreToolStripMenuItem.Text = "Save as...";
            this.savreToolStripMenuItem.Click += new System.EventHandler(this.savreToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jsonToolStripMenuItem1});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
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
            this.jsonToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // jsonToolStripMenuItem
            // 
            this.jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            this.jsonToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.jsonToolStripMenuItem.Text = ".json";
            this.jsonToolStripMenuItem.Click += new System.EventHandler(this.jsonToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewRowToolStripMenuItem,
            this.deleteSelectedRowsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addNewRowToolStripMenuItem
            // 
            this.addNewRowToolStripMenuItem.Name = "addNewRowToolStripMenuItem";
            this.addNewRowToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.addNewRowToolStripMenuItem.Text = "Add new enemy";
            this.addNewRowToolStripMenuItem.Click += new System.EventHandler(this.addNewRowToolStripMenuItem_Click);
            // 
            // deleteSelectedRowsToolStripMenuItem
            // 
            this.deleteSelectedRowsToolStripMenuItem.Name = "deleteSelectedRowsToolStripMenuItem";
            this.deleteSelectedRowsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.deleteSelectedRowsToolStripMenuItem.Text = "Delete selected enemies";
            this.deleteSelectedRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedRowsToolStripMenuItem_Click);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(819, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 721);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_CREATE,
            this.TARGET_ID_CREATE});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(599, 689);
            this.dataGridView2.TabIndex = 0;
            // 
            // TIME_CREATE
            // 
            this.TIME_CREATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_CREATE.HeaderText = "Time";
            this.TIME_CREATE.Name = "TIME_CREATE";
            // 
            // TARGET_ID_CREATE
            // 
            this.TARGET_ID_CREATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TARGET_ID_CREATE.HeaderText = "TargetId";
            this.TARGET_ID_CREATE.Name = "TARGET_ID_CREATE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRowToolStripMenuItem,
            this.deleteRowsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 48);
            // 
            // newRowToolStripMenuItem
            // 
            this.newRowToolStripMenuItem.Name = "newRowToolStripMenuItem";
            this.newRowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newRowToolStripMenuItem.Text = "Add new row";
            this.newRowToolStripMenuItem.Click += new System.EventHandler(this.newRowToolStripMenuItem_Click);
            // 
            // deleteRowsToolStripMenuItem
            // 
            this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
            this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteRowsToolStripMenuItem.Text = "Delete selected rows";
            this.deleteRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteRowsToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shoot";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_SHOOT,
            this.TARGET_ID_SHOOT,
            this.PARTICLE_ID_SHOOT,
            this.DESTINATION_SHOOT,
            this.DIRECTION_SHOOT,
            this.SPEED_SHOOT,
            this.PARTICLE_TYPE_SHOOT});
            this.dataGridView3.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView3.Size = new System.Drawing.Size(599, 689);
            this.dataGridView3.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(605, 695);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Move";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIME_MOVE,
            this.TARGET_ID_MOVE,
            this.DESTINATION_MOVE,
            this.DIRECTION_MOVE,
            this.SPEED_MOVE,
            this.FINAL_DIRECTION_MOVE,
            this.FINAL_SPEED_MOVE});
            this.dataGridView4.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView4.Size = new System.Drawing.Size(599, 689);
            this.dataGridView4.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(787, 689);
            this.dataGridView1.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(12, 27);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(801, 721);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(793, 695);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Enemies";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ID_ENEMIES
            // 
            this.ID_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID_ENEMIES.HeaderText = "Id";
            this.ID_ENEMIES.Name = "ID_ENEMIES";
            this.ID_ENEMIES.ReadOnly = true;
            this.ID_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.FINAL_DIRECTION_ENEMIES.HeaderText = "FinalDirection";
            this.FINAL_DIRECTION_ENEMIES.Name = "FINAL_DIRECTION_ENEMIES";
            this.FINAL_DIRECTION_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FINAL_SPEED_ENEMIES
            // 
            this.FINAL_SPEED_ENEMIES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_SPEED_ENEMIES.HeaderText = "FinalSpeed";
            this.FINAL_SPEED_ENEMIES.Name = "FINAL_SPEED_ENEMIES";
            this.FINAL_SPEED_ENEMIES.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TIME_SHOOT
            // 
            this.TIME_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_SHOOT.HeaderText = "Time";
            this.TIME_SHOOT.Name = "TIME_SHOOT";
            // 
            // TARGET_ID_SHOOT
            // 
            this.TARGET_ID_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TARGET_ID_SHOOT.HeaderText = "TargetId";
            this.TARGET_ID_SHOOT.Name = "TARGET_ID_SHOOT";
            // 
            // PARTICLE_ID_SHOOT
            // 
            this.PARTICLE_ID_SHOOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PARTICLE_ID_SHOOT.HeaderText = "ParticleId";
            this.PARTICLE_ID_SHOOT.Name = "PARTICLE_ID_SHOOT";
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
            // TIME_MOVE
            // 
            this.TIME_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIME_MOVE.HeaderText = "Time";
            this.TIME_MOVE.Name = "TIME_MOVE";
            // 
            // TARGET_ID_MOVE
            // 
            this.TARGET_ID_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TARGET_ID_MOVE.HeaderText = "TargetId";
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
            this.FINAL_DIRECTION_MOVE.HeaderText = "FinalDirection";
            this.FINAL_DIRECTION_MOVE.Name = "FINAL_DIRECTION_MOVE";
            // 
            // FINAL_SPEED_MOVE
            // 
            this.FINAL_SPEED_MOVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FINAL_SPEED_MOVE.HeaderText = "FinalSpeed";
            this.FINAL_SPEED_MOVE.Name = "FINAL_SPEED_MOVE";
            // 
            // StageMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 754);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StageMaker";
            this.Text = "StageMaker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedRowsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_CREATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID_CREATE;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savreToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEALTH_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_DIRECTION_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_SPEED_ENEMIES;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTICLE_ID_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTICLE_TYPE_SHOOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARGET_ID_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESTINATION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SPEED_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_DIRECTION_MOVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_SPEED_MOVE;
    }
}

