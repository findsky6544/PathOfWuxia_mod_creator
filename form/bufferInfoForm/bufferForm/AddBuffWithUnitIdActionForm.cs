using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AddBuffWithUnitIdActionForm : Form
    {
        public bool isAdd;
        public AddBuffWithUnitIdActionForm()
        {
            InitializeComponent();
        }
        public AddBuffWithUnitIdActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);
                unitIdTextBox.Text = fieldsList[0];
                buffIdTextBox.Text = fieldsList[1];
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (unitIdTextBox.Text == "")
            {
                MessageBox.Show("请输入指定的ID");
                return;
            }
            if (buffIdTextBox.Text == "")
            {
                MessageBox.Show("请输入添加的Buff id");
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

            currentNode.Tag = "\"AddBuffWithUnitIdAction\" : " + "\"" + unitIdTextBox.Text + "\"" + ", \"" + buffIdTextBox.Text + "\"";



            currentNode.Text = "指定ID增加Buff:" + DataManager.getUnitsName(unitIdTextBox.Text) + " 添加 " + buffIdTextBox.Text + "(" + DataManager.getBuffersName(buffIdTextBox.Text) + ")";
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectUnitIdButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIdTextBox, true);
            form.ShowDialog();
        }

        private void selectBuffButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, buffIdTextBox, false);
            form.ShowDialog();
        }
    }
}
