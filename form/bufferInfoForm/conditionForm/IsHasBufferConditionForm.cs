using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class IsHasBufferConditionForm : Form
    {
        public bool isAdd;
        public IsHasBufferConditionForm()
        {
            InitializeComponent();
        }
        public IsHasBufferConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                bufferIdTextBox.Text = fieldsList[0];
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (bufferIdTextBox.Text == "")
            {
                MessageBox.Show("请至少选择一个buffer");
                return;
            }


            BufferInfoForm bufferInfoForm = (BufferInfoForm)Owner;
            TreeView bufferNodeTreeView = bufferInfoForm.getBufferNodeTreeView();

            TreeNode currentNode = bufferNodeTreeView.SelectedNode;

            if (isAdd)
            {
                string tag = currentNode.Tag.ToString();
                while (!tag.Contains("BufferEventNode") && !tag.Contains("BufferPriorityNode") && !tag.Contains("BufferSequenceNode"))
                {
                    currentNode = currentNode.Parent;
                    tag = currentNode.Tag.ToString();
                }

                TreeNode addNode = currentNode.Nodes.Add("");
                bufferNodeTreeView.SelectedNode = addNode;

                currentNode = addNode;
            }

            currentNode.Tag = "\"IsHasBufferCondition\" : \"" + bufferIdTextBox.Text + "\"";


            currentNode.Text = "判断自身持有特定BUFF: " + DataManager.getBuffersName(bufferIdTextBox.Text);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, bufferIdTextBox, true);
            form.ShowDialog();
        }
    }
}
