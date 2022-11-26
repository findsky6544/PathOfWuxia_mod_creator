
namespace 侠之道mod制作器
{
    partial class PropsTabControlUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropsTabControlUserControl));
            this.PropsTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PropsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropsImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newPropsButton = new System.Windows.Forms.Button();
            this.editPropsButton = new System.Windows.Forms.Button();
            this.showOriginalPropsCheckBox = new System.Windows.Forms.CheckBox();
            this.deletePropsButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.PropsListView = new 侠之道mod制作器.UserListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PropsTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PropsContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropsTabPage
            // 
            this.PropsTabPage.Controls.Add(this.panel2);
            this.PropsTabPage.Controls.Add(this.panel1);
            this.PropsTabPage.Location = new System.Drawing.Point(4, 22);
            this.PropsTabPage.Name = "PropsTabPage";
            this.PropsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PropsTabPage.Size = new System.Drawing.Size(838, 518);
            this.PropsTabPage.TabIndex = 3;
            this.PropsTabPage.Text = "Props     ";
            this.PropsTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PropsListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // PropsContextMenuStrip
            // 
            this.PropsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.PropsContextMenuStrip.Name = "PropsContextMenuStrip";
            this.PropsContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            // PropsImageList
            // 
            this.PropsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PropsImageList.ImageStream")));
            this.PropsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.PropsImageList.Images.SetKeyName(0, "PropsCategory000");
            this.PropsImageList.Images.SetKeyName(1, "PropsCategory101");
            this.PropsImageList.Images.SetKeyName(2, "PropsCategory102");
            this.PropsImageList.Images.SetKeyName(3, "PropsCategory103");
            this.PropsImageList.Images.SetKeyName(4, "PropsCategory104");
            this.PropsImageList.Images.SetKeyName(5, "PropsCategory105");
            this.PropsImageList.Images.SetKeyName(6, "PropsCategory106");
            this.PropsImageList.Images.SetKeyName(7, "PropsCategory107");
            this.PropsImageList.Images.SetKeyName(8, "PropsCategory108");
            this.PropsImageList.Images.SetKeyName(9, "PropsCategory109");
            this.PropsImageList.Images.SetKeyName(10, "PropsCategory201");
            this.PropsImageList.Images.SetKeyName(11, "PropsCategory301");
            this.PropsImageList.Images.SetKeyName(12, "PropsCategory401");
            this.PropsImageList.Images.SetKeyName(13, "PropsCategory402");
            this.PropsImageList.Images.SetKeyName(14, "PropsCategory403");
            this.PropsImageList.Images.SetKeyName(15, "PropsCategory404");
            this.PropsImageList.Images.SetKeyName(16, "PropsCategory405");
            this.PropsImageList.Images.SetKeyName(17, "PropsCategory406");
            this.PropsImageList.Images.SetKeyName(18, "PropsCategory407");
            this.PropsImageList.Images.SetKeyName(19, "PropsCategory408");
            this.PropsImageList.Images.SetKeyName(20, "PropsCategory409");
            this.PropsImageList.Images.SetKeyName(21, "PropsCategory411");
            this.PropsImageList.Images.SetKeyName(22, "PropsCategory412");
            this.PropsImageList.Images.SetKeyName(23, "PropsCategory413");
            this.PropsImageList.Images.SetKeyName(24, "PropsCategory414");
            this.PropsImageList.Images.SetKeyName(25, "PropsCategory415");
            this.PropsImageList.Images.SetKeyName(26, "PropsCategory416");
            this.PropsImageList.Images.SetKeyName(27, "PropsCategory417");
            this.PropsImageList.Images.SetKeyName(28, "PropsCategory418");
            this.PropsImageList.Images.SetKeyName(29, "PropsCategory419");
            this.PropsImageList.Images.SetKeyName(30, "PropsCategory501");
            this.PropsImageList.Images.SetKeyName(31, "PropsCategory502");
            this.PropsImageList.Images.SetKeyName(32, "PropsCategory601");
            this.PropsImageList.Images.SetKeyName(33, "PropsCategory602");
            this.PropsImageList.Images.SetKeyName(34, "PropsCategory603");
            this.PropsImageList.Images.SetKeyName(35, "PropsCategory604");
            this.PropsImageList.Images.SetKeyName(36, "PropsCategory605");
            this.PropsImageList.Images.SetKeyName(37, "PropsCategory606");
            this.PropsImageList.Images.SetKeyName(38, "PropsCategory701");
            this.PropsImageList.Images.SetKeyName(39, "PropsCategory702");
            this.PropsImageList.Images.SetKeyName(40, "PropsCategory703");
            this.PropsImageList.Images.SetKeyName(41, "PropsCategory704");
            this.PropsImageList.Images.SetKeyName(42, "PropsCategory705");
            this.PropsImageList.Images.SetKeyName(43, "PropsCategory706");
            this.PropsImageList.Images.SetKeyName(44, "PropsCategory707");
            this.PropsImageList.Images.SetKeyName(45, "PropsCategory708");
            this.PropsImageList.Images.SetKeyName(46, "PropsCategory709");
            this.PropsImageList.Images.SetKeyName(47, "PropsCategory710");
            this.PropsImageList.Images.SetKeyName(48, "PropsCategory711");
            this.PropsImageList.Images.SetKeyName(49, "PropsCategory712");
            this.PropsImageList.Images.SetKeyName(50, "PropsCategory713");
            this.PropsImageList.Images.SetKeyName(51, "PropsCategory714");
            this.PropsImageList.Images.SetKeyName(52, "PropsCategory715");
            this.PropsImageList.Images.SetKeyName(53, "PropsCategory801");
            this.PropsImageList.Images.SetKeyName(54, "PropsCategory802");
            this.PropsImageList.Images.SetKeyName(55, "PropsCategoryEmpty");
            this.PropsImageList.Images.SetKeyName(56, "PropsCategoryMentalEmpty");
            this.PropsImageList.Images.SetKeyName(57, "PropsCategoryTalkEmpty");
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
            this.panel4.Controls.Add(this.newPropsButton);
            this.panel4.Controls.Add(this.editPropsButton);
            this.panel4.Controls.Add(this.showOriginalPropsCheckBox);
            this.panel4.Controls.Add(this.deletePropsButton);
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
            // newPropsButton
            // 
            this.newPropsButton.Location = new System.Drawing.Point(3, 3);
            this.newPropsButton.Name = "newPropsButton";
            this.newPropsButton.Size = new System.Drawing.Size(75, 23);
            this.newPropsButton.TabIndex = 0;
            this.newPropsButton.Text = "新增";
            this.newPropsButton.UseVisualStyleBackColor = true;
            this.newPropsButton.Click += new System.EventHandler(this.newPropsButton_Click);
            // 
            // editPropsButton
            // 
            this.editPropsButton.Location = new System.Drawing.Point(84, 3);
            this.editPropsButton.Name = "editPropsButton";
            this.editPropsButton.Size = new System.Drawing.Size(75, 23);
            this.editPropsButton.TabIndex = 1;
            this.editPropsButton.Text = "修改";
            this.editPropsButton.UseVisualStyleBackColor = true;
            this.editPropsButton.Click += new System.EventHandler(this.editPropsButton_Click);
            // 
            // showOriginalPropsCheckBox
            // 
            this.showOriginalPropsCheckBox.AutoSize = true;
            this.showOriginalPropsCheckBox.Checked = true;
            this.showOriginalPropsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalPropsCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalPropsCheckBox.Name = "showOriginalPropsCheckBox";
            this.showOriginalPropsCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalPropsCheckBox.TabIndex = 3;
            this.showOriginalPropsCheckBox.Text = "显示原游戏数据";
            this.showOriginalPropsCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalPropsCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalPropsCheckBox_CheckedChanged);
            // 
            // deletePropsButton
            // 
            this.deletePropsButton.Location = new System.Drawing.Point(165, 3);
            this.deletePropsButton.Name = "deletePropsButton";
            this.deletePropsButton.Size = new System.Drawing.Size(75, 23);
            this.deletePropsButton.TabIndex = 2;
            this.deletePropsButton.Text = "删除";
            this.deletePropsButton.UseVisualStyleBackColor = true;
            this.deletePropsButton.Click += new System.EventHandler(this.deletePropsButton_Click);
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
            this.CustomTabControl.Controls.Add(this.PropsTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // PropsListView
            // 
            this.PropsListView.AllowColumnReorder = true;
            this.PropsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.PropsListView.ContextMenuStrip = this.PropsContextMenuStrip;
            this.PropsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropsListView.FullRowSelect = true;
            this.PropsListView.HideSelection = false;
            this.PropsListView.Location = new System.Drawing.Point(0, 0);
            this.PropsListView.MultiSelect = false;
            this.PropsListView.Name = "PropsListView";
            this.PropsListView.ShowItemToolTips = true;
            this.PropsListView.Size = new System.Drawing.Size(832, 483);
            this.PropsListView.SmallImageList = this.PropsImageList;
            this.PropsListView.TabIndex = 12;
            this.PropsListView.UseCompatibleStateImageBehavior = false;
            this.PropsListView.View = System.Windows.Forms.View.Details;
            this.PropsListView.SelectedIndexChanged += new System.EventHandler(this.PropsListView_SelectedIndexChanged);
            this.PropsListView.DoubleClick += new System.EventHandler(this.PropsListView_DoubleClick);
            this.PropsListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PropsListView_KeyPress);
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "图示";
            this.columnHeader15.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "物品名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描述";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "大分类";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "小分类";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "模型";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "价格";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "使用时机";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "是否可以买卖";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "是否要显示在背包";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "附加状态（装备者本身）";
            this.columnHeader10.Width = 300;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "使用条件描述";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "使用效果描述";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "可使用的npc编号";
            this.columnHeader13.Width = 300;
            // 
            // PropsTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "PropsTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.PropsTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.PropsContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage PropsTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newPropsButton;
        private System.Windows.Forms.Button editPropsButton;
        private System.Windows.Forms.CheckBox showOriginalPropsCheckBox;
        private System.Windows.Forms.Button deletePropsButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip PropsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ImageList PropsImageList;
        private UserListView PropsListView;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}
