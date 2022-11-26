using Heluo.Battle;
using Heluo.Flow;
using System;
using System.Windows.Forms;
using UnityEngine;

namespace 侠之道mod制作器
{
    public partial class BufferTurnPromoteActionForm : Form
    {
        public bool isAdd;
        public BufferTurnPromoteActionForm()
        {
            InitializeComponent();

            initPropertyComboBox();
            initMethodComboBox();
        }
        public BufferTurnPromoteActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < propertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)propertyComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        propertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < methodComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)methodComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        methodComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Text = fieldsList[2];
                valueLimitNumericUpDown.Text = fieldsList[3];
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
            if (propertyComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择作用属性");
                return;
            }
            if (methodComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择作用方式");
                return;
            }
            if (string.IsNullOrEmpty(valueNumericUpDown.Text))
            {
                MessageBox.Show("请输入提升值");
                return;
            }
            if (string.IsNullOrEmpty(valueLimitNumericUpDown.Text))
            {
                valueLimitNumericUpDown.Text = "50";
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

            currentNode.Tag = "\"BufferTurnPromoteAction\" : " + ((ComboBoxItem)propertyComboBox.SelectedItem).key + ", "
                + ((ComboBoxItem)methodComboBox.SelectedItem).key + ", " + float.Parse(valueNumericUpDown.Text).ToString("0.00000") + ", " + float.Parse(valueLimitNumericUpDown.Text).ToString("0.00000");



            BattleProperty battleProperty = (BattleProperty)Enum.Parse(typeof(BattleProperty), ((ComboBoxItem)propertyComboBox.SelectedItem).key);

            string bufferStr = "";


            if (battleProperty == BattleProperty.HP || battleProperty == BattleProperty.Max_HP)
            {
                bufferStr += EnumData.GetDisplayName(BattleProperty.HP);
            }
            else if (battleProperty == BattleProperty.MP || battleProperty == BattleProperty.Max_MP)
            {
                bufferStr += EnumData.GetDisplayName(BattleProperty.MP);
            }
            else
            {
                bufferStr += propertyComboBox.Text;
            }

            Method method = (Method)Enum.Parse(typeof(Method), ((ComboBoxItem)methodComboBox.SelectedItem).key);
            string valueStr = float.Parse(valueNumericUpDown.Text).ToString();
            if (method == Method.Clear)
            {
                valueStr = "";
            }

            if (method != Method.Multiply)
            {
                bufferStr += " " + methodComboBox.Text
                    + " " + valueStr
                    + " 上限 " + float.Parse(valueLimitNumericUpDown.Text).ToString();
            }
            else
            {
                bufferStr += " 增加 " + propertyComboBox.Text + " 的基础值的 " + float.Parse(valueNumericUpDown.Text).ToString() + "%"
                    + " 上限 " + float.Parse(valueLimitNumericUpDown.Text).ToString();
            }

            currentNode.Text = "回合数提升属性:每1回合" + " " + bufferStr;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void valueNumericUpDown_Enter(object sender, EventArgs e)
        {
            valueNumericUpDown.Tag = valueNumericUpDown.Text;
        }

        private void valueNumericUpDown_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(valueNumericUpDown.Text))
                {
                    valueNumericUpDown.Text = "0";
                }

                float value = Mathf.Clamp(float.Parse(valueNumericUpDown.Text), float.MinValue, float.MaxValue);

                valueNumericUpDown.Text = value.ToString("0.00000");
            }
            catch (Exception)
            {

                valueNumericUpDown.Text = valueNumericUpDown.Tag.ToString();
            }
        }

        public void showPercentLabel()
        {
            BufferInfoForm bufferInfoForm = (BufferInfoForm)Owner;
            if (propertyComboBox.SelectedIndex == -1 || methodComboBox.SelectedIndex == -1)
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

        private void propertyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPercentLabel();
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPercentLabel();
        }

        private void valueLimitNumericUpDown_Enter(object sender, EventArgs e)
        {
            valueLimitNumericUpDown.Tag = valueLimitNumericUpDown.Text;
        }

        private void valueLimitNumericUpDown_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(valueLimitNumericUpDown.Text))
                {
                    valueLimitNumericUpDown.Text = "0";
                }

                float valueLimit = Mathf.Clamp(float.Parse(valueLimitNumericUpDown.Text), float.MinValue, float.MaxValue);

                valueLimitNumericUpDown.Text = valueLimit.ToString("0.00000");
            }
            catch (Exception)
            {

                valueLimitNumericUpDown.Text = valueLimitNumericUpDown.Tag.ToString();
            }
        }
    }
}
