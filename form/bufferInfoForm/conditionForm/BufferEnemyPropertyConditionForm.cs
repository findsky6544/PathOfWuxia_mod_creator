using Heluo.Battle;
using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BufferEnemyPropertyConditionForm : Form
    {
        public bool isAdd;
        public BufferEnemyPropertyConditionForm()
        {
            InitializeComponent();

            initPropertyComboBox();
            initOpComboBox();
        }
        public BufferEnemyPropertyConditionForm(string tag, bool isAdd, Form owner) : this()
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
                for (int i = 0; i < propertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)propertyComboBox.Items[i]).key == fieldsList[2].Trim())
                    {
                        propertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initPropertyComboBox()
        {
            propertyComboBox.DisplayMember = "value";
            propertyComboBox.ValueMember = "key";
            foreach (BattleProperty temp in Enum.GetValues(typeof(BattleProperty)))
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
            if (propertyComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择比较属性");
                return;
            }
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

            currentNode.Tag = "\"BufferEnemyPropertyCondition\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value + ", " + ((ComboBoxItem)propertyComboBox.SelectedItem).key;

            BattleProperty battleProperty = (BattleProperty)Enum.Parse(typeof(BattleProperty), ((ComboBoxItem)propertyComboBox.SelectedItem).key);
            string percentStr = "";

            if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.MP)
            {
                percentStr = "%";
            }

            currentNode.Text = "判断敌方属性:" + propertyComboBox.Text + " " + opComboBox.Text + " " + valueNumericUpDown.Value + percentStr;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void propertyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPercentLabel();
        }

        public void showPercentLabel()
        {
            if (propertyComboBox.SelectedIndex == -1)
            {
                percentLabel.Visible = false;
                return;
            }

            BattleProperty battleProperty = (BattleProperty)Enum.Parse(typeof(BattleProperty), ((ComboBoxItem)propertyComboBox.SelectedItem).key);

            if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.MP)
            {
                percentLabel.Visible = true;
            }
            else
            {
                percentLabel.Visible = false;
            }
        }

        private void opComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPercentLabel();
        }
    }
}
