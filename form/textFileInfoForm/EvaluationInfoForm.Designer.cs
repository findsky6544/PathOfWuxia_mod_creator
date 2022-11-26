
namespace 侠之道mod制作器
{
    partial class EvaluationInfoForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.EvaluationPointInfoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.editEvaluationPointInfoButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EvaluationRewardListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.editEvaluationRewardButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 587);
            this.panel1.TabIndex = 20;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 97);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(484, 446);
            this.tabControl2.TabIndex = 30;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.EvaluationPointInfoListView);
            this.tabPage6.Controls.Add(this.panel2);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(476, 420);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "评价点资讯";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // EvaluationPointInfoListView
            // 
            this.EvaluationPointInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.EvaluationPointInfoListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluationPointInfoListView.FullRowSelect = true;
            this.EvaluationPointInfoListView.HideSelection = false;
            this.EvaluationPointInfoListView.Location = new System.Drawing.Point(0, 31);
            this.EvaluationPointInfoListView.MultiSelect = false;
            this.EvaluationPointInfoListView.Name = "EvaluationPointInfoListView";
            this.EvaluationPointInfoListView.ShowItemToolTips = true;
            this.EvaluationPointInfoListView.Size = new System.Drawing.Size(476, 389);
            this.EvaluationPointInfoListView.TabIndex = 16;
            this.EvaluationPointInfoListView.UseCompatibleStateImageBehavior = false;
            this.EvaluationPointInfoListView.View = System.Windows.Forms.View.Details;
            this.EvaluationPointInfoListView.DoubleClick += new System.EventHandler(this.editEquipButton_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "评价点";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "描述";
            this.columnHeader2.Width = 200;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editEvaluationPointInfoButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 31);
            this.panel2.TabIndex = 0;
            // 
            // editEvaluationPointInfoButton
            // 
            this.editEvaluationPointInfoButton.Location = new System.Drawing.Point(84, 3);
            this.editEvaluationPointInfoButton.Name = "editEvaluationPointInfoButton";
            this.editEvaluationPointInfoButton.Size = new System.Drawing.Size(75, 23);
            this.editEvaluationPointInfoButton.TabIndex = 0;
            this.editEvaluationPointInfoButton.Text = "修改";
            this.editEvaluationPointInfoButton.UseVisualStyleBackColor = true;
            this.editEvaluationPointInfoButton.Click += new System.EventHandler(this.editEquipButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EvaluationRewardListView);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(476, 420);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "评价奖励";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EvaluationRewardListView
            // 
            this.EvaluationRewardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7});
            this.EvaluationRewardListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluationRewardListView.FullRowSelect = true;
            this.EvaluationRewardListView.HideSelection = false;
            this.EvaluationRewardListView.Location = new System.Drawing.Point(0, 31);
            this.EvaluationRewardListView.MultiSelect = false;
            this.EvaluationRewardListView.Name = "EvaluationRewardListView";
            this.EvaluationRewardListView.ShowItemToolTips = true;
            this.EvaluationRewardListView.Size = new System.Drawing.Size(476, 389);
            this.EvaluationRewardListView.TabIndex = 18;
            this.EvaluationRewardListView.UseCompatibleStateImageBehavior = false;
            this.EvaluationRewardListView.View = System.Windows.Forms.View.Details;
            this.EvaluationRewardListView.DoubleClick += new System.EventHandler(this.editPropertyButton_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "等级";
            this.columnHeader3.Width = 100;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.editEvaluationRewardButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(476, 31);
            this.panel4.TabIndex = 17;
            // 
            // editEvaluationRewardButton
            // 
            this.editEvaluationRewardButton.Location = new System.Drawing.Point(84, 4);
            this.editEvaluationRewardButton.Name = "editEvaluationRewardButton";
            this.editEvaluationRewardButton.Size = new System.Drawing.Size(75, 23);
            this.editEvaluationRewardButton.TabIndex = 0;
            this.editEvaluationRewardButton.Text = "修改";
            this.editEvaluationRewardButton.UseVisualStyleBackColor = true;
            this.editEvaluationRewardButton.Click += new System.EventHandler(this.editPropertyButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.saveButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 543);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 44);
            this.panel5.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(206, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DescriptionTextBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.NameTextBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.idLabel);
            this.panel3.Controls.Add(this.RemarkTextBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.idTextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 97);
            this.panel3.TabIndex = 32;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(40, 64);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(432, 21);
            this.DescriptionTextBox.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "描述";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(180, 10);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(292, 21);
            this.NameTextBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "名称";
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
            // RemarkTextBox
            // 
            this.RemarkTextBox.Location = new System.Drawing.Point(40, 37);
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(432, 21);
            this.RemarkTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "备注";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(37, 10);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(102, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "分数";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "编号";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "数量";
            // 
            // EvaluationInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 587);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "EvaluationInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluation信息";
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox RemarkTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button editEvaluationPointInfoButton;
        private System.Windows.Forms.ListView EvaluationPointInfoListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView EvaluationRewardListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button editEvaluationRewardButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}