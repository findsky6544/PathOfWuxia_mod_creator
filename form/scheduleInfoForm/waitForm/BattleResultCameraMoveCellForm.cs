using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultCameraMoveCellForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultCameraMoveCellForm()
        {
            InitializeComponent();
        }

        public BattleResultCameraMoveCellForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                CellNumberTextBox.Text = fieldsList[0];
                XNumericUpDown.Text = fieldsList[1];
                DistanceNumericUpDown.Text = fieldsList[2];
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CellNumberTextBox.Text))
            {
                MessageBox.Show("请选择锁定格子");
                return;
            }
            if (string.IsNullOrEmpty(XNumericUpDown.Text))
            {
                MessageBox.Show("请输入X轴向");
                return;
            }
            if (string.IsNullOrEmpty(DistanceNumericUpDown.Text))
            {
                MessageBox.Show("请输入摄影机距离");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultCameraMoveCell\\\" : \\\"" + CellNumberTextBox.Text + "\\\", " + XNumericUpDown.Text + ", " + DistanceNumericUpDown.Text;
            lvi.SubItems[1].Text = Text + ":" + CellNumberTextBox.Text + ", 旋转至 " + XNumericUpDown.Text + ", 距离 " + DistanceNumericUpDown.Text;
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
            SelectCellForm form = new SelectCellForm(this, CellNumberTextBox, false);
            form.ShowDialog();
        }
    }
}
