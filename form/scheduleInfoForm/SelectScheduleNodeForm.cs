using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SelectScheduleNodeForm : Form
    {
        public NumericUpDown textBox;
        public SelectScheduleNodeForm()
        {
            InitializeComponent();
        }
        public SelectScheduleNodeForm(Form owner, NumericUpDown textBox) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            initScheduleListView();
        }

        public void initScheduleListView()
        {
            Form form = Owner;
            while (!(form is ScheduleInfoForm))
            {
                form = form.Owner;
            }

            ScheduleInfoForm form1 = form as ScheduleInfoForm;

            List<ListViewItem> lvis = new List<ListViewItem>();

            for (int i = 0; i < form1.getScheduleListView().Items.Count; i++)
            {
                ListViewItem lvi = form1.getScheduleListView().Items[i];
                if (!lvi.Tag.ToString().Contains("BattleEventNode"))
                {
                    lvis.Add((ListViewItem)lvi.Clone());
                }
            }

            scheduleListView.Items.AddRange(lvis.ToArray());
        }

        private void SelectScheduleNodeForm_Shown(object sender, EventArgs e)
        {
            searchBuffer(textBox.Text, true);
            scheduleListView.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = scheduleListView.SelectedItems[0].Text;
            Close();
        }

        private void scheduleListView_DoubleClick(object sender, EventArgs e)
        {
            textBox.Text = scheduleListView.SelectedItems[0].Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBuffer(searchTextBox.Text, false);
        }

        public void searchBuffer(string bufferId, bool isEqual)
        {
            if (string.IsNullOrEmpty(bufferId))
            {
                return;
            }
            bool isSearched = false;

            if (scheduleListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (scheduleListView.SelectedItems != null && scheduleListView.SelectedItems.Count != 0)
                {
                    startIndex = scheduleListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == scheduleListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = scheduleListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (isEqual)
                        {
                            if (lvi.SubItems[i].Text.ToLower() == bufferId.ToLower())
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                scheduleListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                        else
                        {
                            if (lvi.SubItems[i].Text.ToLower().Contains(bufferId.ToLower()))
                            {
                                lvi.Selected = true;
                                isSearched = true;
                                scheduleListView.EnsureVisible(lvi.Index);
                                break;
                            }
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == scheduleListView.Items.Count)
                    {
                        index = 0;
                    }
                } while (index != startIndex);
            }
            if (!isSearched)
            {
                MessageBox.Show("未找到该数据");
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchBuffer(searchTextBox.Text, false);
            }
        }
    }
}
