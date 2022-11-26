using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NurturanceFadeActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public NurturanceFadeActionForm()
        {
            InitializeComponent();
        }
        public NurturanceFadeActionForm(object obj, bool isAdd) : this()
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


                isFadeInCheckBox.Checked = fieldsList[0] == "True";
                durationNumericUpDown.Text = fieldsList[1].Trim();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (durationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入持续时间");
                return;
            }

            string tag = "\"NurturanceFadeAction\" : " + isFadeInCheckBox.Checked + ", " + durationNumericUpDown.Text;
            string text = Text + ":" + (isFadeInCheckBox.Checked ? "淡入" : "淡出") + " " + durationNumericUpDown.Text + " 秒";

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
