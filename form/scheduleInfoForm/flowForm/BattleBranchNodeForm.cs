using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleBranchNodeForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleBranchNodeForm()
        {
            InitializeComponent();
            initOpComboBox();
        }

        public BattleBranchNodeForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < opComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)opComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        opComboBox.SelectedIndex = i;
                        break;
                    }
                }

                valueNumericUpDown.Value = int.Parse(fieldsList[1].Trim());
                if (fieldsList[2] == "True")
                {
                    isGlobalCheckBox.Checked = true;
                }
                flagNameTextBox.Text = fieldsList[3].Trim();
                descTextBox.Text = fieldsList[4].Trim();

                nextNumericUpDown.Value = int.Parse(fieldsList[5].Trim());
                prallelNumericUpDown.Value = int.Parse(fieldsList[6].Trim());
            }


            this.isAdd = isAdd;
        }

        public void initOpComboBox()
        {
            opComboBox.DisplayMember = "value";
            opComboBox.ValueMember = "key";
            foreach (Operator temp in Enum.GetValues(typeof(Operator)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                opComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(flagNameTextBox.Text))
            {
                MessageBox.Show("请输入旗标名称");
                return;
            }
            if (opComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择比较方式");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleBranchNode\\\" : " + ((ComboBoxItem)opComboBox.SelectedItem).key + ", " + valueNumericUpDown.Value + ", "
                + isGlobalCheckBox.Checked + ", \\\"" + flagNameTextBox.Text + "\\\", \\\"" + descTextBox.Text + "\\\", "
                + nextNumericUpDown.Text + ", " + prallelNumericUpDown.Text;
            lvi.SubItems[1].Text = Text + ": " + (isGlobalCheckBox.Checked ? "全域旗标" : "战斗旗标") + " " + flagNameTextBox.Text + " "
                + opComboBox.Text + " " + valueNumericUpDown.Value + (descTextBox.Text.Length > 0 ? "(" + descTextBox.Text + ")" : "");
            lvi.SubItems[2].Text = nextNumericUpDown.Text;
            lvi.SubItems[3].Text = prallelNumericUpDown.Text;

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

        private void selectPrallelButton_Click(object sender, EventArgs e)
        {
            SelectScheduleNodeForm form = new SelectScheduleNodeForm(this, prallelNumericUpDown);
            form.ShowDialog();
        }
    }
}
