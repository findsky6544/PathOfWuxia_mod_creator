using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferRestrictedStateActionForm : Form
    {
        public bool isAdd;
        public BufferRestrictedStateActionForm()
        {
            InitializeComponent();

            initStatusComboBox();
        }
        public BufferRestrictedStateActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = fields.Split(',');
                for (int i = 0; i < StausComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)StausComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        StausComboBox.SelectedIndex = i;
                        break;
                    }
                }
                if (fieldsList.Length > 1)
                {
                    valueNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
                }
            }

            this.isAdd = isAdd;
        }

        public void initStatusComboBox()
        {
            StausComboBox.DisplayMember = "value";
            StausComboBox.ValueMember = "key";
            foreach (BattleRestrictedState temp in Enum.GetValues(typeof(BattleRestrictedState)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                StausComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (StausComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择作用属性");
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

            currentNode.Tag = "\"BufferRestrictedStateAction\" : " + ((ComboBoxItem)StausComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value;



            currentNode.Text = "赋予限制状态:" + StausComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
