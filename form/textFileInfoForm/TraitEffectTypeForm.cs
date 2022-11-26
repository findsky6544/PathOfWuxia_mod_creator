using Heluo.Data;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TraitEffectTypeForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public TraitEffectTypeForm()
        {
            InitializeComponent();

            Utils.initComboBox(TypeComboBox, typeof(TraitEffectType));
            Utils.initComboBox(PropertyComboBox, typeof(CharacterUpgradableProperty));
            Utils.initComboBox(PropsCategoryComboBox, typeof(PropsCategory));
        }
        public TraitEffectTypeForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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
                    string type = ((TraitEffectType)int.Parse(((ComboBoxItem)TypeComboBox.Items[i]).key)).ToString();
                    if (type == fieldsList[0].Trim())
                    {
                        TypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < PropertyComboBox.Items.Count; i++)
                {
                    string property = ((CharacterUpgradableProperty)int.Parse(((ComboBoxItem)PropertyComboBox.Items[i]).key)).ToString();
                    if (property == fieldsList[1].Trim())
                    {
                        PropertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                ValueNumericUpDown.Text = fieldsList[2];


                label2.Visible = false;
                IdTextBox.Visible = false;
                selectBufferButton.Visible = false;

                label4.Visible = false;
                PropsCategoryComboBox.Visible = false;
                if (TypeComboBox.SelectedItem != null)
                {
                    TraitEffectType type = (TraitEffectType)Enum.Parse(typeof(TraitEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key);

                    switch (type)
                    {
                        case TraitEffectType.SkillQuicken:
                            label4.Visible = true;
                            PropsCategoryComboBox.Visible = true;
                            for (int i = 0; i < PropsCategoryComboBox.Items.Count; i++)
                            {
                                if (((ComboBoxItem)PropsCategoryComboBox.Items[i]).key == fieldsList[3].Trim())
                                {
                                    PropsCategoryComboBox.SelectedIndex = i;
                                    break;
                                }
                            }
                            break;
                        case TraitEffectType.PropertyMaxLevel:
                        case TraitEffectType.UpgradableProperty:
                        case TraitEffectType.MantraQuicken:
                        case TraitEffectType.WorkMoney:
                        case TraitEffectType.StoreDiscount:
                        case TraitEffectType.ReadingBonus:
                        case TraitEffectType.EmotionMax:
                            break;
                        case TraitEffectType.SelfBuffer:
                            label2.Visible = true;
                            IdTextBox.Visible = true;
                            selectBufferButton.Visible = true;
                            IdTextBox.Text = fieldsList[3];
                            break;
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (TypeComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入类型");
                return;
            }
            lvi.Text = TypeComboBox.Text;
            string type = ((TraitEffectType)int.Parse(((ComboBoxItem)TypeComboBox.SelectedItem).key)).ToString();
            switch ((TraitEffectType)Enum.Parse(typeof(TraitEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key))
            {
                case TraitEffectType.PropertyMaxLevel:
                case TraitEffectType.UpgradableProperty:
                    if (PropertyComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("请输入属性");
                        return;
                    }
                    string property = ((CharacterUpgradableProperty)int.Parse(((ComboBoxItem)PropertyComboBox.SelectedItem).key)).ToString();
                    lvi.SubItems[1].Text = PropertyComboBox.Text;
                    lvi.SubItems[2].Text = ValueNumericUpDown.Text;
                    lvi.SubItems[3].Text = "";
                    lvi.Tag = "(" + type + "," + property + "," + ValueNumericUpDown.Text + ",)";
                    break;
                case TraitEffectType.SkillQuicken:
                    if (PropsCategoryComboBox.SelectedItem == null)
                    {
                        MessageBox.Show("请输入武器类型");
                        return;
                    }
                    lvi.SubItems[1].Text = "0";
                    lvi.SubItems[2].Text = ValueNumericUpDown.Text;
                    lvi.SubItems[3].Text = PropsCategoryComboBox.Text;
                    lvi.Tag = "(" + type + "," + 0 + "," + ValueNumericUpDown.Text + "," + ((ComboBoxItem)PropsCategoryComboBox.SelectedItem).key + ")";
                    break;
                case TraitEffectType.MantraQuicken:
                case TraitEffectType.WorkMoney:
                case TraitEffectType.StoreDiscount:
                case TraitEffectType.ReadingBonus:
                case TraitEffectType.EmotionMax:
                    if (ValueNumericUpDown.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入值");
                        return;
                    }
                    lvi.SubItems[1].Text = "0";
                    lvi.SubItems[2].Text = ValueNumericUpDown.Text;
                    lvi.SubItems[3].Text = "";
                    lvi.Tag = "(" + type + "," + 0 + "," + ValueNumericUpDown.Text + ",)";
                    break;
                case TraitEffectType.SelfBuffer:
                    if (IdTextBox.Text.IsNullOrEmpty())
                    {
                        MessageBox.Show("请输入Id");
                        return;
                    }
                    lvi.SubItems[1].Text = "0";
                    lvi.SubItems[2].Text = "0";
                    lvi.SubItems[3].Text = DataManager.getBuffersName(IdTextBox.Text);
                    lvi.Tag = "(" + type + "," + 0 + "," + 0 + "," + IdTextBox.Text + ")";
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TraitEffectType type = (TraitEffectType)Enum.Parse(typeof(TraitEffectType), ((ComboBoxItem)TypeComboBox.SelectedItem).key);

            label2.Visible = false;
            IdTextBox.Visible = false;
            selectBufferButton.Visible = false;
            label4.Visible = false;
            PropsCategoryComboBox.Visible = false;
            switch (type)
            {
                case TraitEffectType.PropertyMaxLevel:
                case TraitEffectType.UpgradableProperty:
                case TraitEffectType.MantraQuicken:
                case TraitEffectType.WorkMoney:
                case TraitEffectType.StoreDiscount:
                case TraitEffectType.ReadingBonus:
                case TraitEffectType.EmotionMax:
                    break;
                case TraitEffectType.SkillQuicken:
                    label4.Visible = true;
                    PropsCategoryComboBox.Visible = true;
                    break;
                case TraitEffectType.SelfBuffer:
                    label2.Visible = true;
                    IdTextBox.Visible = true;
                    selectBufferButton.Visible = true;
                    break;
            }
        }

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, IdTextBox, false);
            form.ShowDialog();
        }
    }
}
