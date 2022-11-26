
namespace 侠之道mod制作器
{
    partial class MapTabControlUserControl
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
            this.MapTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newMapButton = new System.Windows.Forms.Button();
            this.editMapButton = new System.Windows.Forms.Button();
            this.showOriginalMapCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteMapButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.MapListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MapTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MapContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MapTabPage
            // 
            this.MapTabPage.Controls.Add(this.panel2);
            this.MapTabPage.Controls.Add(this.panel1);
            this.MapTabPage.Location = new System.Drawing.Point(4, 22);
            this.MapTabPage.Name = "MapTabPage";
            this.MapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MapTabPage.Size = new System.Drawing.Size(838, 518);
            this.MapTabPage.TabIndex = 3;
            this.MapTabPage.Text = "Map     ";
            this.MapTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MapListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // MapContextMenuStrip
            // 
            this.MapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.MapContextMenuStrip.Name = "MapContextMenuStrip";
            this.MapContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newMapButton);
            this.panel4.Controls.Add(this.editMapButton);
            this.panel4.Controls.Add(this.showOriginalMapCheckBox);
            this.panel4.Controls.Add(this.deleteMapButton);
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
            // newMapButton
            // 
            this.newMapButton.Location = new System.Drawing.Point(3, 3);
            this.newMapButton.Name = "newMapButton";
            this.newMapButton.Size = new System.Drawing.Size(75, 23);
            this.newMapButton.TabIndex = 0;
            this.newMapButton.Text = "新增";
            this.newMapButton.UseVisualStyleBackColor = true;
            this.newMapButton.Click += new System.EventHandler(this.newMapButton_Click);
            // 
            // editMapButton
            // 
            this.editMapButton.Location = new System.Drawing.Point(84, 3);
            this.editMapButton.Name = "editMapButton";
            this.editMapButton.Size = new System.Drawing.Size(75, 23);
            this.editMapButton.TabIndex = 1;
            this.editMapButton.Text = "修改";
            this.editMapButton.UseVisualStyleBackColor = true;
            this.editMapButton.Click += new System.EventHandler(this.editMapButton_Click);
            // 
            // showOriginalMapCheckBox
            // 
            this.showOriginalMapCheckBox.AutoSize = true;
            this.showOriginalMapCheckBox.Checked = true;
            this.showOriginalMapCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalMapCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalMapCheckBox.Name = "showOriginalMapCheckBox";
            this.showOriginalMapCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalMapCheckBox.TabIndex = 3;
            this.showOriginalMapCheckBox.Text = "显示原游戏数据";
            this.showOriginalMapCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalMapCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalMapCheckBox_CheckedChanged);
            // 
            // deleteMapButton
            // 
            this.deleteMapButton.Location = new System.Drawing.Point(165, 3);
            this.deleteMapButton.Name = "deleteMapButton";
            this.deleteMapButton.Size = new System.Drawing.Size(75, 23);
            this.deleteMapButton.TabIndex = 2;
            this.deleteMapButton.Text = "删除";
            this.deleteMapButton.UseVisualStyleBackColor = true;
            this.deleteMapButton.Click += new System.EventHandler(this.deleteMapButton_Click);
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
            this.CustomTabControl.Controls.Add(this.MapTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // MapListView
            // 
            this.MapListView.AllowColumnReorder = true;
            this.MapListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader5});
            this.MapListView.ContextMenuStrip = this.MapContextMenuStrip;
            this.MapListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapListView.FullRowSelect = true;
            this.MapListView.HideSelection = false;
            this.MapListView.Location = new System.Drawing.Point(0, 0);
            this.MapListView.MultiSelect = false;
            this.MapListView.Name = "MapListView";
            this.MapListView.ShowItemToolTips = true;
            this.MapListView.Size = new System.Drawing.Size(832, 483);
            this.MapListView.TabIndex = 12;
            this.MapListView.UseCompatibleStateImageBehavior = false;
            this.MapListView.View = System.Windows.Forms.View.Details;
            this.MapListView.SelectedIndexChanged += new System.EventHandler(this.MapListView_SelectedIndexChanged);
            this.MapListView.DoubleClick += new System.EventHandler(this.MapListView_DoubleClick);
            this.MapListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "名称";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "场景编号";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "场所编号";
            this.columnHeader3.Width = 65;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "预设位置（玩家）";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "预设旋转值（玩家）";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "播放的音乐";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "战斗最远距离";
            this.columnHeader5.Width = 65;
            // 
            // MapTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "MapTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.MapTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MapContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage MapTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newMapButton;
        private System.Windows.Forms.Button editMapButton;
        private System.Windows.Forms.CheckBox showOriginalMapCheckBox;
        private System.Windows.Forms.Button deleteMapButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip MapContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView MapListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
