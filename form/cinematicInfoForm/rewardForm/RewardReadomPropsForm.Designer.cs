
namespace 侠之道mod制作器
{
    partial class RewardReadomPropsForm
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
            this.RandomCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.RandomMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RandomMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.IsRepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.selectPropsButton = new System.Windows.Forms.Button();
            this.propsIdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RandomCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMinNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMaxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // RandomCountNumericUpDown
            // 
            this.RandomCountNumericUpDown.Location = new System.Drawing.Point(121, 12);
            this.RandomCountNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.RandomCountNumericUpDown.Name = "RandomCountNumericUpDown";
            this.RandomCountNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.RandomCountNumericUpDown.TabIndex = 20;
            this.RandomCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "总共随机几次";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(166, 142);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(59, 142);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // RandomMinNumericUpDown
            // 
            this.RandomMinNumericUpDown.Location = new System.Drawing.Point(121, 39);
            this.RandomMinNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.RandomMinNumericUpDown.Name = "RandomMinNumericUpDown";
            this.RandomMinNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.RandomMinNumericUpDown.TabIndex = 63;
            this.RandomMinNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "每次随机最小值";
            // 
            // RandomMaxNumericUpDown
            // 
            this.RandomMaxNumericUpDown.Location = new System.Drawing.Point(121, 66);
            this.RandomMaxNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.RandomMaxNumericUpDown.Name = "RandomMaxNumericUpDown";
            this.RandomMaxNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.RandomMaxNumericUpDown.TabIndex = 65;
            this.RandomMaxNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 64;
            this.label5.Text = "每次随机最大值";
            // 
            // IsRepeatCheckBox
            // 
            this.IsRepeatCheckBox.AutoSize = true;
            this.IsRepeatCheckBox.Location = new System.Drawing.Point(121, 93);
            this.IsRepeatCheckBox.Name = "IsRepeatCheckBox";
            this.IsRepeatCheckBox.Size = new System.Drawing.Size(96, 16);
            this.IsRepeatCheckBox.TabIndex = 66;
            this.IsRepeatCheckBox.Text = "是否重复随机";
            this.IsRepeatCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectPropsButton
            // 
            this.selectPropsButton.Location = new System.Drawing.Point(247, 113);
            this.selectPropsButton.Name = "selectPropsButton";
            this.selectPropsButton.Size = new System.Drawing.Size(99, 23);
            this.selectPropsButton.TabIndex = 76;
            this.selectPropsButton.Text = "选择道具";
            this.selectPropsButton.UseVisualStyleBackColor = true;
            this.selectPropsButton.Click += new System.EventHandler(this.selectPropsButton_Click);
            // 
            // propsIdTextBox
            // 
            this.propsIdTextBox.Location = new System.Drawing.Point(120, 115);
            this.propsIdTextBox.Name = "propsIdTextBox";
            this.propsIdTextBox.Size = new System.Drawing.Size(121, 21);
            this.propsIdTextBox.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 74;
            this.label6.Text = "道具编号";
            // 
            // RewardReadomPropsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 181);
            this.Controls.Add(this.selectPropsButton);
            this.Controls.Add(this.propsIdTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.IsRepeatCheckBox);
            this.Controls.Add(this.RandomMaxNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RandomMinNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RandomCountNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "RewardReadomPropsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机道具";
            ((System.ComponentModel.ISupportInitialize)(this.RandomCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMinNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomMaxNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown RandomCountNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown RandomMinNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RandomMaxNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox IsRepeatCheckBox;
        private System.Windows.Forms.Button selectPropsButton;
        private System.Windows.Forms.TextBox propsIdTextBox;
        private System.Windows.Forms.Label label6;
    }
}