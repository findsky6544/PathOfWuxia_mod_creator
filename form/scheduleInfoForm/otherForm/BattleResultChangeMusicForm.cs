using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultChangeMusicForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultChangeMusicForm()
        {
            InitializeComponent();
        }

        public BattleResultChangeMusicForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                MusicNameTextBox.Text = fieldsList[0].Trim();

                FadeTimeNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
                if (fieldsList[2] == "True")
                {
                    ContinuousCheckBox.Checked = true;
                }
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MusicNameTextBox.Text))
            {
                MessageBox.Show("请输入音乐名称");
                return;
            }
            if (FadeTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入转换时间");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultChangeMusic\\\" : \\\"" + MusicNameTextBox.Text + "\\\", " + FadeTimeNumericUpDown.Text + ", " + ContinuousCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ": " + MusicNameTextBox.Text + ", 淡出时间 " + FadeTimeNumericUpDown.Text + " 秒, " + (ContinuousCheckBox.Checked ? "" : "不") + "连续";
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
