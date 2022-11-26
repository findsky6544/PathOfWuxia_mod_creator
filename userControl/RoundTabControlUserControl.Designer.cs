
namespace 侠之道mod制作器
{
    partial class RoundTabControlUserControl
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
            this.RoundTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RoundContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newRoundButton = new System.Windows.Forms.Button();
            this.editRoundButton = new System.Windows.Forms.Button();
            this.showOriginalRoundCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteRoundButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.RoundListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoundTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.RoundContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoundTabPage
            // 
            this.RoundTabPage.Controls.Add(this.panel2);
            this.RoundTabPage.Controls.Add(this.panel1);
            this.RoundTabPage.Location = new System.Drawing.Point(4, 22);
            this.RoundTabPage.Name = "RoundTabPage";
            this.RoundTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RoundTabPage.Size = new System.Drawing.Size(838, 518);
            this.RoundTabPage.TabIndex = 3;
            this.RoundTabPage.Text = "Round     ";
            this.RoundTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RoundListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // RoundContextMenuStrip
            // 
            this.RoundContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.RoundContextMenuStrip.Name = "RoundContextMenuStrip";
            this.RoundContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newRoundButton);
            this.panel4.Controls.Add(this.editRoundButton);
            this.panel4.Controls.Add(this.showOriginalRoundCheckBox);
            this.panel4.Controls.Add(this.deleteRoundButton);
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
            // newRoundButton
            // 
            this.newRoundButton.Location = new System.Drawing.Point(3, 3);
            this.newRoundButton.Name = "newRoundButton";
            this.newRoundButton.Size = new System.Drawing.Size(75, 23);
            this.newRoundButton.TabIndex = 0;
            this.newRoundButton.Text = "新增";
            this.newRoundButton.UseVisualStyleBackColor = true;
            this.newRoundButton.Click += new System.EventHandler(this.newRoundButton_Click);
            // 
            // editRoundButton
            // 
            this.editRoundButton.Location = new System.Drawing.Point(84, 3);
            this.editRoundButton.Name = "editRoundButton";
            this.editRoundButton.Size = new System.Drawing.Size(75, 23);
            this.editRoundButton.TabIndex = 1;
            this.editRoundButton.Text = "修改";
            this.editRoundButton.UseVisualStyleBackColor = true;
            this.editRoundButton.Click += new System.EventHandler(this.editRoundButton_Click);
            // 
            // showOriginalRoundCheckBox
            // 
            this.showOriginalRoundCheckBox.AutoSize = true;
            this.showOriginalRoundCheckBox.Checked = true;
            this.showOriginalRoundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalRoundCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalRoundCheckBox.Name = "showOriginalRoundCheckBox";
            this.showOriginalRoundCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalRoundCheckBox.TabIndex = 3;
            this.showOriginalRoundCheckBox.Text = "显示原游戏数据";
            this.showOriginalRoundCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalRoundCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalRoundCheckBox_CheckedChanged);
            // 
            // deleteRoundButton
            // 
            this.deleteRoundButton.Location = new System.Drawing.Point(165, 3);
            this.deleteRoundButton.Name = "deleteRoundButton";
            this.deleteRoundButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRoundButton.TabIndex = 2;
            this.deleteRoundButton.Text = "删除";
            this.deleteRoundButton.UseVisualStyleBackColor = true;
            this.deleteRoundButton.Click += new System.EventHandler(this.deleteRoundButton_Click);
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
            this.CustomTabControl.Controls.Add(this.RoundTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // RoundListView
            // 
            this.RoundListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.RoundListView.ContextMenuStrip = this.RoundContextMenuStrip;
            this.RoundListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoundListView.FullRowSelect = true;
            this.RoundListView.HideSelection = false;
            this.RoundListView.Location = new System.Drawing.Point(0, 0);
            this.RoundListView.MultiSelect = false;
            this.RoundListView.Name = "RoundListView";
            this.RoundListView.ShowItemToolTips = true;
            this.RoundListView.Size = new System.Drawing.Size(832, 483);
            this.RoundListView.TabIndex = 12;
            this.RoundListView.UseCompatibleStateImageBehavior = false;
            this.RoundListView.View = System.Windows.Forms.View.Details;
            this.RoundListView.DoubleClick += new System.EventHandler(this.RoundListView_DoubleClick);
            this.RoundListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RoundListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "事件名称显示条件";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "事件名称";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 300;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "天气";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.DisplayIndex = 13;
            this.columnHeader14.Text = "朋友讯息";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader15
            // 
            this.columnHeader15.DisplayIndex = 14;
            this.columnHeader15.Text = "工具人讯息";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 6;
            this.columnHeader7.Text = "是否团练";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 7;
            this.columnHeader8.Text = "是否内修";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 8;
            this.columnHeader9.Text = "开始事件场景编号";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 9;
            this.columnHeader10.Text = "开始事件演出编号";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 10;
            this.columnHeader11.Text = "强制事件场景编号";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 11;
            this.columnHeader12.Text = "强制事件演出编号";
            this.columnHeader12.Width = 200;
            // 
            // columnHeader13
            // 
            this.columnHeader13.DisplayIndex = 12;
            this.columnHeader13.Text = "开始事件触发条件";
            this.columnHeader13.Width = 200;
            // 
            // RoundTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "RoundTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.RoundTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.RoundContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage RoundTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newRoundButton;
        private System.Windows.Forms.Button editRoundButton;
        private System.Windows.Forms.CheckBox showOriginalRoundCheckBox;
        private System.Windows.Forms.Button deleteRoundButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip RoundContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView RoundListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}
