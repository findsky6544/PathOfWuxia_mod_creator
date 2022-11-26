
namespace 侠之道mod制作器
{
    partial class EventCubeTabControlUserControl
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
            this.EventCubeTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EventCubeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.newEventCubeButton = new System.Windows.Forms.Button();
            this.editEventCubeButton = new System.Windows.Forms.Button();
            this.showOriginalEventCubeCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteEventCubeButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.CustomTabControl = new System.Windows.Forms.TabControl();
            this.EventCubeListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.EventCubeTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.EventCubeContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CustomTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventCubeTabPage
            // 
            this.EventCubeTabPage.Controls.Add(this.panel2);
            this.EventCubeTabPage.Controls.Add(this.panel1);
            this.EventCubeTabPage.Location = new System.Drawing.Point(4, 22);
            this.EventCubeTabPage.Name = "EventCubeTabPage";
            this.EventCubeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EventCubeTabPage.Size = new System.Drawing.Size(838, 518);
            this.EventCubeTabPage.TabIndex = 3;
            this.EventCubeTabPage.Text = "EventCube     ";
            this.EventCubeTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EventCubeListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 483);
            this.panel2.TabIndex = 2;
            // 
            // EventCubeContextMenuStrip
            // 
            this.EventCubeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFilePathToolStripMenuItem});
            this.EventCubeContextMenuStrip.Name = "EventCubeContextMenuStrip";
            this.EventCubeContextMenuStrip.Size = new System.Drawing.Size(149, 48);
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
            this.panel4.Controls.Add(this.newEventCubeButton);
            this.panel4.Controls.Add(this.editEventCubeButton);
            this.panel4.Controls.Add(this.showOriginalEventCubeCheckBox);
            this.panel4.Controls.Add(this.deleteEventCubeButton);
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
            // newEventCubeButton
            // 
            this.newEventCubeButton.Location = new System.Drawing.Point(3, 3);
            this.newEventCubeButton.Name = "newEventCubeButton";
            this.newEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.newEventCubeButton.TabIndex = 0;
            this.newEventCubeButton.Text = "新增";
            this.newEventCubeButton.UseVisualStyleBackColor = true;
            this.newEventCubeButton.Click += new System.EventHandler(this.newEventCubeButton_Click);
            // 
            // editEventCubeButton
            // 
            this.editEventCubeButton.Location = new System.Drawing.Point(84, 3);
            this.editEventCubeButton.Name = "editEventCubeButton";
            this.editEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.editEventCubeButton.TabIndex = 1;
            this.editEventCubeButton.Text = "修改";
            this.editEventCubeButton.UseVisualStyleBackColor = true;
            this.editEventCubeButton.Click += new System.EventHandler(this.editEventCubeButton_Click);
            // 
            // showOriginalEventCubeCheckBox
            // 
            this.showOriginalEventCubeCheckBox.AutoSize = true;
            this.showOriginalEventCubeCheckBox.Checked = true;
            this.showOriginalEventCubeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOriginalEventCubeCheckBox.Location = new System.Drawing.Point(331, 7);
            this.showOriginalEventCubeCheckBox.Name = "showOriginalEventCubeCheckBox";
            this.showOriginalEventCubeCheckBox.Size = new System.Drawing.Size(108, 16);
            this.showOriginalEventCubeCheckBox.TabIndex = 3;
            this.showOriginalEventCubeCheckBox.Text = "显示原游戏数据";
            this.showOriginalEventCubeCheckBox.UseVisualStyleBackColor = true;
            this.showOriginalEventCubeCheckBox.CheckedChanged += new System.EventHandler(this.showOriginalEventCubeCheckBox_CheckedChanged);
            // 
            // deleteEventCubeButton
            // 
            this.deleteEventCubeButton.Location = new System.Drawing.Point(165, 3);
            this.deleteEventCubeButton.Name = "deleteEventCubeButton";
            this.deleteEventCubeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEventCubeButton.TabIndex = 2;
            this.deleteEventCubeButton.Text = "删除";
            this.deleteEventCubeButton.UseVisualStyleBackColor = true;
            this.deleteEventCubeButton.Click += new System.EventHandler(this.deleteEventCubeButton_Click);
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
            this.CustomTabControl.Controls.Add(this.EventCubeTabPage);
            this.CustomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomTabControl.Location = new System.Drawing.Point(0, 0);
            this.CustomTabControl.Name = "CustomTabControl";
            this.CustomTabControl.SelectedIndex = 0;
            this.CustomTabControl.Size = new System.Drawing.Size(846, 544);
            this.CustomTabControl.TabIndex = 0;
            // 
            // EventCubeListView
            // 
            this.EventCubeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.EventCubeListView.ContextMenuStrip = this.EventCubeContextMenuStrip;
            this.EventCubeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventCubeListView.FullRowSelect = true;
            this.EventCubeListView.HideSelection = false;
            this.EventCubeListView.Location = new System.Drawing.Point(0, 0);
            this.EventCubeListView.MultiSelect = false;
            this.EventCubeListView.Name = "EventCubeListView";
            this.EventCubeListView.ShowItemToolTips = true;
            this.EventCubeListView.Size = new System.Drawing.Size(832, 483);
            this.EventCubeListView.TabIndex = 13;
            this.EventCubeListView.UseCompatibleStateImageBehavior = false;
            this.EventCubeListView.View = System.Windows.Forms.View.Details;
            this.EventCubeListView.SelectedIndexChanged += new System.EventHandler(this.EventCubeListView_SelectedIndexChanged);
            this.EventCubeListView.DoubleClick += new System.EventHandler(this.EventCubeListView_DoubleClick);
            this.EventCubeListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EventCubeListView_KeyPress);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ID";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "名称";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Prefab名称";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "是否可重复触发";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "位置";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "旋转值";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "物件大小";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "碰撞体大小";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "EventCube是否强制压到地上";
            this.columnHeader15.Width = 200;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "EventCube是否为触发器";
            this.columnHeader16.Width = 200;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "点击的类型";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "备注（互动用）";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "互动界面出现高度";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "互动事件";
            this.columnHeader20.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "生成条件";
            this.columnHeader21.Width = 150;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "出现条件";
            this.columnHeader22.Width = 150;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "是否显示光点";
            this.columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "中心点";
            // 
            // EventCubeTabControlUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomTabControl);
            this.DoubleBuffered = true;
            this.Name = "EventCubeTabControlUserControl";
            this.Size = new System.Drawing.Size(846, 544);
            this.EventCubeTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.EventCubeContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.CustomTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage EventCubeTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button newEventCubeButton;
        private System.Windows.Forms.Button editEventCubeButton;
        private System.Windows.Forms.CheckBox showOriginalEventCubeCheckBox;
        private System.Windows.Forms.Button deleteEventCubeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TabControl CustomTabControl;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip EventCubeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFilePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ListView EventCubeListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
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
    }
}
