using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ChanageFactionForm : Form
    {
        public bool isAdd;
        public ChanageFactionForm()
        {
            InitializeComponent();

            initUnitFactionComboBox();
        }
        public ChanageFactionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < unitFactionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)unitFactionComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        unitFactionComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initUnitFactionComboBox()
        {
            unitFactionComboBox.DisplayMember = "value";
            unitFactionComboBox.ValueMember = "key";
            foreach (Faction temp in Enum.GetValues(typeof(Faction)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                unitFactionComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (unitFactionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部队阵营");
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

            currentNode.Tag = "\"ChanageFaction\" : " + ((ComboBoxItem)unitFactionComboBox.SelectedItem).key;

            currentNode.Text = "转换阵营:" + unitFactionComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
