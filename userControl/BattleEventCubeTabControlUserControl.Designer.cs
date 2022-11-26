
namespace 侠之道mod制作器
{
    partial class BattleEventCubeTabControlUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.battleEventCubeTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BattleEventCubeListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.battleEventCubeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newBattleEventCubeButton = new System.Windows.Forms.Button();
            this.editBattleEventCubeButton = new System.Windows.Forms.Button();
            this.showOriginalBattleEventCubeCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteBattleEventCubeButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.battleEventCubeTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.battleEventCubeContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // battleEventCubeTabPage
            // 
            this.battleEventCubeTabPage.Controls.Add(this.panel2);
            this.battleEventCubeTabPage.Controls.Add(this.panel1);
            this.battleEventCubeTabPage.Location = new System.Drawing.Point(4, 22);
            this.battleEventCubeTabPage.Name = "battleEventCubeTabPage";
            this.battleEventCubeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.battleEventCubeTabPage.Size = new System.Drawing.Size(838, 518);
            this.battleEventCubeTabPage.TabIndex = 3;
            this.battleEventCubeTabPage.Text = "battleEventCube     ";
            this.battleEventCubeTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BattleEventCubeListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // BattleEventCubeListView
            // 
            this.BattleEventCubeListView.AllowColumnReorder = true;
            this.BattleEventCubeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader10,
            this.columnHeader2,
            this.columnHeader3});
            this.BattleEventCubeListView.ContextMenuStrip = this.battleEventCubeContextMenuStrip;
            this.BattleEventCubeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BattleEventCubeListView.FullRowSelect = true;
            this.BattleEventCubeListView.HideSelection = false;
            this.BattleEventCubeListView.Location = new System.Drawing.Point(0, 0);
            this.BattleEventCubeListView.MultiSelect = false;
            this.BattleEventCubeListView.Name = "BattleEventCubeListView";
            this.BattleEventCubeListView.ShowItemToolTips = true;
            this.BattleEventCubeListView.Size = new System.Drawing.Size(832, 483);
            this.BattleEventCubeListView.TabIndex = 0;
            this.BattleEventCubeListView.UseCompatibleStateImageBehavior = false;
            this.BattleEventCubeListView.View = System.Windows.Forms.View.Details;
            this.BattleEventCubeListView.SelectedIndexChanged += new System.EventHandler(this.battleEventCubeListView_SelectedIndexChanged);
            this.BattleEventCubeListView.DoubleClick += new System.EventHandler(this.battleEventCubeListView_DoubleClick);
            this.BattleEventCubeListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.battleEventCubeListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "角色编号";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "外观编号";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 200;
            // 
            // battleEventCubeContextMenuStrip
            // 
            this.battleEventCubeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.battleEventCubeContextMenuStrip.Name = "battleEventCubeContextMenuStrip";
            this.battleEventCubeContextMenuStrip.Size = new System.Drawing.Size(149, 48);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileToolStripMenuItem.Text = "打开文件";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFilePathToolStripMenuItem
            // 
            this.openFilePathToolStripMenuItem.Name = "openFilePathToolStripMenuItem";
            this.openFilePathToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFilePathToolStripMenuItem.Text = "打开文件位置";
            this.openFilePathToolStripMenuItem.Click += new System.EventHandler(this.OpenFilePathToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 29);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.refreshButton);
            this.panel4.Controls.Add(this.newBattleEventCubeButton);
            this.panel4.Controls.Add(this.editBattleEventCubeButton);
            this.panel4.Controls.Add(this.showOriginalBattleEventCubeCheckBox);
            this.panel4.Controls.Add(this.deleteBattleEventCubeButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(442, 29);
            this.panel4.TabIndex = 7;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(246, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "刷新";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // newBattleEventCubeButton
            // 
            this.newBattleEventCubeButton.Location = new System.Drawing.Point(3, 3);
            this.newBattleEventCubeButton.Name = "newBattleEventCubeButton";
            this.newBattleEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.newBattleEventCubeButton.TabIndex = 0;
            this.newBattleEventCubeButton.Text = "新增";
            this.newBattleEventCubeButton.UseVisualStyleBackColor = true;
            this.newBattleEventCubeButton.Click += new System.EventHandler(this.newBattleEventCubeButton_Click);
            // 
            // editBattleEventCubeButton
            // 
            this.editBattleEventCubeButton.Location = new System.Drawing.Point(84, 3);
            this.editBattleEventCubeButton.Name = "editBattleEventCubeButton";
            this.editBattleEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.editBattleEventCubeButton.TabIndex = 1;
            this.editBattleEventCubeButton.Text = "修改";
            this.editBattleEventCubeButton.UseVisualStyleBackColor = true;
            this.editBattleEventCubeButton.Click += new System.EventHandler(this.editBattleEventCubeButton_Click);
            // 
            // showOriginalBattleEventCubeCheckBox
            // 
            this.showOriginalBattleEventCubeCheckBox.AutoSize = true;
            this.showOriginalBattleEventCubeCheckBox.Checked = true;
            this.showOriginalBattleEventCubeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalBattleEventCubeCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalBattleEventCubeCheckBox.Name = "showOriginalBattleEventCubeCheckBox";
            this.showOriginalBattleEventCubeCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalBattleEventCubeCheckBox.TabIndex = 3;
            this.showOriginalBattleEventCubeCheckBox.Text = "显示原游戏数据";
            this.showOriginalBattleEventCubeCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalBattleEventCubeCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalBattleEventCubeCheckBox_CheckedChanged);
            // 
            // deleteBattleEventCubeButton
            // 
            this.deleteBattleEventCubeButton.Location = new System.Drawing.Point(165, 3);
            this.deleteBattleEventCubeButton.Name = "deleteBattleEventCubeButton";
            this.deleteBattleEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBattleEventCubeButton.TabIndex = 2;
            this.deleteBattleEventCubeButton.Text = "删除";
            this.deleteBattleEventCubeButton.UseVisualStyleBackColor = true;
            this.deleteBattleEventCubeButton.Click += new System.EventHandler(this.deleteBattleEventCubeButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.searchTextBox);
            this.panel3.Controls.Add(this.searchButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(542, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 29);
            this.panel3.TabIndex = 6;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(203, 21);
            this.searchTextBox.TabIndex = 4;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(212, 1);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // CustomTabControl
            // 
            this.CustomTabControl.Controls.Add(this.battleEventCubeTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // BattleEventCubeTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "BattleEventCubeTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.battleEventCubeTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.battleEventCubeContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage battleEventCubeTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newBattleEventCubeButton;
        private System.Windows.Forms.Button editBattleEventCubeButton;
        private System.Windows.Forms.CheckBox showOriginalBattleEventCubeCheckBox;
        private System.Windows.Forms.Button deleteBattleEventCubeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip battleEventCubeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private UserListView BattleEventCubeListView;
    }
}
