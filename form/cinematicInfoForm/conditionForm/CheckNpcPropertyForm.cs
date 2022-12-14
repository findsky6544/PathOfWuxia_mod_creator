using Heluo.Data;
using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckNpcPropertyForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckNpcPropertyForm()
        {
            InitializeComponent();

            initPropertyComboBox();
            initOpComboBox();
        }
        public CheckNpcPropertyForm(TreeNode currentNode, bool isAdd) : this()
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

                for (int i = 0; i < propertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)propertyComboBox.Items[i]).key == fieldsList[2].Trim())
                    {
                        propertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                npcIdTextBox.Text = fieldsList[3].Trim();
            }

            this.isAdd = isAdd;
        }

        public void initPropertyComboBox()
        {
            propertyComboBox.DisplayMember = "value";
            propertyComboBox.ValueMember = "key";
            foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                propertyComboBox.Items.Add(cbi);
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
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC的character编号");
                return;
            }
            if (propertyComboBox.Text == "")
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

            currentNode.Tag = "\"CheckNpcProperty\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Text + ", " + ((ComboBoxItem)propertyComboBox.SelectedItem).key + ", \"" + npcIdTextBox.Text + "\"";
            currentNode.Text = Text + ":" + DataManager.getCharacterExteriorName(npcIdTextBox.Text) + " 的 " + propertyComboBox.Text + " " + opComboBox.Text + " " + valueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectCharacterInfoButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
