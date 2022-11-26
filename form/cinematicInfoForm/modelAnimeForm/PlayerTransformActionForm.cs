using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PlayerTransformActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public PlayerTransformActionForm()
        {
            InitializeComponent();
        }
        public PlayerTransformActionForm(object obj, bool isAdd) : this()
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

                isMoveCheckBox.Checked = fieldsList[0] == "True";
                positionTextBox.Text = "{" + fieldsList[1].Trim() + ", " + fieldsList[2].Trim() + ", " + fieldsList[3].Trim() + "}";
                isRotateCheckBox.Checked = fieldsList[4] == "True";
                rotationTextBox.Text = "{" + fieldsList[5].Trim() + ", " + fieldsList[6].Trim() + ", " + fieldsList[7].Trim() + "}";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入位置");
                return;
            }
            if (rotationTextBox.Text == "")
            {
                MessageBox.Show("请输入旋转");
                return;
            }


            string tag = "\"PlayerTransformAction\" : " + isMoveCheckBox.Checked + ", " + positionTextBox.Text + "," + isRotateCheckBox.Checked + ", " + rotationTextBox.Text;
            string text = Text + ":" + (isMoveCheckBox.Checked ? "瞬移到 " + positionTextBox.Text : "不瞬移") + ";" + (isRotateCheckBox.Checked ? "瞬转到 " + rotationTextBox.Text : "不瞬转");

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
    }
}
