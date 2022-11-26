
namespace 侠之道mod制作器
{
    partial class BattleAreaInfoForm
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
            this.battleMapTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.afterWinMovieTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editDropButton = new System.Windows.Forms.Button();
            this.deleteDropButton = new System.Windows.Forms.Button();
            this.dropPropsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addDropButton = new System.Windows.Forms.Button();
            this.selectLoseCinematicButton = new System.Windows.Forms.Button();
            this.selectWinCinematicButton = new System.Windows.Forms.Button();
            this.afterLoseMovieTextBox = new System.Windows.Forms.TextBox();
            this.selectBattleScheduleButton = new System.Windows.Forms.Button();
            this.scheduleIDTextBox = new System.Windows.Forms.TextBox();
            this.selectBattleMapButton = new System.Windows.Forms.Button();
            this.remarkTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.musicNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Location = new System.Drawing.Point(6, 21);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(29, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(89, 18);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(335, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // battleMapTextBox
            // 
            this.battleMapTextBox.Location = new System.Drawing.Point(89, 45);
            this.battleMapTextBox.Name = "battleMapTextBox";
            this.battleMapTextBox.Size = new System.Drawing.Size(335, 21);
            this.battleMapTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "战斗网格编号";
            // 
            // afterWinMovieTextBox
            // 
            this.afterWinMovieTextBox.Location = new System.Drawing.Point(134, 126);
            this.afterWinMovieTextBox.Name = "afterWinMovieTextBox";
            this.afterWinMovieTextBox.Size = new System.Drawing.Size(290, 21);
            this.afterWinMovieTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "战斗排程编号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "战斗结束后失败movie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "战斗结束后获胜movie";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "一开始战斗音乐";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.selectLoseCinematicButton);
            this.panel1.Controls.Add(this.selectWinCinematicButton);
            this.panel1.Controls.Add(this.afterLoseMovieTextBox);
            this.panel1.Controls.Add(this.selectBattleScheduleButton);
            this.panel1.Controls.Add(this.scheduleIDTextBox);
            this.panel1.Controls.Add(this.selectBattleMapButton);
            this.panel1.Controls.Add(this.remarkTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.musicNameTextBox);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.battleMapTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.afterWinMovieTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 392);
            this.panel1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editDropButton);
            this.groupBox1.Controls.Add(this.deleteDropButton);
            this.groupBox1.Controls.Add(this.dropPropsListView);
            this.groupBox1.Controls.Add(this.addDropButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 144);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "战斗掉落物";
            // 
            // editDropButton
            // 
            this.editDropButton.Location = new System.Drawing.Point(108, 20);
            this.editDropButton.Name = "editDropButton";
            this.editDropButton.Size = new System.Drawing.Size(96, 23);
            this.editDropButton.TabIndex = 31;
            this.editDropButton.Text = "修改掉落";
            this.editDropButton.UseVisualStyleBackColor = true;
            this.editDropButton.Click += new System.EventHandler(this.editDropButton_Click);
            // 
            // deleteDropButton
            // 
            this.deleteDropButton.Location = new System.Drawing.Point(210, 20);
            this.deleteDropButton.Name = "deleteDropButton";
            this.deleteDropButton.Size = new System.Drawing.Size(96, 23);
            this.deleteDropButton.TabIndex = 30;
            this.deleteDropButton.Text = "删除掉落";
            this.deleteDropButton.UseVisualStyleBackColor = true;
            this.deleteDropButton.Click += new System.EventHandler(this.deleteDropButton_Click);
            // 
            // dropPropsListView
            // 
            this.dropPropsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.dropPropsListView.FullRowSelect = true;
            this.dropPropsListView.HideSelection = false;
            this.dropPropsListView.Location = new System.Drawing.Point(3, 49);
            this.dropPropsListView.MultiSelect = false;
            this.dropPropsListView.Name = "dropPropsListView";
            this.dropPropsListView.ShowItemToolTips = true;
            this.dropPropsListView.Size = new System.Drawing.Size(509, 89);
            this.dropPropsListView.TabIndex = 29;
            this.dropPropsListView.UseCompatibleStateImageBehavior = false;
            this.dropPropsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数量";
            this.columnHeader2.Width = 150;
            // 
            // addDropButton
            // 
            this.addDropButton.Location = new System.Drawing.Point(6, 20);
            this.addDropButton.Name = "addDropButton";
            this.addDropButton.Size = new System.Drawing.Size(96, 23);
            this.addDropButton.TabIndex = 25;
            this.addDropButton.Text = "添加掉落";
            this.addDropButton.UseVisualStyleBackColor = true;
            this.addDropButton.Click += new System.EventHandler(this.addDropButton_Click);
            // 
            // selectLoseCinematicButton
            // 
            this.selectLoseCinematicButton.Location = new System.Drawing.Point(430, 151);
            this.selectLoseCinematicButton.Name = "selectLoseCinematicButton";
            this.selectLoseCinematicButton.Size = new System.Drawing.Size(96, 23);
            this.selectLoseCinematicButton.TabIndex = 28;
            this.selectLoseCinematicButton.Tag = "lose";
            this.selectLoseCinematicButton.Text = "选择cinematic";
            this.selectLoseCinematicButton.UseVisualStyleBackColor = true;
            this.selectLoseCinematicButton.Click += new System.EventHandler(this.selectLoseCinematicButton_Click);
            // 
            // selectWinCinematicButton
            // 
            this.selectWinCinematicButton.Location = new System.Drawing.Point(430, 124);
            this.selectWinCinematicButton.Name = "selectWinCinematicButton";
            this.selectWinCinematicButton.Size = new System.Drawing.Size(96, 23);
            this.selectWinCinematicButton.TabIndex = 27;
            this.selectWinCinematicButton.Tag = "win";
            this.selectWinCinematicButton.Text = "选择cinematic";
            this.selectWinCinematicButton.UseVisualStyleBackColor = true;
            this.selectWinCinematicButton.Click += new System.EventHandler(this.selectWinCinematicButton_Click);
            // 
            // afterLoseMovieTextBox
            // 
            this.afterLoseMovieTextBox.Location = new System.Drawing.Point(134, 153);
            this.afterLoseMovieTextBox.Name = "afterLoseMovieTextBox";
            this.afterLoseMovieTextBox.Size = new System.Drawing.Size(290, 21);
            this.afterLoseMovieTextBox.TabIndex = 26;
            // 
            // selectBattleScheduleButton
            // 
            this.selectBattleScheduleButton.Location = new System.Drawing.Point(430, 70);
            this.selectBattleScheduleButton.Name = "selectBattleScheduleButton";
            this.selectBattleScheduleButton.Size = new System.Drawing.Size(96, 23);
            this.selectBattleScheduleButton.TabIndex = 24;
            this.selectBattleScheduleButton.Text = "选择战斗排程";
            this.selectBattleScheduleButton.UseVisualStyleBackColor = true;
            this.selectBattleScheduleButton.Click += new System.EventHandler(this.selectBattleScheduleButton_Click);
            // 
            // scheduleIDTextBox
            // 
            this.scheduleIDTextBox.Location = new System.Drawing.Point(89, 72);
            this.scheduleIDTextBox.Name = "scheduleIDTextBox";
            this.scheduleIDTextBox.Size = new System.Drawing.Size(335, 21);
            this.scheduleIDTextBox.TabIndex = 23;
            // 
            // selectBattleMapButton
            // 
            this.selectBattleMapButton.Location = new System.Drawing.Point(430, 43);
            this.selectBattleMapButton.Name = "selectBattleMapButton";
            this.selectBattleMapButton.Size = new System.Drawing.Size(96, 23);
            this.selectBattleMapButton.TabIndex = 22;
            this.selectBattleMapButton.Text = "选择战斗网格";
            this.selectBattleMapButton.UseVisualStyleBackColor = true;
            this.selectBattleMapButton.Click += new System.EventHandler(this.selectBattleMapButton_Click);
            // 
            // remarkTextBox
            // 
            this.remarkTextBox.Location = new System.Drawing.Point(71, 180);
            this.remarkTextBox.Name = "remarkTextBox";
            this.remarkTextBox.Size = new System.Drawing.Size(353, 21);
            this.remarkTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "备注说明";
            // 
            // musicNameTextBox
            // 
            this.musicNameTextBox.Location = new System.Drawing.Point(104, 99);
            this.musicNameTextBox.Name = "musicNameTextBox";
            this.musicNameTextBox.Size = new System.Drawing.Size(320, 21);
            this.musicNameTextBox.TabIndex = 19;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(146, 357);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BattleAreaInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 392);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "BattleAreaInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BattleArea信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.TextBox idTextBox;
        public System.Windows.Forms.TextBox battleMapTextBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox afterWinMovieTextBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox remarkTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox musicNameTextBox;
        public System.Windows.Forms.Button selectBattleMapButton;
        public System.Windows.Forms.Button addDropButton;
        public System.Windows.Forms.Button selectBattleScheduleButton;
        public System.Windows.Forms.TextBox scheduleIDTextBox;
        public System.Windows.Forms.TextBox afterLoseMovieTextBox;
        public System.Windows.Forms.Button selectLoseCinematicButton;
        public System.Windows.Forms.Button selectWinCinematicButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView dropPropsListView;
        public System.Windows.Forms.Button deleteDropButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button editDropButton;
    }
}