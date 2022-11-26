using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetGlobalFlagBattleActionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public SetGlobalFlagBattleActionForm()
        {
            InitializeComponent();
            initOpComboBox();
        }

        public SetGlobalFlagBattleActionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                flagNameTextBox.Text = fieldsList[0].Trim();
                for (int i = 0; i < methodComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)methodComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        methodComboBox.SelectedIndex = i;
                        break;
                    }
                }

                valueNumericUpDown.Value = int.Parse(fieldsList[2].Trim());
                descTextBox.Text = fieldsList[3].Trim();
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        public void initOpComboBox()
        {
            methodComboBox.DisplayMember = "value";
            methodComboBox.ValueMember = "key";
            foreach (Method temp in Enum.GetValues(typeof(Method)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                methodComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(flagNameTextBox.Text))
            {
                MessageBox.Show("请输入旗标名称");
                return;
            }
            if (methodComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择动作");
                return;
            }
            if (valueNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入值");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"SetGlobalFlagBattleAction\\\" : \\\"" + flagNameTextBox.Text + "\\\", " + ((ComboBoxItem)methodComboBox.SelectedItem).key
                + ", " + valueNumericUpDown.Value + ", \\\"" + descTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = Text + ": " + flagNameTextBox.Text + " "
                + methodComboBox.Text + " " + valueNumericUpDown.Value + (descTextBox.Text.Length > 0 ? "(" + descTextBox.Text + ")" : "");
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
