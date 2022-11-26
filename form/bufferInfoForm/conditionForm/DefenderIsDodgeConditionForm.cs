using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class DefenderIsDodgeConditionForm : Form
    {
        public bool isAdd;
        public DefenderIsDodgeConditionForm()
        {
            InitializeComponent();
        }
        public DefenderIsDodgeConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                    isDodgeCheckBox.Checked = fieldsList[0] == "True";
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {

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

            currentNode.Tag = "\"DefenderIsDodgeCondition\" : " + isDodgeCheckBox.Checked;
            currentNode.Text = "判断防御者是否闪避: " + (isDodgeCheckBox.Checked ? "是" : "否");
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
