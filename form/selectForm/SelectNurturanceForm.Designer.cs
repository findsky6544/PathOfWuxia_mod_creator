
namespace 侠之道mod制作器
{
    partial class SelectNurturanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectNurturanceForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.NurturanceListView = new System.Windows.Forms.ListView();
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
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NurturanceImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.readCinematicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Location = new System.Drawing.Point(194, 433);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.Location = new System.Drawing.Point(304, 433);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(203, 21);
            this.searchTextBox.TabIndex = 9;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(221, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // NurturanceListView
            // 
            this.NurturanceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NurturanceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.NurturanceListView.ContextMenuStrip = this.contextMenuStrip1;
            this.NurturanceListView.FullRowSelect = true;
            this.NurturanceListView.HideSelection = false;
            this.NurturanceListView.Location = new System.Drawing.Point(12, 40);
            this.NurturanceListView.MultiSelect = false;
            this.NurturanceListView.Name = "NurturanceListView";
            this.NurturanceListView.ShowItemToolTips = true;
            this.NurturanceListView.Size = new System.Drawing.Size(543, 388);
            this.NurturanceListView.SmallImageList = this.NurturanceImageList;
            this.NurturanceListView.TabIndex = 12;
            this.NurturanceListView.UseCompatibleStateImageBehavior = false;
            this.NurturanceListView.View = System.Windows.Forms.View.Details;
            this.NurturanceListView.DoubleClick += new System.EventHandler(this.NurturanceListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图片";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "指令名称";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "备注";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "指令功能";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "开启的界面";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "增加的疲惫值";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "显示条件";
            this.columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "开放条件";
            this.columnHeader9.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "加成条件";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "加成数值";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "加成Tip";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "背景编号";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "movie编号（基础编号）";
            this.columnHeader15.Width = 150;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "未开放的Tip";
            this.columnHeader16.Width = 150;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "其他提升的Tip";
            this.columnHeader17.Width = 150;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "设施功能Tip";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "奖励";
            this.columnHeader19.Width = 150;
            // 
            // NurturanceImageList
            // 
            this.NurturanceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NurturanceImageList.ImageStream")));
            this.NurturanceImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.NurturanceImageList.Images.SetKeyName(0, "60211");
            this.NurturanceImageList.Images.SetKeyName(1, "60212");
            this.NurturanceImageList.Images.SetKeyName(2, "60213");
            this.NurturanceImageList.Images.SetKeyName(3, "60221");
            this.NurturanceImageList.Images.SetKeyName(4, "60222");
            this.NurturanceImageList.Images.SetKeyName(5, "60223");
            this.NurturanceImageList.Images.SetKeyName(6, "60231");
            this.NurturanceImageList.Images.SetKeyName(7, "60232");
            this.NurturanceImageList.Images.SetKeyName(8, "60233");
            this.NurturanceImageList.Images.SetKeyName(9, "60241");
            this.NurturanceImageList.Images.SetKeyName(10, "60242");
            this.NurturanceImageList.Images.SetKeyName(11, "60243");
            this.NurturanceImageList.Images.SetKeyName(12, "60300");
            this.NurturanceImageList.Images.SetKeyName(13, "60301");
            this.NurturanceImageList.Images.SetKeyName(14, "60302");
            this.NurturanceImageList.Images.SetKeyName(15, "60303");
            this.NurturanceImageList.Images.SetKeyName(16, "60304");
            this.NurturanceImageList.Images.SetKeyName(17, "60305");
            this.NurturanceImageList.Images.SetKeyName(18, "60306");
            this.NurturanceImageList.Images.SetKeyName(19, "60307");
            this.NurturanceImageList.Images.SetKeyName(20, "60313");
            this.NurturanceImageList.Images.SetKeyName(21, "60411");
            this.NurturanceImageList.Images.SetKeyName(22, "60412");
            this.NurturanceImageList.Images.SetKeyName(23, "60413");
            this.NurturanceImageList.Images.SetKeyName(24, "60421");
            this.NurturanceImageList.Images.SetKeyName(25, "60422");
            this.NurturanceImageList.Images.SetKeyName(26, "60423");
            this.NurturanceImageList.Images.SetKeyName(27, "60431");
            this.NurturanceImageList.Images.SetKeyName(28, "60432");
            this.NurturanceImageList.Images.SetKeyName(29, "60433");
            this.NurturanceImageList.Images.SetKeyName(30, "60441");
            this.NurturanceImageList.Images.SetKeyName(31, "60442");
            this.NurturanceImageList.Images.SetKeyName(32, "60443");
            this.NurturanceImageList.Images.SetKeyName(33, "60451");
            this.NurturanceImageList.Images.SetKeyName(34, "60452");
            this.NurturanceImageList.Images.SetKeyName(35, "60453");
            this.NurturanceImageList.Images.SetKeyName(36, "60461");
            this.NurturanceImageList.Images.SetKeyName(37, "60462");
            this.NurturanceImageList.Images.SetKeyName(38, "60463");
            this.NurturanceImageList.Images.SetKeyName(39, "60464");
            this.NurturanceImageList.Images.SetKeyName(40, "60465");
            this.NurturanceImageList.Images.SetKeyName(41, "60466");
            this.NurturanceImageList.Images.SetKeyName(42, "60467");
            this.NurturanceImageList.Images.SetKeyName(43, "60601");
            this.NurturanceImageList.Images.SetKeyName(44, "60602");
            this.NurturanceImageList.Images.SetKeyName(45, "60603");
            this.NurturanceImageList.Images.SetKeyName(46, "60604");
            this.NurturanceImageList.Images.SetKeyName(47, "60615");
            this.NurturanceImageList.Images.SetKeyName(48, "60624");
            this.NurturanceImageList.Images.SetKeyName(49, "60625");
            this.NurturanceImageList.Images.SetKeyName(50, "60626");
            this.NurturanceImageList.Images.SetKeyName(51, "60627");
            this.NurturanceImageList.Images.SetKeyName(52, "60628");
            this.NurturanceImageList.Images.SetKeyName(53, "60629");
            this.NurturanceImageList.Images.SetKeyName(54, "60701");
            this.NurturanceImageList.Images.SetKeyName(55, "60702");
            this.NurturanceImageList.Images.SetKeyName(56, "60703");
            this.NurturanceImageList.Images.SetKeyName(57, "60704");
            this.NurturanceImageList.Images.SetKeyName(58, "60705");
            this.NurturanceImageList.Images.SetKeyName(59, "60706");
            this.NurturanceImageList.Images.SetKeyName(60, "60707");
            this.NurturanceImageList.Images.SetKeyName(61, "60911");
            this.NurturanceImageList.Images.SetKeyName(62, "60912");
            this.NurturanceImageList.Images.SetKeyName(63, "60913");
            this.NurturanceImageList.Images.SetKeyName(64, "Nurturance_601");
            this.NurturanceImageList.Images.SetKeyName(65, "Nurturance_602");
            this.NurturanceImageList.Images.SetKeyName(66, "Nurturance_603");
            this.NurturanceImageList.Images.SetKeyName(67, "Nurturance_604");
            this.NurturanceImageList.Images.SetKeyName(68, "Nurturance_605");
            this.NurturanceImageList.Images.SetKeyName(69, "Nurturance_606");
            this.NurturanceImageList.Images.SetKeyName(70, "Nurturance_607");
            this.NurturanceImageList.Images.SetKeyName(71, "Nurturance_608");
            this.NurturanceImageList.Images.SetKeyName(72, "Nurturance_609");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.readCinematicToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // readCinematicToolStripMenuItem
            // 
            this.readCinematicToolStripMenuItem.Name = "readCinematicToolStripMenuItem";
            this.readCinematicToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readCinematicToolStripMenuItem.Text = "查看流程";
            this.readCinematicToolStripMenuItem.Click += new System.EventHandler(this.readCinematicToolStripMenuItem_Click);
            // 
            // SelectNurturanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 468);
            this.Controls.Add(this.NurturanceListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SelectNurturanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-选择养成指令";
            this.Shown += new System.EventHandler(this.SelectNurturanceForm_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView NurturanceListView;
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
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ImageList NurturanceImageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem readCinematicToolStripMenuItem;
    }
}