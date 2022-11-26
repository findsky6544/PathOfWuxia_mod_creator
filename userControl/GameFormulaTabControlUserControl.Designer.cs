
namespace 侠之道mod制作器
{
    partial class GameFormulaTabControlUserControl
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
            this.GameFormulaTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GameFormulaListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GameFormulaContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newGameFormulaButton = new System.Windows.Forms.Button();
            this.editGameFormulaButton = new System.Windows.Forms.Button();
            this.showOriginalGameFormulaCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteGameFormulaButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.GameFormulaTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GameFormulaContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameFormulaTabPage
            // 
            this.GameFormulaTabPage.Controls.Add(this.panel2);
            this.GameFormulaTabPage.Controls.Add(this.panel1);
            this.GameFormulaTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameFormulaTabPage.Name = "GameFormulaTabPage";
            this.GameFormulaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameFormulaTabPage.Size = new System.Drawing.Size(838, 518);
            this.GameFormulaTabPage.TabIndex = 3;
            this.GameFormulaTabPage.Text = "GameFormula     ";
            this.GameFormulaTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GameFormulaListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // GameFormulaListView
            // 
            this.GameFormulaListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.GameFormulaListView.ContextMenuStrip = this.GameFormulaContextMenuStrip;
            this.GameFormulaListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameFormulaListView.FullRowSelect = true;
            this.GameFormulaListView.HideSelection = false;
            this.GameFormulaListView.Location = new System.Drawing.Point(0, 0);
            this.GameFormulaListView.MultiSelect = false;
            this.GameFormulaListView.Name = "GameFormulaListView";
            this.GameFormulaListView.ShowItemToolTips = true;
            this.GameFormulaListView.Size = new System.Drawing.Size(832, 483);
            this.GameFormulaListView.TabIndex = 14;
            this.GameFormulaListView.UseCompatibleStateImageBehavior = false;
            this.GameFormulaListView.View = System.Windows.Forms.View.Details;
            this.GameFormulaListView.SelectedIndexChanged += new System.EventHandler(this.GameFormulaListView_SelectedIndexChanged);
            this.GameFormulaListView.DoubleClick += new System.EventHandler(this.GameFormulaListView_DoubleClick);
            this.GameFormulaListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameFormulaListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "别名";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "公式";
            this.columnHeader4.Width = 400;
            // 
            // GameFormulaContextMenuStrip
            // 
            this.GameFormulaContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.GameFormulaContextMenuStrip.Name = "GameFormulaContextMenuStrip";
            this.GameFormulaContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newGameFormulaButton);
            this.panel4.Controls.Add(this.editGameFormulaButton);
            this.panel4.Controls.Add(this.showOriginalGameFormulaCheckBox);
            this.panel4.Controls.Add(this.deleteGameFormulaButton);
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
            // newGameFormulaButton
            // 
            this.newGameFormulaButton.Location = new System.Drawing.Point(3, 3);
            this.newGameFormulaButton.Name = "newGameFormulaButton";
            this.newGameFormulaButton.Size = new System.Drawing.Size(75, 23);
            this.newGameFormulaButton.TabIndex = 0;
            this.newGameFormulaButton.Text = "新增";
            this.newGameFormulaButton.UseVisualStyleBackColor = true;
            this.newGameFormulaButton.Click += new System.EventHandler(this.newGameFormulaButton_Click);
            // 
            // editGameFormulaButton
            // 
            this.editGameFormulaButton.Location = new System.Drawing.Point(84, 3);
            this.editGameFormulaButton.Name = "editGameFormulaButton";
            this.editGameFormulaButton.Size = new System.Drawing.Size(75, 23);
            this.editGameFormulaButton.TabIndex = 1;
            this.editGameFormulaButton.Text = "修改";
            this.editGameFormulaButton.UseVisualStyleBackColor = true;
            this.editGameFormulaButton.Click += new System.EventHandler(this.editGameFormulaButton_Click);
            // 
            // showOriginalGameFormulaCheckBox
            // 
            this.showOriginalGameFormulaCheckBox.AutoSize = true;
            this.showOriginalGameFormulaCheckBox.Checked = true;
            this.showOriginalGameFormulaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalGameFormulaCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalGameFormulaCheckBox.Name = "showOriginalGameFormulaCheckBox";
            this.showOriginalGameFormulaCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalGameFormulaCheckBox.TabIndex = 3;
            this.showOriginalGameFormulaCheckBox.Text = "显示原游戏数据";
            this.showOriginalGameFormulaCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalGameFormulaCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalGameFormulaCheckBox_CheckedChanged);
            // 
            // deleteGameFormulaButton
            // 
            this.deleteGameFormulaButton.Location = new System.Drawing.Point(165, 3);
            this.deleteGameFormulaButton.Name = "deleteGameFormulaButton";
            this.deleteGameFormulaButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGameFormulaButton.TabIndex = 2;
            this.deleteGameFormulaButton.Text = "删除";
            this.deleteGameFormulaButton.UseVisualStyleBackColor = true;
            this.deleteGameFormulaButton.Click += new System.EventHandler(this.deleteGameFormulaButton_Click);
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
            this.CustomTabControl.Controls.Add(this.GameFormulaTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // GameFormulaTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "GameFormulaTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.GameFormulaTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.GameFormulaContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage GameFormulaTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newGameFormulaButton;
        private System.Windows.Forms.Button editGameFormulaButton;
        private System.Windows.Forms.CheckBox showOriginalGameFormulaCheckBox;
        private System.Windows.Forms.Button deleteGameFormulaButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip GameFormulaContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView GameFormulaListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
