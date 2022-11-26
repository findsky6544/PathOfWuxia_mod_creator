using Heluo.Battle;
using Heluo.Flow;
using System;
using System.Windows.Forms;
using UnityEngine;

namespace 侠之道mod制作器
{
    public partial class HPPercentPromoteActionForm : Form
    {
        public bool isAdd;
        public HPPercentPromoteActionForm()
        {
            InitializeComponent();

            initOpComboBox();
            initPropertyComboBox();
        }
        public HPPercentPromoteActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
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
                PercentNumericUpDown.Text = fieldsList[1];
                PercentGapNumericUpDown.Text = fieldsList[2];
                for (int i = 0; i < propertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)propertyComboBox.Items[i]).key == fieldsList[3].Trim())
                    {
                        propertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                valueNumericUpDown.Text = fieldsList[4];
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

        private void okButton_Click(object sender, EventArgs e)
        {
            if (opComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择比较方式");
                return;
            }
            if (string.IsNullOrEmpty(PercentNumericUpDown.Text))
            {
                MessageBox.Show("请输入HP百分比");
                return;
            }
            if (string.IsNullOrEmpty(PercentGapNumericUpDown.Text))
            {
                MessageBox.Show("请输入间隔百分比");
                return;
            }
            if (propertyComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择修改属性");
                return;
            }
            if (string.IsNullOrEmpty(valueNumericUpDown.Text))
            {
                MessageBox.Show("请输入修改值");
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

            currentNode.Tag = "\"HPPercentPromoteAction\" : "
                + ((ComboBoxItem)opComboBox.SelectedItem).key
                 + ", " + float.Parse(PercentNumericUpDown.Text).ToString("0.00000")
                 + ", " + float.Parse(PercentGapNumericUpDown.Text).ToString("0.00000")
                 + ", " + ((ComboBoxItem)propertyComboBox.SelectedItem).key
                 + ", " + float.Parse(valueNumericUpDown.Text).ToString("0.00000");


            string bufferStr = "相较 " + float.Parse(PercentNumericUpDown.Text).ToString() + "% 每 " + opComboBox.Text + " " + float.Parse(PercentGapNumericUpDown.Text).ToString() + "%, "
                    + propertyComboBox.Text + " 提升 " + float.Parse(valueNumericUpDown.Text).ToString();

            currentNode.Text = "HP百分比修改属性:" + bufferStr;
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

        private void PercentNumericUpDown_Enter(object sender, EventArgs e)
        {
            PercentNumericUpDown.Tag = PercentNumericUpDown.Text;
        }

        private void PercentNumericUpDown_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PercentNumericUpDown.Text))
                {
                    PercentNumericUpDown.Text = "0";
                }

                float valueLimit = Mathf.Clamp(float.Parse(PercentNumericUpDown.Text), float.MinValue, float.MaxValue);

                PercentNumericUpDown.Text = valueLimit.ToString("0.00000");
            }
            catch (Exception)
            {

                PercentNumericUpDown.Text = PercentNumericUpDown.Tag.ToString();
            }
        }

        private void PercentGapNumericUpDown_Enter(object sender, EventArgs e)
        {
            PercentGapNumericUpDown.Tag = PercentGapNumericUpDown.Text;
        }

        private void PercentGapNumericUpDown_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PercentGapNumericUpDown.Text))
                {
                    PercentGapNumericUpDown.Text = "0";
                }

                float valueLimit = Mathf.Clamp(float.Parse(PercentGapNumericUpDown.Text), float.MinValue, float.MaxValue);

                PercentGapNumericUpDown.Text = valueLimit.ToString("0.00000");
            }
            catch (Exception)
            {

                PercentGapNumericUpDown.Text = PercentGapNumericUpDown.Tag.ToString();
            }
        }
    }
}
