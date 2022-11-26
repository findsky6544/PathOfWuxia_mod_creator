using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleFactorCellFactionForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleFactorCellFactionForm()
        {
            InitializeComponent();
            initFactionComboBox();
        }

        public BattleFactorCellFactionForm(ListViewItem lvi, bool isAdd, Form owner) : this()
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
                cellIndexTextBox.Text = fieldsList[1];

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
            if (string.IsNullOrEmpty(cellIndexTextBox.Text))
            {
                MessageBox.Show("请选择格子编号");
                return;
            }
            if (factionComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择阵营");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleFactorCellFaction\\\" : " + ((ComboBoxItem)factionComboBox.SelectedItem).key + ", \\\"" + cellIndexTextBox.Text + "\\\"";
            lvi.SubItems[1].Text = "判断 " + cellIndexTextBox.Text + " 格子上是否有 " + factionComboBox.Text + ":是";
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
