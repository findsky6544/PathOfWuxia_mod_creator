using Heluo.Data;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class EvaluationPointForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public EvaluationPointForm()
        {
            InitializeComponent();

            initEquipTypeComboBox();
        }
        public EvaluationPointForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            this.lvi = lvi;
            this.isAdd = isAdd;
            Owner = owner;
            Text = owner.Text + Text;

            string fields = "";
            fields = lvi.Tag.ToString();

            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                for (int i = 0; i < EvaluationPointComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)EvaluationPointComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        EvaluationPointComboBox.SelectedIndex = i;
                        break;
                    }
                }
                DescriptionTextBox.Text = fieldsList[1].Trim();
                ValueNumericUpDown.Text = fieldsList[2].Trim();
            }
        }

        public void initEquipTypeComboBox()
        {
            EvaluationPointComboBox.DisplayMember = "value";
            EvaluationPointComboBox.ValueMember = "key";
            foreach (EvaluationPoint temp in Enum.GetValues(typeof(EvaluationPoint)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                EvaluationPointComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValueNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入分数");
                return;
            }

            lvi.Tag = "[" + ((ComboBoxItem)EvaluationPointComboBox.SelectedItem).key + ",( " + DescriptionTextBox.Text + "," + ValueNumericUpDown.Text + ")]";
            lvi.SubItems[1].Text = DescriptionTextBox.Text;
            lvi.SubItems[2].Text = ValueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
