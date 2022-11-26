using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultAddUnitForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultAddUnitForm()
        {
            InitializeComponent();
            initFactionComboBox();
        }

        public BattleResultAddUnitForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                unitIDTextBox.Text = fieldsList[0];
                for (int i = 0; i < factionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)factionComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        factionComboBox.SelectedIndex = i;
                        break;
                    }
                }
                cellIndexTextBox.Text = fieldsList[2];
                magnificationNumericUpDown.Value = decimal.Parse(fieldsList[3]);
                angleNumericUpDown.Value = decimal.Parse(fieldsList[4]);

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
            if (string.IsNullOrEmpty(unitIDTextBox.Text))
            {
                MessageBox.Show("请选择部队");
                return;
            }
            if (string.IsNullOrEmpty(factionComboBox.Text))
            {
                MessageBox.Show("请选择阵营");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultAddUnit\\\" : \\\"" + unitIDTextBox.Text + "\\\", " + ((ComboBoxItem)factionComboBox.SelectedItem).key + ", " + cellIndexTextBox.Text + ", " + magnificationNumericUpDown.Value + ", " + angleNumericUpDown.Value;
            lvi.SubItems[1].Text = Text + ":" + "  加入 " + factionComboBox.Text + " " + DataManager.getUnitsName(unitIDTextBox.Text) + " 至 " + cellIndexTextBox.Text + " 放大倍率: " + magnificationNumericUpDown.Value + " 面向角度: " + angleNumericUpDown.Value;
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
            SelectCellForm form = new SelectCellForm(this, cellIndexTextBox, false);
            if (!form.IsDisposed)
            {
                form.ShowDialog();
            }
        }

        private void selectUnitButton_Click(object sender, EventArgs e)
        {
            SelectUnitForm form = new SelectUnitForm(this, unitIDTextBox, false);
            form.ShowDialog();
        }
    }
}
