using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoEquipForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoEquipForm()
        {
            InitializeComponent();

            initEquipTypeComboBox();
        }
        public CharacterInfoEquipForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < EquipTypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)EquipTypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        EquipTypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                propsIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        public void initEquipTypeComboBox()
        {
            EquipTypeComboBox.DisplayMember = "value";
            EquipTypeComboBox.ValueMember = "key";
            foreach (EquipType temp in Enum.GetValues(typeof(EquipType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                EquipTypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            lvi.Tag = "(" + ((ComboBoxItem)EquipTypeComboBox.SelectedItem).key + "," + propsIdTextBox.Text + ")";
            lvi.SubItems[1].Text = DataManager.getPropssName(propsIdTextBox.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            EquipType equipType = (EquipType)(Enum.Parse(typeof(EquipType), ((ComboBoxItem)EquipTypeComboBox.SelectedItem).key));
            SelectPropsForm form = null;
            switch (equipType)
            {
                case EquipType.Weapon:
                    form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "Weapon" }, new string[] { "all" });
                    break;
                case EquipType.Cloth:
                    form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "Armor" }, new string[] { "all" });
                    break;
                case EquipType.Jewelry:
                    form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "Accessories" }, new string[] { "all" });
                    break;
                default:
                    form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
                    break;
            }
            form.ShowDialog();
        }
    }
}
