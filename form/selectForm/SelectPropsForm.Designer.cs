
namespace 侠之道mod制作器
{
    partial class SelectPropsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPropsForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.propsListView = new 侠之道mod制作器.UserListView();
            this.propsCategoryImageList = new System.Windows.Forms.ImageList(this.components);
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "物品名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "描述";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "大分类";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "小分类";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "模型";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "图示";
            this.columnHeader15.Width = 150;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "价格";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "使用时机";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "是否可以买卖";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "是否要显示在背包";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "附加状态（装备者本身）";
            this.columnHeader10.Width = 300;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "使用条件描述";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "使用效果描述";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "可使用的npc编号";
            this.columnHeader13.Width = 300;
            // 
            // propsListView
            // 
            this.propsListView.AllowColumnReorder = true;
            this.propsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.propsListView.FullRowSelect = true;
            this.propsListView.HideSelection = false;
            this.propsListView.Location = new System.Drawing.Point(12, 39);
            this.propsListView.MultiSelect = false;
            this.propsListView.Name = "propsListView";
            this.propsListView.ShowItemToolTips = true;
            this.propsListView.Size = new System.Drawing.Size(543, 388);
            this.propsListView.SmallImageList = this.propsCategoryImageList;
            this.propsListView.TabIndex = 11;
            this.propsListView.UseCompatibleStateImageBehavior = false;
            this.propsListView.View = System.Windows.Forms.View.Details;
            this.propsListView.DoubleClick += new System.EventHandler(this.propsListView_DoubleClick);
            // 
            // propsCategoryImageList
            // 
            this.propsCategoryImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("propsCategoryImageList.ImageStream")));
            this.propsCategoryImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.propsCategoryImageList.Images.SetKeyName(0, "PropsCategory000");
            this.propsCategoryImageList.Images.SetKeyName(1, "PropsCategory101");
            this.propsCategoryImageList.Images.SetKeyName(2, "PropsCategory102");
            this.propsCategoryImageList.Images.SetKeyName(3, "PropsCategory103");
            this.propsCategoryImageList.Images.SetKeyName(4, "PropsCategory104");
            this.propsCategoryImageList.Images.SetKeyName(5, "PropsCategory105");
            this.propsCategoryImageList.Images.SetKeyName(6, "PropsCategory106");
            this.propsCategoryImageList.Images.SetKeyName(7, "PropsCategory107");
            this.propsCategoryImageList.Images.SetKeyName(8, "PropsCategory108");
            this.propsCategoryImageList.Images.SetKeyName(9, "PropsCategory109");
            this.propsCategoryImageList.Images.SetKeyName(10, "PropsCategory201");
            this.propsCategoryImageList.Images.SetKeyName(11, "PropsCategory301");
            this.propsCategoryImageList.Images.SetKeyName(12, "PropsCategory401");
            this.propsCategoryImageList.Images.SetKeyName(13, "PropsCategory402");
            this.propsCategoryImageList.Images.SetKeyName(14, "PropsCategory403");
            this.propsCategoryImageList.Images.SetKeyName(15, "PropsCategory404");
            this.propsCategoryImageList.Images.SetKeyName(16, "PropsCategory405");
            this.propsCategoryImageList.Images.SetKeyName(17, "PropsCategory406");
            this.propsCategoryImageList.Images.SetKeyName(18, "PropsCategory407");
            this.propsCategoryImageList.Images.SetKeyName(19, "PropsCategory408");
            this.propsCategoryImageList.Images.SetKeyName(20, "PropsCategory409");
            this.propsCategoryImageList.Images.SetKeyName(21, "PropsCategory411");
            this.propsCategoryImageList.Images.SetKeyName(22, "PropsCategory412");
            this.propsCategoryImageList.Images.SetKeyName(23, "PropsCategory413");
            this.propsCategoryImageList.Images.SetKeyName(24, "PropsCategory414");
            this.propsCategoryImageList.Images.SetKeyName(25, "PropsCategory415");
            this.propsCategoryImageList.Images.SetKeyName(26, "PropsCategory416");
            this.propsCategoryImageList.Images.SetKeyName(27, "PropsCategory417");
            this.propsCategoryImageList.Images.SetKeyName(28, "PropsCategory418");
            this.propsCategoryImageList.Images.SetKeyName(29, "PropsCategory419");
            this.propsCategoryImageList.Images.SetKeyName(30, "PropsCategory501");
            this.propsCategoryImageList.Images.SetKeyName(31, "PropsCategory502");
            this.propsCategoryImageList.Images.SetKeyName(32, "PropsCategory601");
            this.propsCategoryImageList.Images.SetKeyName(33, "PropsCategory602");
            this.propsCategoryImageList.Images.SetKeyName(34, "PropsCategory603");
            this.propsCategoryImageList.Images.SetKeyName(35, "PropsCategory604");
            this.propsCategoryImageList.Images.SetKeyName(36, "PropsCategory605");
            this.propsCategoryImageList.Images.SetKeyName(37, "PropsCategory606");
            this.propsCategoryImageList.Images.SetKeyName(38, "PropsCategory701");
            this.propsCategoryImageList.Images.SetKeyName(39, "PropsCategory702");
            this.propsCategoryImageList.Images.SetKeyName(40, "PropsCategory703");
            this.propsCategoryImageList.Images.SetKeyName(41, "PropsCategory704");
            this.propsCategoryImageList.Images.SetKeyName(42, "PropsCategory705");
            this.propsCategoryImageList.Images.SetKeyName(43, "PropsCategory706");
            this.propsCategoryImageList.Images.SetKeyName(44, "PropsCategory707");
            this.propsCategoryImageList.Images.SetKeyName(45, "PropsCategory708");
            this.propsCategoryImageList.Images.SetKeyName(46, "PropsCategory709");
            this.propsCategoryImageList.Images.SetKeyName(47, "PropsCategory710");
            this.propsCategoryImageList.Images.SetKeyName(48, "PropsCategory711");
            this.propsCategoryImageList.Images.SetKeyName(49, "PropsCategory712");
            this.propsCategoryImageList.Images.SetKeyName(50, "PropsCategory713");
            this.propsCategoryImageList.Images.SetKeyName(51, "PropsCategory714");
            this.propsCategoryImageList.Images.SetKeyName(52, "PropsCategory715");
            this.propsCategoryImageList.Images.SetKeyName(53, "PropsCategory801");
            this.propsCategoryImageList.Images.SetKeyName(54, "PropsCategory802");
            this.propsCategoryImageList.Images.SetKeyName(55, "PropsCategoryEmpty");
            this.propsCategoryImageList.Images.SetKeyName(56, "PropsCategoryMentalEmpty");
            this.propsCategoryImageList.Images.SetKeyName(57, "PropsCategoryTalkEmpty");
            // 
            // SelectPropsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 468);
            this.Controls.Add(this.propsListView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SelectPropsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-选择道具";
            this.Shown += new System.EventHandler(this.SelectPropsForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private UserListView propsListView;
        private System.Windows.Forms.ImageList propsCategoryImageList;
    }
}