using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcChatacterInfoActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcChatacterInfoActionForm()
        {
            InitializeComponent();
        }
        public SetNpcChatacterInfoActionForm(object obj, bool isAdd) : this()
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


                NpcIdTextBox.Text = fieldsList[0].Trim();
                InfoIdTextBox.Text = fieldsList[1].Trim();
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (NpcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }
            if (InfoIdTextBox.Text == "")
            {
                MessageBox.Show("请输入资讯编号");
                return;
            }


            string tag = "\"SetNpcChatacterInfoAction\" : " + "\"" + NpcIdTextBox.Text + "\"" + ", " + "\"" + InfoIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getNpcsName(NpcIdTextBox.Text) + " 角色资讯编号变更为 " + DataManager.getCharacterInfoRemark(InfoIdTextBox.Text);

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
            SelectNpcForm form = new SelectNpcForm(this, NpcIdTextBox, false);
            form.ShowDialog();
        }

        private void selectCharacterInfoButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, InfoIdTextBox, false);
            form.ShowDialog();
        }
    }
}
