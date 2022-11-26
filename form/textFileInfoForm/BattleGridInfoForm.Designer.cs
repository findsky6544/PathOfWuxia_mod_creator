
namespace 侠之道mod制作器
{
    partial class BattleGridInfoForm
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
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.MapIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EulerAnglesTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.AllCellsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cellsPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.addCellButton = new System.Windows.Forms.Button();
            this.editCellButton = new System.Windows.Forms.Button();
            this.deleteCellButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LayoutTypeComboBox = new System.Windows.Forms.ComboBox();
            this.selectMapButton = new System.Windows.Forms.Button();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PositionTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(14, 13);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(17, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(37, 10);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // MapIdTextBox
            // 
            this.MapIdTextBox.Location = new System.Drawing.Point(202, 10);
            this.MapIdTextBox.Name = "MapIdTextBox";
            this.MapIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.MapIdTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "场景编号";
            // 
            // EulerAnglesTextBox
            // 
            this.EulerAnglesTextBox.Location = new System.Drawing.Point(360, 90);
            this.EulerAnglesTextBox.Name = "EulerAnglesTextBox";
            this.EulerAnglesTextBox.Size = new System.Drawing.Size(174, 21);
            this.EulerAnglesTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "格子方向";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "中心点的方向";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "中心点的位置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 519);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 359);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有格子的资料";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 304);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.AllCellsListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // AllCellsListView
            // 
            this.AllCellsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.AllCellsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllCellsListView.FullRowSelect = true;
            this.AllCellsListView.HideSelection = false;
            this.AllCellsListView.Location = new System.Drawing.Point(3, 3);
            this.AllCellsListView.MultiSelect = false;
            this.AllCellsListView.Name = "AllCellsListView";
            this.AllCellsListView.ShowItemToolTips = true;
            this.AllCellsListView.Size = new System.Drawing.Size(772, 272);
            this.AllCellsListView.TabIndex = 29;
            this.AllCellsListView.UseCompatibleStateImageBehavior = false;
            this.AllCellsListView.View = System.Windows.Forms.View.Details;
            this.AllCellsListView.SelectedIndexChanged += new System.EventHandler(this.AllCellsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "格子的位置";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "格子的坐标";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "格子的编号";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "是否可以移动";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "是否显示";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "五行单位";
            this.columnHeader6.Width = 150;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预览";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cellsPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 272);
            this.panel2.TabIndex = 1;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
            // 
            // cellsPanel
            // 
            this.cellsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cellsPanel.AutoScroll = true;
            this.cellsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.cellsPanel.Location = new System.Drawing.Point(0, 0);
            this.cellsPanel.Name = "cellsPanel";
            this.cellsPanel.Size = new System.Drawing.Size(769, 269);
            this.cellsPanel.TabIndex = 10;
            this.cellsPanel.Click += new System.EventHandler(this.cellsPanel_Click);
            this.cellsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cellsPanel_MouseMove);
            this.cellsPanel.Resize += new System.EventHandler(this.SelectCellForm_ResizeEnd);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.addCellButton);
            this.panel4.Controls.Add(this.editCellButton);
            this.panel4.Controls.Add(this.deleteCellButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 35);
            this.panel4.TabIndex = 35;
            // 
            // addCellButton
            // 
            this.addCellButton.Location = new System.Drawing.Point(3, 5);
            this.addCellButton.Name = "addCellButton";
            this.addCellButton.Size = new System.Drawing.Size(96, 23);
            this.addCellButton.TabIndex = 32;
            this.addCellButton.Text = "添加格子";
            this.addCellButton.UseVisualStyleBackColor = true;
            this.addCellButton.Click += new System.EventHandler(this.addCellButton_Click);
            // 
            // editCellButton
            // 
            this.editCellButton.Location = new System.Drawing.Point(105, 5);
            this.editCellButton.Name = "editCellButton";
            this.editCellButton.Size = new System.Drawing.Size(96, 23);
            this.editCellButton.TabIndex = 34;
            this.editCellButton.Text = "修改格子";
            this.editCellButton.UseVisualStyleBackColor = true;
            this.editCellButton.Click += new System.EventHandler(this.editCellButton_Click);
            // 
            // deleteCellButton
            // 
            this.deleteCellButton.Location = new System.Drawing.Point(207, 5);
            this.deleteCellButton.Name = "deleteCellButton";
            this.deleteCellButton.Size = new System.Drawing.Size(96, 23);
            this.deleteCellButton.TabIndex = 33;
            this.deleteCellButton.Text = "删除格子";
            this.deleteCellButton.UseVisualStyleBackColor = true;
            this.deleteCellButton.Click += new System.EventHandler(this.deleteCellButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.saveButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 475);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(792, 44);
            this.panel5.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(360, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.idLabel);
            this.panel3.Controls.Add(this.LayoutTypeComboBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.selectMapButton);
            this.panel3.Controls.Add(this.EulerAnglesTextBox);
            this.panel3.Controls.Add(this.RemarkTextBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.MapIdTextBox);
            this.panel3.Controls.Add(this.PositionTextBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.idTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 116);
            this.panel3.TabIndex = 32;
            // 
            // LayoutTypeComboBox
            // 
            this.LayoutTypeComboBox.FormattingEnabled = true;
            this.LayoutTypeComboBox.Location = new System.Drawing.Point(73, 64);
            this.LayoutTypeComboBox.Name = "LayoutTypeComboBox";
            this.LayoutTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.LayoutTypeComboBox.TabIndex = 31;
            // 
            // selectMapButton
            // 
            this.selectMapButton.Location = new System.Drawing.Point(308, 8);
            this.selectMapButton.Name = "selectMapButton";
            this.selectMapButton.Size = new System.Drawing.Size(96, 23);
            this.selectMapButton.TabIndex = 22;
            this.selectMapButton.Text = "选择场景";
            this.selectMapButton.UseVisualStyleBackColor = true;
            this.selectMapButton.Click += new System.EventHandler(this.selectBattleMapButton_Click);
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Location = new System.Drawing.Point(49, 37);
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(485, 21);
            this.RemarkTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "备注";
            // 
            // PositionTextBox
            // 
            this.PositionTextBox.Location = new System.Drawing.Point(97, 90);
            this.PositionTextBox.Name = "PositionTextBox";
            this.PositionTextBox.Size = new System.Drawing.Size(174, 21);
            this.PositionTextBox.TabIndex = 19;
            // 
            // BattleGridInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 519);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "BattleGridInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleGrid信息";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox MapIdTextBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox EulerAnglesTextBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox RemarkTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox PositionTextBox;
        public System.Windows.Forms.Button selectMapButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox LayoutTypeComboBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView AllCellsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel cellsPanel;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button addCellButton;
        public System.Windows.Forms.Button editCellButton;
        public System.Windows.Forms.Button deleteCellButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
    }
}