using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerTalkTypeConditionForm : Form
    {
        public bool isAdd;
        public AttackerTalkTypeConditionForm()
        {
            InitializeComponent();
            initDirComboBox();
        }
        public AttackerTalkTypeConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = fields.Split(',');

                for (int i = 0; i < typeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)typeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        typeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }


        public void initDirComboBox()
        {
            typeComboBox.DisplayMember = "value";
            typeComboBox.ValueMember = "key";
            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                if (temp <= PropsCategory.Special)
                {
                    ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                    typeComboBox.Items.Add(cbi);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择武器类型");
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

            currentNode.Tag = "\"AttackerTalkTypeCondition\" : " + ((ComboBoxItem)typeComboBox.SelectedItem).key;
            currentNode.Text = "判断攻击者招式的武器类型: " + typeComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
