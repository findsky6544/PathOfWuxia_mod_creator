using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ReplaceNPCMantraForm : Form
    {
        public bool isAdd;
        public object obj;
        public ReplaceNPCMantraForm()
        {
            InitializeComponent();
        }
        public ReplaceNPCMantraForm(object obj, bool isAdd) : this()
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
                OldIDTextBox.Text = fieldsList[0].Trim();
                NewIDTextBox.Text = fieldsList[1].Trim();
                npcIdTextBox.Text = fieldsList[2].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (OldIDTextBox.Text == "")
            {
                MessageBox.Show("请输入旧的心法编号");
                return;
            }
            if (NewIDTextBox.Text == "")
            {
                MessageBox.Show("请输入新的心法编号");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC的character编号");
                return;
            }


            string tag = "\"ReplaceNPCMantra\" : " + "\"" + OldIDTextBox.Text + "\"" + ", " + "\"" + NewIDTextBox.Text + "\"" + ", " + "\"" + npcIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterInfoRemark(npcIdTextBox.Text) + " 的 " + DataManager.getMantraName(OldIDTextBox.Text) + " 取代成 " + DataManager.getMantraName(NewIDTextBox.Text);

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

        private void selectNewMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, NewIDTextBox, false);
            form.ShowDialog();
        }

        private void selectOldMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, OldIDTextBox, false);
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
