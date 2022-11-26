using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerGenderForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerGenderForm()
        {
            InitializeComponent();
        }
        public CheckPlayerGenderForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                isMaleCheckBox.Checked = fieldsList[0].Trim() == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            currentNode.Tag = "\"CheckPlayerGender\" : " + isMaleCheckBox.Checked;
            currentNode.Text = Text + ":" + "为 " + (isMaleCheckBox.Checked ? "男" : "女");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
