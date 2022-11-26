using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferNegativeStateActionForm : Form
    {
        public bool isAdd;
        public BufferNegativeStateActionForm()
        {
            InitializeComponent();

            initStatusComboBox();
        }
        public BufferNegativeStateActionForm(string tag, bool isAdd, Form owner) : this()
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
            }

            this.isAdd = isAdd;
        }

        public void initStatusComboBox()
        {
            StausComboBox.DisplayMember = "value";
            StausComboBox.ValueMember = "key";
            foreach (BattleNegativeState temp in Enum.GetValues(typeof(BattleNegativeState)))
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

            currentNode.Tag = "\"BufferNegativeStateAction\" : " + ((ComboBoxItem)StausComboBox.SelectedItem).key;



            currentNode.Text = "赋予负面状态（叠加类型）:" + StausComboBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
