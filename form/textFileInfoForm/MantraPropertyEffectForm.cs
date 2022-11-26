using Heluo.Battle;
using Heluo.Flow;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MantraPropertyEffectForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public MantraPropertyEffectForm()
        {
            InitializeComponent();

            initPropertyComboBox();
            initMethodComboBox();
        }
        public MantraPropertyEffectForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                MartraLevelNumericUpDown.Text = fieldsList[0].Trim();
                for (int i = 0; i < PropertyComboBox.Items.Count; i++)
                {
                    if (Enum.Parse(typeof(BattleProperty), ((ComboBoxItem)PropertyComboBox.Items[i]).key).ToString() == fieldsList[1].Trim())
                    {
                        PropertyComboBox.SelectedIndex = i;
                        break;
                    }
                }
                for (int i = 0; i < MethodComboBox.Items.Count; i++)
                {
                    if (Enum.Parse(typeof(Method), ((ComboBoxItem)MethodComboBox.Items[i]).key).ToString() == fieldsList[2].Trim())
                    {
                        MethodComboBox.SelectedIndex = i;
                        break;
                    }
                }
                MaxValueNumericUpDown.Text = fieldsList[3].Trim();
            }
        }

        public void initPropertyComboBox()
        {
            PropertyComboBox.DisplayMember = "value";
            PropertyComboBox.ValueMember = "key";
            foreach (BattleProperty temp in Enum.GetValues(typeof(BattleProperty)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                PropertyComboBox.Items.Add(cbi);
            }
        }

        public void initMethodComboBox()
        {
            MethodComboBox.DisplayMember = "value";
            MethodComboBox.ValueMember = "key";
            foreach (Method temp in Enum.GetValues(typeof(Method)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                MethodComboBox.Items.Add(cbi);
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            if (MartraLevelNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入内功需求等级");
                return;
            }
            if (PropertyComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入内功效果属性");
                return;
            }
            if (MethodComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入提升方式");
                return;
            }
            if (MaxValueNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入等级最高提升值");
                return;
            }


            lvi.Tag = "(" + MartraLevelNumericUpDown.Text + ", " + Enum.Parse(typeof(BattleProperty), ((ComboBoxItem)PropertyComboBox.SelectedItem).key) + ", " + Enum.Parse(typeof(Method), ((ComboBoxItem)MethodComboBox.SelectedItem).key) + ", " + MaxValueNumericUpDown.Text + ")";
            lvi.Text = MartraLevelNumericUpDown.Text;
            lvi.SubItems[1].Text = PropertyComboBox.Text;
            lvi.SubItems[2].Text = MethodComboBox.Text;
            lvi.SubItems[3].Text = MaxValueNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
