
namespace 侠之道mod制作器
{
    partial class OpenUIEvaluationActionForm
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
            this.movieidTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectCinematicButton = new System.Windows.Forms.Button();
            this.selectEvaluationButton = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(187, 99);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(80, 99);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // movieidTextBox
            // 
            this.movieidTextBox.Location = new System.Drawing.Point(96, 53);
            this.movieidTextBox.Name = "movieidTextBox";
            this.movieidTextBox.Size = new System.Drawing.Size(121, 21);
            this.movieidTextBox.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "接续的movieID";
            // 
            // selectCinematicButton
            // 
            this.selectCinematicButton.Location = new System.Drawing.Point(223, 51);
            this.selectCinematicButton.Name = "selectCinematicButton";
            this.selectCinematicButton.Size = new System.Drawing.Size(99, 23);
            this.selectCinematicButton.TabIndex = 41;
            this.selectCinematicButton.Text = "选择movie";
            this.selectCinematicButton.UseVisualStyleBackColor = true;
            this.selectCinematicButton.Click += new System.EventHandler(this.selectAdjustmentButton_Click);
            // 
            // selectEvaluationButton
            // 
            this.selectEvaluationButton.Location = new System.Drawing.Point(223, 24);
            this.selectEvaluationButton.Name = "selectEvaluationButton";
            this.selectEvaluationButton.Size = new System.Drawing.Size(99, 23);
            this.selectEvaluationButton.TabIndex = 52;
            this.selectEvaluationButton.Text = "选择评价";
            this.selectEvaluationButton.UseVisualStyleBackColor = true;
            this.selectEvaluationButton.Click += new System.EventHandler(this.selectEvaluationButton_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(96, 26);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(121, 21);
            this.idTextBox.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "评价编号";
            // 
            // OpenUIEvaluationActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 155);
            this.Controls.Add(this.selectEvaluationButton);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectCinematicButton);
            this.Controls.Add(this.movieidTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "OpenUIEvaluationActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开启评价界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox movieidTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectCinematicButton;
        private System.Windows.Forms.Button selectEvaluationButton;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label3;
    }
}