using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcTalkIdActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcTalkIdActionForm()
        {
            InitializeComponent();
        }
        public SetNpcTalkIdActionForm(object obj, bool isAdd) : this()
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

                characterBehaviourIdTextBox.Text = fieldsList[0].Trim();
                talkIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (characterBehaviourIdTextBox.Text == "")
            {
                MessageBox.Show("请输入行为编号");
                return;
            }
            if (talkIdTextBox.Text == "")
            {
                MessageBox.Show("请输入对话名称");
                return;
            }

            string tag = "\"SetNpcTalkIdAction\" : " + "\"" + characterBehaviourIdTextBox.Text + "\"" + ", " + "\"" + talkIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterBehaviourRemark(characterBehaviourIdTextBox.Text) + " 的对话编号变为 " + DataManager.getTalkMessage(talkIdTextBox.Text);

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
            SelectCharacterBehaviourForm form = new SelectCharacterBehaviourForm(this, characterBehaviourIdTextBox, false);
            form.ShowDialog();
        }

        private void selectSchedulerButton_Click(object sender, EventArgs e)
        {
            SelectTalkForm form = new SelectTalkForm(this, talkIdTextBox, false, Heluo.Data.TalkType.Message);
            form.ShowDialog();
        }
    }
}
