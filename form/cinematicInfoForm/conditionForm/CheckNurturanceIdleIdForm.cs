using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckNurturanceIdleIdForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckNurturanceIdleIdForm()
        {
            InitializeComponent();
        }
        public CheckNurturanceIdleIdForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                idTextBox.Text = fieldsList[0].Trim();
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入养成ID");
                return;
            }

            currentNode.Tag = "\"CheckNurturanceIdleId\" : \"" + idTextBox.Text + "\"";
            currentNode.Text = Text + ":" + " 为 " + idTextBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
