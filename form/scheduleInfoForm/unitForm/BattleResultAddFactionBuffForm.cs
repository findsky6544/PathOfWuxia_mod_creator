using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultAddFactionBuffForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultAddFactionBuffForm()
        {
            InitializeComponent();
            initFactionComboBox();
        }

        public BattleResultAddFactionBuffForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                if (fieldsList[0] == "True")
                {
                    showEffectCheckBox.Checked = true;
                }
                for (int i = 0; i < factionComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)factionComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        factionComboBox.SelectedIndex = i;
                        break;
                    }
                }
                buffIdTextBox.Text = fieldsList[2];
                if (fieldsList[3] == "True")
                {
                    isBufferCheckBox.Checked = true;
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
            if (string.IsNullOrEmpty(factionComboBox.Text))
            {
                MessageBox.Show("请选择阵营");
                return;
            }
            if (string.IsNullOrEmpty(buffIdTextBox.Text))
            {
                MessageBox.Show("请选择增益");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultAddFactionBuff\\\" : " + showEffectCheckBox.Checked + ", " + ((ComboBoxItem)factionComboBox.SelectedItem).key + ", \\\"" + buffIdTextBox.Text + "\\\"," + isBufferCheckBox.Checked;
            lvi.SubItems[1].Text = Text + ":" + factionComboBox.Text + " 加入 " + (isBufferCheckBox.Checked ? "增益" : "减益") + " " + DataManager.getBuffersName(buffIdTextBox.Text) + " " + (showEffectCheckBox.Checked ? "" : "不") + "显示特效";
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

        private void selectUnitBIDButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, buffIdTextBox, false);
            form.ShowDialog();
        }
    }
}
