using Heluo.Controller;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class InputTypeConditionForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public InputTypeConditionForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public InputTypeConditionForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < typeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)typeComboBox.Items[i]).key == fieldsList[2].Trim())
                    {
                        typeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initTypeComboBox()
        {
            typeComboBox.DisplayMember = "value";
            typeComboBox.ValueMember = "key";
            foreach (InputType temp in Enum.GetValues(typeof(InputType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                typeComboBox.Items.Add(cbi);
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (typeComboBox.Text == "")
            {
                MessageBox.Show("请选择输入装置");
                return;
            }

            currentNode.Tag = "\"InputTypeCondition\" : " + "0, 0, " + ((ComboBoxItem)typeComboBox.SelectedItem).key;
            currentNode.Text = Text + ":" + "为 " + typeComboBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
