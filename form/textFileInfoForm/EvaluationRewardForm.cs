using Heluo.Data;
using Heluo.Utility;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class EvaluationLevelForm : Form
    {
        public bool isAdd;
        public ListViewItem lvi;
        public EvaluationLevelForm()
        {
            InitializeComponent();

            initEquipTypeComboBox();
        }
        public EvaluationLevelForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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


                for (int i = 0; i < EvaluationLevelComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)EvaluationLevelComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        EvaluationLevelComboBox.SelectedIndex = i;
                        break;
                    }
                }
                propsIdTextBox.Text = fieldsList[1].Trim();
                CountNumericUpDown.Text = fieldsList[2].Trim();
            }
        }

        public void initEquipTypeComboBox()
        {
            EvaluationLevelComboBox.DisplayMember = "value";
            EvaluationLevelComboBox.ValueMember = "key";
            foreach (EvaluationLevel temp in Enum.GetValues(typeof(EvaluationLevel)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                EvaluationLevelComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (CountNumericUpDown.Text.IsNullOrEmpty())
            {
                MessageBox.Show("请输入数量");
                return;
            }

            lvi.Tag = "[" + ((ComboBoxItem)EvaluationLevelComboBox.SelectedItem).key + ",(" + propsIdTextBox.Text + "," + CountNumericUpDown.Text + ")]";
            lvi.SubItems[1].Text = DataManager.getPropssName(propsIdTextBox.Text);
            lvi.SubItems[2].Text = CountNumericUpDown.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, propsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }
    }
}
