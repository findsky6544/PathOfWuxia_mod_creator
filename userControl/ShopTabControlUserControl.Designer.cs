
namespace 侠之道mod制作器
{
    partial class ShopTabControlUserControl
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
            this.ShopTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShopListView = new 侠之道mod制作器.UserListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShopContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newShopButton = new System.Windows.Forms.Button();
            this.editShopButton = new System.Windows.Forms.Button();
            this.showOriginalShopCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteShopButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.ShopTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ShopContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShopTabPage
            // 
            this.ShopTabPage.Controls.Add(this.panel2);
            this.ShopTabPage.Controls.Add(this.panel1);
            this.ShopTabPage.Location = new System.Drawing.Point(4, 22);
            this.ShopTabPage.Name = "ShopTabPage";
            this.ShopTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ShopTabPage.Size = new System.Drawing.Size(838, 518);
            this.ShopTabPage.TabIndex = 3;
            this.ShopTabPage.Text = "Shop     ";
            this.ShopTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ShopListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // ShopListView
            // 
            this.ShopListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader6});
            this.ShopListView.ContextMenuStrip = this.ShopContextMenuStrip;
            this.ShopListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShopListView.FullRowSelect = true;
            this.ShopListView.HideSelection = false;
            this.ShopListView.Location = new System.Drawing.Point(0, 0);
            this.ShopListView.MultiSelect = false;
            this.ShopListView.Name = "ShopListView";
            this.ShopListView.ShowItemToolTips = true;
            this.ShopListView.Size = new System.Drawing.Size(832, 483);
            this.ShopListView.TabIndex = 12;
            this.ShopListView.UseCompatibleStateImageBehavior = false;
            this.ShopListView.View = System.Windows.Forms.View.Details;
            this.ShopListView.DoubleClick += new System.EventHandler(this.ShopListView_DoubleClick);
            this.ShopListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShopListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "贩售条件";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "是否可以重复购买";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "物品编号";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "商店周期";
            this.columnHeader5.Width = 200;
            // 
            // ShopContextMenuStrip
            // 
            this.ShopContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.ShopContextMenuStrip.Name = "ShopContextMenuStrip";
            this.ShopContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newShopButton);
            this.panel4.Controls.Add(this.editShopButton);
            this.panel4.Controls.Add(this.showOriginalShopCheckBox);
            this.panel4.Controls.Add(this.deleteShopButton);
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
            // newShopButton
            // 
            this.newShopButton.Location = new System.Drawing.Point(3, 3);
            this.newShopButton.Name = "newShopButton";
            this.newShopButton.Size = new System.Drawing.Size(75, 23);
            this.newShopButton.TabIndex = 0;
            this.newShopButton.Text = "新增";
            this.newShopButton.UseVisualStyleBackColor = true;
            this.newShopButton.Click += new System.EventHandler(this.newShopButton_Click);
            // 
            // editShopButton
            // 
            this.editShopButton.Location = new System.Drawing.Point(84, 3);
            this.editShopButton.Name = "editShopButton";
            this.editShopButton.Size = new System.Drawing.Size(75, 23);
            this.editShopButton.TabIndex = 1;
            this.editShopButton.Text = "修改";
            this.editShopButton.UseVisualStyleBackColor = true;
            this.editShopButton.Click += new System.EventHandler(this.editShopButton_Click);
            // 
            // showOriginalShopCheckBox
            // 
            this.showOriginalShopCheckBox.AutoSize = true;
            this.showOriginalShopCheckBox.Checked = true;
            this.showOriginalShopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalShopCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalShopCheckBox.Name = "showOriginalShopCheckBox";
            this.showOriginalShopCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalShopCheckBox.TabIndex = 3;
            this.showOriginalShopCheckBox.Text = "显示原游戏数据";
            this.showOriginalShopCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalShopCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalShopCheckBox_CheckedChanged);
            // 
            // deleteShopButton
            // 
            this.deleteShopButton.Location = new System.Drawing.Point(165, 3);
            this.deleteShopButton.Name = "deleteShopButton";
            this.deleteShopButton.Size = new System.Drawing.Size(75, 23);
            this.deleteShopButton.TabIndex = 2;
            this.deleteShopButton.Text = "删除";
            this.deleteShopButton.UseVisualStyleBackColor = true;
            this.deleteShopButton.Click += new System.EventHandler(this.deleteShopButton_Click);
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
            this.CustomTabControl.Controls.Add(this.ShopTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // ShopTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "ShopTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.ShopTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ShopContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ShopTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newShopButton;
        private System.Windows.Forms.Button editShopButton;
        private System.Windows.Forms.CheckBox showOriginalShopCheckBox;
        private System.Windows.Forms.Button deleteShopButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip ShopContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private UserListView ShopListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
