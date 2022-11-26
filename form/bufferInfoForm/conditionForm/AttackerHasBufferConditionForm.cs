using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerHasBufferConditionForm : Form
    {
        public bool isAdd;
        public AttackerHasBufferConditionForm()
        {
            InitializeComponent();
        }
        public AttackerHasBufferConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                bufferIdTextBox.Text = fieldsList[0];
                    existCheckBox.Checked = fieldsList[1] == "True";
            }

            this.isAdd = isAdd;
        }

        public TextBox getBufferIdTextBox()
        {
            return bufferIdTextBox;
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

            currentNode.Tag = "\"AttackerHasBufferCondition\" : \"" + bufferIdTextBox.Text + "\", " + existCheckBox.Checked;
            currentNode.Text = "攻击者是否存在指定buff: " + (existCheckBox.Checked ? "存在" : "不存在") + " " + DataManager.getBuffersName(bufferIdTextBox.Text);
            Close();
        }

        /*public string getBufferName(string bufferid)
        {
            List<ListViewItem> lvis = BufferTabControlUserControl.lvis;

            for (int i = 0; i < lvis.Count; i++)
            {
                if (bufferid == lvis[i].SubItems[1].Text)
                {
                    return lvis[i].SubItems[2].Text;
                }
            }
            return "";
        }*/

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
