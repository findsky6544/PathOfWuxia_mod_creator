using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoPropertyForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoPropertyForm()
        {
            InitializeComponent();

            initCharacterPropertyComboBox();
        }
        public CharacterInfoPropertyForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < CharacterPropertyComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)CharacterPropertyComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        CharacterPropertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                PropertyNumericUpDown.Text = fieldsList[1].Trim();
            }
        }

        public void initCharacterPropertyComboBox()
        {
            CharacterPropertyComboBox.DisplayMember = "value";
            CharacterPropertyComboBox.ValueMember = "key";
            foreach (CharacterProperty temp in Enum.GetValues(typeof(CharacterProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                CharacterPropertyComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            lvi.Tag = "(" + ((ComboBoxItem)CharacterPropertyComboBox.SelectedItem).key + "," + PropertyNumericUpDown.Text + ")";
            lvi.SubItems[1].Text = PropertyNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
