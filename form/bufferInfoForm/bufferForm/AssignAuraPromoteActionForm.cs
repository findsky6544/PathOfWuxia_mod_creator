using Heluo.Data;
using Heluo.Flow.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AssignAuraPromoteActionForm : Form
    {
        public bool isAdd;
        public AssignAuraPromoteActionForm()
        {
            InitializeComponent();

            initUnitFactionComboBox();
            initGenderComboBox();
        }
        public AssignAuraPromoteActionForm(string tag, bool isAdd, Form owner) : this()
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
                unitIdTextBox.Text = fieldsList[3];
                buffIdTextBox.Text = fieldsList[4];
                if (fieldsList[5] == "True")
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
            if (unitIdTextBox.Text == "")
            {
                MessageBox.Show("请输入指定的ID");
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

            currentNode.Tag = "\"AssignAuraPromoteAction\" : " + ((ComboBoxItem)unitFactionComboBox.SelectedItem).key
                + ", " + ((ComboBoxItem)genderComboBox.SelectedItem).key + ", " + distanceNumericUpDown.Value
                + ", \"" + unitIdTextBox.Text + "\"" + ", \"" + buffIdTextBox.Text + "\"" + ", " + hasSelfCheckBox.Checked;

            Gender gender = (Gender)Enum.Parse(typeof(Gender), ((ComboBoxItem)genderComboBox.SelectedItem).key);

            currentNode.Text = "指定ID范围增加Buff:" + "距离 " + DataManager.getUnitsName(unitIdTextBox.Text) + " " + distanceNumericUpDown.Value + " 格内的 " + unitFactionComboBox.Text
                    + (gender == Gender.All ? "" : " " + genderComboBox.Text)
                    + " 添加 " + DataManager.getBuffersName(buffIdTextBox.Text) + " " + (hasSelfCheckBox.Checked ? "包含自身" : "不包含自身");
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectUnitIdButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIdTextBox, false);
            form.ShowDialog();
        }

        private void selectBuffButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, buffIdTextBox, false);
            form.ShowDialog();
        }
    }
}
