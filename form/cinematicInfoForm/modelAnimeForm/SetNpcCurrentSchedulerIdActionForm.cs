using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcCurrentSchedulerIdActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcCurrentSchedulerIdActionForm()
        {
            InitializeComponent();
        }
        public SetNpcCurrentSchedulerIdActionForm(object obj, bool isAdd) : this()
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

                npcIdTextBox.Text = fieldsList[0].Trim();
                schedulerIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入Npc编号");
                return;
            }
            if (schedulerIdTextBox.Text == "")
            {
                MessageBox.Show("请输入排程名称");
                return;
            }

            string tag = "\"SetNpcCurrentSchedulerIdAction\" : " + "\"" + npcIdTextBox.Text + "\"" + ", " + "\"" + schedulerIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getNpcsName(npcIdTextBox.Text) + " 的排程编号变为 " + DataManager.getConfigScheduleName(schedulerIdTextBox.Text);

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

        private void selectSchedulerButton_Click(object sender, EventArgs e)
        {
            SelectConfigScheduleForm form = new SelectConfigScheduleForm(this, schedulerIdTextBox, false);
            form.ShowDialog();
        }
    }
}
