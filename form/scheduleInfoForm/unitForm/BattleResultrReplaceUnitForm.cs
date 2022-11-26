using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultrReplaceUnitForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultrReplaceUnitForm()
        {
            InitializeComponent();
        }

        public BattleResultrReplaceUnitForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitIDTextBox.Text = fieldsList[0];
                addIDTextBox.Text = fieldsList[1];
                magnificationNumericUpDown.Value = decimal.Parse(fieldsList[2]);
                angleNumericUpDown.Value = decimal.Parse(fieldsList[3]);

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择取代的部队");
                return;
            }
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择加入的部队");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultrReplaceUnit\\\" : \\\"" + unitIDTextBox.Text + "\\\", \\\"" + addIDTextBox.Text + "\\\", " + magnificationNumericUpDown.Value + ", " + angleNumericUpDown.Value;
            lvi.SubItems[1].Text = Text + ":" + DataManager.getUnitsName(addIDTextBox.Text) + " 取代 " + DataManager.getUnitsName(unitIDTextBox.Text) + " 放大倍率: " + magnificationNumericUpDown.Value + " 面向角度: " + angleNumericUpDown.Value;
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

        private void selectAddUnitButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, addIDTextBox, false);
            form.ShowDialog();
        }
    }
}
