using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CameraShakeActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public CameraShakeActionForm()
        {
            InitializeComponent();
        }
        public CameraShakeActionForm(object obj, bool isAdd) : this()
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


                durationNumericUpDown.Text = fieldsList[0].Trim();
                levelNumericUpDown.Text = fieldsList[1].Trim();
                vibratoNumericUpDown.Text = fieldsList[2].Trim();
                fadeOutCheckBox.Checked = fieldsList[3].Trim() == "True";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (durationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入持续时间");
                return;
            }
            if (levelNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入强度");
                return;
            }
            if (vibratoNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入速度");
                return;
            }


            string tag = "\"CameraShakeAction\" : " + durationNumericUpDown.Text + ", " + levelNumericUpDown.Text + ", " + vibratoNumericUpDown.Text + ", " + fadeOutCheckBox.Checked;
            string text = Text + ":" + "持续时间 " + durationNumericUpDown.Text + " 秒 强度 " + levelNumericUpDown.Text + " 速度 " + vibratoNumericUpDown.Text + " " + (fadeOutCheckBox.Checked ? "" : "不") + "淡出";

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
