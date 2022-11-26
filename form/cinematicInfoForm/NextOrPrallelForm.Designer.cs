
namespace 侠之道mod制作器
{
    partial class NextOrPrallelForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.selectNextNodeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectPrallelNodeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nextNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.prallelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prallelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(62, 93);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // selectNextNodeButton
            // 
            this.selectNextNodeButton.Location = new System.Drawing.Point(217, 22);
            this.selectNextNodeButton.Name = "selectNextNodeButton";
            this.selectNextNodeButton.Size = new System.Drawing.Size(99, 23);
            this.selectNextNodeButton.TabIndex = 44;
            this.selectNextNodeButton.Text = "选择节点";
            this.selectNextNodeButton.UseVisualStyleBackColor = true;
            this.selectNextNodeButton.Click += new System.EventHandler(this.selectNextNodeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "下一个节点";
            // 
            // selectPrallelNodeButton
            // 
            this.selectPrallelNodeButton.Location = new System.Drawing.Point(217, 49);
            this.selectPrallelNodeButton.Name = "selectPrallelNodeButton";
            this.selectPrallelNodeButton.Size = new System.Drawing.Size(99, 23);
            this.selectPrallelNodeButton.TabIndex = 47;
            this.selectPrallelNodeButton.Text = "选择节点";
            this.selectPrallelNodeButton.UseVisualStyleBackColor = true;
            this.selectPrallelNodeButton.Click += new System.EventHandler(this.selectPrallelNodeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "并行处理节点";
            // 
            // nextNumericUpDown
            // 
            this.nextNumericUpDown.Location = new System.Drawing.Point(90, 24);
            this.nextNumericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nextNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nextNumericUpDown.Name = "nextNumericUpDown";
            this.nextNumericUpDown.Size = new System.Drawing.Size(121, 21);
            this.nextNumericUpDown.TabIndex = 48;
            this.nextNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // prallelNumericUpDown
            // 
            this.prallelNumericUpDown.Location = new System.Drawing.Point(90, 51);
            this.prallelNumericUpDown.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.prallelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.prallelNumericUpDown.Name = "prallelNumericUpDown";
            this.prallelNumericUpDown.Size = new System.Drawing.Size(121, 21);
            this.prallelNumericUpDown.TabIndex = 49;
            this.prallelNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // NextOrPrallelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 126);
            this.Controls.Add(this.prallelNumericUpDown);
            this.Controls.Add(this.nextNumericUpDown);
            this.Controls.Add(this.selectPrallelNodeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectNextNodeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "NextOrPrallelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改下一个/并行处理节点";
            ((System.ComponentModel.ISupportInitialize)(this.nextNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prallelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectNextNodeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectPrallelNodeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nextNumericUpDown;
        private System.Windows.Forms.NumericUpDown prallelNumericUpDown;
    }
}