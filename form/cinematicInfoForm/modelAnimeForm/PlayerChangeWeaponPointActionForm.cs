using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PlayerChangeWeaponPointActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public PlayerChangeWeaponPointActionForm()
        {
            InitializeComponent();
        }
        public PlayerChangeWeaponPointActionForm(object obj, bool isAdd) : this()
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
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            string tag = "\"PlayerChangeWeaponPointAction\" : " + isHandheldCheckBox.Checked;
            string text = Text + ":" + (isHandheldCheckBox.Checked ? "手持武器" : "佩戴武器");

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
