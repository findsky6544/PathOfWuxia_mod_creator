using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CameraTransformActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public CameraTransformActionForm()
        {
            InitializeComponent();
        }
        public CameraTransformActionForm(object obj, bool isAdd) : this()
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
                moveDurationNumericUpDown.Text = fieldsList[4].Trim();
                isRotateCheckBox.Checked = fieldsList[5] == "True";
                rotationTextBox.Text = "{" + fieldsList[6].Trim() + ", " + fieldsList[7].Trim() + ", " + fieldsList[8].Trim() + "}";
                rotateDurationNumericUpDown.Text = fieldsList[9].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (positionTextBox.Text == "")
            {
                MessageBox.Show("请输入位置");
                return;
            }
            if (moveDurationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入移动持续时间");
                return;
            }
            if (rotationTextBox.Text == "")
            {
                MessageBox.Show("请输入旋转");
                return;
            }
            if (rotateDurationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入旋转持续时间");
                return;
            }

            string tag = "\"CameraTransformAction\" : " + isMoveCheckBox.Checked + ", " + positionTextBox.Text + ", " + moveDurationNumericUpDown.Text + "," + isRotateCheckBox.Checked + ", " + rotationTextBox.Text + ", " + rotateDurationNumericUpDown.Text;
            string text = Text + ":" + (isMoveCheckBox.Checked ? moveDurationNumericUpDown.Text + " 秒移动到 " + positionTextBox.Text : "不移动") + ";" + (isRotateCheckBox.Checked ? rotateDurationNumericUpDown.Text + " 秒旋转到 " + rotationTextBox.Text : "不旋转");

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
