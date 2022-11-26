using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerIDConditionForm : Form
    {
        public bool isAdd;
        public AttackerIDConditionForm()
        {
            InitializeComponent();
        }
        public AttackerIDConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitIdTextBox.Text = fieldsList[0];
                    IsReverseCheckBox.Checked = fieldsList[1] == "True";
            }

            this.isAdd = isAdd;
        }

        public TextBox getBufferIdTextBox()
        {
            return unitIdTextBox;
        }

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIdTextBox, false);
            form.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (unitIdTextBox.Text == "")
            {
                MessageBox.Show("请选择一个部队");
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

            currentNode.Tag = "\"AttackerIDCondition\" : \"" + unitIdTextBox.Text + "\", " + IsReverseCheckBox.Checked;
            currentNode.Text = "判断攻击者ID: " + (IsReverseCheckBox.Checked ? "不是" : "是") + " " + DataManager.getUnitsName(unitIdTextBox.Text);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
