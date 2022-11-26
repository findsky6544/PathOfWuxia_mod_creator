using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ReplaceNPCTraitForm : Form
    {
        public bool isAdd;
        public object obj;
        public ReplaceNPCTraitForm()
        {
            InitializeComponent();
        }
        public ReplaceNPCTraitForm(object obj, bool isAdd) : this()
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
                MessageBox.Show("请输入旧的特质编号");
                return;
            }
            if (NewIDTextBox.Text == "")
            {
                MessageBox.Show("请输入新的特质编号");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC的character编号");
                return;
            }

            string tag = "\"ReplaceNPCTrait\" : " + "\"" + OldIDTextBox.Text + "\"" + ", " + "\"" + NewIDTextBox.Text + "\"" + ", " + "\"" + npcIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterInfoRemark(npcIdTextBox.Text) + " 的 " + DataManager.getTraitName(OldIDTextBox.Text) + " 取代成 " + DataManager.getTraitName(NewIDTextBox.Text);

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

        private void selectNewTraitButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, NewIDTextBox, false);
            form.ShowDialog();
        }

        private void selectOldTraitButton_Click(object sender, EventArgs e)
        {
            SelectTraitForm form = new SelectTraitForm(this, OldIDTextBox, false);
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
