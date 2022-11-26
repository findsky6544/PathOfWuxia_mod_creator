using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultPalySoundForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultPalySoundForm()
        {
            InitializeComponent();
        }

        public BattleResultPalySoundForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                SoundPathTextBox.Text = fieldsList[0].Trim();

                VolumeNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SoundPathTextBox.Text))
            {
                MessageBox.Show("请输入音效路径");
                return;
            }
            if (VolumeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入音量大小");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultPalySound\\\" : \\\"" + SoundPathTextBox.Text + "\\\", " + VolumeNumericUpDown.Text;
            lvi.SubItems[1].Text = Text + ": " + SoundPathTextBox.Text/* + ", 音量 " +VolumeNumericUpDown.Text*/;
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
