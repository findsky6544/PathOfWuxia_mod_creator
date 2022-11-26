using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcCurrentBehaviourClickTypeForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcCurrentBehaviourClickTypeForm()
        {
            InitializeComponent();

            initClickTypeComboBox();
        }
        public SetNpcCurrentBehaviourClickTypeForm(object obj, bool isAdd) : this()
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
                for (int i = 0; i < ClickTypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)ClickTypeComboBox.Items[i]).key == fieldsList[1].Trim())
                    {
                        ClickTypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        public void initClickTypeComboBox()
        {
            ClickTypeComboBox.DisplayMember = "value";
            ClickTypeComboBox.ValueMember = "key";
            foreach (ClickType temp in Enum.GetValues(typeof(ClickType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ClickTypeComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (characterBehaviourIdTextBox.Text == "")
            {
                MessageBox.Show("请输入行为编号");
                return;
            }
            if (ClickTypeComboBox.Text == "")
            {
                MessageBox.Show("请输入互动名称");
                return;
            }

            string tag = "\"SetNpcCurrentBehaviourClickType\" : " + "\"" + characterBehaviourIdTextBox.Text + "\"" + ", " + ((ComboBoxItem)ClickTypeComboBox.SelectedItem).key;
            string text = Text + ":" + DataManager.getCharacterBehaviourRemark(characterBehaviourIdTextBox.Text) + " 的行為互動類型变为 " + ClickTypeComboBox.Text;

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
    }
}
