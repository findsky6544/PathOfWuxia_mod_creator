
namespace 侠之道mod制作器
{
    partial class BattleScheduleTabControlUserControl
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
            this.scheduleTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.scheduleListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scheduleContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newScheduleButton = new System.Windows.Forms.Button();
            this.editScheduleButton = new System.Windows.Forms.Button();
            this.showOriginalScheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteScheduleButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.scheduleTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.scheduleContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduleTabPage
            // 
            this.scheduleTabPage.Controls.Add(this.panel2);
            this.scheduleTabPage.Controls.Add(this.panel1);
            this.scheduleTabPage.Location = new System.Drawing.Point(4, 22);
            this.scheduleTabPage.Name = "scheduleTabPage";
            this.scheduleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTabPage.Size = new System.Drawing.Size(838, 518);
            this.scheduleTabPage.TabIndex = 3;
            this.scheduleTabPage.Text = "battle/schedule     ";
            this.scheduleTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.scheduleListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // scheduleListView
            // 
            this.scheduleListView.AllowColumnReorder = true;
            this.scheduleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.scheduleListView.ContextMenuStrip = this.scheduleContextMenuStrip;
            this.scheduleListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleListView.FullRowSelect = true;
            this.scheduleListView.HideSelection = false;
            this.scheduleListView.Location = new System.Drawing.Point(0, 0);
            this.scheduleListView.MultiSelect = false;
            this.scheduleListView.Name = "scheduleListView";
            this.scheduleListView.ShowItemToolTips = true;
            this.scheduleListView.Size = new System.Drawing.Size(832, 483);
            this.scheduleListView.TabIndex = 0;
            this.scheduleListView.UseCompatibleStateImageBehavior = false;
            this.scheduleListView.View = System.Windows.Forms.View.Details;
            this.scheduleListView.SelectedIndexChanged += new System.EventHandler(this.scheduleListView_SelectedIndexChanged);
            this.scheduleListView.DoubleClick += new System.EventHandler(this.scheduleListView_DoubleClick);
            this.scheduleListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scheduleListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "胜利提示";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "失败提示";
            this.columnHeader5.Width = 200;
            // 
            // scheduleContextMenuStrip
            // 
            this.scheduleContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.scheduleContextMenuStrip.Name = "scheduleContextMenuStrip";
            this.scheduleContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newScheduleButton);
            this.panel4.Controls.Add(this.editScheduleButton);
            this.panel4.Controls.Add(this.showOriginalScheduleCheckBox);
            this.panel4.Controls.Add(this.deleteScheduleButton);
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
            // newScheduleButton
            // 
            this.newScheduleButton.Location = new System.Drawing.Point(3, 3);
            this.newScheduleButton.Name = "newScheduleButton";
            this.newScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.newScheduleButton.TabIndex = 0;
            this.newScheduleButton.Text = "新增";
            this.newScheduleButton.UseVisualStyleBackColor = true;
            this.newScheduleButton.Click += new System.EventHandler(this.newScheduleButton_Click);
            // 
            // editScheduleButton
            // 
            this.editScheduleButton.Location = new System.Drawing.Point(84, 3);
            this.editScheduleButton.Name = "editScheduleButton";
            this.editScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.editScheduleButton.TabIndex = 1;
            this.editScheduleButton.Text = "修改";
            this.editScheduleButton.UseVisualStyleBackColor = true;
            this.editScheduleButton.Click += new System.EventHandler(this.editScheduleButton_Click);
            // 
            // showOriginalScheduleCheckBox
            // 
            this.showOriginalScheduleCheckBox.AutoSize = true;
            this.showOriginalScheduleCheckBox.Checked = true;
            this.showOriginalScheduleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalScheduleCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalScheduleCheckBox.Name = "showOriginalScheduleCheckBox";
            this.showOriginalScheduleCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalScheduleCheckBox.TabIndex = 3;
            this.showOriginalScheduleCheckBox.Text = "显示原游戏数据";
            this.showOriginalScheduleCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalScheduleCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalScheduleCheckBox_CheckedChanged);
            // 
            // deleteScheduleButton
            // 
            this.deleteScheduleButton.Location = new System.Drawing.Point(165, 3);
            this.deleteScheduleButton.Name = "deleteScheduleButton";
            this.deleteScheduleButton.Size = new System.Drawing.Size(75, 23);
            this.deleteScheduleButton.TabIndex = 2;
            this.deleteScheduleButton.Text = "删除";
            this.deleteScheduleButton.UseVisualStyleBackColor = true;
            this.deleteScheduleButton.Click += new System.EventHandler(this.deleteScheduleButton_Click);
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
            this.CustomTabControl.Controls.Add(this.scheduleTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // BattleScheduleTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "BattleScheduleTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.scheduleTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.scheduleContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage scheduleTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newScheduleButton;
        private System.Windows.Forms.Button editScheduleButton;
        private System.Windows.Forms.CheckBox showOriginalScheduleCheckBox;
        private System.Windows.Forms.Button deleteScheduleButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip scheduleContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView scheduleListView;
    }
}
