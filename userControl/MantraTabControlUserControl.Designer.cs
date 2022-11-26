
namespace 侠之道mod制作器
{
    partial class MantraTabControlUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantraTabControlUserControl));
            this.MantraTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MantraContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newMantraButton = new System.Windows.Forms.Button();
            this.editMantraButton = new System.Windows.Forms.Button();
            this.showOriginalMantraCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteMantraButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.MantraImageList = new System.Windows.Forms.ImageList(this.components);
            this.MantraListView = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MantraTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MantraContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MantraTabPage
            // 
            this.MantraTabPage.Controls.Add(this.panel2);
            this.MantraTabPage.Controls.Add(this.panel1);
            this.MantraTabPage.Location = new System.Drawing.Point(4, 22);
            this.MantraTabPage.Name = "MantraTabPage";
            this.MantraTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MantraTabPage.Size = new System.Drawing.Size(838, 518);
            this.MantraTabPage.TabIndex = 3;
            this.MantraTabPage.Text = "Mantra     ";
            this.MantraTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MantraListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // MantraContextMenuStrip
            // 
            this.MantraContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.MantraContextMenuStrip.Name = "MantraContextMenuStrip";
            this.MantraContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newMantraButton);
            this.panel4.Controls.Add(this.editMantraButton);
            this.panel4.Controls.Add(this.showOriginalMantraCheckBox);
            this.panel4.Controls.Add(this.deleteMantraButton);
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
            // newMantraButton
            // 
            this.newMantraButton.Location = new System.Drawing.Point(3, 3);
            this.newMantraButton.Name = "newMantraButton";
            this.newMantraButton.Size = new System.Drawing.Size(75, 23);
            this.newMantraButton.TabIndex = 0;
            this.newMantraButton.Text = "新增";
            this.newMantraButton.UseVisualStyleBackColor = true;
            this.newMantraButton.Click += new System.EventHandler(this.newMantraButton_Click);
            // 
            // editMantraButton
            // 
            this.editMantraButton.Location = new System.Drawing.Point(84, 3);
            this.editMantraButton.Name = "editMantraButton";
            this.editMantraButton.Size = new System.Drawing.Size(75, 23);
            this.editMantraButton.TabIndex = 1;
            this.editMantraButton.Text = "修改";
            this.editMantraButton.UseVisualStyleBackColor = true;
            this.editMantraButton.Click += new System.EventHandler(this.editMantraButton_Click);
            // 
            // showOriginalMantraCheckBox
            // 
            this.showOriginalMantraCheckBox.AutoSize = true;
            this.showOriginalMantraCheckBox.Checked = true;
            this.showOriginalMantraCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalMantraCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalMantraCheckBox.Name = "showOriginalMantraCheckBox";
            this.showOriginalMantraCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalMantraCheckBox.TabIndex = 3;
            this.showOriginalMantraCheckBox.Text = "显示原游戏数据";
            this.showOriginalMantraCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalMantraCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalMantraCheckBox_CheckedChanged);
            // 
            // deleteMantraButton
            // 
            this.deleteMantraButton.Location = new System.Drawing.Point(165, 3);
            this.deleteMantraButton.Name = "deleteMantraButton";
            this.deleteMantraButton.Size = new System.Drawing.Size(75, 23);
            this.deleteMantraButton.TabIndex = 2;
            this.deleteMantraButton.Text = "删除";
            this.deleteMantraButton.UseVisualStyleBackColor = true;
            this.deleteMantraButton.Click += new System.EventHandler(this.deleteMantraButton_Click);
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
            this.CustomTabControl.Controls.Add(this.MantraTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // MantraImageList
            // 
            this.MantraImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MantraImageList.ImageStream")));
            this.MantraImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MantraImageList.Images.SetKeyName(0, "xi_000_fanyong");
            // 
            // MantraListView
            // 
            this.MantraListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10});
            this.MantraListView.ContextMenuStrip = this.MantraContextMenuStrip;
            this.MantraListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MantraListView.FullRowSelect = true;
            this.MantraListView.HideSelection = false;
            this.MantraListView.Location = new System.Drawing.Point(0, 0);
            this.MantraListView.MultiSelect = false;
            this.MantraListView.Name = "MantraListView";
            this.MantraListView.ShowItemToolTips = true;
            this.MantraListView.Size = new System.Drawing.Size(832, 483);
            this.MantraListView.SmallImageList = this.MantraImageList;
            this.MantraListView.TabIndex = 12;
            this.MantraListView.UseCompatibleStateImageBehavior = false;
            this.MantraListView.View = System.Windows.Forms.View.Details;
            this.MantraListView.SelectedIndexChanged += new System.EventHandler(this.MantraListView_SelectedIndexChanged);
            this.MantraListView.DoubleClick += new System.EventHandler(this.MantraListView_DoubleClick);
            this.MantraListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MantraListView_KeyPress);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "图标";
            this.columnHeader8.Width = 100;
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
            this.columnHeader6.Text = "基本功需求四维";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "基本功需求值";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "运行效果描述";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "修炼效果描述";
            // 
            // MantraTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "MantraTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.MantraTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MantraContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage MantraTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newMantraButton;
        private System.Windows.Forms.Button editMantraButton;
        private System.Windows.Forms.CheckBox showOriginalMantraCheckBox;
        private System.Windows.Forms.Button deleteMantraButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip MantraContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ImageList MantraImageList;
        private System.Windows.Forms.ListView MantraListView;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}
