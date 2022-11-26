
namespace 侠之道mod制作器
{
    partial class BufferTabControlUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BufferTabControlUserControl));
            this.bufferTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bufferListView = new UserListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bufferContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bufferImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newBufferButton = new System.Windows.Forms.Button();
            this.editBufferButton = new System.Windows.Forms.Button();
            this.showOriginalBufferCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteBufferButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.bufferTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.bufferContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bufferTabPage
            // 
            this.bufferTabPage.Controls.Add(this.panel2);
            this.bufferTabPage.Controls.Add(this.panel1);
            this.bufferTabPage.Location = new System.Drawing.Point(4, 22);
            this.bufferTabPage.Name = "bufferTabPage";
            this.bufferTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.bufferTabPage.Size = new System.Drawing.Size(838, 518);
            this.bufferTabPage.TabIndex = 3;
            this.bufferTabPage.Text = "buffer     ";
            this.bufferTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bufferListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // bufferListView
            // 
            this.bufferListView.AllowColumnReorder = true;
            this.bufferListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.bufferListView.ContextMenuStrip = this.bufferContextMenuStrip;
            this.bufferListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufferListView.FullRowSelect = true;
            this.bufferListView.HideSelection = false;
            this.bufferListView.Location = new System.Drawing.Point(0, 0);
            this.bufferListView.MultiSelect = false;
            this.bufferListView.Name = "bufferListView";
            this.bufferListView.ShowItemToolTips = true;
            this.bufferListView.Size = new System.Drawing.Size(832, 483);
            this.bufferListView.SmallImageList = this.bufferImageList;
            this.bufferListView.TabIndex = 0;
            this.bufferListView.UseCompatibleStateImageBehavior = false;
            this.bufferListView.View = System.Windows.Forms.View.Details;
            this.bufferListView.SelectedIndexChanged += new System.EventHandler(this.bufferListView_SelectedIndexChanged);
            this.bufferListView.DoubleClick += new System.EventHandler(this.bufferListView_DoubleClick);
            this.bufferListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bufferListView_KeyPress);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "图片";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "描述";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "效果面向";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "持续作用次数";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "叠加层数";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "增益效果";
            // 
            // bufferContextMenuStrip
            // 
            this.bufferContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.bufferContextMenuStrip.Name = "bufferContextMenuStrip";
            this.bufferContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            // bufferImageList
            // 
            this.bufferImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bufferImageList.ImageStream")));
            this.bufferImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bufferImageList.Images.SetKeyName(0, "buff_critical");
            this.bufferImageList.Images.SetKeyName(1, "buff_damage");
            this.bufferImageList.Images.SetKeyName(2, "buff_dodge");
            this.bufferImageList.Images.SetKeyName(3, "buff_fury");
            this.bufferImageList.Images.SetKeyName(4, "buff_hp");
            this.bufferImageList.Images.SetKeyName(5, "buff_move");
            this.bufferImageList.Images.SetKeyName(6, "buff_mp");
            this.bufferImageList.Images.SetKeyName(7, "buff_parry");
            this.bufferImageList.Images.SetKeyName(8, "buff_trait");
            this.bufferImageList.Images.SetKeyName(9, "buff_xingfa");
            this.bufferImageList.Images.SetKeyName(10, "debuff_critical");
            this.bufferImageList.Images.SetKeyName(11, "debuff_damage");
            this.bufferImageList.Images.SetKeyName(12, "debuff_dodge");
            this.bufferImageList.Images.SetKeyName(13, "debuff_hp");
            this.bufferImageList.Images.SetKeyName(14, "debuff_move");
            this.bufferImageList.Images.SetKeyName(15, "debuff_mp");
            this.bufferImageList.Images.SetKeyName(16, "debuff_parry");
            this.bufferImageList.Images.SetKeyName(17, "debuff_poison");
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
            this.panel4.Controls.Add(this.newBufferButton);
            this.panel4.Controls.Add(this.editBufferButton);
            this.panel4.Controls.Add(this.showOriginalBufferCheckBox);
            this.panel4.Controls.Add(this.deleteBufferButton);
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
            // newBufferButton
            // 
            this.newBufferButton.Location = new System.Drawing.Point(3, 3);
            this.newBufferButton.Name = "newBufferButton";
            this.newBufferButton.Size = new System.Drawing.Size(75, 23);
            this.newBufferButton.TabIndex = 0;
            this.newBufferButton.Text = "新增";
            this.newBufferButton.UseVisualStyleBackColor = true;
            this.newBufferButton.Click += new System.EventHandler(this.newBufferButton_Click);
            // 
            // editBufferButton
            // 
            this.editBufferButton.Location = new System.Drawing.Point(84, 3);
            this.editBufferButton.Name = "editBufferButton";
            this.editBufferButton.Size = new System.Drawing.Size(75, 23);
            this.editBufferButton.TabIndex = 1;
            this.editBufferButton.Text = "修改";
            this.editBufferButton.UseVisualStyleBackColor = true;
            this.editBufferButton.Click += new System.EventHandler(this.editBufferButton_Click);
            // 
            // showOriginalBufferCheckBox
            // 
            this.showOriginalBufferCheckBox.AutoSize = true;
            this.showOriginalBufferCheckBox.Checked = true;
            this.showOriginalBufferCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalBufferCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalBufferCheckBox.Name = "showOriginalBufferCheckBox";
            this.showOriginalBufferCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalBufferCheckBox.TabIndex = 3;
            this.showOriginalBufferCheckBox.Text = "显示原游戏数据";
            this.showOriginalBufferCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalBufferCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalBufferCheckBox_CheckedChanged);
            // 
            // deleteBufferButton
            // 
            this.deleteBufferButton.Location = new System.Drawing.Point(165, 3);
            this.deleteBufferButton.Name = "deleteBufferButton";
            this.deleteBufferButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBufferButton.TabIndex = 2;
            this.deleteBufferButton.Text = "删除";
            this.deleteBufferButton.UseVisualStyleBackColor = true;
            this.deleteBufferButton.Click += new System.EventHandler(this.deleteBufferButton_Click);
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
            this.CustomTabControl.Controls.Add(this.bufferTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // BufferTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "BufferTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.bufferTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.bufferContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage bufferTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView bufferListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newBufferButton;
        private System.Windows.Forms.Button editBufferButton;
        private System.Windows.Forms.CheckBox showOriginalBufferCheckBox;
        private System.Windows.Forms.Button deleteBufferButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.ImageList bufferImageList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip bufferContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
