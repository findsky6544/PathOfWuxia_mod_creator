using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SequenceNodeForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public SequenceNodeForm()
        {
            InitializeComponent();
        }
        public SequenceNodeForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;


            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);
            prallelNumericUpDown.Value = int.Parse(lvi.SubItems[3].Text);

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"SequenceNode\\\" : " + "[ ]";
            lvi.SubItems[1].Text = Text;
            lvi.SubItems[2].Text = nextNumericUpDown.Text;
            lvi.SubItems[3].Text = prallelNumericUpDown.Text;

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

        private void selectPrallelButton_Click(object sender, EventArgs e)
        {
            SelectScheduleNodeForm form = new SelectScheduleNodeForm(this, prallelNumericUpDown);
            form.ShowDialog();
        }
    }
}
