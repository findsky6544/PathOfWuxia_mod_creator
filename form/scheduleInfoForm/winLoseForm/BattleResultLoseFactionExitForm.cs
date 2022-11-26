using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultLoseFactionExitForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultLoseFactionExitForm()
        {
            InitializeComponent();
            initAitypeComboBox();
        }
        public BattleResultLoseFactionExitForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                WinLoseIDTextBox.Text = fieldsList[0];
                for (int i = 0; i < factionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)factionComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        factionComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);

            this.isAdd = isAdd;
        }

        public void initAitypeComboBox()
        {
            factionComboBox.DisplayMember = "value";
            factionComboBox.ValueMember = "key";
            foreach (Faction temp in Enum.GetValues(typeof(Faction)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                factionComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(factionComboBox.Text))
            {
                MessageBox.Show("请选择阵营");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultLoseFactionExit\\\" : \\\"" + WinLoseIDTextBox.Text + "\\\", " + ((ComboBoxItem)factionComboBox.SelectedItem).key;
            lvi.SubItems[1].Text = Text + ":" + (WinLoseIDTextBox.Text == "" ? "" : "id:" + WinLoseIDTextBox.Text) + " " + factionComboBox.Text + " 到达目标点";
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
