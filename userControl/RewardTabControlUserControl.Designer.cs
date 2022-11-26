
namespace 侠之道mod制作器
{
    partial class RewardTabControlUserControl
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
            this.rewardTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RewardListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rewardContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newRewardButton = new System.Windows.Forms.Button();
            this.editRewardButton = new System.Windows.Forms.Button();
            this.showOriginalRewardCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteRewardButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.rewardTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.rewardContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // rewardTabPage
            // 
            this.rewardTabPage.Controls.Add(this.panel2);
            this.rewardTabPage.Controls.Add(this.panel1);
            this.rewardTabPage.Location = new System.Drawing.Point(4, 22);
            this.rewardTabPage.Name = "rewardTabPage";
            this.rewardTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.rewardTabPage.Size = new System.Drawing.Size(838, 518);
            this.rewardTabPage.TabIndex = 3;
            this.rewardTabPage.Text = "reward     ";
            this.rewardTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RewardListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // RewardListView
            // 
            this.RewardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4});
            this.RewardListView.ContextMenuStrip = this.rewardContextMenuStrip;
            this.RewardListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RewardListView.FullRowSelect = true;
            this.RewardListView.HideSelection = false;
            this.RewardListView.Location = new System.Drawing.Point(0, 0);
            this.RewardListView.MultiSelect = false;
            this.RewardListView.Name = "RewardListView";
            this.RewardListView.ShowItemToolTips = true;
            this.RewardListView.Size = new System.Drawing.Size(832, 483);
            this.RewardListView.TabIndex = 12;
            this.RewardListView.UseCompatibleStateImageBehavior = false;
            this.RewardListView.View = System.Windows.Forms.View.Details;
            this.RewardListView.DoubleClick += new System.EventHandler(this.rewardListView_DoubleClick);
            this.RewardListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rewardListView_KeyPress);
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "是否显示讯息";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描述";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "奖励内容";
            this.columnHeader4.Width = 300;
            // 
            // rewardContextMenuStrip
            // 
            this.rewardContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.rewardContextMenuStrip.Name = "rewardContextMenuStrip";
            this.rewardContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newRewardButton);
            this.panel4.Controls.Add(this.editRewardButton);
            this.panel4.Controls.Add(this.showOriginalRewardCheckBox);
            this.panel4.Controls.Add(this.deleteRewardButton);
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
            // newRewardButton
            // 
            this.newRewardButton.Location = new System.Drawing.Point(3, 3);
            this.newRewardButton.Name = "newRewardButton";
            this.newRewardButton.Size = new System.Drawing.Size(75, 23);
            this.newRewardButton.TabIndex = 0;
            this.newRewardButton.Text = "新增";
            this.newRewardButton.UseVisualStyleBackColor = true;
            this.newRewardButton.Click += new System.EventHandler(this.newRewardButton_Click);
            // 
            // editRewardButton
            // 
            this.editRewardButton.Location = new System.Drawing.Point(84, 3);
            this.editRewardButton.Name = "editRewardButton";
            this.editRewardButton.Size = new System.Drawing.Size(75, 23);
            this.editRewardButton.TabIndex = 1;
            this.editRewardButton.Text = "修改";
            this.editRewardButton.UseVisualStyleBackColor = true;
            this.editRewardButton.Click += new System.EventHandler(this.editRewardButton_Click);
            // 
            // showOriginalRewardCheckBox
            // 
            this.showOriginalRewardCheckBox.AutoSize = true;
            this.showOriginalRewardCheckBox.Checked = true;
            this.showOriginalRewardCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalRewardCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalRewardCheckBox.Name = "showOriginalRewardCheckBox";
            this.showOriginalRewardCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalRewardCheckBox.TabIndex = 3;
            this.showOriginalRewardCheckBox.Text = "显示原游戏数据";
            this.showOriginalRewardCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalRewardCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalRewardCheckBox_CheckedChanged);
            // 
            // deleteRewardButton
            // 
            this.deleteRewardButton.Location = new System.Drawing.Point(165, 3);
            this.deleteRewardButton.Name = "deleteRewardButton";
            this.deleteRewardButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRewardButton.TabIndex = 2;
            this.deleteRewardButton.Text = "删除";
            this.deleteRewardButton.UseVisualStyleBackColor = true;
            this.deleteRewardButton.Click += new System.EventHandler(this.deleteRewardButton_Click);
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
            this.CustomTabControl.Controls.Add(this.rewardTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // RewardTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "RewardTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.rewardTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.rewardContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage rewardTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newRewardButton;
        private System.Windows.Forms.Button editRewardButton;
        private System.Windows.Forms.CheckBox showOriginalRewardCheckBox;
        private System.Windows.Forms.Button deleteRewardButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip rewardContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView RewardListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
