
namespace 侠之道mod制作器
{
    partial class FavorabilityTabControlUserControl
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
            this.FavorabilityTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FavorabilityListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FavorabilityContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newFavorabilityButton = new System.Windows.Forms.Button();
            this.editFavorabilityButton = new System.Windows.Forms.Button();
            this.showOriginalFavorabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteFavorabilityButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.FavorabilityTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.FavorabilityContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // FavorabilityTabPage
            // 
            this.FavorabilityTabPage.Controls.Add(this.panel2);
            this.FavorabilityTabPage.Controls.Add(this.panel1);
            this.FavorabilityTabPage.Location = new System.Drawing.Point(4, 22);
            this.FavorabilityTabPage.Name = "FavorabilityTabPage";
            this.FavorabilityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FavorabilityTabPage.Size = new System.Drawing.Size(838, 518);
            this.FavorabilityTabPage.TabIndex = 3;
            this.FavorabilityTabPage.Text = "Favorability     ";
            this.FavorabilityTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FavorabilityListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // FavorabilityListView
            // 
            this.FavorabilityListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.FavorabilityListView.ContextMenuStrip = this.FavorabilityContextMenuStrip;
            this.FavorabilityListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FavorabilityListView.FullRowSelect = true;
            this.FavorabilityListView.HideSelection = false;
            this.FavorabilityListView.Location = new System.Drawing.Point(0, 0);
            this.FavorabilityListView.MultiSelect = false;
            this.FavorabilityListView.Name = "FavorabilityListView";
            this.FavorabilityListView.ShowItemToolTips = true;
            this.FavorabilityListView.Size = new System.Drawing.Size(832, 483);
            this.FavorabilityListView.TabIndex = 13;
            this.FavorabilityListView.UseCompatibleStateImageBehavior = false;
            this.FavorabilityListView.View = System.Windows.Forms.View.Details;
            this.FavorabilityListView.SelectedIndexChanged += new System.EventHandler(this.FavorabilityListView_SelectedIndexChanged);
            this.FavorabilityListView.DoubleClick += new System.EventHandler(this.FavorabilityListView_DoubleClick);
            this.FavorabilityListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FavorabilityListView_KeyPress);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ID";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "名称";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "备注";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "描述";
            this.columnHeader10.Width = 400;
            // 
            // FavorabilityContextMenuStrip
            // 
            this.FavorabilityContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.FavorabilityContextMenuStrip.Name = "FavorabilityContextMenuStrip";
            this.FavorabilityContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newFavorabilityButton);
            this.panel4.Controls.Add(this.editFavorabilityButton);
            this.panel4.Controls.Add(this.showOriginalFavorabilityCheckBox);
            this.panel4.Controls.Add(this.deleteFavorabilityButton);
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
            // newFavorabilityButton
            // 
            this.newFavorabilityButton.Location = new System.Drawing.Point(3, 3);
            this.newFavorabilityButton.Name = "newFavorabilityButton";
            this.newFavorabilityButton.Size = new System.Drawing.Size(75, 23);
            this.newFavorabilityButton.TabIndex = 0;
            this.newFavorabilityButton.Text = "新增";
            this.newFavorabilityButton.UseVisualStyleBackColor = true;
            this.newFavorabilityButton.Click += new System.EventHandler(this.newFavorabilityButton_Click);
            // 
            // editFavorabilityButton
            // 
            this.editFavorabilityButton.Location = new System.Drawing.Point(84, 3);
            this.editFavorabilityButton.Name = "editFavorabilityButton";
            this.editFavorabilityButton.Size = new System.Drawing.Size(75, 23);
            this.editFavorabilityButton.TabIndex = 1;
            this.editFavorabilityButton.Text = "修改";
            this.editFavorabilityButton.UseVisualStyleBackColor = true;
            this.editFavorabilityButton.Click += new System.EventHandler(this.editFavorabilityButton_Click);
            // 
            // showOriginalFavorabilityCheckBox
            // 
            this.showOriginalFavorabilityCheckBox.AutoSize = true;
            this.showOriginalFavorabilityCheckBox.Checked = true;
            this.showOriginalFavorabilityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalFavorabilityCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalFavorabilityCheckBox.Name = "showOriginalFavorabilityCheckBox";
            this.showOriginalFavorabilityCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalFavorabilityCheckBox.TabIndex = 3;
            this.showOriginalFavorabilityCheckBox.Text = "显示原游戏数据";
            this.showOriginalFavorabilityCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalFavorabilityCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalFavorabilityCheckBox_CheckedChanged);
            // 
            // deleteFavorabilityButton
            // 
            this.deleteFavorabilityButton.Location = new System.Drawing.Point(165, 3);
            this.deleteFavorabilityButton.Name = "deleteFavorabilityButton";
            this.deleteFavorabilityButton.Size = new System.Drawing.Size(75, 23);
            this.deleteFavorabilityButton.TabIndex = 2;
            this.deleteFavorabilityButton.Text = "删除";
            this.deleteFavorabilityButton.UseVisualStyleBackColor = true;
            this.deleteFavorabilityButton.Click += new System.EventHandler(this.deleteFavorabilityButton_Click);
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
            this.CustomTabControl.Controls.Add(this.FavorabilityTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // FavorabilityTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "FavorabilityTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.FavorabilityTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.FavorabilityContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage FavorabilityTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newFavorabilityButton;
        private System.Windows.Forms.Button editFavorabilityButton;
        private System.Windows.Forms.CheckBox showOriginalFavorabilityCheckBox;
        private System.Windows.Forms.Button deleteFavorabilityButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip FavorabilityContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView FavorabilityListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}
