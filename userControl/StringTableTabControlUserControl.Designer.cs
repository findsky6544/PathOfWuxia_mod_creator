
namespace 侠之道mod制作器
{
    partial class StringTableTabControlUserControl
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
            this.StringTableTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StringTableListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StringTableContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newStringTableButton = new System.Windows.Forms.Button();
            this.editStringTableButton = new System.Windows.Forms.Button();
            this.showOriginalStringTableCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteStringTableButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StringTableTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.StringTableContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // StringTableTabPage
            // 
            this.StringTableTabPage.Controls.Add(this.panel2);
            this.StringTableTabPage.Controls.Add(this.panel1);
            this.StringTableTabPage.Location = new System.Drawing.Point(4, 22);
            this.StringTableTabPage.Name = "StringTableTabPage";
            this.StringTableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StringTableTabPage.Size = new System.Drawing.Size(838, 518);
            this.StringTableTabPage.TabIndex = 3;
            this.StringTableTabPage.Text = "StringTable     ";
            this.StringTableTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StringTableListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // StringTableListView
            // 
            this.StringTableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7});
            this.StringTableListView.ContextMenuStrip = this.StringTableContextMenuStrip;
            this.StringTableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StringTableListView.FullRowSelect = true;
            this.StringTableListView.HideSelection = false;
            this.StringTableListView.Location = new System.Drawing.Point(0, 0);
            this.StringTableListView.MultiSelect = false;
            this.StringTableListView.Name = "StringTableListView";
            this.StringTableListView.ShowItemToolTips = true;
            this.StringTableListView.Size = new System.Drawing.Size(832, 483);
            this.StringTableListView.TabIndex = 12;
            this.StringTableListView.UseCompatibleStateImageBehavior = false;
            this.StringTableListView.View = System.Windows.Forms.View.Details;
            this.StringTableListView.DoubleClick += new System.EventHandler(this.StringTableListView_DoubleClick);
            this.StringTableListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StringTableListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 150;
            // 
            // StringTableContextMenuStrip
            // 
            this.StringTableContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.StringTableContextMenuStrip.Name = "StringTableContextMenuStrip";
            this.StringTableContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newStringTableButton);
            this.panel4.Controls.Add(this.editStringTableButton);
            this.panel4.Controls.Add(this.showOriginalStringTableCheckBox);
            this.panel4.Controls.Add(this.deleteStringTableButton);
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
            // newStringTableButton
            // 
            this.newStringTableButton.Location = new System.Drawing.Point(3, 3);
            this.newStringTableButton.Name = "newStringTableButton";
            this.newStringTableButton.Size = new System.Drawing.Size(75, 23);
            this.newStringTableButton.TabIndex = 0;
            this.newStringTableButton.Text = "新增";
            this.newStringTableButton.UseVisualStyleBackColor = true;
            this.newStringTableButton.Click += new System.EventHandler(this.newStringTableButton_Click);
            // 
            // editStringTableButton
            // 
            this.editStringTableButton.Location = new System.Drawing.Point(84, 3);
            this.editStringTableButton.Name = "editStringTableButton";
            this.editStringTableButton.Size = new System.Drawing.Size(75, 23);
            this.editStringTableButton.TabIndex = 1;
            this.editStringTableButton.Text = "修改";
            this.editStringTableButton.UseVisualStyleBackColor = true;
            this.editStringTableButton.Click += new System.EventHandler(this.editStringTableButton_Click);
            // 
            // showOriginalStringTableCheckBox
            // 
            this.showOriginalStringTableCheckBox.AutoSize = true;
            this.showOriginalStringTableCheckBox.Checked = true;
            this.showOriginalStringTableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalStringTableCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalStringTableCheckBox.Name = "showOriginalStringTableCheckBox";
            this.showOriginalStringTableCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalStringTableCheckBox.TabIndex = 3;
            this.showOriginalStringTableCheckBox.Text = "显示原游戏数据";
            this.showOriginalStringTableCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalStringTableCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalStringTableCheckBox_CheckedChanged);
            // 
            // deleteStringTableButton
            // 
            this.deleteStringTableButton.Location = new System.Drawing.Point(165, 3);
            this.deleteStringTableButton.Name = "deleteStringTableButton";
            this.deleteStringTableButton.Size = new System.Drawing.Size(75, 23);
            this.deleteStringTableButton.TabIndex = 2;
            this.deleteStringTableButton.Text = "删除";
            this.deleteStringTableButton.UseVisualStyleBackColor = true;
            this.deleteStringTableButton.Click += new System.EventHandler(this.deleteStringTableButton_Click);
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
            this.CustomTabControl.Controls.Add(this.StringTableTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "文字";
            this.columnHeader7.Width = 400;
            // 
            // StringTableTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "StringTableTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.StringTableTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.StringTableContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage StringTableTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newStringTableButton;
        private System.Windows.Forms.Button editStringTableButton;
        private System.Windows.Forms.CheckBox showOriginalStringTableCheckBox;
        private System.Windows.Forms.Button deleteStringTableButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip StringTableContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView StringTableListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
