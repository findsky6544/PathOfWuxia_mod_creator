using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerTraitForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerTraitForm()
        {
            InitializeComponent();
        }
        public CheckPlayerTraitForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                trait_IdTextBox.Text = fieldsList[0].Trim();
                isContainsCheckBox.Checked = fieldsList[1].Trim() == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (trait_IdTextBox.Text == "")
            {
                MessageBox.Show("请输入特质编号");
                return;
            }

            currentNode.Tag = "\"CheckPlayerTrait\" : \"" + trait_IdTextBox.Text + "\", " + isContainsCheckBox.Checked;
            currentNode.Text = Text + ":" + (isContainsCheckBox.Checked ? "具备" : "不具备") + "特质 " + DataManager.getTraitName(trait_IdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectTraitButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, trait_IdTextBox, false);
            form.ShowDialog();
        }
    }
}
