using Heluo.Data;
using Heluo.Flow.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SingleAuraPromoteActionForm : Form
    {
        public bool isAdd;
        public SingleAuraPromoteActionForm()
        {
            InitializeComponent();

            initUnitFactionComboBox();
            initGenderComboBox();
        }
        public SingleAuraPromoteActionForm(string tag, bool isAdd, Form owner) : this()
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
                for (int i = 0; i < genderComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)genderComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        genderComboBox.SelectedIndex = i;
                        break;
                    }
                }
                distanceNumericUpDown.Value = int.Parse(fieldsList[2]);
                buffIdTextBox.Text = fieldsList[3];
                if (fieldsList[4] == "True")
                {
                    hasSelfCheckBox.Checked = true;
                }
            }

            this.isAdd = isAdd;
        }

        public void initUnitFactionComboBox()
        {
            unitFactionComboBox.DisplayMember = "value";
            unitFactionComboBox.ValueMember = "key";
            foreach (UnitFaction temp in Enum.GetValues(typeof(UnitFaction)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                unitFactionComboBox.Items.Add(cbi);
            }
        }

        public void initGenderComboBox()
        {
            genderComboBox.DisplayMember = "value";
            genderComboBox.ValueMember = "key";
            foreach (Gender temp in Enum.GetValues(typeof(Gender)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                genderComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (unitFactionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部队阵营");
                return;
            }
            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择部队性别");
                return;
            }
            if (buffIdTextBox.Text == "")
            {
                MessageBox.Show("请输入添加的Buff id");
                return;
            }
            if (distanceNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入距离");
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

            currentNode.Tag = "\"SingleAuraPromoteAction\" : " + ((ComboBoxItem)unitFactionComboBox.SelectedItem).key
                + ", " + ((ComboBoxItem)genderComboBox.SelectedItem).key + ", " + distanceNumericUpDown.Value
                + ", \"" + buffIdTextBox.Text + "\"" + ", " + hasSelfCheckBox.Checked;

            Gender gender = (Gender)Enum.Parse(typeof(Gender), ((ComboBoxItem)genderComboBox.SelectedItem).key);

            currentNode.Text = "条件式范围增加Buff(单次触发):" + "距离 " + distanceNumericUpDown.Value + " 格内的 " + unitFactionComboBox.Text
                    + (gender == Gender.All ? "" : " " + genderComboBox.Text)
                    + " 添加 " + DataManager.getBuffersName(buffIdTextBox.Text) + " " + (hasSelfCheckBox.Checked ? "包含自身" : "不包含自身");
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectBuffButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, buffIdTextBox, false);
            form.ShowDialog();
        }
    }
}
