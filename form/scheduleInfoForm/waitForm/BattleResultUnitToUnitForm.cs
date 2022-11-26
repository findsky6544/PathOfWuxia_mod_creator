using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultUnitToUnitForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultUnitToUnitForm()
        {
            InitializeComponent();
        }

        public BattleResultUnitToUnitForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                move_idTextBox.Text = fieldsList[0];
                target_idTextBox.Text = fieldsList[1];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(move_idTextBox.Text))
            {
                MessageBox.Show("请选择移动部队");
                return;
            }
            if (string.IsNullOrEmpty(target_idTextBox.Text))
            {
                MessageBox.Show("请选择移动目标");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultUnitToUnit\\\" : \\\"" + move_idTextBox.Text + "\\\", \\\"" + target_idTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = Text + ":" + "移动 " + DataManager.getUnitsName(move_idTextBox.Text) + " 至 " + DataManager.getUnitsName(target_idTextBox.Text);
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
            SelectUnitForm form = new SelectUnitForm(this, move_idTextBox, false);
            form.ShowDialog();
        }

        private void selectUnitBIDButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, target_idTextBox, false);
            form.ShowDialog();
        }
    }
}
