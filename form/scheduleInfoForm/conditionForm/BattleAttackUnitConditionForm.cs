using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleAttackUnitConditionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleAttackUnitConditionForm()
        {
            InitializeComponent();
        }

        public BattleAttackUnitConditionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitAIDTextBox.Text = fieldsList[0];
                unitBIDTextBox.Text = fieldsList[1];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unitAIDTextBox.Text))
            {
                MessageBox.Show("请选择部队A");
                return;
            }
            if (string.IsNullOrEmpty(unitBIDTextBox.Text))
            {
                MessageBox.Show("请选择部队B");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleAttackUnitCondition\\\" : \\\"" + unitAIDTextBox.Text + "\\\", \\\"" + unitBIDTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = "判断 " + DataManager.getUnitsName(unitAIDTextBox.Text) + " 是否攻击 " + DataManager.getUnitsName(unitBIDTextBox.Text) + ":是";
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
            SelectUnitForm form = new SelectUnitForm(this, unitAIDTextBox, false);
            form.ShowDialog();
        }

        private void selectUnitBIDButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitBIDTextBox, false);
            form.ShowDialog();
        }
    }
}
