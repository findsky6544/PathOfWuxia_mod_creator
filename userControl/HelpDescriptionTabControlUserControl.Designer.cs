
namespace 侠之道mod制作器
{
    partial class HelpDescriptionTabControlUserControl
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
            this.HelpDescriptionTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HelpDescriptionContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newHelpDescriptionButton = new System.Windows.Forms.Button();
            this.editHelpDescriptionButton = new System.Windows.Forms.Button();
            this.showOriginalHelpDescriptionCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteHelpDescriptionButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.HelpDescriptionListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HelpDescriptionTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.HelpDescriptionContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpDescriptionTabPage
            // 
            this.HelpDescriptionTabPage.Controls.Add(this.panel2);
            this.HelpDescriptionTabPage.Controls.Add(this.panel1);
            this.HelpDescriptionTabPage.Location = new System.Drawing.Point(4, 22);
            this.HelpDescriptionTabPage.Name = "HelpDescriptionTabPage";
            this.HelpDescriptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HelpDescriptionTabPage.Size = new System.Drawing.Size(838, 518);
            this.HelpDescriptionTabPage.TabIndex = 3;
            this.HelpDescriptionTabPage.Text = "HelpDescription     ";
            this.HelpDescriptionTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.HelpDescriptionListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // HelpDescriptionContextMenuStrip
            // 
            this.HelpDescriptionContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.HelpDescriptionContextMenuStrip.Name = "HelpDescriptionContextMenuStrip";
            this.HelpDescriptionContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newHelpDescriptionButton);
            this.panel4.Controls.Add(this.editHelpDescriptionButton);
            this.panel4.Controls.Add(this.showOriginalHelpDescriptionCheckBox);
            this.panel4.Controls.Add(this.deleteHelpDescriptionButton);
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
            // newHelpDescriptionButton
            // 
            this.newHelpDescriptionButton.Location = new System.Drawing.Point(3, 3);
            this.newHelpDescriptionButton.Name = "newHelpDescriptionButton";
            this.newHelpDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.newHelpDescriptionButton.TabIndex = 0;
            this.newHelpDescriptionButton.Text = "新增";
            this.newHelpDescriptionButton.UseVisualStyleBackColor = true;
            this.newHelpDescriptionButton.Click += new System.EventHandler(this.newHelpDescriptionButton_Click);
            // 
            // editHelpDescriptionButton
            // 
            this.editHelpDescriptionButton.Location = new System.Drawing.Point(84, 3);
            this.editHelpDescriptionButton.Name = "editHelpDescriptionButton";
            this.editHelpDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.editHelpDescriptionButton.TabIndex = 1;
            this.editHelpDescriptionButton.Text = "修改";
            this.editHelpDescriptionButton.UseVisualStyleBackColor = true;
            this.editHelpDescriptionButton.Click += new System.EventHandler(this.editHelpDescriptionButton_Click);
            // 
            // showOriginalHelpDescriptionCheckBox
            // 
            this.showOriginalHelpDescriptionCheckBox.AutoSize = true;
            this.showOriginalHelpDescriptionCheckBox.Checked = true;
            this.showOriginalHelpDescriptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalHelpDescriptionCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalHelpDescriptionCheckBox.Name = "showOriginalHelpDescriptionCheckBox";
            this.showOriginalHelpDescriptionCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalHelpDescriptionCheckBox.TabIndex = 3;
            this.showOriginalHelpDescriptionCheckBox.Text = "显示原游戏数据";
            this.showOriginalHelpDescriptionCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalHelpDescriptionCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalHelpDescriptionCheckBox_CheckedChanged);
            // 
            // deleteHelpDescriptionButton
            // 
            this.deleteHelpDescriptionButton.Location = new System.Drawing.Point(165, 3);
            this.deleteHelpDescriptionButton.Name = "deleteHelpDescriptionButton";
            this.deleteHelpDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.deleteHelpDescriptionButton.TabIndex = 2;
            this.deleteHelpDescriptionButton.Text = "删除";
            this.deleteHelpDescriptionButton.UseVisualStyleBackColor = true;
            this.deleteHelpDescriptionButton.Click += new System.EventHandler(this.deleteHelpDescriptionButton_Click);
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
            this.CustomTabControl.Controls.Add(this.HelpDescriptionTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // HelpDescriptionListView
            // 
            this.HelpDescriptionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader9});
            this.HelpDescriptionListView.ContextMenuStrip = this.HelpDescriptionContextMenuStrip;
            this.HelpDescriptionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HelpDescriptionListView.FullRowSelect = true;
            this.HelpDescriptionListView.HideSelection = false;
            this.HelpDescriptionListView.Location = new System.Drawing.Point(0, 0);
            this.HelpDescriptionListView.MultiSelect = false;
            this.HelpDescriptionListView.Name = "HelpDescriptionListView";
            this.HelpDescriptionListView.ShowItemToolTips = true;
            this.HelpDescriptionListView.Size = new System.Drawing.Size(832, 483);
            this.HelpDescriptionListView.TabIndex = 16;
            this.HelpDescriptionListView.UseCompatibleStateImageBehavior = false;
            this.HelpDescriptionListView.View = System.Windows.Forms.View.Details;
            this.HelpDescriptionListView.SelectedIndexChanged += new System.EventHandler(this.HelpDescriptionListView_SelectedIndexChanged);
            this.HelpDescriptionListView.DoubleClick += new System.EventHandler(this.HelpDescriptionListView_DoubleClick);
            this.HelpDescriptionListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HelpDescriptionListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "叙述内容";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "显示顺位";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "显示条件";
            this.columnHeader9.Width = 200;
            // 
            // HelpDescriptionTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "HelpDescriptionTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.HelpDescriptionTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.HelpDescriptionContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage HelpDescriptionTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newHelpDescriptionButton;
        private System.Windows.Forms.Button editHelpDescriptionButton;
        private System.Windows.Forms.CheckBox showOriginalHelpDescriptionCheckBox;
        private System.Windows.Forms.Button deleteHelpDescriptionButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip HelpDescriptionContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView HelpDescriptionListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
