
namespace 侠之道mod制作器
{
    partial class ProcessActionForm
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
            this.endgameidTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.musicTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectCinematicButton = new System.Windows.Forms.Button();
            this.cinematicTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.movieTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.isMandatoryStayCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(209, 142);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(102, 142);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // endgameidTextBox
            // 
            this.endgameidTextBox.Location = new System.Drawing.Point(136, 12);
            this.endgameidTextBox.Name = "endgameidTextBox";
            this.endgameidTextBox.Size = new System.Drawing.Size(226, 21);
            this.endgameidTextBox.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 68;
            this.label6.Text = "结局编号";
            // 
            // musicTextBox
            // 
            this.musicTextBox.Location = new System.Drawing.Point(136, 39);
            this.musicTextBox.Name = "musicTextBox";
            this.musicTextBox.Size = new System.Drawing.Size(226, 21);
            this.musicTextBox.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 71;
            this.label1.Text = "结局音乐";
            // 
            // selectCinematicButton
            // 
            this.selectCinematicButton.Location = new System.Drawing.Point(263, 64);
            this.selectCinematicButton.Name = "selectCinematicButton";
            this.selectCinematicButton.Size = new System.Drawing.Size(99, 23);
            this.selectCinematicButton.TabIndex = 75;
            this.selectCinematicButton.Text = "选择cinematic";
            this.selectCinematicButton.UseVisualStyleBackColor = true;
            this.selectCinematicButton.Click += new System.EventHandler(this.selectCinematicButton_Click);
            // 
            // cinematicTextBox
            // 
            this.cinematicTextBox.Location = new System.Drawing.Point(136, 66);
            this.cinematicTextBox.Name = "cinematicTextBox";
            this.cinematicTextBox.Size = new System.Drawing.Size(121, 21);
            this.cinematicTextBox.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 73;
            this.label2.Text = "接续的cinematic编号";
            // 
            // movieTextBox
            // 
            this.movieTextBox.Location = new System.Drawing.Point(136, 93);
            this.movieTextBox.Name = "movieTextBox";
            this.movieTextBox.Size = new System.Drawing.Size(226, 21);
            this.movieTextBox.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 76;
            this.label5.Text = "接续的movie编号";
            // 
            // isMandatoryStayCheckBox
            // 
            this.isMandatoryStayCheckBox.AutoSize = true;
            this.isMandatoryStayCheckBox.Location = new System.Drawing.Point(32, 120);
            this.isMandatoryStayCheckBox.Name = "isMandatoryStayCheckBox";
            this.isMandatoryStayCheckBox.Size = new System.Drawing.Size(342, 16);
            this.isMandatoryStayCheckBox.TabIndex = 78;
            this.isMandatoryStayCheckBox.Text = "如果有接續的Cinematic，結局是否強制停留(打勾強制停留)";
            this.isMandatoryStayCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProcessActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 180);
            this.Controls.Add(this.isMandatoryStayCheckBox);
            this.Controls.Add(this.movieTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectCinematicButton);
            this.Controls.Add(this.cinematicTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.musicTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endgameidTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "ProcessActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进入结局";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox endgameidTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox musicTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectCinematicButton;
        private System.Windows.Forms.TextBox cinematicTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox movieTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox isMandatoryStayCheckBox;
    }
}