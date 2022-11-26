﻿using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckFavorabilityIsLoverForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckFavorabilityIsLoverForm()
        {
            InitializeComponent();
        }
        public CheckFavorabilityIsLoverForm(TreeNode currentNode, bool isAdd) : this()
        {
            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                npcIdTextBox.Text = fieldsList[2].Trim();
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }

            currentNode.Tag = "\"CheckFavorabilityIsLover\" : 0, 1, \"" + npcIdTextBox.Text + "\"";
            currentNode.Text = DataManager.getNpcsName(npcIdTextBox.Text) + " 是恋人";

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