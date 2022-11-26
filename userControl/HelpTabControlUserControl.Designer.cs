
namespace 侠之道mod制作器
{
    partial class HelpTabControlUserControl
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
            this.HelpTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HelpListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HelpContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newHelpButton = new System.Windows.Forms.Button();
            this.editHelpButton = new System.Windows.Forms.Button();
            this.showOriginalHelpCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteHelpButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HelpTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.HelpContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpTabPage
            // 
            this.HelpTabPage.Controls.Add(this.panel2);
            this.HelpTabPage.Controls.Add(this.panel1);
            this.HelpTabPage.Location = new System.Drawing.Point(4, 22);
            this.HelpTabPage.Name = "HelpTabPage";
            this.HelpTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HelpTabPage.Size = new System.Drawing.Size(838, 518);
            this.HelpTabPage.TabIndex = 3;
            this.HelpTabPage.Text = "Help     ";
            this.HelpTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.HelpListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // HelpListView
            // 
            this.HelpListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader11,
            this.columnHeader7,
            this.columnHeader8});
            this.HelpListView.ContextMenuStrip = this.HelpContextMenuStrip;
            this.HelpListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpListView.FullRowSelect = true;
            this.HelpListView.HideSelection = false;
            this.HelpListView.Location = new System.Drawing.Point(0, 0);
            this.HelpListView.MultiSelect = false;
            this.HelpListView.Name = "HelpListView";
            this.HelpListView.ShowItemToolTips = true;
            this.HelpListView.Size = new System.Drawing.Size(832, 483);
            this.HelpListView.TabIndex = 14;
            this.HelpListView.UseCompatibleStateImageBehavior = false;
            this.HelpListView.View = System.Windows.Forms.View.Details;
            this.HelpListView.SelectedIndexChanged += new System.EventHandler(this.HelpListView_SelectedIndexChanged);
            this.HelpListView.DoubleClick += new System.EventHandler(this.HelpListView_DoubleClick);
            this.HelpListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HelpListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "隶属分页";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "是否为主条目";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "对应主条目Id";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "条目名称";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "显示条件";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "补充图片";
            this.columnHeader11.Width = 100;
            // 
            // HelpContextMenuStrip
            // 
            this.HelpContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.HelpContextMenuStrip.Name = "HelpContextMenuStrip";
            this.HelpContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newHelpButton);
            this.panel4.Controls.Add(this.editHelpButton);
            this.panel4.Controls.Add(this.showOriginalHelpCheckBox);
            this.panel4.Controls.Add(this.deleteHelpButton);
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
            // newHelpButton
            // 
            this.newHelpButton.Location = new System.Drawing.Point(3, 3);
            this.newHelpButton.Name = "newHelpButton";
            this.newHelpButton.Size = new System.Drawing.Size(75, 23);
            this.newHelpButton.TabIndex = 0;
            this.newHelpButton.Text = "新增";
            this.newHelpButton.UseVisualStyleBackColor = true;
            this.newHelpButton.Click += new System.EventHandler(this.newHelpButton_Click);
            // 
            // editHelpButton
            // 
            this.editHelpButton.Location = new System.Drawing.Point(84, 3);
            this.editHelpButton.Name = "editHelpButton";
            this.editHelpButton.Size = new System.Drawing.Size(75, 23);
            this.editHelpButton.TabIndex = 1;
            this.editHelpButton.Text = "修改";
            this.editHelpButton.UseVisualStyleBackColor = true;
            this.editHelpButton.Click += new System.EventHandler(this.editHelpButton_Click);
            // 
            // showOriginalHelpCheckBox
            // 
            this.showOriginalHelpCheckBox.AutoSize = true;
            this.showOriginalHelpCheckBox.Checked = true;
            this.showOriginalHelpCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalHelpCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalHelpCheckBox.Name = "showOriginalHelpCheckBox";
            this.showOriginalHelpCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalHelpCheckBox.TabIndex = 3;
            this.showOriginalHelpCheckBox.Text = "显示原游戏数据";
            this.showOriginalHelpCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalHelpCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalHelpCheckBox_CheckedChanged);
            // 
            // deleteHelpButton
            // 
            this.deleteHelpButton.Location = new System.Drawing.Point(165, 3);
            this.deleteHelpButton.Name = "deleteHelpButton";
            this.deleteHelpButton.Size = new System.Drawing.Size(75, 23);
            this.deleteHelpButton.TabIndex = 2;
            this.deleteHelpButton.Text = "删除";
            this.deleteHelpButton.UseVisualStyleBackColor = true;
            this.deleteHelpButton.Click += new System.EventHandler(this.deleteHelpButton_Click);
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
            this.CustomTabControl.Controls.Add(this.HelpTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "人物外观";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "叙述内容";
            this.columnHeader8.Width = 200;
            // 
            // HelpTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "HelpTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.HelpTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.HelpContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage HelpTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newHelpButton;
        private System.Windows.Forms.Button editHelpButton;
        private System.Windows.Forms.CheckBox showOriginalHelpCheckBox;
        private System.Windows.Forms.Button deleteHelpButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip HelpContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView HelpListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
