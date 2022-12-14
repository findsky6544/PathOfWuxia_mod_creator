using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultPlayActionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultPlayActionForm()
        {
            InitializeComponent();
        }

        public BattleResultPlayActionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                unitIDTextBox.Text = fieldsList[0].Trim();
                animationIDTextBox.Text = fieldsList[1].Trim();
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择部队");
                return;
            }
            if (string.IsNullOrEmpty(animationIDTextBox.Text))
            {
                MessageBox.Show("请输入动画ID");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultPlayAction\\\" : " + " \\\"" + unitIDTextBox.Text + "\\\", \\\"" + animationIDTextBox.Text + "\\\", 0.00000";
            lvi.SubItems[1].Text = Text + ": " + DataManager.getUnitsName(unitIDTextBox.Text) + " 播放动画 " + animationIDTextBox.Text;
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
            SelectUnitForm form = new SelectUnitForm(this, unitIDTextBox, false);
            form.ShowDialog();
        }
    }
}
