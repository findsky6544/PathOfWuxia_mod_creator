using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PlayerPathMoveActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public PlayerPathMoveActionForm()
        {
            InitializeComponent();
        }
        public PlayerPathMoveActionForm(object obj, bool isAdd) : this()
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

                pathIdTextBox.Text = fieldsList[0].Trim();
                durationNumericUpDown.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (pathIdTextBox.Text == "")
            {
                MessageBox.Show("请输入路径编号");
                return;
            }
            if (durationNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入持续时间");
                return;
            }

            string tag = "\"PlayerPathMoveAction\" : \"" + pathIdTextBox.Text + "\", " + durationNumericUpDown.Text;
            string text = Text + ":" + "用 " + durationNumericUpDown.Text + " 秒根据路径 " + DataManager.getMovePathDescription(pathIdTextBox.Text) + " 移动";

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

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            SelectMovePathForm selectAdjustmentForm = new SelectMovePathForm(this, pathIdTextBox, false);
            selectAdjustmentForm.ShowDialog();
        }
    }
}
