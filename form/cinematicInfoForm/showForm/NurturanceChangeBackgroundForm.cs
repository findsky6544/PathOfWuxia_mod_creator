using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NurturanceChangeBackgroundForm : Form
    {
        public bool isAdd;
        public object obj;
        public NurturanceChangeBackgroundForm()
        {
            InitializeComponent();

            initBackIdComboBox();
        }
        public NurturanceChangeBackgroundForm(object obj, bool isAdd) : this()
        {
            this.obj = obj;
            this.isAdd = isAdd;

            string fields = "";
            if (obj is ListViewItem)
            {
                fields = (obj as ListViewItem).Tag.ToString().Split(':')[1];
            }
            else
            {
                fields = (obj as TreeNode).Tag.ToString().Split(':')[1];
            }

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                backidComboBox.Text = fieldsList[0].Trim();
            }
        }

        public void initBackIdComboBox()
        {
            for (int i = 0; i < backImageList.Images.Count; i++)
            {
                string imageName = backImageList.Images.Keys[i];
                imageName = imageName.Substring(0, imageName.LastIndexOf('_'));
                if (!backidComboBox.Items.Contains(imageName))
                {
                    backidComboBox.Items.Add(imageName);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (backidComboBox.Text == "")
            {
                MessageBox.Show("请输入背景编号");
                return;
            }

            string tag = "\"NurturanceChangeBackground\" : " + "\"" + backidComboBox.Text + "\"";
            string text = Text + ":" + " " + backidComboBox.Text;

            if (obj is ListViewItem)
            {
                ListViewItem lvi = obj as ListViewItem;
                lvi.Tag = tag;
                lvi.SubItems[1].Text = text;
            }
            else
            {
                TreeNode node = obj as TreeNode;
                node.Tag = tag;
                node.Text = text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backidComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = backidComboBox.Text + "_Day";
            dayPictureBox.Image = backImageList.Images[backImageList.Images.IndexOfKey(text)];
            text = backidComboBox.Text + "_Night";
            nightPictureBox.Image = backImageList.Images[backImageList.Images.IndexOfKey(text)];
        }
    }
}
