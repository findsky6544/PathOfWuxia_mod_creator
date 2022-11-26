using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ScheduleEventNodeForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public ScheduleEventNodeForm()
        {
            InitializeComponent();
            initScheduleTiming();
        }
        public ScheduleEventNodeForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string scheduleTimingStr = lvi.SubItems[1].Text;
            string[] scheduleTimingParams = scheduleTimingStr.Split(':');
            scheduleTimingComboBox.Text = scheduleTimingParams[0].Trim();

            if (!string.IsNullOrEmpty(scheduleTimingParams[1].Trim()))
            {
                priorityNumericUpDown.Value = int.Parse(scheduleTimingParams[1].Trim().Split(' ')[1]);
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);
            prallelNumericUpDown.Value = int.Parse(lvi.SubItems[3].Text);

            this.isAdd = isAdd;

            if (isAdd)
            {
                Text = "添加新时点";
            }
            else
            {
                Text = "修改时点";
            }
        }


        public void initScheduleTiming()
        {
            scheduleTimingComboBox.DisplayMember = "value";
            scheduleTimingComboBox.ValueMember = "key";
            foreach (BattleEventToggleTime temp in Enum.GetValues(typeof(BattleEventToggleTime)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                scheduleTimingComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (scheduleTimingComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择时点");
                return;
            }
            if (priorityNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入优先权");
                return;
            }
            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleEventNode\\\" : " + ((ComboBoxItem)scheduleTimingComboBox.SelectedItem).key + ", " + priorityNumericUpDown.Text + ", [ ]";
            lvi.SubItems[1].Text = scheduleTimingComboBox.Text + ":优先权 " + priorityNumericUpDown.Text;
            lvi.SubItems[2].Text = nextNumericUpDown.Text;
            lvi.SubItems[3].Text = prallelNumericUpDown.Text;

            if (Text == "添加新时点")
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

        private void selectPrallelButton_Click(object sender, EventArgs e)
        {
            SelectScheduleNodeForm form = new SelectScheduleNodeForm(this, prallelNumericUpDown);
            form.ShowDialog();
        }
    }
}
