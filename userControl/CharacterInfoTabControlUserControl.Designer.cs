
namespace 侠之道mod制作器
{
    partial class CharacterInfoTabControlUserControl
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
            this.CharacterInfoTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CharacterInfoContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newCharacterInfoButton = new System.Windows.Forms.Button();
            this.editCharacterInfoButton = new System.Windows.Forms.Button();
            this.showOriginalCharacterInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteCharacterInfoButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.CharacterInfoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CharacterInfoTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.CharacterInfoContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CharacterInfoTabPage
            // 
            this.CharacterInfoTabPage.Controls.Add(this.panel2);
            this.CharacterInfoTabPage.Controls.Add(this.panel1);
            this.CharacterInfoTabPage.Location = new System.Drawing.Point(4, 22);
            this.CharacterInfoTabPage.Name = "CharacterInfoTabPage";
            this.CharacterInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CharacterInfoTabPage.Size = new System.Drawing.Size(838, 518);
            this.CharacterInfoTabPage.TabIndex = 3;
            this.CharacterInfoTabPage.Text = "CharacterInfo     ";
            this.CharacterInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CharacterInfoListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // CharacterInfoContextMenuStrip
            // 
            this.CharacterInfoContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.CharacterInfoContextMenuStrip.Name = "CharacterInfoContextMenuStrip";
            this.CharacterInfoContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newCharacterInfoButton);
            this.panel4.Controls.Add(this.editCharacterInfoButton);
            this.panel4.Controls.Add(this.showOriginalCharacterInfoCheckBox);
            this.panel4.Controls.Add(this.deleteCharacterInfoButton);
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
            // newCharacterInfoButton
            // 
            this.newCharacterInfoButton.Location = new System.Drawing.Point(3, 3);
            this.newCharacterInfoButton.Name = "newCharacterInfoButton";
            this.newCharacterInfoButton.Size = new System.Drawing.Size(75, 23);
            this.newCharacterInfoButton.TabIndex = 0;
            this.newCharacterInfoButton.Text = "新增";
            this.newCharacterInfoButton.UseVisualStyleBackColor = true;
            this.newCharacterInfoButton.Click += new System.EventHandler(this.newCharacterInfoButton_Click);
            // 
            // editCharacterInfoButton
            // 
            this.editCharacterInfoButton.Location = new System.Drawing.Point(84, 3);
            this.editCharacterInfoButton.Name = "editCharacterInfoButton";
            this.editCharacterInfoButton.Size = new System.Drawing.Size(75, 23);
            this.editCharacterInfoButton.TabIndex = 1;
            this.editCharacterInfoButton.Text = "修改";
            this.editCharacterInfoButton.UseVisualStyleBackColor = true;
            this.editCharacterInfoButton.Click += new System.EventHandler(this.editCharacterInfoButton_Click);
            // 
            // showOriginalCharacterInfoCheckBox
            // 
            this.showOriginalCharacterInfoCheckBox.AutoSize = true;
            this.showOriginalCharacterInfoCheckBox.Checked = true;
            this.showOriginalCharacterInfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalCharacterInfoCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalCharacterInfoCheckBox.Name = "showOriginalCharacterInfoCheckBox";
            this.showOriginalCharacterInfoCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalCharacterInfoCheckBox.TabIndex = 3;
            this.showOriginalCharacterInfoCheckBox.Text = "显示原游戏数据";
            this.showOriginalCharacterInfoCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalCharacterInfoCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalCharacterInfoCheckBox_CheckedChanged);
            // 
            // deleteCharacterInfoButton
            // 
            this.deleteCharacterInfoButton.Location = new System.Drawing.Point(165, 3);
            this.deleteCharacterInfoButton.Name = "deleteCharacterInfoButton";
            this.deleteCharacterInfoButton.Size = new System.Drawing.Size(75, 23);
            this.deleteCharacterInfoButton.TabIndex = 2;
            this.deleteCharacterInfoButton.Text = "删除";
            this.deleteCharacterInfoButton.UseVisualStyleBackColor = true;
            this.deleteCharacterInfoButton.Click += new System.EventHandler(this.deleteCharacterInfoButton_Click);
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
            this.CustomTabControl.Controls.Add(this.CharacterInfoTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // CharacterInfoListView
            // 
            this.CharacterInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31});
            this.CharacterInfoListView.ContextMenuStrip = this.CharacterInfoContextMenuStrip;
            this.CharacterInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterInfoListView.FullRowSelect = true;
            this.CharacterInfoListView.HideSelection = false;
            this.CharacterInfoListView.Location = new System.Drawing.Point(0, 0);
            this.CharacterInfoListView.MultiSelect = false;
            this.CharacterInfoListView.Name = "CharacterInfoListView";
            this.CharacterInfoListView.ShowItemToolTips = true;
            this.CharacterInfoListView.Size = new System.Drawing.Size(832, 483);
            this.CharacterInfoListView.TabIndex = 15;
            this.CharacterInfoListView.UseCompatibleStateImageBehavior = false;
            this.CharacterInfoListView.View = System.Windows.Forms.View.Details;
            this.CharacterInfoListView.SelectedIndexChanged += new System.EventHandler(this.CharacterInfoListView_SelectedIndexChanged);
            this.CharacterInfoListView.DoubleClick += new System.EventHandler(this.CharacterInfoListView_DoubleClick);
            this.CharacterInfoListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CharacterInfoListView_KeyPress);
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
            this.columnHeader10.Text = "等级";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "功体";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "是否可转功体";
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "装备栏位";
            this.columnHeader22.Width = 400;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "人物属性";
            this.columnHeader23.Width = 400;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "可升级属性";
            this.columnHeader24.Width = 400;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "人物成长属性";
            this.columnHeader25.Width = 400;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "人物成长因子";
            this.columnHeader26.Width = 100;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "人物天赋列表";
            this.columnHeader27.Width = 100;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "已学招式列表";
            this.columnHeader28.Width = 400;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "已学心法列表";
            this.columnHeader29.Width = 300;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "特殊技能";
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "人物掉落奖励列表";
            this.columnHeader31.Width = 150;
            // 
            // CharacterInfoTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "CharacterInfoTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.CharacterInfoTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.CharacterInfoContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CharacterInfoTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newCharacterInfoButton;
        private System.Windows.Forms.Button editCharacterInfoButton;
        private System.Windows.Forms.CheckBox showOriginalCharacterInfoCheckBox;
        private System.Windows.Forms.Button deleteCharacterInfoButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip CharacterInfoContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView CharacterInfoListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader20;
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
        private System.Windows.Forms.ColumnHeader columnHeader31;
    }
}
