using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultTalkForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultTalkForm()
        {
            InitializeComponent();
        }

        public BattleResultTalkForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                TalkIDTextBox.Text = fieldsList[0];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TalkIDTextBox.Text))
            {
                MessageBox.Show("请选择对话");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultTalk\\\" : \\\"" + TalkIDTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = Text + ":" + DataManager.getTalkMessage(TalkIDTextBox.Text);
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

        private void selectUnitAIDButton_Click(object sender, EventArgs e)
        {
            SelectTalkForm form = new SelectTalkForm(this, TalkIDTextBox, false, Heluo.Data.TalkType.Message);
            form.ShowDialog();
        }
    }
}
