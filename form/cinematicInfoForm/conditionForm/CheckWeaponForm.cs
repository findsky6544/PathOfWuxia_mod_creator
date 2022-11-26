using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckWeaponForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckWeaponForm()
        {
            InitializeComponent();

            initPropsCategoryComboBox();
        }
        public CheckWeaponForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
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
                if (string.IsNullOrEmpty(propsCategoryComboBox.Text))
                {
                    propsCategoryComboBox.SelectedIndex = 0;
                }
            }

            this.isAdd = isAdd;
        }

        public void initPropsCategoryComboBox()
        {
            propsCategoryComboBox.DisplayMember = "value";
            propsCategoryComboBox.ValueMember = "key";
            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                if (temp >= PropsCategory.Fist && temp <= PropsCategory.Special)
                {
                    ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                    propsCategoryComboBox.Items.Add(cbi);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (propsCategoryComboBox.Text == "")
            {
                MessageBox.Show("请选择武器种类");
                return;
            }

            currentNode.Tag = "\"CheckWeapon\" : " + ((ComboBoxItem)propsCategoryComboBox.SelectedItem).key;
            currentNode.Text = Text + ":" + "为 " + propsCategoryComboBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
