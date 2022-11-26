using Heluo.Data;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NurturanceInfoRewardForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public NurturanceInfoRewardForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public NurturanceInfoRewardForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < TypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)TypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        TypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < PropComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)PropComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        PropComboBox.SelectedIndex = i;
                        break;
                    }
                }
                ValueNumericUpDown.Text = fieldsList[2].Trim();
            }
        }

        public void initTypeComboBox()
        {
            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";
            foreach (NurturanceRewardType temp in Enum.GetValues(typeof(NurturanceRewardType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (TypeComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入类型");
                return;
            }
            if (PropComboBox.Enabled && PropComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入属性");
                return;
            }
            if (ValueNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入值");
                return;
            }


            lvi.Tag = "(" + ((ComboBoxItem)TypeComboBox.SelectedItem).key + ", " + (PropComboBox.Enabled ? ((ComboBoxItem)PropComboBox.SelectedItem).key : "0") + "," + ValueNumericUpDown.Text + ")";
            lvi.Text = TypeComboBox.Text;
            lvi.SubItems[1].Text = (PropComboBox.Enabled ? PropComboBox.Text : "");
            lvi.SubItems[2].Text = ValueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NurturanceRewardType type = (NurturanceRewardType)Enum.Parse(typeof(NurturanceRewardType), ((ComboBoxItem)TypeComboBox.SelectedItem).key);
            PropComboBox.Items.Clear();
            PropComboBox.Text = "";
            PropComboBox.DisplayMember = "value";
            PropComboBox.ValueMember = "key";

            PropComboBox.Enabled = true;
            switch (type)
            {
                case NurturanceRewardType.UpgradableProperty:

                    foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
                    {
                        ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                        PropComboBox.Items.Add(cbi);
                    }
                    break;
                case NurturanceRewardType.CharacterProperty:
                    foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
                    {
                        ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                        PropComboBox.Items.Add(cbi);
                    }
                    break;
                case NurturanceRewardType.Money:
                    PropComboBox.SelectedIndex = -1;
                    PropComboBox.Enabled = false;
                    break;
            }
        }
    }
}
