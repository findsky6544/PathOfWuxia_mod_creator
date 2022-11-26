using Heluo.Data;
using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckPlayerTotalSkillLevelForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckPlayerTotalSkillLevelForm()
        {
            InitializeComponent();

            initTypeComboBox();
            initOpComboBox();
        }
        public CheckPlayerTotalSkillLevelForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < opComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)opComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        opComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Value = int.Parse(fieldsList[1].Trim());

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
            foreach (PropsCategory temp in Enum.GetValues(typeof(PropsCategory)))
            {
                if (temp >= PropsCategory.Fist && temp <= PropsCategory.Special)
                {
                    ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                    typeComboBox.Items.Add(cbi);
                }
            }
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
            if (typeComboBox.Text == "")
            {
                MessageBox.Show("请选择角色属性");
                return;
            }
            if (opComboBox.Text == "")
            {
                MessageBox.Show("请选择比较方式");
                return;
            }
            if (opComboBox.Text == "")
            {
                MessageBox.Show("请输入值");
                return;
            }

            currentNode.Tag = "\"CheckPlayerTotalSkillLevel\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Text + ", " + ((ComboBoxItem)typeComboBox.SelectedItem).key;
            currentNode.Text = "检查 Player 的 " + typeComboBox.Text + " 类型技能等级总和 " + opComboBox.Text + " " + valueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
