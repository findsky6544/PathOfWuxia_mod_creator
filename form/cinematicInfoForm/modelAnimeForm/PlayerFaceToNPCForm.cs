using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PlayerFaceToNPCForm : Form
    {
        public bool isAdd;
        public object obj;
        public PlayerFaceToNPCForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public PlayerFaceToNPCForm(object obj, bool isAdd) : this()
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

                faceidTextBox.Text = fieldsList[0].Trim();
                for (int i = 0; i < typeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)typeComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        typeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public void initTypeComboBox()
        {
            typeComboBox.DisplayMember = "value";
            typeComboBox.ValueMember = "key";
            foreach (PlayerFaceToNPC.FaceType temp in Enum.GetValues(typeof(PlayerFaceToNPC.FaceType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                typeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (faceidTextBox.Text == "")
            {
                MessageBox.Show("请输入面对的NPC编号");
                return;
            }
            if (typeComboBox.Text == "")
            {
                MessageBox.Show("请选择面对类型");
                return;
            }

            string tag = "\"PlayerFaceToNPC\" : " + "\"" + faceidTextBox.Text + "\"" + ", " + ((ComboBoxItem)typeComboBox.SelectedItem).key;
            string text = Text + ":" + " Player " + typeComboBox.Text + " " + DataManager.getNpcsName(faceidTextBox.Text);

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
            SelectNpcForm form = new SelectNpcForm(this, faceidTextBox, false);
            form.ShowDialog();
        }
    }
}
