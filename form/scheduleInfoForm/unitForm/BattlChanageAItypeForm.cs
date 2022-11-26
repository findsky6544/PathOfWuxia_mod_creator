using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattlChanageAItypeForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattlChanageAItypeForm()
        {
            InitializeComponent();
            initAitypeComboBox();
        }

        public BattlChanageAItypeForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < aitypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)aitypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        aitypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                unitIdsTextBox.Text = fieldsList[1];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        public void initAitypeComboBox()
        {
            aitypeComboBox.DisplayMember = "value";
            aitypeComboBox.ValueMember = "key";
            foreach (AIType temp in Enum.GetValues(typeof(AIType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                aitypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unitIdsTextBox.Text))
            {
                MessageBox.Show("请选择部队");
                return;
            }
            if (string.IsNullOrEmpty(aitypeComboBox.Text))
            {
                MessageBox.Show("请选择AI类型");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattlChanageAItype\\\" : " + ((ComboBoxItem)aitypeComboBox.SelectedItem).key + ", \\\"" + unitIdsTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = Text + ":" + DataManager.getUnitsName(unitIdsTextBox.Text) + " AI类型转换为 " + aitypeComboBox.Text;
            lvi.SubItems[2].Text = nextNumericUpDown.Text;

            if (isAdd)
            {
                scheduleListView.Items.Add(lvi);
            }
            Close();

            scheduleInfoForm.createScheduleTree();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectNextButton_Click(object sender, EventArgs e)
        {
            SelectScheduleNodeForm form = new SelectScheduleNodeForm(this, nextNumericUpDown);
            form.ShowDialog();
        }

        private void selectUnitButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIdsTextBox, false);
            form.ShowDialog();
        }
    }
}
