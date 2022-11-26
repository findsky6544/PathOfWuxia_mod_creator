﻿using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NpcArcMoveActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public NpcArcMoveActionForm()
        {
            InitializeComponent();
        }
        public NpcArcMoveActionForm(object obj, bool isAdd) : this()
        {
            this.obj = obj;
            this.isAdd = isAdd;

            string fields = "";
            if (obj is ListViewItem)
            {
                fields = (obj as ListViewItem).Tag.ToString().Split(':')[1];
            }
            else
            {
                fields = (obj as TreeNode).Tag.ToString().Split(':')[1];
            }
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                locationTextBox.Text = "{" + fieldsList[0].Trim() + ", " + fieldsList[1].Trim() + ", " + fieldsList[2].Trim() + "}";
                relayPointTextBox.Text = "{" + fieldsList[3].Trim() + ", " + fieldsList[4].Trim() + ", " + fieldsList[5].Trim() + "}";
                durationNumericUpDown.Text = fieldsList[6].Trim();
                npcIdTextBox.Text = fieldsList[7].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (locationTextBox.Text == "")
            {
                MessageBox.Show("请输入目的地");
                return;
            }
            if (relayPointTextBox.Text == "")
            {
                MessageBox.Show("请输入中继点");
                return;
            }
            if (durationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入持续时间");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }


            string tag = "\"NpcArcMoveAction\" : " + locationTextBox.Text + ", " + relayPointTextBox.Text + ", " + durationNumericUpDown.Text + ", \"" + npcIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getNpcsName(npcIdTextBox.Text) + " " + "用 " + durationNumericUpDown.Text + " 秒通过 " + relayPointTextBox.Text + " 到达 " + locationTextBox.Text;


            if (obj is ListViewItem)
            {
                ListViewItem lvi = obj as ListViewItem;
                lvi.Tag = tag;
                lvi.SubItems[1].Text = text;
            }
            else
            {
                TreeNode node = obj as TreeNode;
                node.Tag = tag;
                node.Text = text;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
