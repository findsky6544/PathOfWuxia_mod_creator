using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelfBufferOrientedConditionForm : Form
    {
        public bool isAdd;
        public SelfBufferOrientedConditionForm()
        {
            InitializeComponent();
            initOrientedComboBox();
        }
        public SelfBufferOrientedConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = fields.Split(',');

                for (int i = 0; i < orientedComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)orientedComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        orientedComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }


        public void initOrientedComboBox()
        {
            orientedComboBox.DisplayMember = "value";
            orientedComboBox.ValueMember = "key";
            foreach (BufferOriented temp in Enum.GetValues(typeof(BufferOriented)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                orientedComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (orientedComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择比较状态");
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

            currentNode.Tag = "\"SelfBufferOrientedCondition\" : " + ((ComboBoxItem)orientedComboBox.SelectedItem).key;
            currentNode.Text = "判断持有者状态:持有 " + orientedComboBox.Text + " buff";
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
