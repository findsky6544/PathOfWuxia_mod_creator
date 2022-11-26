
namespace 侠之道mod制作器
{
    partial class CharacterExteriorTabControlUserControl
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
            this.CharacterExteriorTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CharacterExteriorContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newCharacterExteriorButton = new System.Windows.Forms.Button();
            this.editCharacterExteriorButton = new System.Windows.Forms.Button();
            this.showOriginalCharacterExteriorCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCharacterExteriorButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.CharacterExteriorListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CharacterExteriorTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.CharacterExteriorContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharacterExteriorTabPage
            // 
            this.CharacterExteriorTabPage.Controls.Add(this.panel2);
            this.CharacterExteriorTabPage.Controls.Add(this.panel1);
            this.CharacterExteriorTabPage.Location = new System.Drawing.Point(4, 22);
            this.CharacterExteriorTabPage.Name = "CharacterExteriorTabPage";
            this.CharacterExteriorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CharacterExteriorTabPage.Size = new System.Drawing.Size(838, 518);
            this.CharacterExteriorTabPage.TabIndex = 3;
            this.CharacterExteriorTabPage.Text = "CharacterExterior     ";
            this.CharacterExteriorTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CharacterExteriorListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // CharacterExteriorContextMenuStrip
            // 
            this.CharacterExteriorContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.CharacterExteriorContextMenuStrip.Name = "CharacterExteriorContextMenuStrip";
            this.CharacterExteriorContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newCharacterExteriorButton);
            this.panel4.Controls.Add(this.editCharacterExteriorButton);
            this.panel4.Controls.Add(this.showOriginalCharacterExteriorCheckBox);
            this.panel4.Controls.Add(this.deleteCharacterExteriorButton);
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
            // newCharacterExteriorButton
            // 
            this.newCharacterExteriorButton.Location = new System.Drawing.Point(3, 3);
            this.newCharacterExteriorButton.Name = "newCharacterExteriorButton";
            this.newCharacterExteriorButton.Size = new System.Drawing.Size(75, 23);
            this.newCharacterExteriorButton.TabIndex = 0;
            this.newCharacterExteriorButton.Text = "新增";
            this.newCharacterExteriorButton.UseVisualStyleBackColor = true;
            this.newCharacterExteriorButton.Click += new System.EventHandler(this.newCharacterExteriorButton_Click);
            // 
            // editCharacterExteriorButton
            // 
            this.editCharacterExteriorButton.Location = new System.Drawing.Point(84, 3);
            this.editCharacterExteriorButton.Name = "editCharacterExteriorButton";
            this.editCharacterExteriorButton.Size = new System.Drawing.Size(75, 23);
            this.editCharacterExteriorButton.TabIndex = 1;
            this.editCharacterExteriorButton.Text = "修改";
            this.editCharacterExteriorButton.UseVisualStyleBackColor = true;
            this.editCharacterExteriorButton.Click += new System.EventHandler(this.editCharacterExteriorButton_Click);
            // 
            // showOriginalCharacterExteriorCheckBox
            // 
            this.showOriginalCharacterExteriorCheckBox.AutoSize = true;
            this.showOriginalCharacterExteriorCheckBox.Checked = true;
            this.showOriginalCharacterExteriorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalCharacterExteriorCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalCharacterExteriorCheckBox.Name = "showOriginalCharacterExteriorCheckBox";
            this.showOriginalCharacterExteriorCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalCharacterExteriorCheckBox.TabIndex = 3;
            this.showOriginalCharacterExteriorCheckBox.Text = "显示原游戏数据";
            this.showOriginalCharacterExteriorCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalCharacterExteriorCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalCharacterExteriorCheckBox_CheckedChanged);
            // 
            // deleteCharacterExteriorButton
            // 
            this.deleteCharacterExteriorButton.Location = new System.Drawing.Point(165, 3);
            this.deleteCharacterExteriorButton.Name = "deleteCharacterExteriorButton";
            this.deleteCharacterExteriorButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCharacterExteriorButton.TabIndex = 2;
            this.deleteCharacterExteriorButton.Text = "删除";
            this.deleteCharacterExteriorButton.UseVisualStyleBackColor = true;
            this.deleteCharacterExteriorButton.Click += new System.EventHandler(this.deleteCharacterExteriorButton_Click);
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
            this.CustomTabControl.Controls.Add(this.CharacterExteriorTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // CharacterExteriorListView
            // 
            this.CharacterExteriorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.CharacterExteriorListView.ContextMenuStrip = this.CharacterExteriorContextMenuStrip;
            this.CharacterExteriorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterExteriorListView.FullRowSelect = true;
            this.CharacterExteriorListView.HideSelection = false;
            this.CharacterExteriorListView.Location = new System.Drawing.Point(0, 0);
            this.CharacterExteriorListView.MultiSelect = false;
            this.CharacterExteriorListView.Name = "CharacterExteriorListView";
            this.CharacterExteriorListView.ShowItemToolTips = true;
            this.CharacterExteriorListView.Size = new System.Drawing.Size(832, 483);
            this.CharacterExteriorListView.TabIndex = 14;
            this.CharacterExteriorListView.UseCompatibleStateImageBehavior = false;
            this.CharacterExteriorListView.View = System.Windows.Forms.View.Details;
            this.CharacterExteriorListView.SelectedIndexChanged += new System.EventHandler(this.CharacterExteriorListView_SelectedIndexChanged);
            this.CharacterExteriorListView.DoubleClick += new System.EventHandler(this.CharacterExteriorListView_DoubleClick);
            this.CharacterExteriorListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharacterExteriorListView_KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "姓";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "名";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "称号";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "人物立绘";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "人物描述";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "性别";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "体型";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "模型";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "动作对应ID";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "身高";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "人物喜好";
            this.columnHeader16.Width = 150;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "是否显示立绘（对话）";
            this.columnHeader17.Width = 150;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "资讯编号";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "年龄层";
            // 
            // CharacterExteriorTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "CharacterExteriorTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.CharacterExteriorTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.CharacterExteriorContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CharacterExteriorTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newCharacterExteriorButton;
        private System.Windows.Forms.Button editCharacterExteriorButton;
        private System.Windows.Forms.CheckBox showOriginalCharacterExteriorCheckBox;
        private System.Windows.Forms.Button deleteCharacterExteriorButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip CharacterExteriorContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView CharacterExteriorListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
    }
}
