using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class TalkActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public TalkActionForm()
        {
            InitializeComponent();
        }
        public TalkActionForm(object obj, bool isAdd) : this()
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


                talkIdTextBox.Text = fieldsList[0].Trim();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (talkIdTextBox.Text == "")
            {
                MessageBox.Show("请输入对话编号");
                return;
            }

            string tag = "\"TalkAction\" : " + "\"" + talkIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getTalkMessage(talkIdTextBox.Text);

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

        private void selectQuestButton_Click(object sender, EventArgs e)
        {
            SelectTalkForm form = new SelectTalkForm(this, talkIdTextBox, false, Heluo.Data.TalkType.Message);
            form.ShowDialog();
        }
    }
}
