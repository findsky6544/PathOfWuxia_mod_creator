
namespace 侠之道mod制作器
{
    partial class AdjustmentTabControlUserControl
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
            this.AdjustmentTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AdjustmentListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdjustmentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newAdjustmentButton = new System.Windows.Forms.Button();
            this.editAdjustmentButton = new System.Windows.Forms.Button();
            this.showOriginalAdjustmentCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteAdjustmentButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.AdjustmentTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.AdjustmentContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdjustmentTabPage
            // 
            this.AdjustmentTabPage.Controls.Add(this.panel2);
            this.AdjustmentTabPage.Controls.Add(this.panel1);
            this.AdjustmentTabPage.Location = new System.Drawing.Point(4, 22);
            this.AdjustmentTabPage.Name = "AdjustmentTabPage";
            this.AdjustmentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdjustmentTabPage.Size = new System.Drawing.Size(838, 518);
            this.AdjustmentTabPage.TabIndex = 3;
            this.AdjustmentTabPage.Text = "Adjustment     ";
            this.AdjustmentTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AdjustmentListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // AdjustmentListView
            // 
            this.AdjustmentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.AdjustmentListView.ContextMenuStrip = this.AdjustmentContextMenuStrip;
            this.AdjustmentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdjustmentListView.FullRowSelect = true;
            this.AdjustmentListView.HideSelection = false;
            this.AdjustmentListView.Location = new System.Drawing.Point(0, 0);
            this.AdjustmentListView.MultiSelect = false;
            this.AdjustmentListView.Name = "AdjustmentListView";
            this.AdjustmentListView.ShowItemToolTips = true;
            this.AdjustmentListView.Size = new System.Drawing.Size(832, 483);
            this.AdjustmentListView.TabIndex = 12;
            this.AdjustmentListView.UseCompatibleStateImageBehavior = false;
            this.AdjustmentListView.View = System.Windows.Forms.View.Details;
            this.AdjustmentListView.SelectedIndexChanged += new System.EventHandler(this.adjustmentListView_SelectedIndexChanged);
            this.AdjustmentListView.DoubleClick += new System.EventHandler(this.adjustmentListView_DoubleClick);
            this.AdjustmentListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adjustmentListView_KeyPress);
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
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "建议功体";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "不建议功体";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "最少出战人数";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "最多出战人数";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "必定出战队友";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "无法出战队友";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "接续演出编号";
            this.columnHeader11.Width = 100;
            // 
            // AdjustmentContextMenuStrip
            // 
            this.AdjustmentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.AdjustmentContextMenuStrip.Name = "AdjustmentContextMenuStrip";
            this.AdjustmentContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newAdjustmentButton);
            this.panel4.Controls.Add(this.editAdjustmentButton);
            this.panel4.Controls.Add(this.showOriginalAdjustmentCheckBox);
            this.panel4.Controls.Add(this.deleteAdjustmentButton);
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
            // newAdjustmentButton
            // 
            this.newAdjustmentButton.Location = new System.Drawing.Point(3, 3);
            this.newAdjustmentButton.Name = "newAdjustmentButton";
            this.newAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.newAdjustmentButton.TabIndex = 0;
            this.newAdjustmentButton.Text = "新增";
            this.newAdjustmentButton.UseVisualStyleBackColor = true;
            this.newAdjustmentButton.Click += new System.EventHandler(this.newAdjustmentButton_Click);
            // 
            // editAdjustmentButton
            // 
            this.editAdjustmentButton.Location = new System.Drawing.Point(84, 3);
            this.editAdjustmentButton.Name = "editAdjustmentButton";
            this.editAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.editAdjustmentButton.TabIndex = 1;
            this.editAdjustmentButton.Text = "修改";
            this.editAdjustmentButton.UseVisualStyleBackColor = true;
            this.editAdjustmentButton.Click += new System.EventHandler(this.editAdjustmentButton_Click);
            // 
            // showOriginalAdjustmentCheckBox
            // 
            this.showOriginalAdjustmentCheckBox.AutoSize = true;
            this.showOriginalAdjustmentCheckBox.Checked = true;
            this.showOriginalAdjustmentCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalAdjustmentCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalAdjustmentCheckBox.Name = "showOriginalAdjustmentCheckBox";
            this.showOriginalAdjustmentCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalAdjustmentCheckBox.TabIndex = 3;
            this.showOriginalAdjustmentCheckBox.Text = "显示原游戏数据";
            this.showOriginalAdjustmentCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalAdjustmentCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalAdjustmentCheckBox_CheckedChanged);
            // 
            // deleteAdjustmentButton
            // 
            this.deleteAdjustmentButton.Location = new System.Drawing.Point(165, 3);
            this.deleteAdjustmentButton.Name = "deleteAdjustmentButton";
            this.deleteAdjustmentButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAdjustmentButton.TabIndex = 2;
            this.deleteAdjustmentButton.Text = "删除";
            this.deleteAdjustmentButton.UseVisualStyleBackColor = true;
            this.deleteAdjustmentButton.Click += new System.EventHandler(this.deleteAdjustmentButton_Click);
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
            // CustomTabControl
            // 
            this.CustomTabControl.Controls.Add(this.AdjustmentTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // AdjustmentTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "AdjustmentTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.AdjustmentTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.AdjustmentContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage AdjustmentTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newAdjustmentButton;
        private System.Windows.Forms.Button editAdjustmentButton;
        private System.Windows.Forms.CheckBox showOriginalAdjustmentCheckBox;
        private System.Windows.Forms.Button deleteAdjustmentButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip AdjustmentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView AdjustmentListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}
