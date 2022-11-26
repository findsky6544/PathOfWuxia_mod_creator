using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoGrowPropertyForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoGrowPropertyForm()
        {
            InitializeComponent();

            initCharacterUpgradablePropertyComboBox();
        }
        public CharacterInfoGrowPropertyForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < GrowPropertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)GrowPropertyComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        GrowPropertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                MinNumericUpDown.Text = fieldsList[1].Trim();
                MaxNumericUpDown.Text = fieldsList[2].Trim();
            }
        }

        public void initCharacterUpgradablePropertyComboBox()
        {
            GrowPropertyComboBox.DisplayMember = "value";
            GrowPropertyComboBox.ValueMember = "key";
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                GrowPropertyComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            lvi.Tag = "[" + ((ComboBoxItem)GrowPropertyComboBox.SelectedItem).key + ",(" + MinNumericUpDown.Text + "," + MaxNumericUpDown.Text + ")]";
            lvi.SubItems[1].Text = MinNumericUpDown.Text;
            lvi.SubItems[2].Text = MaxNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
