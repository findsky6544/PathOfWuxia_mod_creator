using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferLiberatedStateActionForm : Form
    {
        public bool isAdd;
        public BufferLiberatedStateActionForm()
        {
            InitializeComponent();

            initStatusComboBox();
        }
        public BufferLiberatedStateActionForm(string tag, bool isAdd, Form owner) : this()
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
            foreach (BattleLiberatedState temp in Enum.GetValues(typeof(BattleLiberatedState)))
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

            currentNode.Tag = "\"BufferLiberatedStateAction\" : " + ((ComboBoxItem)StausComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value;



            currentNode.Text = "赋予解放状态:" + StausComboBox.Text;

            BattleLiberatedState battleLiberatedState = (BattleLiberatedState)Enum.Parse(typeof(BattleLiberatedState), ((ComboBoxItem)StausComboBox.SelectedItem).key);

            if (battleLiberatedState >= BattleLiberatedState.Lock_HP_Percent && battleLiberatedState <= BattleLiberatedState.Lock_MP_Value)
            {
                currentNode.Text += " " + valueNumericUpDown.Value;
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StausComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BattleLiberatedState battleLiberatedState = (BattleLiberatedState)Enum.Parse(typeof(BattleLiberatedState), ((ComboBoxItem)StausComboBox.SelectedItem).key);

            if (battleLiberatedState >= BattleLiberatedState.Lock_HP_Percent && battleLiberatedState <= BattleLiberatedState.Lock_MP_Value)
            {
                label3.Visible = true;
                valueNumericUpDown.Visible = true;
            }
            else
            {
                label3.Visible = false;
                valueNumericUpDown.Visible = false;
            }
        }
    }
}
