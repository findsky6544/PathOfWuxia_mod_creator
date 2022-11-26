
namespace 侠之道mod制作器
{
    partial class ForgeTabControlUserControl
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
            this.ForgeTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ForgeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newForgeButton = new System.Windows.Forms.Button();
            this.editForgeButton = new System.Windows.Forms.Button();
            this.showOriginalForgeCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteForgeButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.ForgeListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ForgeTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ForgeContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ForgeTabPage
            // 
            this.ForgeTabPage.Controls.Add(this.panel2);
            this.ForgeTabPage.Controls.Add(this.panel1);
            this.ForgeTabPage.Location = new System.Drawing.Point(4, 22);
            this.ForgeTabPage.Name = "ForgeTabPage";
            this.ForgeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ForgeTabPage.Size = new System.Drawing.Size(838, 518);
            this.ForgeTabPage.TabIndex = 3;
            this.ForgeTabPage.Text = "Forge     ";
            this.ForgeTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ForgeListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // ForgeContextMenuStrip
            // 
            this.ForgeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.ForgeContextMenuStrip.Name = "ForgeContextMenuStrip";
            this.ForgeContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newForgeButton);
            this.panel4.Controls.Add(this.editForgeButton);
            this.panel4.Controls.Add(this.showOriginalForgeCheckBox);
            this.panel4.Controls.Add(this.deleteForgeButton);
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
            // newForgeButton
            // 
            this.newForgeButton.Location = new System.Drawing.Point(3, 3);
            this.newForgeButton.Name = "newForgeButton";
            this.newForgeButton.Size = new System.Drawing.Size(75, 23);
            this.newForgeButton.TabIndex = 0;
            this.newForgeButton.Text = "新增";
            this.newForgeButton.UseVisualStyleBackColor = true;
            this.newForgeButton.Click += new System.EventHandler(this.newForgeButton_Click);
            // 
            // editForgeButton
            // 
            this.editForgeButton.Location = new System.Drawing.Point(84, 3);
            this.editForgeButton.Name = "editForgeButton";
            this.editForgeButton.Size = new System.Drawing.Size(75, 23);
            this.editForgeButton.TabIndex = 1;
            this.editForgeButton.Text = "修改";
            this.editForgeButton.UseVisualStyleBackColor = true;
            this.editForgeButton.Click += new System.EventHandler(this.editForgeButton_Click);
            // 
            // showOriginalForgeCheckBox
            // 
            this.showOriginalForgeCheckBox.AutoSize = true;
            this.showOriginalForgeCheckBox.Checked = true;
            this.showOriginalForgeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalForgeCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalForgeCheckBox.Name = "showOriginalForgeCheckBox";
            this.showOriginalForgeCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalForgeCheckBox.TabIndex = 3;
            this.showOriginalForgeCheckBox.Text = "显示原游戏数据";
            this.showOriginalForgeCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalForgeCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalForgeCheckBox_CheckedChanged);
            // 
            // deleteForgeButton
            // 
            this.deleteForgeButton.Location = new System.Drawing.Point(165, 3);
            this.deleteForgeButton.Name = "deleteForgeButton";
            this.deleteForgeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteForgeButton.TabIndex = 2;
            this.deleteForgeButton.Text = "删除";
            this.deleteForgeButton.UseVisualStyleBackColor = true;
            this.deleteForgeButton.Click += new System.EventHandler(this.deleteForgeButton_Click);
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
            this.CustomTabControl.Controls.Add(this.ForgeTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // ForgeListView
            // 
            this.ForgeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader11});
            this.ForgeListView.ContextMenuStrip = this.ForgeContextMenuStrip;
            this.ForgeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ForgeListView.FullRowSelect = true;
            this.ForgeListView.HideSelection = false;
            this.ForgeListView.Location = new System.Drawing.Point(0, 0);
            this.ForgeListView.MultiSelect = false;
            this.ForgeListView.Name = "ForgeListView";
            this.ForgeListView.ShowItemToolTips = true;
            this.ForgeListView.Size = new System.Drawing.Size(832, 483);
            this.ForgeListView.TabIndex = 14;
            this.ForgeListView.UseCompatibleStateImageBehavior = false;
            this.ForgeListView.View = System.Windows.Forms.View.Details;
            this.ForgeListView.SelectedIndexChanged += new System.EventHandler(this.ForgeListView_SelectedIndexChanged);
            this.ForgeListView.DoubleClick += new System.EventHandler(this.ForgeListView_DoubleClick);
            this.ForgeListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ForgeListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "锻造装备编号（props编号）";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "锻造需求等级";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "开启回合";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "是否为特殊装备";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "是否限制数量";
            this.columnHeader11.Width = 100;
            // 
            // ForgeTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "ForgeTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.ForgeTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ForgeContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ForgeTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newForgeButton;
        private System.Windows.Forms.Button editForgeButton;
        private System.Windows.Forms.CheckBox showOriginalForgeCheckBox;
        private System.Windows.Forms.Button deleteForgeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip ForgeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView ForgeListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}
