using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferAttackerWeaponTypeConditionForm : Form
    {
        public bool isAdd;
        public BufferAttackerWeaponTypeConditionForm()
        {
            InitializeComponent();

            initFactionComboBox();
        }
        public BufferAttackerWeaponTypeConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < propsCategoryComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)propsCategoryComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        propsCategoryComboBox.SelectedIndex = i;
                        break;
                    }
                }
                    IsReverseCheckBox.Checked = fieldsList[1] == "True";
            }

            this.isAdd = isAdd;
        }

        public void initFactionComboBox()
        {
            propsCategoryComboBox.DisplayMember = "value";
            propsCategoryComboBox.ValueMember = "key";
            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                propsCategoryComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (propsCategoryComboBox.Text == "")
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

            currentNode.Tag = "\"BufferAttackerWeaponTypeCondition\" : " + ((ComboBoxItem)propsCategoryComboBox.SelectedItem).key + ", " + IsReverseCheckBox.Checked;
            currentNode.Text = "判断攻击者武器类型: " + (IsReverseCheckBox.Checked ? "不是" : "是") + " " + propsCategoryComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
