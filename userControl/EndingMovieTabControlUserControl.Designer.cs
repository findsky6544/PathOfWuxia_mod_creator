
namespace 侠之道mod制作器
{
    partial class EndingMovieTabControlUserControl
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
            this.EndingMovieTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EndingMovieListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndingMovieContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newEndingMovieButton = new System.Windows.Forms.Button();
            this.editEndingMovieButton = new System.Windows.Forms.Button();
            this.showOriginalEndingMovieCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteEndingMovieButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.EndingMovieTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.EndingMovieContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // EndingMovieTabPage
            // 
            this.EndingMovieTabPage.Controls.Add(this.panel2);
            this.EndingMovieTabPage.Controls.Add(this.panel1);
            this.EndingMovieTabPage.Location = new System.Drawing.Point(4, 22);
            this.EndingMovieTabPage.Name = "EndingMovieTabPage";
            this.EndingMovieTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EndingMovieTabPage.Size = new System.Drawing.Size(838, 518);
            this.EndingMovieTabPage.TabIndex = 3;
            this.EndingMovieTabPage.Text = "EndingMovie     ";
            this.EndingMovieTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EndingMovieListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // EndingMovieListView
            // 
            this.EndingMovieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader10,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.EndingMovieListView.ContextMenuStrip = this.EndingMovieContextMenuStrip;
            this.EndingMovieListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndingMovieListView.FullRowSelect = true;
            this.EndingMovieListView.HideSelection = false;
            this.EndingMovieListView.Location = new System.Drawing.Point(0, 0);
            this.EndingMovieListView.MultiSelect = false;
            this.EndingMovieListView.Name = "EndingMovieListView";
            this.EndingMovieListView.ShowItemToolTips = true;
            this.EndingMovieListView.Size = new System.Drawing.Size(832, 483);
            this.EndingMovieListView.TabIndex = 15;
            this.EndingMovieListView.UseCompatibleStateImageBehavior = false;
            this.EndingMovieListView.View = System.Windows.Forms.View.Details;
            this.EndingMovieListView.SelectedIndexChanged += new System.EventHandler(this.EndingMovieListView_SelectedIndexChanged);
            this.EndingMovieListView.DoubleClick += new System.EventHandler(this.EndingMovieListView_DoubleClick);
            this.EndingMovieListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndingMovieListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "备注";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "结局编号";
            this.columnHeader20.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "结局音乐";
            this.columnHeader21.Width = 150;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "条件";
            this.columnHeader22.Width = 200;
            // 
            // EndingMovieContextMenuStrip
            // 
            this.EndingMovieContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.EndingMovieContextMenuStrip.Name = "EndingMovieContextMenuStrip";
            this.EndingMovieContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newEndingMovieButton);
            this.panel4.Controls.Add(this.editEndingMovieButton);
            this.panel4.Controls.Add(this.showOriginalEndingMovieCheckBox);
            this.panel4.Controls.Add(this.deleteEndingMovieButton);
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
            // newEndingMovieButton
            // 
            this.newEndingMovieButton.Location = new System.Drawing.Point(3, 3);
            this.newEndingMovieButton.Name = "newEndingMovieButton";
            this.newEndingMovieButton.Size = new System.Drawing.Size(75, 23);
            this.newEndingMovieButton.TabIndex = 0;
            this.newEndingMovieButton.Text = "新增";
            this.newEndingMovieButton.UseVisualStyleBackColor = true;
            this.newEndingMovieButton.Click += new System.EventHandler(this.newEndingMovieButton_Click);
            // 
            // editEndingMovieButton
            // 
            this.editEndingMovieButton.Location = new System.Drawing.Point(84, 3);
            this.editEndingMovieButton.Name = "editEndingMovieButton";
            this.editEndingMovieButton.Size = new System.Drawing.Size(75, 23);
            this.editEndingMovieButton.TabIndex = 1;
            this.editEndingMovieButton.Text = "修改";
            this.editEndingMovieButton.UseVisualStyleBackColor = true;
            this.editEndingMovieButton.Click += new System.EventHandler(this.editEndingMovieButton_Click);
            // 
            // showOriginalEndingMovieCheckBox
            // 
            this.showOriginalEndingMovieCheckBox.AutoSize = true;
            this.showOriginalEndingMovieCheckBox.Checked = true;
            this.showOriginalEndingMovieCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalEndingMovieCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalEndingMovieCheckBox.Name = "showOriginalEndingMovieCheckBox";
            this.showOriginalEndingMovieCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalEndingMovieCheckBox.TabIndex = 3;
            this.showOriginalEndingMovieCheckBox.Text = "显示原游戏数据";
            this.showOriginalEndingMovieCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalEndingMovieCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalEndingMovieCheckBox_CheckedChanged);
            // 
            // deleteEndingMovieButton
            // 
            this.deleteEndingMovieButton.Location = new System.Drawing.Point(165, 3);
            this.deleteEndingMovieButton.Name = "deleteEndingMovieButton";
            this.deleteEndingMovieButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEndingMovieButton.TabIndex = 2;
            this.deleteEndingMovieButton.Text = "删除";
            this.deleteEndingMovieButton.UseVisualStyleBackColor = true;
            this.deleteEndingMovieButton.Click += new System.EventHandler(this.deleteEndingMovieButton_Click);
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
            this.CustomTabControl.Controls.Add(this.EndingMovieTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // EndingMovieTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "EndingMovieTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.EndingMovieTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.EndingMovieContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage EndingMovieTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newEndingMovieButton;
        private System.Windows.Forms.Button editEndingMovieButton;
        private System.Windows.Forms.CheckBox showOriginalEndingMovieCheckBox;
        private System.Windows.Forms.Button deleteEndingMovieButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip EndingMovieContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView EndingMovieListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
    }
}
