using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TeammateConditionForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public TeammateConditionForm()
        {
            InitializeComponent();
        }
        public TeammateConditionForm(TreeNode currentNode, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                idTextBox.Text = fieldsList[0].Trim();
                isContainsCheckBox.Checked = fieldsList[1].Trim() == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }

            currentNode.Tag = "\"TeammateCondition\" : \"" + idTextBox.Text + "\", " + isContainsCheckBox.Checked;
            currentNode.Text = Text + ":" + DataManager.getNpcsName(idTextBox.Text) + " " + (isContainsCheckBox.Checked ? "在" : "不在") + "队伍中";

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
