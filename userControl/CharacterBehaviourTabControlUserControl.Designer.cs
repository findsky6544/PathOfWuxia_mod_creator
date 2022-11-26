
namespace 侠之道mod制作器
{
    partial class CharacterBehaviourTabControlUserControl
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
            this.CharacterBehaviourTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CharacterBehaviourListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newCharacterBehaviourButton = new System.Windows.Forms.Button();
            this.editCharacterBehaviourButton = new System.Windows.Forms.Button();
            this.showOriginalCharacterBehaviourCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCharacterBehaviourButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CharacterBehaviourContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.CharacterBehaviourTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CharacterBehaviourContextMenuStrip.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharacterBehaviourTabPage
            // 
            this.CharacterBehaviourTabPage.Controls.Add(this.panel2);
            this.CharacterBehaviourTabPage.Controls.Add(this.panel1);
            this.CharacterBehaviourTabPage.Location = new System.Drawing.Point(4, 22);
            this.CharacterBehaviourTabPage.Name = "CharacterBehaviourTabPage";
            this.CharacterBehaviourTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CharacterBehaviourTabPage.Size = new System.Drawing.Size(838, 518);
            this.CharacterBehaviourTabPage.TabIndex = 3;
            this.CharacterBehaviourTabPage.Text = "CharacterBehaviour     ";
            this.CharacterBehaviourTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CharacterBehaviourListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // CharacterBehaviourListView
            // 
            this.CharacterBehaviourListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.CharacterBehaviourListView.ContextMenuStrip = this.CharacterBehaviourContextMenuStrip;
            this.CharacterBehaviourListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterBehaviourListView.FullRowSelect = true;
            this.CharacterBehaviourListView.HideSelection = false;
            this.CharacterBehaviourListView.Location = new System.Drawing.Point(0, 0);
            this.CharacterBehaviourListView.MultiSelect = false;
            this.CharacterBehaviourListView.Name = "CharacterBehaviourListView";
            this.CharacterBehaviourListView.ShowItemToolTips = true;
            this.CharacterBehaviourListView.Size = new System.Drawing.Size(832, 483);
            this.CharacterBehaviourListView.TabIndex = 13;
            this.CharacterBehaviourListView.UseCompatibleStateImageBehavior = false;
            this.CharacterBehaviourListView.View = System.Windows.Forms.View.Details;
            this.CharacterBehaviourListView.SelectedIndexChanged += new System.EventHandler(this.CharacterBehaviourListView_SelectedIndexChanged);
            this.CharacterBehaviourListView.DoubleClick += new System.EventHandler(this.CharacterBehaviourListView_DoubleClick);
            this.CharacterBehaviourListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharacterBehaviourListView_KeyPress);
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
            // columnHeader10
            // 
            this.columnHeader10.Text = "位置";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "旋转值";
            this.columnHeader21.Width = 150;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "对话是否转身";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "对话编号";
            this.columnHeader23.Width = 400;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "动画名称（依排程为主）";
            this.columnHeader24.Width = 150;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "排程编号";
            this.columnHeader25.Width = 150;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "点击的类型";
            this.columnHeader26.Width = 150;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "互动名称";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "互动事件";
            this.columnHeader28.Width = 150;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "生成条件";
            this.columnHeader29.Width = 400;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "出现条件";
            this.columnHeader30.Width = 400;
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
            this.panel4.Controls.Add(this.newCharacterBehaviourButton);
            this.panel4.Controls.Add(this.editCharacterBehaviourButton);
            this.panel4.Controls.Add(this.showOriginalCharacterBehaviourCheckBox);
            this.panel4.Controls.Add(this.deleteCharacterBehaviourButton);
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
            // newCharacterBehaviourButton
            // 
            this.newCharacterBehaviourButton.Location = new System.Drawing.Point(3, 3);
            this.newCharacterBehaviourButton.Name = "newCharacterBehaviourButton";
            this.newCharacterBehaviourButton.Size = new System.Drawing.Size(75, 23);
            this.newCharacterBehaviourButton.TabIndex = 0;
            this.newCharacterBehaviourButton.Text = "新增";
            this.newCharacterBehaviourButton.UseVisualStyleBackColor = true;
            this.newCharacterBehaviourButton.Click += new System.EventHandler(this.newCharacterBehaviourButton_Click);
            // 
            // editCharacterBehaviourButton
            // 
            this.editCharacterBehaviourButton.Location = new System.Drawing.Point(84, 3);
            this.editCharacterBehaviourButton.Name = "editCharacterBehaviourButton";
            this.editCharacterBehaviourButton.Size = new System.Drawing.Size(75, 23);
            this.editCharacterBehaviourButton.TabIndex = 1;
            this.editCharacterBehaviourButton.Text = "修改";
            this.editCharacterBehaviourButton.UseVisualStyleBackColor = true;
            this.editCharacterBehaviourButton.Click += new System.EventHandler(this.editCharacterBehaviourButton_Click);
            // 
            // showOriginalCharacterBehaviourCheckBox
            // 
            this.showOriginalCharacterBehaviourCheckBox.AutoSize = true;
            this.showOriginalCharacterBehaviourCheckBox.Checked = true;
            this.showOriginalCharacterBehaviourCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalCharacterBehaviourCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalCharacterBehaviourCheckBox.Name = "showOriginalCharacterBehaviourCheckBox";
            this.showOriginalCharacterBehaviourCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalCharacterBehaviourCheckBox.TabIndex = 3;
            this.showOriginalCharacterBehaviourCheckBox.Text = "显示原游戏数据";
            this.showOriginalCharacterBehaviourCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalCharacterBehaviourCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalCharacterBehaviourCheckBox_CheckedChanged);
            // 
            // deleteCharacterBehaviourButton
            // 
            this.deleteCharacterBehaviourButton.Location = new System.Drawing.Point(165, 3);
            this.deleteCharacterBehaviourButton.Name = "deleteCharacterBehaviourButton";
            this.deleteCharacterBehaviourButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCharacterBehaviourButton.TabIndex = 2;
            this.deleteCharacterBehaviourButton.Text = "删除";
            this.deleteCharacterBehaviourButton.UseVisualStyleBackColor = true;
            this.deleteCharacterBehaviourButton.Click += new System.EventHandler(this.deleteCharacterBehaviourButton_Click);
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
            // CharacterBehaviourContextMenuStrip
            // 
            this.CharacterBehaviourContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.CharacterBehaviourContextMenuStrip.Name = "CharacterBehaviourContextMenuStrip";
            this.CharacterBehaviourContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.CustomTabControl.Controls.Add(this.CharacterBehaviourTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // CharacterBehaviourTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "CharacterBehaviourTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.CharacterBehaviourTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CharacterBehaviourContextMenuStrip.ResumeLayout(false);
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CharacterBehaviourTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newCharacterBehaviourButton;
        private System.Windows.Forms.Button editCharacterBehaviourButton;
        private System.Windows.Forms.CheckBox showOriginalCharacterBehaviourCheckBox;
        private System.Windows.Forms.Button deleteCharacterBehaviourButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip CharacterBehaviourContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView CharacterBehaviourListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
    }
}
