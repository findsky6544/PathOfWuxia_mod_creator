using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerMantraForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerMantraForm()
        {
            InitializeComponent();
        }
        public CheckPlayerMantraForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                mantra_IdTextBox.Text = fieldsList[0].Trim();
                isContainsCheckBox.Checked = fieldsList[1].Trim() == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (mantra_IdTextBox.Text == "")
            {
                MessageBox.Show("请输入心法编号");
                return;
            }

            currentNode.Tag = "\"CheckPlayerMantra\" : \"" + mantra_IdTextBox.Text + "\", " + isContainsCheckBox.Checked;
            currentNode.Text = Text + ":" + (isContainsCheckBox.Checked ? "具备" : "不具备") + "心法 " + DataManager.getMantraName(mantra_IdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, mantra_IdTextBox, false);
            form.ShowDialog();
        }
    }
}
