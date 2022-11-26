
namespace 侠之道mod制作器
{
    partial class BattleResultUnitToUnitForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nextNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectNextButton = new System.Windows.Forms.Button();
            this.selectmove_idButton = new System.Windows.Forms.Button();
            this.move_idTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selecttarget_idButton = new System.Windows.Forms.Button();
            this.target_idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(87, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(184, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 70);
            this.nextNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nextNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nextNumericUpDown.Name = "nextNumericUpDown";
            this.nextNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.nextNumericUpDown.TabIndex = 7;
            this.nextNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // selectNextButton
            // 
            this.selectNextButton.Location = new System.Drawing.Point(251, 70);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // selectmove_idButton
            // 
            this.selectmove_idButton.Location = new System.Drawing.Point(251, 14);
            this.selectmove_idButton.Name = "selectmove_idButton";
            this.selectmove_idButton.Size = new System.Drawing.Size(75, 23);
            this.selectmove_idButton.TabIndex = 33;
            this.selectmove_idButton.Text = "选择部队";
            this.selectmove_idButton.UseVisualStyleBackColor = true;
            this.selectmove_idButton.Click += new System.EventHandler(this.selectUnitAIDButton_Click);
            // 
            // move_idTextBox
            // 
            this.move_idTextBox.Location = new System.Drawing.Point(102, 16);
            this.move_idTextBox.Name = "move_idTextBox";
            this.move_idTextBox.Size = new System.Drawing.Size(143, 21);
            this.move_idTextBox.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "移动部队编号";
            // 
            // selecttarget_idButton
            // 
            this.selecttarget_idButton.Location = new System.Drawing.Point(251, 41);
            this.selecttarget_idButton.Name = "selecttarget_idButton";
            this.selecttarget_idButton.Size = new System.Drawing.Size(75, 23);
            this.selecttarget_idButton.TabIndex = 30;
            this.selecttarget_idButton.Text = "选择部队";
            this.selecttarget_idButton.UseVisualStyleBackColor = true;
            this.selecttarget_idButton.Click += new System.EventHandler(this.selectUnitBIDButton_Click);
            // 
            // target_idTextBox
            // 
            this.target_idTextBox.Location = new System.Drawing.Point(102, 43);
            this.target_idTextBox.Name = "target_idTextBox";
            this.target_idTextBox.Size = new System.Drawing.Size(143, 21);
            this.target_idTextBox.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "移动目标编号";
            // 
            // BattleResultUnitToUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 143);
            this.Controls.Add(this.selectmove_idButton);
            this.Controls.Add(this.move_idTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selecttarget_idButton);
            this.Controls.Add(this.target_idTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BattleResultUnitToUnitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部队会面";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.Button selectNextButton;
        private System.Windows.Forms.Button selectmove_idButton;
        private System.Windows.Forms.TextBox move_idTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selecttarget_idButton;
        private System.Windows.Forms.TextBox target_idTextBox;
        private System.Windows.Forms.Label label1;
    }
}