
namespace 侠之道mod制作器
{
    partial class SelectBufferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectBufferForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.bufferImageList = new System.Windows.Forms.ImageList(this.components);
            this.bufferListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okButton.Location = new System.Drawing.Point(194, 433);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelButton.Location = new System.Drawing.Point(304, 433);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(203, 21);
            this.searchTextBox.TabIndex = 9;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchTextBox_KeyPress);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(221, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "搜索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
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
            // bufferListView
            // 
            this.bufferListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.bufferListView.ContextMenuStrip = this.contextMenuStrip1;
            this.bufferListView.FullRowSelect = true;
            this.bufferListView.HideSelection = false;
            this.bufferListView.Location = new System.Drawing.Point(12, 39);
            this.bufferListView.MultiSelect = false;
            this.bufferListView.Name = "bufferListView";
            this.bufferListView.ShowItemToolTips = true;
            this.bufferListView.Size = new System.Drawing.Size(543, 388);
            this.bufferListView.SmallImageList = this.bufferImageList;
            this.bufferListView.TabIndex = 11;
            this.bufferListView.UseCompatibleStateImageBehavior = false;
            this.bufferListView.View = System.Windows.Forms.View.Details;
            this.bufferListView.DoubleClick += new System.EventHandler(this.bufferListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图片";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "名称";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "备注";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "效果面向";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "持续作用次数";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "叠加层数";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "增益效果";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // SelectBufferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 468);
            this.Controls.Add(this.bufferListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SelectBufferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-选择Buff";
            this.Shown += new System.EventHandler(this.SelectBufferForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ImageList bufferImageList;
        private System.Windows.Forms.ListView bufferListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}