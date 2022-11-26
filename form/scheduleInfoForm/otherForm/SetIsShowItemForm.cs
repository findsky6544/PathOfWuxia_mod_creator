using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetIsShowItemForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public SetIsShowItemForm()
        {
            InitializeComponent();
        }

        public SetIsShowItemForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                if (fieldsList[0] == "True")
                {
                    IsOpenCheckBox.Checked = true;
                }
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"SetIsShowItem\\\" : " + IsOpenCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ": " + (IsOpenCheckBox.Checked ? "开" : "关");
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
    }
}
