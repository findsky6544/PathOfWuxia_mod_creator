using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RewardReadomPropsForm : Form
    {
        public bool isAdd;
        public object obj;
        public RewardReadomPropsForm()
        {
            InitializeComponent();
        }
        public RewardReadomPropsForm(object obj, bool isAdd) : this()
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


                RandomCountNumericUpDown.Text = fieldsList[0].Trim();
                RandomMinNumericUpDown.Text = fieldsList[1].Trim();
                RandomMaxNumericUpDown.Text = fieldsList[2].Trim();
                IsRepeatCheckBox.Checked = fieldsList[3].Trim() == "True";
                propsIdTextBox.Text = fieldsList[4].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (RandomCountNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入总共随机几次");
                return;
            }
            if (RandomMinNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入每次随机最小值");
                return;
            }
            if (RandomMaxNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入每次随机最大值");
                return;
            }
            if (propsIdTextBox.Text == "")
            {
                MessageBox.Show("请输入道具编号");
                return;
            }

            string tag = "\"RewardReadomProps\" : " + RandomCountNumericUpDown.Text + ", " + RandomMinNumericUpDown.Text + ", " + RandomMaxNumericUpDown.Text + ", " + IsRepeatCheckBox.Checked + ", " + "\"" + propsIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getPropssName(propsIdTextBox.Text) + " " + RandomCountNumericUpDown.Text + " 次 每次增加 " + RandomMinNumericUpDown.Text + "-" + RandomMaxNumericUpDown.Text + " " + (IsRepeatCheckBox.Checked ? "可" : "不") + "重复";

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

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, propsIdTextBox, true, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }
    }
}
