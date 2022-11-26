using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultRemoveTileUnitForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultRemoveTileUnitForm()
        {
            InitializeComponent();
        }

        public BattleResultRemoveTileUnitForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                cellIndexTextBox.Text = fieldsList[0];
                if (fieldsList[1] == "True")
                {
                    IsDeadCheckBox.Checked = true;
                }

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cellIndexTextBox.Text))
            {
                MessageBox.Show("请选择格子编号");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultRemoveTileUnit\\\" :[" + cellIndexTextBox.Text + "], " + (IsDeadCheckBox.Checked ? "True" : "False");
            lvi.SubItems[1].Text = Text + ":" + "移除 " + cellIndexTextBox.Text + " 上的部队并 " + (IsDeadCheckBox.Checked ? "死亡" : "离开");
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
            SelectCellForm form = new SelectCellForm(this, cellIndexTextBox, true);
            if (!form.IsDisposed)
            {
                form.ShowDialog();
            }
        }
    }
}
