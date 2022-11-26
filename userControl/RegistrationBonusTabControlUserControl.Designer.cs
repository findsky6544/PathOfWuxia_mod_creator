
namespace 侠之道mod制作器
{
    partial class RegistrationBonusTabControlUserControl
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
            this.RegistrationBonusTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RegistrationBonusListView = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegistrationBonusContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newRegistrationBonusButton = new System.Windows.Forms.Button();
            this.editRegistrationBonusButton = new System.Windows.Forms.Button();
            this.showOriginalRegistrationBonusCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteRegistrationBonusButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.RegistrationBonusTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.RegistrationBonusContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistrationBonusTabPage
            // 
            this.RegistrationBonusTabPage.Controls.Add(this.panel2);
            this.RegistrationBonusTabPage.Controls.Add(this.panel1);
            this.RegistrationBonusTabPage.Location = new System.Drawing.Point(4, 22);
            this.RegistrationBonusTabPage.Name = "RegistrationBonusTabPage";
            this.RegistrationBonusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RegistrationBonusTabPage.Size = new System.Drawing.Size(838, 518);
            this.RegistrationBonusTabPage.TabIndex = 3;
            this.RegistrationBonusTabPage.Text = "RegistrationBonus     ";
            this.RegistrationBonusTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RegistrationBonusListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // RegistrationBonusListView
            // 
            this.RegistrationBonusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.RegistrationBonusListView.ContextMenuStrip = this.RegistrationBonusContextMenuStrip;
            this.RegistrationBonusListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistrationBonusListView.FullRowSelect = true;
            this.RegistrationBonusListView.HideSelection = false;
            this.RegistrationBonusListView.Location = new System.Drawing.Point(0, 0);
            this.RegistrationBonusListView.MultiSelect = false;
            this.RegistrationBonusListView.Name = "RegistrationBonusListView";
            this.RegistrationBonusListView.ShowItemToolTips = true;
            this.RegistrationBonusListView.Size = new System.Drawing.Size(832, 483);
            this.RegistrationBonusListView.TabIndex = 13;
            this.RegistrationBonusListView.UseCompatibleStateImageBehavior = false;
            this.RegistrationBonusListView.View = System.Windows.Forms.View.Details;
            this.RegistrationBonusListView.SelectedIndexChanged += new System.EventHandler(this.RegistrationBonusListView_SelectedIndexChanged);
            this.RegistrationBonusListView.DoubleClick += new System.EventHandler(this.RegistrationBonusListView_DoubleClick);
            this.RegistrationBonusListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegistrationBonusListView_KeyPress);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "描述";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "增加的四维点";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "增加的特质点";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "解锁特质";
            this.columnHeader13.Width = 400;
            // 
            // RegistrationBonusContextMenuStrip
            // 
            this.RegistrationBonusContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.RegistrationBonusContextMenuStrip.Name = "RegistrationBonusContextMenuStrip";
            this.RegistrationBonusContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newRegistrationBonusButton);
            this.panel4.Controls.Add(this.editRegistrationBonusButton);
            this.panel4.Controls.Add(this.showOriginalRegistrationBonusCheckBox);
            this.panel4.Controls.Add(this.deleteRegistrationBonusButton);
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
            // newRegistrationBonusButton
            // 
            this.newRegistrationBonusButton.Location = new System.Drawing.Point(3, 3);
            this.newRegistrationBonusButton.Name = "newRegistrationBonusButton";
            this.newRegistrationBonusButton.Size = new System.Drawing.Size(75, 23);
            this.newRegistrationBonusButton.TabIndex = 0;
            this.newRegistrationBonusButton.Text = "新增";
            this.newRegistrationBonusButton.UseVisualStyleBackColor = true;
            this.newRegistrationBonusButton.Visible = false;
            this.newRegistrationBonusButton.Click += new System.EventHandler(this.newRegistrationBonusButton_Click);
            // 
            // editRegistrationBonusButton
            // 
            this.editRegistrationBonusButton.Location = new System.Drawing.Point(84, 3);
            this.editRegistrationBonusButton.Name = "editRegistrationBonusButton";
            this.editRegistrationBonusButton.Size = new System.Drawing.Size(75, 23);
            this.editRegistrationBonusButton.TabIndex = 1;
            this.editRegistrationBonusButton.Text = "修改";
            this.editRegistrationBonusButton.UseVisualStyleBackColor = true;
            this.editRegistrationBonusButton.Click += new System.EventHandler(this.editRegistrationBonusButton_Click);
            // 
            // showOriginalRegistrationBonusCheckBox
            // 
            this.showOriginalRegistrationBonusCheckBox.AutoSize = true;
            this.showOriginalRegistrationBonusCheckBox.Checked = true;
            this.showOriginalRegistrationBonusCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalRegistrationBonusCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalRegistrationBonusCheckBox.Name = "showOriginalRegistrationBonusCheckBox";
            this.showOriginalRegistrationBonusCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalRegistrationBonusCheckBox.TabIndex = 3;
            this.showOriginalRegistrationBonusCheckBox.Text = "显示原游戏数据";
            this.showOriginalRegistrationBonusCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalRegistrationBonusCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalRegistrationBonusCheckBox_CheckedChanged);
            // 
            // deleteRegistrationBonusButton
            // 
            this.deleteRegistrationBonusButton.Location = new System.Drawing.Point(165, 3);
            this.deleteRegistrationBonusButton.Name = "deleteRegistrationBonusButton";
            this.deleteRegistrationBonusButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRegistrationBonusButton.TabIndex = 2;
            this.deleteRegistrationBonusButton.Text = "删除";
            this.deleteRegistrationBonusButton.UseVisualStyleBackColor = true;
            this.deleteRegistrationBonusButton.Click += new System.EventHandler(this.deleteRegistrationBonusButton_Click);
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
            this.CustomTabControl.Controls.Add(this.RegistrationBonusTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // RegistrationBonusTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "RegistrationBonusTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.RegistrationBonusTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.RegistrationBonusContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage RegistrationBonusTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newRegistrationBonusButton;
        private System.Windows.Forms.Button editRegistrationBonusButton;
        private System.Windows.Forms.CheckBox showOriginalRegistrationBonusCheckBox;
        private System.Windows.Forms.Button deleteRegistrationBonusButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip RegistrationBonusContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView RegistrationBonusListView;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}
