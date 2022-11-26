
namespace 侠之道mod制作器
{
    partial class AlchemyTabControlUserControl
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
            this.AlchemyTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AlchemyListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newAlchemyButton = new System.Windows.Forms.Button();
            this.editAlchemyButton = new System.Windows.Forms.Button();
            this.showOriginalAlchemyCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteAlchemyButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.AlchemyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.AlchemyTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.AlchemyContextMenuStrip.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AlchemyTabPage
            // 
            this.AlchemyTabPage.Controls.Add(this.panel2);
            this.AlchemyTabPage.Controls.Add(this.panel1);
            this.AlchemyTabPage.Location = new System.Drawing.Point(4, 22);
            this.AlchemyTabPage.Name = "AlchemyTabPage";
            this.AlchemyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AlchemyTabPage.Size = new System.Drawing.Size(838, 518);
            this.AlchemyTabPage.TabIndex = 3;
            this.AlchemyTabPage.Text = "Alchemy     ";
            this.AlchemyTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AlchemyListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // AlchemyListView
            // 
            this.AlchemyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.AlchemyListView.ContextMenuStrip = this.AlchemyContextMenuStrip;
            this.AlchemyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlchemyListView.FullRowSelect = true;
            this.AlchemyListView.HideSelection = false;
            this.AlchemyListView.Location = new System.Drawing.Point(0, 0);
            this.AlchemyListView.MultiSelect = false;
            this.AlchemyListView.Name = "AlchemyListView";
            this.AlchemyListView.ShowItemToolTips = true;
            this.AlchemyListView.Size = new System.Drawing.Size(832, 483);
            this.AlchemyListView.TabIndex = 12;
            this.AlchemyListView.UseCompatibleStateImageBehavior = false;
            this.AlchemyListView.View = System.Windows.Forms.View.Details;
            this.AlchemyListView.SelectedIndexChanged += new System.EventHandler(this.AlchemyListView_SelectedIndexChanged);
            this.AlchemyListView.DoubleClick += new System.EventHandler(this.AlchemyListView_DoubleClick);
            this.AlchemyListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlchemyListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "炼制药品";
            this.columnHeader3.Width = 200;
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
            this.panel4.Controls.Add(this.newAlchemyButton);
            this.panel4.Controls.Add(this.editAlchemyButton);
            this.panel4.Controls.Add(this.showOriginalAlchemyCheckBox);
            this.panel4.Controls.Add(this.deleteAlchemyButton);
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
            // newAlchemyButton
            // 
            this.newAlchemyButton.Location = new System.Drawing.Point(3, 3);
            this.newAlchemyButton.Name = "newAlchemyButton";
            this.newAlchemyButton.Size = new System.Drawing.Size(75, 23);
            this.newAlchemyButton.TabIndex = 0;
            this.newAlchemyButton.Text = "新增";
            this.newAlchemyButton.UseVisualStyleBackColor = true;
            this.newAlchemyButton.Click += new System.EventHandler(this.newAlchemyButton_Click);
            // 
            // editAlchemyButton
            // 
            this.editAlchemyButton.Location = new System.Drawing.Point(84, 3);
            this.editAlchemyButton.Name = "editAlchemyButton";
            this.editAlchemyButton.Size = new System.Drawing.Size(75, 23);
            this.editAlchemyButton.TabIndex = 1;
            this.editAlchemyButton.Text = "修改";
            this.editAlchemyButton.UseVisualStyleBackColor = true;
            this.editAlchemyButton.Click += new System.EventHandler(this.editAlchemyButton_Click);
            // 
            // showOriginalAlchemyCheckBox
            // 
            this.showOriginalAlchemyCheckBox.AutoSize = true;
            this.showOriginalAlchemyCheckBox.Checked = true;
            this.showOriginalAlchemyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalAlchemyCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalAlchemyCheckBox.Name = "showOriginalAlchemyCheckBox";
            this.showOriginalAlchemyCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalAlchemyCheckBox.TabIndex = 3;
            this.showOriginalAlchemyCheckBox.Text = "显示原游戏数据";
            this.showOriginalAlchemyCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalAlchemyCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalAlchemyCheckBox_CheckedChanged);
            // 
            // deleteAlchemyButton
            // 
            this.deleteAlchemyButton.Location = new System.Drawing.Point(165, 3);
            this.deleteAlchemyButton.Name = "deleteAlchemyButton";
            this.deleteAlchemyButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAlchemyButton.TabIndex = 2;
            this.deleteAlchemyButton.Text = "删除";
            this.deleteAlchemyButton.UseVisualStyleBackColor = true;
            this.deleteAlchemyButton.Click += new System.EventHandler(this.deleteAlchemyButton_Click);
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
            this.searchButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // AlchemyContextMenuStrip
            // 
            this.AlchemyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.AlchemyContextMenuStrip.Name = "AlchemyContextMenuStrip";
            this.AlchemyContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            // CustomTabControl
            // 
            this.CustomTabControl.Controls.Add(this.AlchemyTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // AlchemyTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "AlchemyTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.AlchemyTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.AlchemyContextMenuStrip.ResumeLayout(false);
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage AlchemyTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newAlchemyButton;
        private System.Windows.Forms.Button editAlchemyButton;
        private System.Windows.Forms.CheckBox showOriginalAlchemyCheckBox;
        private System.Windows.Forms.Button deleteAlchemyButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip AlchemyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView AlchemyListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
