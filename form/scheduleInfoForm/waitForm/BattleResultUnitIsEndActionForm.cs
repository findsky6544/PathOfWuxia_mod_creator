using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultUnitIsEndActionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultUnitIsEndActionForm()
        {
            InitializeComponent();
        }

        public BattleResultUnitIsEndActionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitIDTextBox.Text = fieldsList[0];
                if (fieldsList[1] == "True")
                {
                    IsEndActionCheckBox.Checked = true;
                }
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

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultUnitIsEndAction\\\" : \\\"" + unitIDTextBox.Text + "\\\", " + IsEndActionCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ":" + DataManager.getUnitsName(unitIDTextBox.Text) + " " + (IsEndActionCheckBox.Checked ? "行动完毕" : "开始行动");
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
            SelectUnitForm form = new SelectUnitForm(this, unitIDTextBox, false);
            form.ShowDialog();
        }
    }
}
