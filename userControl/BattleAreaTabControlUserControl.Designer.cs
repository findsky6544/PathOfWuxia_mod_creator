
namespace 侠之道mod制作器
{
    partial class BattleAreaTabControlUserControl
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
            this.battleAreaTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.battleAreaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newBattleAreaButton = new System.Windows.Forms.Button();
            this.editBattleAreaButton = new System.Windows.Forms.Button();
            this.showOriginalBattleAreaCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteBattleAreaButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.BattleAreaListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.battleAreaTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.battleAreaContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // battleAreaTabPage
            // 
            this.battleAreaTabPage.Controls.Add(this.panel2);
            this.battleAreaTabPage.Controls.Add(this.panel1);
            this.battleAreaTabPage.Location = new System.Drawing.Point(4, 22);
            this.battleAreaTabPage.Name = "battleAreaTabPage";
            this.battleAreaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.battleAreaTabPage.Size = new System.Drawing.Size(838, 518);
            this.battleAreaTabPage.TabIndex = 3;
            this.battleAreaTabPage.Text = "battleArea     ";
            this.battleAreaTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BattleAreaListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // battleAreaContextMenuStrip
            // 
            this.battleAreaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.battleAreaContextMenuStrip.Name = "battleAreaContextMenuStrip";
            this.battleAreaContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newBattleAreaButton);
            this.panel4.Controls.Add(this.editBattleAreaButton);
            this.panel4.Controls.Add(this.showOriginalBattleAreaCheckBox);
            this.panel4.Controls.Add(this.deleteBattleAreaButton);
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
            // newBattleAreaButton
            // 
            this.newBattleAreaButton.Location = new System.Drawing.Point(3, 3);
            this.newBattleAreaButton.Name = "newBattleAreaButton";
            this.newBattleAreaButton.Size = new System.Drawing.Size(75, 23);
            this.newBattleAreaButton.TabIndex = 0;
            this.newBattleAreaButton.Text = "新增";
            this.newBattleAreaButton.UseVisualStyleBackColor = true;
            this.newBattleAreaButton.Click += new System.EventHandler(this.newBattleAreaButton_Click);
            // 
            // editBattleAreaButton
            // 
            this.editBattleAreaButton.Location = new System.Drawing.Point(84, 3);
            this.editBattleAreaButton.Name = "editBattleAreaButton";
            this.editBattleAreaButton.Size = new System.Drawing.Size(75, 23);
            this.editBattleAreaButton.TabIndex = 1;
            this.editBattleAreaButton.Text = "修改";
            this.editBattleAreaButton.UseVisualStyleBackColor = true;
            this.editBattleAreaButton.Click += new System.EventHandler(this.editBattleAreaButton_Click);
            // 
            // showOriginalBattleAreaCheckBox
            // 
            this.showOriginalBattleAreaCheckBox.AutoSize = true;
            this.showOriginalBattleAreaCheckBox.Checked = true;
            this.showOriginalBattleAreaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalBattleAreaCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalBattleAreaCheckBox.Name = "showOriginalBattleAreaCheckBox";
            this.showOriginalBattleAreaCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalBattleAreaCheckBox.TabIndex = 3;
            this.showOriginalBattleAreaCheckBox.Text = "显示原游戏数据";
            this.showOriginalBattleAreaCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalBattleAreaCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalBattleAreaCheckBox_CheckedChanged);
            // 
            // deleteBattleAreaButton
            // 
            this.deleteBattleAreaButton.Location = new System.Drawing.Point(165, 3);
            this.deleteBattleAreaButton.Name = "deleteBattleAreaButton";
            this.deleteBattleAreaButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBattleAreaButton.TabIndex = 2;
            this.deleteBattleAreaButton.Text = "删除";
            this.deleteBattleAreaButton.UseVisualStyleBackColor = true;
            this.deleteBattleAreaButton.Click += new System.EventHandler(this.deleteBattleAreaButton_Click);
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
            this.CustomTabControl.Controls.Add(this.battleAreaTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // BattleAreaListView
            // 
            this.BattleAreaListView.AllowColumnReorder = true;
            this.BattleAreaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader10,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader11});
            this.BattleAreaListView.ContextMenuStrip = this.battleAreaContextMenuStrip;
            this.BattleAreaListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BattleAreaListView.FullRowSelect = true;
            this.BattleAreaListView.HideSelection = false;
            this.BattleAreaListView.Location = new System.Drawing.Point(0, 0);
            this.BattleAreaListView.MultiSelect = false;
            this.BattleAreaListView.Name = "BattleAreaListView";
            this.BattleAreaListView.ShowItemToolTips = true;
            this.BattleAreaListView.Size = new System.Drawing.Size(832, 483);
            this.BattleAreaListView.TabIndex = 0;
            this.BattleAreaListView.UseCompatibleStateImageBehavior = false;
            this.BattleAreaListView.View = System.Windows.Forms.View.Details;
            this.BattleAreaListView.SelectedIndexChanged += new System.EventHandler(this.battleAreaListView_SelectedIndexChanged);
            this.BattleAreaListView.DoubleClick += new System.EventHandler(this.battleAreaListView_DoubleClick);
            this.BattleAreaListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.battleAreaListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "战斗网格编号";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "战斗排程编号";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "战斗掉落物";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "战斗音乐";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "备注说明";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "战斗获胜movie";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "战斗失败movie";
            this.columnHeader11.Width = 200;
            // 
            // BattleAreaTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "BattleAreaTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.battleAreaTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.battleAreaContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage battleAreaTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newBattleAreaButton;
        private System.Windows.Forms.Button editBattleAreaButton;
        private System.Windows.Forms.CheckBox showOriginalBattleAreaCheckBox;
        private System.Windows.Forms.Button deleteBattleAreaButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip battleAreaContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private UserListView BattleAreaListView;
    }
}
