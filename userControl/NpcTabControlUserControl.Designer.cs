
namespace 侠之道mod制作器
{
    partial class NpcTabControlUserControl
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
            this.NpcTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NpcContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newNpcButton = new System.Windows.Forms.Button();
            this.editNpcButton = new System.Windows.Forms.Button();
            this.showOriginalNpcCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteNpcButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.NpcListView = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NpcTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.NpcContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // NpcTabPage
            // 
            this.NpcTabPage.Controls.Add(this.panel2);
            this.NpcTabPage.Controls.Add(this.panel1);
            this.NpcTabPage.Location = new System.Drawing.Point(4, 22);
            this.NpcTabPage.Name = "NpcTabPage";
            this.NpcTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NpcTabPage.Size = new System.Drawing.Size(838, 518);
            this.NpcTabPage.TabIndex = 3;
            this.NpcTabPage.Text = "Npc     ";
            this.NpcTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NpcListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // NpcContextMenuStrip
            // 
            this.NpcContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.NpcContextMenuStrip.Name = "NpcContextMenuStrip";
            this.NpcContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newNpcButton);
            this.panel4.Controls.Add(this.editNpcButton);
            this.panel4.Controls.Add(this.showOriginalNpcCheckBox);
            this.panel4.Controls.Add(this.deleteNpcButton);
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
            // newNpcButton
            // 
            this.newNpcButton.Location = new System.Drawing.Point(3, 3);
            this.newNpcButton.Name = "newNpcButton";
            this.newNpcButton.Size = new System.Drawing.Size(75, 23);
            this.newNpcButton.TabIndex = 0;
            this.newNpcButton.Text = "新增";
            this.newNpcButton.UseVisualStyleBackColor = true;
            this.newNpcButton.Click += new System.EventHandler(this.newNpcButton_Click);
            // 
            // editNpcButton
            // 
            this.editNpcButton.Location = new System.Drawing.Point(84, 3);
            this.editNpcButton.Name = "editNpcButton";
            this.editNpcButton.Size = new System.Drawing.Size(75, 23);
            this.editNpcButton.TabIndex = 1;
            this.editNpcButton.Text = "修改";
            this.editNpcButton.UseVisualStyleBackColor = true;
            this.editNpcButton.Click += new System.EventHandler(this.editNpcButton_Click);
            // 
            // showOriginalNpcCheckBox
            // 
            this.showOriginalNpcCheckBox.AutoSize = true;
            this.showOriginalNpcCheckBox.Checked = true;
            this.showOriginalNpcCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalNpcCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalNpcCheckBox.Name = "showOriginalNpcCheckBox";
            this.showOriginalNpcCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalNpcCheckBox.TabIndex = 3;
            this.showOriginalNpcCheckBox.Text = "显示原游戏数据";
            this.showOriginalNpcCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalNpcCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalNpcCheckBox_CheckedChanged);
            // 
            // deleteNpcButton
            // 
            this.deleteNpcButton.Location = new System.Drawing.Point(165, 3);
            this.deleteNpcButton.Name = "deleteNpcButton";
            this.deleteNpcButton.Size = new System.Drawing.Size(75, 23);
            this.deleteNpcButton.TabIndex = 2;
            this.deleteNpcButton.Text = "删除";
            this.deleteNpcButton.UseVisualStyleBackColor = true;
            this.deleteNpcButton.Click += new System.EventHandler(this.deleteNpcButton_Click);
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
            this.CustomTabControl.Controls.Add(this.NpcTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // NpcListView
            // 
            this.NpcListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.NpcListView.ContextMenuStrip = this.NpcContextMenuStrip;
            this.NpcListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NpcListView.FullRowSelect = true;
            this.NpcListView.HideSelection = false;
            this.NpcListView.Location = new System.Drawing.Point(0, 0);
            this.NpcListView.MultiSelect = false;
            this.NpcListView.Name = "NpcListView";
            this.NpcListView.ShowItemToolTips = true;
            this.NpcListView.Size = new System.Drawing.Size(832, 483);
            this.NpcListView.TabIndex = 13;
            this.NpcListView.UseCompatibleStateImageBehavior = false;
            this.NpcListView.View = System.Windows.Forms.View.Details;
            this.NpcListView.SelectedIndexChanged += new System.EventHandler(this.NpcListView_SelectedIndexChanged);
            this.NpcListView.DoubleClick += new System.EventHandler(this.NpcListView_DoubleClick);
            this.NpcListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NpcListView_KeyPress);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 2;
            this.columnHeader9.Text = "名称";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 1;
            this.columnHeader11.Text = "备注";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "角色咨询编号";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "角色外观编号";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "是否可以被穿越";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "行为编号";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "互动界面出现高度";
            // 
            // NpcTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "NpcTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.NpcTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.NpcContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage NpcTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newNpcButton;
        private System.Windows.Forms.Button editNpcButton;
        private System.Windows.Forms.CheckBox showOriginalNpcCheckBox;
        private System.Windows.Forms.Button deleteNpcButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip NpcContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView NpcListView;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
    }
}
