
namespace 侠之道mod制作器
{
    partial class EvaluationTabControlUserControl
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
            this.EvaluationTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EvaluationContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newEvaluationButton = new System.Windows.Forms.Button();
            this.editEvaluationButton = new System.Windows.Forms.Button();
            this.showOriginalEvaluationCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteEvaluationButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.EvaluationListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EvaluationTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.EvaluationContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // EvaluationTabPage
            // 
            this.EvaluationTabPage.Controls.Add(this.panel2);
            this.EvaluationTabPage.Controls.Add(this.panel1);
            this.EvaluationTabPage.Location = new System.Drawing.Point(4, 22);
            this.EvaluationTabPage.Name = "EvaluationTabPage";
            this.EvaluationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EvaluationTabPage.Size = new System.Drawing.Size(838, 518);
            this.EvaluationTabPage.TabIndex = 3;
            this.EvaluationTabPage.Text = "Evaluation     ";
            this.EvaluationTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EvaluationListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // EvaluationContextMenuStrip
            // 
            this.EvaluationContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.EvaluationContextMenuStrip.Name = "EvaluationContextMenuStrip";
            this.EvaluationContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newEvaluationButton);
            this.panel4.Controls.Add(this.editEvaluationButton);
            this.panel4.Controls.Add(this.showOriginalEvaluationCheckBox);
            this.panel4.Controls.Add(this.deleteEvaluationButton);
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
            // newEvaluationButton
            // 
            this.newEvaluationButton.Location = new System.Drawing.Point(3, 3);
            this.newEvaluationButton.Name = "newEvaluationButton";
            this.newEvaluationButton.Size = new System.Drawing.Size(75, 23);
            this.newEvaluationButton.TabIndex = 0;
            this.newEvaluationButton.Text = "新增";
            this.newEvaluationButton.UseVisualStyleBackColor = true;
            this.newEvaluationButton.Click += new System.EventHandler(this.newEvaluationButton_Click);
            // 
            // editEvaluationButton
            // 
            this.editEvaluationButton.Location = new System.Drawing.Point(84, 3);
            this.editEvaluationButton.Name = "editEvaluationButton";
            this.editEvaluationButton.Size = new System.Drawing.Size(75, 23);
            this.editEvaluationButton.TabIndex = 1;
            this.editEvaluationButton.Text = "修改";
            this.editEvaluationButton.UseVisualStyleBackColor = true;
            this.editEvaluationButton.Click += new System.EventHandler(this.editEvaluationButton_Click);
            // 
            // showOriginalEvaluationCheckBox
            // 
            this.showOriginalEvaluationCheckBox.AutoSize = true;
            this.showOriginalEvaluationCheckBox.Checked = true;
            this.showOriginalEvaluationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalEvaluationCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalEvaluationCheckBox.Name = "showOriginalEvaluationCheckBox";
            this.showOriginalEvaluationCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalEvaluationCheckBox.TabIndex = 3;
            this.showOriginalEvaluationCheckBox.Text = "显示原游戏数据";
            this.showOriginalEvaluationCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalEvaluationCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalEvaluationCheckBox_CheckedChanged);
            // 
            // deleteEvaluationButton
            // 
            this.deleteEvaluationButton.Location = new System.Drawing.Point(165, 3);
            this.deleteEvaluationButton.Name = "deleteEvaluationButton";
            this.deleteEvaluationButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEvaluationButton.TabIndex = 2;
            this.deleteEvaluationButton.Text = "删除";
            this.deleteEvaluationButton.UseVisualStyleBackColor = true;
            this.deleteEvaluationButton.Click += new System.EventHandler(this.deleteEvaluationButton_Click);
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
            this.CustomTabControl.Controls.Add(this.EvaluationTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // EvaluationListView
            // 
            this.EvaluationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.EvaluationListView.ContextMenuStrip = this.EvaluationContextMenuStrip;
            this.EvaluationListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluationListView.FullRowSelect = true;
            this.EvaluationListView.HideSelection = false;
            this.EvaluationListView.Location = new System.Drawing.Point(0, 0);
            this.EvaluationListView.MultiSelect = false;
            this.EvaluationListView.Name = "EvaluationListView";
            this.EvaluationListView.ShowItemToolTips = true;
            this.EvaluationListView.Size = new System.Drawing.Size(832, 483);
            this.EvaluationListView.TabIndex = 12;
            this.EvaluationListView.UseCompatibleStateImageBehavior = false;
            this.EvaluationListView.View = System.Windows.Forms.View.Details;
            this.EvaluationListView.SelectedIndexChanged += new System.EventHandler(this.EvaluationListView_SelectedIndexChanged);
            this.EvaluationListView.DoubleClick += new System.EventHandler(this.EvaluationListView_DoubleClick);
            this.EvaluationListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EvaluationListView_KeyPress);
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
            this.columnHeader5.Text = "评价点资讯";
            this.columnHeader5.Width = 300;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "评价奖励";
            this.columnHeader6.Width = 300;
            // 
            // EvaluationTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "EvaluationTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.EvaluationTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.EvaluationContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage EvaluationTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newEvaluationButton;
        private System.Windows.Forms.Button editEvaluationButton;
        private System.Windows.Forms.CheckBox showOriginalEvaluationCheckBox;
        private System.Windows.Forms.Button deleteEvaluationButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip EvaluationContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView EvaluationListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}
