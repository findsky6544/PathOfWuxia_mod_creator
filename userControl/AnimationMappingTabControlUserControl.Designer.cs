
namespace 侠之道mod制作器
{
    partial class AnimationMappingTabControlUserControl
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
            this.AnimationMappingTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AnimationMappingContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newAnimationMappingButton = new System.Windows.Forms.Button();
            this.editAnimationMappingButton = new System.Windows.Forms.Button();
            this.showOriginalAnimationMappingCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteAnimationMappingButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.AnimationMappingListView = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AnimationMappingTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.AnimationMappingContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AnimationMappingTabPage
            // 
            this.AnimationMappingTabPage.Controls.Add(this.panel2);
            this.AnimationMappingTabPage.Controls.Add(this.panel1);
            this.AnimationMappingTabPage.Location = new System.Drawing.Point(4, 22);
            this.AnimationMappingTabPage.Name = "AnimationMappingTabPage";
            this.AnimationMappingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AnimationMappingTabPage.Size = new System.Drawing.Size(838, 518);
            this.AnimationMappingTabPage.TabIndex = 3;
            this.AnimationMappingTabPage.Text = "AnimationMapping     ";
            this.AnimationMappingTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AnimationMappingListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // AnimationMappingContextMenuStrip
            // 
            this.AnimationMappingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.AnimationMappingContextMenuStrip.Name = "AnimationMappingContextMenuStrip";
            this.AnimationMappingContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newAnimationMappingButton);
            this.panel4.Controls.Add(this.editAnimationMappingButton);
            this.panel4.Controls.Add(this.showOriginalAnimationMappingCheckBox);
            this.panel4.Controls.Add(this.deleteAnimationMappingButton);
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
            // newAnimationMappingButton
            // 
            this.newAnimationMappingButton.Location = new System.Drawing.Point(3, 3);
            this.newAnimationMappingButton.Name = "newAnimationMappingButton";
            this.newAnimationMappingButton.Size = new System.Drawing.Size(75, 23);
            this.newAnimationMappingButton.TabIndex = 0;
            this.newAnimationMappingButton.Text = "新增";
            this.newAnimationMappingButton.UseVisualStyleBackColor = true;
            this.newAnimationMappingButton.Click += new System.EventHandler(this.newAnimationMappingButton_Click);
            // 
            // editAnimationMappingButton
            // 
            this.editAnimationMappingButton.Location = new System.Drawing.Point(84, 3);
            this.editAnimationMappingButton.Name = "editAnimationMappingButton";
            this.editAnimationMappingButton.Size = new System.Drawing.Size(75, 23);
            this.editAnimationMappingButton.TabIndex = 1;
            this.editAnimationMappingButton.Text = "修改";
            this.editAnimationMappingButton.UseVisualStyleBackColor = true;
            this.editAnimationMappingButton.Click += new System.EventHandler(this.editAnimationMappingButton_Click);
            // 
            // showOriginalAnimationMappingCheckBox
            // 
            this.showOriginalAnimationMappingCheckBox.AutoSize = true;
            this.showOriginalAnimationMappingCheckBox.Checked = true;
            this.showOriginalAnimationMappingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalAnimationMappingCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalAnimationMappingCheckBox.Name = "showOriginalAnimationMappingCheckBox";
            this.showOriginalAnimationMappingCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalAnimationMappingCheckBox.TabIndex = 3;
            this.showOriginalAnimationMappingCheckBox.Text = "显示原游戏数据";
            this.showOriginalAnimationMappingCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalAnimationMappingCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalAnimationMappingCheckBox_CheckedChanged);
            // 
            // deleteAnimationMappingButton
            // 
            this.deleteAnimationMappingButton.Location = new System.Drawing.Point(165, 3);
            this.deleteAnimationMappingButton.Name = "deleteAnimationMappingButton";
            this.deleteAnimationMappingButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAnimationMappingButton.TabIndex = 2;
            this.deleteAnimationMappingButton.Text = "删除";
            this.deleteAnimationMappingButton.UseVisualStyleBackColor = true;
            this.deleteAnimationMappingButton.Click += new System.EventHandler(this.deleteAnimationMappingButton_Click);
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
            this.CustomTabControl.Controls.Add(this.AnimationMappingTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // AnimationMappingListView
            // 
            this.AnimationMappingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader1,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27});
            this.AnimationMappingListView.ContextMenuStrip = this.AnimationMappingContextMenuStrip;
            this.AnimationMappingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationMappingListView.FullRowSelect = true;
            this.AnimationMappingListView.HideSelection = false;
            this.AnimationMappingListView.Location = new System.Drawing.Point(0, 0);
            this.AnimationMappingListView.MultiSelect = false;
            this.AnimationMappingListView.Name = "AnimationMappingListView";
            this.AnimationMappingListView.ShowItemToolTips = true;
            this.AnimationMappingListView.Size = new System.Drawing.Size(832, 483);
            this.AnimationMappingListView.TabIndex = 13;
            this.AnimationMappingListView.UseCompatibleStateImageBehavior = false;
            this.AnimationMappingListView.View = System.Windows.Forms.View.Details;
            this.AnimationMappingListView.SelectedIndexChanged += new System.EventHandler(this.AnimationMappingListView_SelectedIndexChanged);
            this.AnimationMappingListView.DoubleClick += new System.EventHandler(this.AnimationMappingListView_DoubleClick);
            this.AnimationMappingListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AnimationMappingListView_KeyPress);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "ID";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "名称";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "备注";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "站立动作";
            this.columnHeader15.Width = 150;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "走路动作";
            this.columnHeader16.Width = 150;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "开始走路动作";
            this.columnHeader17.Width = 150;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "结束走路动作";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "跑步动作";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "移动动作";
            this.columnHeader20.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "受伤动作";
            this.columnHeader21.Width = 150;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "大受伤动作";
            this.columnHeader22.Width = 150;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "晕眩动作";
            this.columnHeader23.Width = 150;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "闪避动作";
            this.columnHeader24.Width = 150;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "死亡动作";
            this.columnHeader25.Width = 150;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "格挡、招架动作";
            this.columnHeader26.Width = 150;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "增益动作";
            this.columnHeader27.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "待机动作";
            this.columnHeader1.Width = 150;
            // 
            // AnimationMappingTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "AnimationMappingTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.AnimationMappingTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.AnimationMappingContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage AnimationMappingTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newAnimationMappingButton;
        private System.Windows.Forms.Button editAnimationMappingButton;
        private System.Windows.Forms.CheckBox showOriginalAnimationMappingCheckBox;
        private System.Windows.Forms.Button deleteAnimationMappingButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip AnimationMappingContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView AnimationMappingListView;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
