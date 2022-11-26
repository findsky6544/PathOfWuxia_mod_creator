using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckCurrentRoundForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckCurrentRoundForm()
        {
            InitializeComponent();
        }
        public CheckCurrentRoundForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                roundNumericUpDown.Value = int.Parse(fieldsList[0].Trim());
                multipleNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
                maxNumericUpDown.Value = int.Parse(fieldsList[2].Trim());
                otherTextBox.Text = fieldsList[3].Trim();
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (roundNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入回合");
                return;
            }
            if (multipleNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入倍数");
                return;
            }
            if (maxNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入最大回合");
                return;
            }

            currentNode.Tag = "\"CheckCurrentRound\" : " + roundNumericUpDown.Text + ", " + multipleNumericUpDown.Text + ", " + maxNumericUpDown.Text + ", \"" + otherTextBox.Text + "\"";
            currentNode.Text = Text + ":" + "符合大于等于 " + DataManager.getRoundStr((int)roundNumericUpDown.Value) + " 且小于等于 " + DataManager.getRoundStr((int)maxNumericUpDown.Value) + " 的 " + multipleNumericUpDown.Text + " 倍数回合";
            if (!string.IsNullOrEmpty(otherTextBox.Text))
            {
                currentNode.Text += " 或是 " + otherTextBox.Text + " 回合";
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
