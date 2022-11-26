using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleFactorCurrentFactionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleFactorCurrentFactionForm()
        {
            InitializeComponent();
            initFactionComboBox();
        }

        public BattleFactorCurrentFactionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < factionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)factionComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        factionComboBox.SelectedIndex = i;
                        break;
                    }
                }
                if (fieldsList[1] == "True")
                {
                    isReverseCheckBox.Checked = true;
                }

            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        public void initFactionComboBox()
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
            if (factionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择阵营");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleFactorCurrentFaction\\\" : " + ((ComboBoxItem)factionComboBox.SelectedItem).key + ", " + isReverseCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ": " + (isReverseCheckBox.Checked ? "不是" : "是") + " " + factionComboBox.Text;
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
