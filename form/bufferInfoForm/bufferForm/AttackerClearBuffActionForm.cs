using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerClearBuffActionForm : Form
    {
        public bool isAdd;
        public AttackerClearBuffActionForm()
        {
            InitializeComponent();
        }
        public AttackerClearBuffActionForm(string tag, bool isAdd, Form owner) : this()
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

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, bufferIdTextBox, false);
            form.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (bufferIdTextBox.Text == "")
            {
                MessageBox.Show("请选择一个buffer");
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

            currentNode.Tag = "\"AttackerClearBuffAction\" : \"" + bufferIdTextBox.Text + "\"";
            currentNode.Text = "指定清除攻击者Buff: " + DataManager.getBuffersName(bufferIdTextBox.Text);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
