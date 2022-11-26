
namespace 侠之道mod制作器
{
    partial class CinematicTabControlUserControl
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
            this.cinematicTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cinematicListView =new  UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cinematicContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newCinematicButton = new System.Windows.Forms.Button();
            this.editCinematicButton = new System.Windows.Forms.Button();
            this.showOriginalCinematicCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCinematicButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.cinematicTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cinematicContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // cinematicTabPage
            // 
            this.cinematicTabPage.Controls.Add(this.panel2);
            this.cinematicTabPage.Controls.Add(this.panel1);
            this.cinematicTabPage.Location = new System.Drawing.Point(4, 22);
            this.cinematicTabPage.Name = "cinematicTabPage";
            this.cinematicTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cinematicTabPage.Size = new System.Drawing.Size(838, 518);
            this.cinematicTabPage.TabIndex = 3;
            this.cinematicTabPage.Text = "cinematic     ";
            this.cinematicTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cinematicListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // cinematicListView
            // 
            this.cinematicListView.AllowColumnReorder = true;
            this.cinematicListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6});
            this.cinematicListView.ContextMenuStrip = this.cinematicContextMenuStrip;
            this.cinematicListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cinematicListView.FullRowSelect = true;
            this.cinematicListView.HideSelection = false;
            this.cinematicListView.Location = new System.Drawing.Point(0, 0);
            this.cinematicListView.MultiSelect = false;
            this.cinematicListView.Name = "cinematicListView";
            this.cinematicListView.ShowItemToolTips = true;
            this.cinematicListView.Size = new System.Drawing.Size(832, 483);
            this.cinematicListView.TabIndex = 0;
            this.cinematicListView.UseCompatibleStateImageBehavior = false;
            this.cinematicListView.View = System.Windows.Forms.View.Details;
            this.cinematicListView.SelectedIndexChanged += new System.EventHandler(this.cinematicListView_SelectedIndexChanged);
            this.cinematicListView.DoubleClick += new System.EventHandler(this.cinematicListView_DoubleClick);
            this.cinematicListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cinematicListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "进入点";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内容";
            // 
            // cinematicContextMenuStrip
            // 
            this.cinematicContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.cinematicContextMenuStrip.Name = "cinematicContextMenuStrip";
            this.cinematicContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newCinematicButton);
            this.panel4.Controls.Add(this.editCinematicButton);
            this.panel4.Controls.Add(this.showOriginalCinematicCheckBox);
            this.panel4.Controls.Add(this.deleteCinematicButton);
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
            // newCinematicButton
            // 
            this.newCinematicButton.Location = new System.Drawing.Point(3, 3);
            this.newCinematicButton.Name = "newCinematicButton";
            this.newCinematicButton.Size = new System.Drawing.Size(75, 23);
            this.newCinematicButton.TabIndex = 0;
            this.newCinematicButton.Text = "新增";
            this.newCinematicButton.UseVisualStyleBackColor = true;
            this.newCinematicButton.Click += new System.EventHandler(this.newCinematicButton_Click);
            // 
            // editCinematicButton
            // 
            this.editCinematicButton.Location = new System.Drawing.Point(84, 3);
            this.editCinematicButton.Name = "editCinematicButton";
            this.editCinematicButton.Size = new System.Drawing.Size(75, 23);
            this.editCinematicButton.TabIndex = 1;
            this.editCinematicButton.Text = "修改";
            this.editCinematicButton.UseVisualStyleBackColor = true;
            this.editCinematicButton.Click += new System.EventHandler(this.editCinematicButton_Click);
            // 
            // showOriginalCinematicCheckBox
            // 
            this.showOriginalCinematicCheckBox.AutoSize = true;
            this.showOriginalCinematicCheckBox.Checked = true;
            this.showOriginalCinematicCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalCinematicCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalCinematicCheckBox.Name = "showOriginalCinematicCheckBox";
            this.showOriginalCinematicCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalCinematicCheckBox.TabIndex = 3;
            this.showOriginalCinematicCheckBox.Text = "显示原游戏数据";
            this.showOriginalCinematicCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalCinematicCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalCinematicCheckBox_CheckedChanged);
            // 
            // deleteCinematicButton
            // 
            this.deleteCinematicButton.Location = new System.Drawing.Point(165, 3);
            this.deleteCinematicButton.Name = "deleteCinematicButton";
            this.deleteCinematicButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCinematicButton.TabIndex = 2;
            this.deleteCinematicButton.Text = "删除";
            this.deleteCinematicButton.UseVisualStyleBackColor = true;
            this.deleteCinematicButton.Click += new System.EventHandler(this.deleteCinematicButton_Click);
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
            this.CustomTabControl.Controls.Add(this.cinematicTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // CinematicTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "CinematicTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.cinematicTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.cinematicContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage cinematicTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView cinematicListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newCinematicButton;
        private System.Windows.Forms.Button editCinematicButton;
        private System.Windows.Forms.CheckBox showOriginalCinematicCheckBox;
        private System.Windows.Forms.Button deleteCinematicButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip cinematicContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
