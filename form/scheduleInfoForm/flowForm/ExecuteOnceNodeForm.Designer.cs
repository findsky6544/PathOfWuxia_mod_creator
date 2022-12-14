
namespace 侠之道mod制作器
{
    partial class ExecuteOnceNodeForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.prallelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nextNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.selectNextButton = new System.Windows.Forms.Button();
            this.selectPrallelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prallelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(86, 73);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(183, 73);
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
            this.label3.Location = new System.Drawing.Point(31, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "下一个节点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "失败时节点";
            this.label4.Visible = false;
            // 
            // prallelNumericUpDown
            // 
            this.prallelNumericUpDown.Location = new System.Drawing.Point(102, 39);
            this.prallelNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.prallelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.prallelNumericUpDown.Name = "prallelNumericUpDown";
            this.prallelNumericUpDown.Size = new System.Drawing.Size(143, 21);
            this.prallelNumericUpDown.TabIndex = 9;
            this.prallelNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.prallelNumericUpDown.Visible = false;
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(102, 12);
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
            this.selectNextButton.Location = new System.Drawing.Point(251, 12);
            this.selectNextButton.Name = "selectNextButton";
            this.selectNextButton.Size = new System.Drawing.Size(75, 23);
            this.selectNextButton.TabIndex = 10;
            this.selectNextButton.Text = "选择节点";
            this.selectNextButton.UseVisualStyleBackColor = true;
            this.selectNextButton.Click += new System.EventHandler(this.selectNextButton_Click);
            // 
            // selectPrallelButton
            // 
            this.selectPrallelButton.Location = new System.Drawing.Point(251, 37);
            this.selectPrallelButton.Name = "selectPrallelButton";
            this.selectPrallelButton.Size = new System.Drawing.Size(75, 23);
            this.selectPrallelButton.TabIndex = 11;
            this.selectPrallelButton.Text = "选择节点";
            this.selectPrallelButton.UseVisualStyleBackColor = true;
            this.selectPrallelButton.Visible = false;
            this.selectPrallelButton.Click += new System.EventHandler(this.selectPrallelButton_Click);
            // 
            // ExecuteOnceNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 108);
            this.Controls.Add(this.selectPrallelButton);
            this.Controls.Add(this.selectNextButton);
            this.Controls.Add(this.prallelNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ExecuteOnceNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一次性节点";
            ((System.ComponentModel.ISupportInitialize)(this.prallelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown prallelNumericUpDown;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.Button selectNextButton;
        private System.Windows.Forms.Button selectPrallelButton;
    }
}