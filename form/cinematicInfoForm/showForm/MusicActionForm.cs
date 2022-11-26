using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class MusicActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public MusicActionForm()
        {
            InitializeComponent();
        }
        public MusicActionForm(object obj, bool isAdd) : this()
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


                MusicNameTextBox.Text = fieldsList[0].Trim();
                FadeTimeNumericUpDown.Text = fieldsList[1].Trim();
                ContinuousCheckBox.Checked = fieldsList[2] == "True";
                VolumeNumericUpDown.Text = fieldsList[3].Trim();
                IsStopCheckBox.Checked = fieldsList[4] == "True";
                FadeOutTimeNumericUpDown.Text = fieldsList[5].Trim();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (MusicNameTextBox.Text == "")
            {
                MessageBox.Show("请输入音乐名");
                return;
            }
            if (FadeTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入转换时间");
                return;
            }
            if (VolumeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入音量大小");
                return;
            }
            if (FadeOutTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入停止转换时间");
                return;
            }

            string tag = "\"MusicAction\" : " + "\"" + MusicNameTextBox.Text + "\"" + ", " + FadeTimeNumericUpDown.Text + ", " + ContinuousCheckBox.Checked + ", " + VolumeNumericUpDown.Text + ", " + IsStopCheckBox.Checked + ", " + FadeOutTimeNumericUpDown.Text;
            string text = Text + ":" + (IsStopCheckBox.Checked ? "停止" : "播放 " + MusicNameTextBox.Text) + " " + (IsStopCheckBox.Checked ? "淡出" : "切换") + "时间:" + (IsStopCheckBox.Checked ? FadeOutTimeNumericUpDown.Text : FadeTimeNumericUpDown.Text) + " 秒" + (IsStopCheckBox.Checked ? "" : " 音量大小:" + VolumeNumericUpDown.Text + " " + (ContinuousCheckBox.Checked ? "" : "不") + "连续");

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
    }
}
