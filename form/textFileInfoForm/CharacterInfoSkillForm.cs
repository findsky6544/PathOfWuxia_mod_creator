using Heluo.Data;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CharacterInfoSkillForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public CharacterInfoSkillForm()
        {
            InitializeComponent();

            initColumnComboBox();
        }
        public CharacterInfoSkillForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < ColumnComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)ColumnComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        ColumnComboBox.SelectedIndex = i;
                        break;
                    }
                }
                IdTextBox.Text = fieldsList[1].Trim();
                LevelNumericUpDown.Text = fieldsList[2].Trim();
            }
        }

        public void initColumnComboBox()
        {
            ColumnComboBox.DisplayMember = "value";
            ColumnComboBox.ValueMember = "key";
            foreach (SkillColumn temp in Enum.GetValues(typeof(SkillColumn)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ColumnComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ColumnComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入装备的栏位");
                return;
            }
            if (IdTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入技能编号");
                return;
            }
            if (LevelNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入目前等级");
                return;
            }


            lvi.Tag = "(" + ((ComboBoxItem)ColumnComboBox.SelectedItem).key + "," + IdTextBox.Text + "," + LevelNumericUpDown.Text + ")";
            lvi.Text = ColumnComboBox.Text;
            lvi.SubItems[1].Text = DataManager.getSkillsName(IdTextBox.Text);
            lvi.SubItems[2].Text = LevelNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectSkillButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, IdTextBox, false, SelectSkillForm.selectSkillType.normal);
            form.ShowDialog();
        }
    }
}
