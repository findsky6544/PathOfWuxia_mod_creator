using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultWalkableForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultWalkableForm()
        {
            InitializeComponent();
        }

        public BattleResultWalkableForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                tileNumbersTextBox.Text = fieldsList[0];
                if (fieldsList[1] == "True")
                {
                    WalkableCheckBox.Checked = true;
                }
                else
                {
                    WalkableCheckBox.Checked = false;
                }

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tileNumbersTextBox.Text))
            {
                MessageBox.Show("请选择宝藏点");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultWalkable\\\" : \\\"" + tileNumbersTextBox.Text + "\\\", " + WalkableCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ":" + tileNumbersTextBox.Text + " 为 " + (WalkableCheckBox.Checked ? "" : "不") + "可行走";
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
            SelectCellForm form = new SelectCellForm(this, tileNumbersTextBox, true);
            if (!form.IsDisposed)
            {
                form.ShowDialog();
            }
        }
    }
}
