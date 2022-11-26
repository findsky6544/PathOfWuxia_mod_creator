using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoUpgradeablePropertyForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoUpgradeablePropertyForm()
        {
            InitializeComponent();

            initCharacterUpgradablePropertyComboBox();
        }
        public CharacterInfoUpgradeablePropertyForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < CharacterUpgradablePropertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)CharacterUpgradablePropertyComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        CharacterUpgradablePropertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                UpgradeablePropertyNumericUpDown.Text = fieldsList[1].Trim();
            }
        }

        public void initCharacterUpgradablePropertyComboBox()
        {
            CharacterUpgradablePropertyComboBox.DisplayMember = "value";
            CharacterUpgradablePropertyComboBox.ValueMember = "key";
            foreach (CharacterUpgradableProperty temp in Enum.GetValues(typeof(CharacterUpgradableProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                CharacterUpgradablePropertyComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            lvi.Tag = "(" + ((ComboBoxItem)CharacterUpgradablePropertyComboBox.SelectedItem).key + "," + UpgradeablePropertyNumericUpDown.Text + ")";
            lvi.SubItems[1].Text = UpgradeablePropertyNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
