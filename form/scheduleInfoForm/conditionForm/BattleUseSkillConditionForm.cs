using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleUseSkillConditionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleUseSkillConditionForm()
        {
            InitializeComponent();
        }

        public BattleUseSkillConditionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitIDTextBox.Text = fieldsList[0];
                SkillIdTextBox.Text = fieldsList[1];

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SkillIdTextBox.Text))
            {
                MessageBox.Show("请选择技能");
                return;
            }
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择部队");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleUseSkillCondition\\\" : \\\"" + unitIDTextBox.Text + "\\\", \\\"" + SkillIdTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = "判断 " + DataManager.getUnitsName(unitIDTextBox.Text) + " 是否使用技能 " + DataManager.getSkillsName(SkillIdTextBox.Text) + " : 是";
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

        private void selectCellButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, SkillIdTextBox, false, SelectSkillForm.selectSkillType.normal);
            if (!form.IsDisposed)
            {
                form.ShowDialog();
            }
        }

        private void selectUnitButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIDTextBox, false);
            form.ShowDialog();
        }
    }
}
