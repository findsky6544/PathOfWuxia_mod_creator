using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultAddDistributionPointForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultAddDistributionPointForm()
        {
            InitializeComponent();
        }

        public BattleResultAddDistributionPointForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                tileNumbersTextBox.Text = fieldsList[0];
                DistributionCountNumericUpDown.Text = fieldsList[1];
                unitIDTextBox.Text = fieldsList[2];

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tileNumbersTextBox.Text))
            {
                MessageBox.Show("请选择布阵点");
                return;
            }
            if (string.IsNullOrEmpty(DistributionCountNumericUpDown.Text))
            {
                MessageBox.Show("请输入可布阵数");
                return;
            }
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择部队");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultAddDistributionPoint\\\" : \\\"" + tileNumbersTextBox.Text + "\\\"," + DistributionCountNumericUpDown.Text + ", \\\"" + unitIDTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = Text + ":" + tileNumbersTextBox.Text + " 可布阵数: " + DistributionCountNumericUpDown.Text + " 排除 " + DataManager.getUnitsName(unitIDTextBox.Text);
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

        private void selectUnitButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIDTextBox, true);
            form.ShowDialog();
        }
    }
}
