
namespace 侠之道mod制作器
{
    partial class TraitTabControlUserControl
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
            this.TraitTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TraitContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newTraitButton = new System.Windows.Forms.Button();
            this.editTraitButton = new System.Windows.Forms.Button();
            this.showOriginalTraitCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteTraitButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.TraitListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TraitTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TraitContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TraitTabPage
            // 
            this.TraitTabPage.Controls.Add(this.panel2);
            this.TraitTabPage.Controls.Add(this.panel1);
            this.TraitTabPage.Location = new System.Drawing.Point(4, 22);
            this.TraitTabPage.Name = "TraitTabPage";
            this.TraitTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TraitTabPage.Size = new System.Drawing.Size(838, 518);
            this.TraitTabPage.TabIndex = 3;
            this.TraitTabPage.Text = "Trait     ";
            this.TraitTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TraitListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // TraitContextMenuStrip
            // 
            this.TraitContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.TraitContextMenuStrip.Name = "TraitContextMenuStrip";
            this.TraitContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newTraitButton);
            this.panel4.Controls.Add(this.editTraitButton);
            this.panel4.Controls.Add(this.showOriginalTraitCheckBox);
            this.panel4.Controls.Add(this.deleteTraitButton);
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
            // newTraitButton
            // 
            this.newTraitButton.Location = new System.Drawing.Point(3, 3);
            this.newTraitButton.Name = "newTraitButton";
            this.newTraitButton.Size = new System.Drawing.Size(75, 23);
            this.newTraitButton.TabIndex = 0;
            this.newTraitButton.Text = "新增";
            this.newTraitButton.UseVisualStyleBackColor = true;
            this.newTraitButton.Click += new System.EventHandler(this.newTraitButton_Click);
            // 
            // editTraitButton
            // 
            this.editTraitButton.Location = new System.Drawing.Point(84, 3);
            this.editTraitButton.Name = "editTraitButton";
            this.editTraitButton.Size = new System.Drawing.Size(75, 23);
            this.editTraitButton.TabIndex = 1;
            this.editTraitButton.Text = "修改";
            this.editTraitButton.UseVisualStyleBackColor = true;
            this.editTraitButton.Click += new System.EventHandler(this.editTraitButton_Click);
            // 
            // showOriginalTraitCheckBox
            // 
            this.showOriginalTraitCheckBox.AutoSize = true;
            this.showOriginalTraitCheckBox.Checked = true;
            this.showOriginalTraitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalTraitCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalTraitCheckBox.Name = "showOriginalTraitCheckBox";
            this.showOriginalTraitCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalTraitCheckBox.TabIndex = 3;
            this.showOriginalTraitCheckBox.Text = "显示原游戏数据";
            this.showOriginalTraitCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalTraitCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalTraitCheckBox_CheckedChanged);
            // 
            // deleteTraitButton
            // 
            this.deleteTraitButton.Location = new System.Drawing.Point(165, 3);
            this.deleteTraitButton.Name = "deleteTraitButton";
            this.deleteTraitButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTraitButton.TabIndex = 2;
            this.deleteTraitButton.Text = "删除";
            this.deleteTraitButton.UseVisualStyleBackColor = true;
            this.deleteTraitButton.Click += new System.EventHandler(this.deleteTraitButton_Click);
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
            this.CustomTabControl.Controls.Add(this.TraitTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // TraitListView
            // 
            this.TraitListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.TraitListView.ContextMenuStrip = this.TraitContextMenuStrip;
            this.TraitListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TraitListView.FullRowSelect = true;
            this.TraitListView.HideSelection = false;
            this.TraitListView.Location = new System.Drawing.Point(0, 0);
            this.TraitListView.MultiSelect = false;
            this.TraitListView.Name = "TraitListView";
            this.TraitListView.ShowItemToolTips = true;
            this.TraitListView.Size = new System.Drawing.Size(832, 483);
            this.TraitListView.TabIndex = 12;
            this.TraitListView.UseCompatibleStateImageBehavior = false;
            this.TraitListView.View = System.Windows.Forms.View.Details;
            this.TraitListView.SelectedIndexChanged += new System.EventHandler(this.TraitListView_SelectedIndexChanged);
            this.TraitListView.DoubleClick += new System.EventHandler(this.TraitListView_DoubleClick);
            this.TraitListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TraitListView_KeyPress);
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "描述";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "是否为初始特质";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "点数消耗";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "特质连锁条件";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "特质连锁添加";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "特质初始奖励（奖励编号）";
            this.columnHeader11.Width = 200;
            // 
            // TraitTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "TraitTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.TraitTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.TraitContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TraitTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newTraitButton;
        private System.Windows.Forms.Button editTraitButton;
        private System.Windows.Forms.CheckBox showOriginalTraitCheckBox;
        private System.Windows.Forms.Button deleteTraitButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip TraitContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView TraitListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}
