
namespace 侠之道mod制作器
{
    partial class SelectCinematicNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCinematicNodeForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.bufferImageList = new System.Windows.Forms.ImageList(this.components);
            this.cinematicListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // okButton
            // 
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
            // cinematicListView
            // 
            this.cinematicListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader17,
            this.columnHeader18});
            this.cinematicListView.FullRowSelect = true;
            this.cinematicListView.HideSelection = false;
            this.cinematicListView.Location = new System.Drawing.Point(8, 39);
            this.cinematicListView.MultiSelect = false;
            this.cinematicListView.Name = "cinematicListView";
            this.cinematicListView.ShowItemToolTips = true;
            this.cinematicListView.Size = new System.Drawing.Size(547, 388);
            this.cinematicListView.TabIndex = 15;
            this.cinematicListView.UseCompatibleStateImageBehavior = false;
            this.cinematicListView.View = System.Windows.Forms.View.Details;
            this.cinematicListView.DoubleClick += new System.EventHandler(this.cinematicListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "节点";
            this.columnHeader12.Width = 300;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "下一个";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "并行处理";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "分支成功节点";
            this.columnHeader17.Width = 120;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "分支失败节点";
            this.columnHeader18.Width = 120;
            // 
            // SelectCinematicNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 468);
            this.Controls.Add(this.cinematicListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SelectCinematicNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-选择节点";
            this.Shown += new System.EventHandler(this.SelectCinematicNodeForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ImageList bufferImageList;
        private System.Windows.Forms.ListView cinematicListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
    }
}