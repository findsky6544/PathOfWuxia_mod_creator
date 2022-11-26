using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerFactionConditionForm : Form
    {
        public bool isAdd;
        public AttackerFactionConditionForm()
        {
            InitializeComponent();

            initFactionComboBox();
        }
        public AttackerFactionConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < factionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)factionComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        factionComboBox.SelectedIndex = i;
                        break;
                    }
                }
                IsReverseCheckBox.Checked = fieldsList[1] == "True";
            }

            this.isAdd = isAdd;
        }

        public void initFactionComboBox()
        {
            factionComboBox.DisplayMember = "value";
            factionComboBox.ValueMember = "key";
            foreach (Faction temp in Enum.GetValues(typeof(Faction)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                factionComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (factionComboBox.Text == "")
            {
                MessageBox.Show("请选择攻击者阵营");
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

            currentNode.Tag = "\"AttackerFactionCondition\" : " + ((ComboBoxItem)factionComboBox.SelectedItem).key + ", " + IsReverseCheckBox.Checked;
            currentNode.Text = "判断攻击者阵营: " + (IsReverseCheckBox.Checked ? "不是" : "是") + " " + factionComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
