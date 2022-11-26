﻿using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class BattleResultFadeOutMusicForm : Form
    {
        public bool isAdd;
        ListViewItem lvi = null;
        public BattleResultFadeOutMusicForm()
        {
            InitializeComponent();
        }

        public BattleResultFadeOutMusicForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;
            this.lvi = lvi;

            string fields = lvi.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);


                FadeTimeNumericUpDown.Value = int.Parse(fieldsList[0].Trim());
            }

            nextNumericUpDown.Value = int.Parse(lvi.SubItems[2].Text);


            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (FadeTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入淡出时间");
                return;
            }

            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)Owner;
            ListView scheduleListView = scheduleInfoForm.getScheduleListView();
            lvi.Tag = "\\\"BattleResultFadeOutMusic\\\" : " + FadeTimeNumericUpDown.Text;
            lvi.SubItems[1].Text = Text + ": " + "淡出时间 " + FadeTimeNumericUpDown.Text + " 秒";
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
