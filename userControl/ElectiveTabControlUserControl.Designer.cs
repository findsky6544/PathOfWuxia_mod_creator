
namespace 侠之道mod制作器
{
    partial class ElectiveTabControlUserControl
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
            this.ElectiveTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ElectiveListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ElectiveContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newElectiveButton = new System.Windows.Forms.Button();
            this.editElectiveButton = new System.Windows.Forms.Button();
            this.showOriginalElectiveCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteElectiveButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.ElectiveTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ElectiveContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElectiveTabPage
            // 
            this.ElectiveTabPage.Controls.Add(this.panel2);
            this.ElectiveTabPage.Controls.Add(this.panel1);
            this.ElectiveTabPage.Location = new System.Drawing.Point(4, 22);
            this.ElectiveTabPage.Name = "ElectiveTabPage";
            this.ElectiveTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ElectiveTabPage.Size = new System.Drawing.Size(838, 518);
            this.ElectiveTabPage.TabIndex = 3;
            this.ElectiveTabPage.Text = "Elective     ";
            this.ElectiveTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ElectiveListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // ElectiveListView
            // 
            this.ElectiveListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader26,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
            this.ElectiveListView.ContextMenuStrip = this.ElectiveContextMenuStrip;
            this.ElectiveListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElectiveListView.FullRowSelect = true;
            this.ElectiveListView.HideSelection = false;
            this.ElectiveListView.Location = new System.Drawing.Point(0, 0);
            this.ElectiveListView.MultiSelect = false;
            this.ElectiveListView.Name = "ElectiveListView";
            this.ElectiveListView.ShowItemToolTips = true;
            this.ElectiveListView.Size = new System.Drawing.Size(832, 483);
            this.ElectiveListView.TabIndex = 15;
            this.ElectiveListView.UseCompatibleStateImageBehavior = false;
            this.ElectiveListView.View = System.Windows.Forms.View.Details;
            this.ElectiveListView.SelectedIndexChanged += new System.EventHandler(this.ElectiveListView_SelectedIndexChanged);
            this.ElectiveListView.DoubleClick += new System.EventHandler(this.ElectiveListView_DoubleClick);
            this.ElectiveListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ElectiveListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "备注";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "授课教师编号";
            this.columnHeader20.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "描述";
            this.columnHeader21.Width = 200;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "阶段";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "条件描述";
            this.columnHeader23.Width = 200;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "条件";
            this.columnHeader24.Width = 200;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "是否重复开启";
            this.columnHeader25.Width = 100;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "可习得招式编号";
            this.columnHeader26.Width = 200;
            // 
            // ElectiveContextMenuStrip
            // 
            this.ElectiveContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.ElectiveContextMenuStrip.Name = "ElectiveContextMenuStrip";
            this.ElectiveContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newElectiveButton);
            this.panel4.Controls.Add(this.editElectiveButton);
            this.panel4.Controls.Add(this.showOriginalElectiveCheckBox);
            this.panel4.Controls.Add(this.deleteElectiveButton);
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
            // newElectiveButton
            // 
            this.newElectiveButton.Location = new System.Drawing.Point(3, 3);
            this.newElectiveButton.Name = "newElectiveButton";
            this.newElectiveButton.Size = new System.Drawing.Size(75, 23);
            this.newElectiveButton.TabIndex = 0;
            this.newElectiveButton.Text = "新增";
            this.newElectiveButton.UseVisualStyleBackColor = true;
            this.newElectiveButton.Click += new System.EventHandler(this.newElectiveButton_Click);
            // 
            // editElectiveButton
            // 
            this.editElectiveButton.Location = new System.Drawing.Point(84, 3);
            this.editElectiveButton.Name = "editElectiveButton";
            this.editElectiveButton.Size = new System.Drawing.Size(75, 23);
            this.editElectiveButton.TabIndex = 1;
            this.editElectiveButton.Text = "修改";
            this.editElectiveButton.UseVisualStyleBackColor = true;
            this.editElectiveButton.Click += new System.EventHandler(this.editElectiveButton_Click);
            // 
            // showOriginalElectiveCheckBox
            // 
            this.showOriginalElectiveCheckBox.AutoSize = true;
            this.showOriginalElectiveCheckBox.Checked = true;
            this.showOriginalElectiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalElectiveCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalElectiveCheckBox.Name = "showOriginalElectiveCheckBox";
            this.showOriginalElectiveCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalElectiveCheckBox.TabIndex = 3;
            this.showOriginalElectiveCheckBox.Text = "显示原游戏数据";
            this.showOriginalElectiveCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalElectiveCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalElectiveCheckBox_CheckedChanged);
            // 
            // deleteElectiveButton
            // 
            this.deleteElectiveButton.Location = new System.Drawing.Point(165, 3);
            this.deleteElectiveButton.Name = "deleteElectiveButton";
            this.deleteElectiveButton.Size = new System.Drawing.Size(75, 23);
            this.deleteElectiveButton.TabIndex = 2;
            this.deleteElectiveButton.Text = "删除";
            this.deleteElectiveButton.UseVisualStyleBackColor = true;
            this.deleteElectiveButton.Click += new System.EventHandler(this.deleteElectiveButton_Click);
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
            this.CustomTabControl.Controls.Add(this.ElectiveTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // ElectiveTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "ElectiveTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.ElectiveTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ElectiveContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ElectiveTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newElectiveButton;
        private System.Windows.Forms.Button editElectiveButton;
        private System.Windows.Forms.CheckBox showOriginalElectiveCheckBox;
        private System.Windows.Forms.Button deleteElectiveButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip ElectiveContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView ElectiveListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
    }
}
