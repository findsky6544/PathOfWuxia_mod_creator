
namespace 侠之道mod制作器
{
    partial class ForgeInfoForm
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
            this.selectPropsButton = new System.Windows.Forms.Button();
            this.OpenRoundNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.IsRestrictionCountCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PropsIdTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.IsSpecialCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RemarkTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpenRoundNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectPropsButton);
            this.panel1.Controls.Add(this.OpenRoundNumericUpDown);
            this.panel1.Controls.Add(this.LevelNumericUpDown);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.IsRestrictionCountCheckBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.PropsIdTextBox);
            this.panel1.Controls.Add(this.idTextBox);
            this.panel1.Controls.Add(this.IsSpecialCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RemarkTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 206);
            this.panel1.TabIndex = 20;
            // 
            // selectPropsButton
            // 
            this.selectPropsButton.Location = new System.Drawing.Point(260, 64);
            this.selectPropsButton.Name = "selectPropsButton";
            this.selectPropsButton.Size = new System.Drawing.Size(99, 23);
            this.selectPropsButton.TabIndex = 83;
            this.selectPropsButton.Text = "选择装备";
            this.selectPropsButton.UseVisualStyleBackColor = true;
            this.selectPropsButton.Click += new System.EventHandler(this.selectPropsButton_Click);
            // 
            // OpenRoundNumericUpDown
            // 
            this.OpenRoundNumericUpDown.Location = new System.Drawing.Point(94, 120);
            this.OpenRoundNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.OpenRoundNumericUpDown.Name = "OpenRoundNumericUpDown";
            this.OpenRoundNumericUpDown.Size = new System.Drawing.Size(160, 21);
            this.OpenRoundNumericUpDown.TabIndex = 52;
            // 
            // LevelNumericUpDown
            // 
            this.LevelNumericUpDown.Location = new System.Drawing.Point(94, 93);
            this.LevelNumericUpDown.Name = "LevelNumericUpDown";
            this.LevelNumericUpDown.Size = new System.Drawing.Size(160, 21);
            this.LevelNumericUpDown.TabIndex = 51;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(94, 169);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 17;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // IsRestrictionCountCheckBox
            // 
            this.IsRestrictionCountCheckBox.AutoSize = true;
            this.IsRestrictionCountCheckBox.Location = new System.Drawing.Point(134, 147);
            this.IsRestrictionCountCheckBox.Name = "IsRestrictionCountCheckBox";
            this.IsRestrictionCountCheckBox.Size = new System.Drawing.Size(96, 16);
            this.IsRestrictionCountCheckBox.TabIndex = 50;
            this.IsRestrictionCountCheckBox.Text = "是否限制数量";
            this.IsRestrictionCountCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "锻造装备编号";
            // 
            // PropsIdTextBox
            // 
            this.PropsIdTextBox.Location = new System.Drawing.Point(94, 66);
            this.PropsIdTextBox.Name = "PropsIdTextBox";
            this.PropsIdTextBox.Size = new System.Drawing.Size(160, 21);
            this.PropsIdTextBox.TabIndex = 41;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(94, 12);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(160, 21);
            this.idTextBox.TabIndex = 0;
            // 
            // IsSpecialCheckBox
            // 
            this.IsSpecialCheckBox.AutoSize = true;
            this.IsSpecialCheckBox.Location = new System.Drawing.Point(20, 147);
            this.IsSpecialCheckBox.Name = "IsSpecialCheckBox";
            this.IsSpecialCheckBox.Size = new System.Drawing.Size(108, 16);
            this.IsSpecialCheckBox.TabIndex = 32;
            this.IsSpecialCheckBox.Text = "是否为特殊装备";
            this.IsSpecialCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "锻造需求等级";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(71, 15);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(17, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "开启回合";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "备注";
            // 
            // RemarkTextBox
            // 
            this.RemarkTextBox.Location = new System.Drawing.Point(94, 39);
            this.RemarkTextBox.Name = "RemarkTextBox";
            this.RemarkTextBox.Size = new System.Drawing.Size(160, 21);
            this.RemarkTextBox.TabIndex = 20;
            // 
            // ForgeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 206);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(200, 39);
            this.Name = "ForgeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forge信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OpenRoundNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox IsRestrictionCountCheckBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox PropsIdTextBox;
        public System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.CheckBox IsSpecialCheckBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label idLabel;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox RemarkTextBox;
        private System.Windows.Forms.NumericUpDown OpenRoundNumericUpDown;
        private System.Windows.Forms.NumericUpDown LevelNumericUpDown;
        private System.Windows.Forms.Button selectPropsButton;
    }
}