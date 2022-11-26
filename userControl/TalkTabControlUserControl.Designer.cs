
namespace 侠之道mod制作器
{
    partial class TalkTabControlUserControl
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
            this.talkTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.talkListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.talkContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newTalkButton = new System.Windows.Forms.Button();
            this.editTalkButton = new System.Windows.Forms.Button();
            this.showOriginalTalkCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteTalkButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.talkTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.talkContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // talkTabPage
            // 
            this.talkTabPage.Controls.Add(this.panel2);
            this.talkTabPage.Controls.Add(this.panel1);
            this.talkTabPage.Location = new System.Drawing.Point(4, 22);
            this.talkTabPage.Name = "talkTabPage";
            this.talkTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.talkTabPage.Size = new System.Drawing.Size(838, 518);
            this.talkTabPage.TabIndex = 3;
            this.talkTabPage.Text = "talk     ";
            this.talkTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.talkListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // talkListView
            // 
            this.talkListView.AllowColumnReorder = true;
            this.talkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader5,
            this.columnHeader11,
            this.columnHeader7});
            this.talkListView.ContextMenuStrip = this.talkContextMenuStrip;
            this.talkListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.talkListView.FullRowSelect = true;
            this.talkListView.HideSelection = false;
            this.talkListView.Location = new System.Drawing.Point(0, 0);
            this.talkListView.MultiSelect = false;
            this.talkListView.Name = "talkListView";
            this.talkListView.ShowItemToolTips = true;
            this.talkListView.Size = new System.Drawing.Size(832, 483);
            this.talkListView.TabIndex = 0;
            this.talkListView.UseCompatibleStateImageBehavior = false;
            this.talkListView.View = System.Windows.Forms.View.Details;
            this.talkListView.SelectedIndexChanged += new System.EventHandler(this.talkListView_SelectedIndexChanged);
            this.talkListView.DoubleClick += new System.EventHandler(this.talkListView_DoubleClick);
            this.talkListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.talkListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "NPC编号（说话的人）";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "情感";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "讯息类型";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "讯息";
            this.columnHeader4.Width = 300;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "条件失败对话编号";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "下一个对话类型";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "下一个对话";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "动画";
            this.columnHeader7.Width = 150;
            // 
            // talkContextMenuStrip
            // 
            this.talkContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.talkContextMenuStrip.Name = "talkContextMenuStrip";
            this.talkContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newTalkButton);
            this.panel4.Controls.Add(this.editTalkButton);
            this.panel4.Controls.Add(this.showOriginalTalkCheckBox);
            this.panel4.Controls.Add(this.deleteTalkButton);
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
            // newTalkButton
            // 
            this.newTalkButton.Location = new System.Drawing.Point(3, 3);
            this.newTalkButton.Name = "newTalkButton";
            this.newTalkButton.Size = new System.Drawing.Size(75, 23);
            this.newTalkButton.TabIndex = 0;
            this.newTalkButton.Text = "新增";
            this.newTalkButton.UseVisualStyleBackColor = true;
            this.newTalkButton.Click += new System.EventHandler(this.newTalkButton_Click);
            // 
            // editTalkButton
            // 
            this.editTalkButton.Location = new System.Drawing.Point(84, 3);
            this.editTalkButton.Name = "editTalkButton";
            this.editTalkButton.Size = new System.Drawing.Size(75, 23);
            this.editTalkButton.TabIndex = 1;
            this.editTalkButton.Text = "修改";
            this.editTalkButton.UseVisualStyleBackColor = true;
            this.editTalkButton.Click += new System.EventHandler(this.editTalkButton_Click);
            // 
            // showOriginalTalkCheckBox
            // 
            this.showOriginalTalkCheckBox.AutoSize = true;
            this.showOriginalTalkCheckBox.Checked = true;
            this.showOriginalTalkCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalTalkCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalTalkCheckBox.Name = "showOriginalTalkCheckBox";
            this.showOriginalTalkCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalTalkCheckBox.TabIndex = 3;
            this.showOriginalTalkCheckBox.Text = "显示原游戏数据";
            this.showOriginalTalkCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalTalkCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalTalkCheckBox_CheckedChanged);
            // 
            // deleteTalkButton
            // 
            this.deleteTalkButton.Location = new System.Drawing.Point(165, 3);
            this.deleteTalkButton.Name = "deleteTalkButton";
            this.deleteTalkButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTalkButton.TabIndex = 2;
            this.deleteTalkButton.Text = "删除";
            this.deleteTalkButton.UseVisualStyleBackColor = true;
            this.deleteTalkButton.Click += new System.EventHandler(this.deleteTalkButton_Click);
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
            this.CustomTabControl.Controls.Add(this.talkTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // TalkTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "TalkTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.talkTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.talkContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage talkTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newTalkButton;
        private System.Windows.Forms.Button editTalkButton;
        private System.Windows.Forms.CheckBox showOriginalTalkCheckBox;
        private System.Windows.Forms.Button deleteTalkButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip talkContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private UserListView talkListView;
    }
}
