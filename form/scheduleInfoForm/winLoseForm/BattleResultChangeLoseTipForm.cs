using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultChangeLoseTipForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultChangeLoseTipForm()
        {
            InitializeComponent();
        }
        public BattleResultChangeLoseTipForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                LoseTipTextBox.Text = fieldsList[0];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoseTipTextBox.Text))
            {
                MessageBox.Show("请输入失败条件说明");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultChangeLoseTip\\\" : \\\"" + LoseTipTextBox.Text + "\\\" ";
            lvi.SubItems[1].Text = Text + ":" + LoseTipTextBox.Text;
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
