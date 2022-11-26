using Heluo.Battle;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultChangeSecondaryGoalForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultChangeSecondaryGoalForm()
        {
            InitializeComponent();
            initStausComboBox();
        }
        public BattleResultChangeSecondaryGoalForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                SecondaryGoalIDTextBox.Text = fieldsList[0];
                for (int i = 0; i < StausComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)StausComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        StausComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);

            this.isAdd = isAdd;
        }

        public void initStausComboBox()
        {
            StausComboBox.DisplayMember = "value";
            StausComboBox.ValueMember = "key";
            foreach (SecondaryGoalTip.TipStaus temp in Enum.GetValues(typeof(SecondaryGoalTip.TipStaus)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                StausComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SecondaryGoalIDTextBox.Text))
            {
                MessageBox.Show("请输入次要条件编号");
                return;
            }
            if (string.IsNullOrEmpty(StausComboBox.Text))
            {
                MessageBox.Show("请选择次要条件状态");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultChangeSecondaryGoal\\\" :\\\"" + SecondaryGoalIDTextBox.Text + "\\\", " + ((ComboBoxItem)StausComboBox.SelectedItem).key;
            lvi.SubItems[1].Text = Text + ":" + "(ID:" + SecondaryGoalIDTextBox.Text + ")" + StausComboBox.Text;
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
    }
}
