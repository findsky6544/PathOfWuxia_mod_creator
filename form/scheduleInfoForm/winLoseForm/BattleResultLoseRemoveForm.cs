using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultLoseRemoveForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultLoseRemoveForm()
        {
            InitializeComponent();
        }
        public BattleResultLoseRemoveForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                WinLoseIDTextBox.Text = fieldsList[0];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WinLoseIDTextBox.Text))
            {
                MessageBox.Show("请输入条件编号");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultLoseRemove\\\" : \\\"" + WinLoseIDTextBox.Text + "\\\" ";
            lvi.SubItems[1].Text = Text + ":" + (WinLoseIDTextBox.Text == "" ? "" : "id:" + WinLoseIDTextBox.Text);
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
