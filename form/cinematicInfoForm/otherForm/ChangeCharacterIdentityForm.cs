using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ChangeCharacterIdentityForm : Form
    {
        public bool isAdd;
        public object obj;
        public ChangeCharacterIdentityForm()
        {
            InitializeComponent();

            initTypeComboBox();
        }
        public ChangeCharacterIdentityForm(object obj, bool isAdd) : this()
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


                idTextBox.Text = fieldsList[0].Trim();
                for (int i = 0; i < TypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)TypeComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        TypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public void initTypeComboBox()
        {
            TypeComboBox.DisplayMember = "value";
            TypeComboBox.ValueMember = "key";
            foreach (ChangeCharacterIdentity.Identity temp in Enum.GetValues(typeof(ChangeCharacterIdentity.Identity)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                TypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入Exterior编号");
                return;
            }
            if (TypeComboBox.Text == "")
            {
                MessageBox.Show("请输入转换身份");
                return;
            }

            string tag = "\"ChangeCharacterIdentity\" : " + "\"" + idTextBox.Text + "\"" + ", " + ((ComboBoxItem)TypeComboBox.SelectedItem).key;
            string text = Text + ":" + DataManager.getCharacterExteriorName(idTextBox.Text) + " 的身份变更为 " + TypeComboBox.Text;

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

        private void selectExteriorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
