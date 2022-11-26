
namespace 侠之道mod制作器
{
    partial class IsHasBufferConditionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsHasBufferConditionForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bufferImageList = new System.Windows.Forms.ImageList(this.components);
            this.selectBufferButton = new System.Windows.Forms.Button();
            this.bufferIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(100, 55);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(210, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bufferImageList
            // 
            this.bufferImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("bufferImageList.ImageStream")));
            this.bufferImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.bufferImageList.Images.SetKeyName(0, "buff_critical");
            this.bufferImageList.Images.SetKeyName(1, "buff_damage");
            this.bufferImageList.Images.SetKeyName(2, "buff_dodge");
            this.bufferImageList.Images.SetKeyName(3, "buff_fury");
            this.bufferImageList.Images.SetKeyName(4, "buff_hp");
            this.bufferImageList.Images.SetKeyName(5, "buff_move");
            this.bufferImageList.Images.SetKeyName(6, "buff_mp");
            this.bufferImageList.Images.SetKeyName(7, "buff_parry");
            this.bufferImageList.Images.SetKeyName(8, "buff_trait");
            this.bufferImageList.Images.SetKeyName(9, "buff_xingfa");
            this.bufferImageList.Images.SetKeyName(10, "debuff_critical");
            this.bufferImageList.Images.SetKeyName(11, "debuff_damage");
            this.bufferImageList.Images.SetKeyName(12, "debuff_dodge");
            this.bufferImageList.Images.SetKeyName(13, "debuff_hp");
            this.bufferImageList.Images.SetKeyName(14, "debuff_move");
            this.bufferImageList.Images.SetKeyName(15, "debuff_mp");
            this.bufferImageList.Images.SetKeyName(16, "debuff_parry");
            this.bufferImageList.Images.SetKeyName(17, "debuff_poison");
            // 
            // selectBufferButton
            // 
            this.selectBufferButton.Location = new System.Drawing.Point(276, 10);
            this.selectBufferButton.Name = "selectBufferButton";
            this.selectBufferButton.Size = new System.Drawing.Size(75, 23);
            this.selectBufferButton.TabIndex = 24;
            this.selectBufferButton.Text = "选择";
            this.selectBufferButton.UseVisualStyleBackColor = true;
            this.selectBufferButton.Click += new System.EventHandler(this.selectBufferButton_Click);
            // 
            // bufferIdTextBox
            // 
            this.bufferIdTextBox.Location = new System.Drawing.Point(104, 12);
            this.bufferIdTextBox.Name = "bufferIdTextBox";
            this.bufferIdTextBox.Size = new System.Drawing.Size(165, 21);
            this.bufferIdTextBox.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "buff id";
            // 
            // IsHasBufferConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 96);
            this.Controls.Add(this.selectBufferButton);
            this.Controls.Add(this.bufferIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "IsHasBufferConditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "判断自身持有特定BUFF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ImageList bufferImageList;
        private System.Windows.Forms.Button selectBufferButton;
        private System.Windows.Forms.TextBox bufferIdTextBox;
        private System.Windows.Forms.Label label2;
    }
}