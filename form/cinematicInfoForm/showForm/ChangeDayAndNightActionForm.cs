using Heluo.Data;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ChangeDayAndNightActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public ChangeDayAndNightActionForm()
        {
            InitializeComponent();

            initTimeTypeComboBox();
        }
        public ChangeDayAndNightActionForm(object obj, bool isAdd) : this()
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

                for (int i = 0; i < timeTypeComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)timeTypeComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        timeTypeComboBox.SelectedIndex = i;
                        break;
                    }
                }
                IsRealCheckBox.Checked = fieldsList[1] == "True";
            }
        }

        public void initTimeTypeComboBox()
        {
            timeTypeComboBox.DisplayMember = "value";
            timeTypeComboBox.ValueMember = "key";
            foreach (TimeType temp in Enum.GetValues(typeof(TimeType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                timeTypeComboBox.Items.Add(cbi);
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (timeTypeComboBox.Text == "")
            {
                MessageBox.Show("请输入切换到哪个（日、夜）");
                return;
            }

            string tag = "\"ChangeDayAndNightAction\" : " + ((ComboBoxItem)timeTypeComboBox.SelectedItem).key + ", " + IsRealCheckBox.Checked;
            string text = Text + ":" + "切换到 " + timeTypeComboBox.Text + "(" + (IsRealCheckBox.Checked ? "确实切换" : "仅环境") + ")";

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
