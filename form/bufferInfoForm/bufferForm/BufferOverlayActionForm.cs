using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferOverlayActionForm : Form
    {
        public bool isAdd;
        public BufferOverlayActionForm()
        {
            InitializeComponent();

            initMethodComboBox();
        }
        public BufferOverlayActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < methodComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)methodComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        methodComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Value = int.Parse(fieldsList[1]);
            }

            this.isAdd = isAdd;
        }

        public void initMethodComboBox()
        {
            methodComboBox.DisplayMember = "value";
            methodComboBox.ValueMember = "key";
            foreach (Method temp in Enum.GetValues(typeof(Method)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                methodComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (methodComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择作用方式");
                return;
            }
            if (string.IsNullOrEmpty(valueNumericUpDown.Text))
            {
                MessageBox.Show("请输入值");
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

            currentNode.Tag = "\"BufferOverlayAction\" : " + ((ComboBoxItem)methodComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value;

            string valueText = valueNumericUpDown.Text;

            Method method = (Method)Enum.Parse(typeof(Method), ((ComboBoxItem)methodComboBox.SelectedItem).key);
            if (method == Method.Clear)
            {
                valueText = "";
            }

            string bufferStr = "";


            if (method != Method.Multiply)
            {
                bufferStr = methodComboBox.Text + " " + valueText;
            }
            else
            {
                bufferStr = "增加 " + valueText + "%";
            }

            currentNode.Text = "增益重数:" + bufferStr;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPercentLabel();
        }

        public void showPercentLabel()
        {
            if (methodComboBox.SelectedIndex == -1)
            {
                percentLabel.Visible = false;
                return;
            }
            Method method = (Method)Enum.Parse(typeof(Method), ((ComboBoxItem)methodComboBox.SelectedItem).key);
            if (method == Method.Multiply)
            {
                percentLabel.Visible = true;
            }
            else
            {
                percentLabel.Visible = false;
            }
        }
    }
}
