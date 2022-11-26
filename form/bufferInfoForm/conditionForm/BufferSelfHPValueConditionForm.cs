using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferSelfHPValueConditionForm : Form
    {
        public bool isAdd;
        public BufferSelfHPValueConditionForm()
        {
            InitializeComponent();

            initOpComboBox();
        }
        public BufferSelfHPValueConditionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = fields.Split(',');

                for (int i = 0; i < opComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)opComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        opComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
            }

            this.isAdd = isAdd;
        }

        public void initOpComboBox()
        {
            opComboBox.DisplayMember = "value";
            opComboBox.ValueMember = "key";
            foreach (Operator temp in Enum.GetValues(typeof(Operator)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                opComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (opComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择比较方式");
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

            currentNode.Tag = "\"BufferSelfHPValueCondition\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value;
            currentNode.Text = "判断自身气血（值）:" + " " + opComboBox.Text + " " + valueNumericUpDown.Value;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
