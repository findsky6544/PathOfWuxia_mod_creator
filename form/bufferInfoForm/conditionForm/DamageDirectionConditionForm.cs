using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class DamageDirectionConditionForm : Form
    {
        public bool isAdd;
        public DamageDirectionConditionForm()
        {
            InitializeComponent();
            initDirComboBox();
        }
        public DamageDirectionConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = fields.Split(',');

                for (int i = 0; i < dirComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)dirComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        dirComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }


        public void initDirComboBox()
        {
            dirComboBox.DisplayMember = "value";
            dirComboBox.ValueMember = "key";
            foreach (DamageDirection temp in Enum.GetValues(typeof(DamageDirection)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                dirComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (dirComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择面向");
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

            currentNode.Tag = "\"DamageDirectionCondition\" : " + ((ComboBoxItem)dirComboBox.SelectedItem).key;
            currentNode.Text = "攻击面向判断: " + dirComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
