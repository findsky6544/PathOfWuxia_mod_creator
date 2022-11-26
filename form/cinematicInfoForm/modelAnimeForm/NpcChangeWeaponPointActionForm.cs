using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NpcChangeWeaponPointActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public NpcChangeWeaponPointActionForm()
        {
            InitializeComponent();
        }
        public NpcChangeWeaponPointActionForm(object obj, bool isAdd) : this()
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

                isHandheldCheckBox.Checked = fieldsList[0].Trim() == "True";
                npcIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }

            string tag = "\"NpcChangeWeaponPointAction\" : " + isHandheldCheckBox.Checked + ", \"" + npcIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getNpcsName(npcIdTextBox.Text) + " " + (isHandheldCheckBox.Checked ? "手持武器" : "佩戴武器");

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
