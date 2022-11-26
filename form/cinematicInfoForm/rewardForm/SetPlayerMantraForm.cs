using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetPlayerMantraForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetPlayerMantraForm()
        {
            InitializeComponent();

            initMethodComboBox();
        }
        public SetPlayerMantraForm(object obj, bool isAdd) : this()
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


                for (int i = 0; i < methodComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)methodComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        methodComboBox.SelectedIndex = i;
                        break;
                    }
                }
                mantraIdTextBox.Text = fieldsList[1].Trim();
            }
        }

        public void initMethodComboBox()
        {
            methodComboBox.DisplayMember = "value";
            methodComboBox.ValueMember = "key";
            foreach (Method temp in Enum.GetValues(typeof(Method)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                methodComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (methodComboBox.Text == "")
            {
                MessageBox.Show("请选择修改方式");
                return;
            }
            if (mantraIdTextBox.Text == "")
            {
                MessageBox.Show("请输入心法编号");
                return;
            }

            string tag = "\"SetPlayerMantra\" : " + ((ComboBoxItem)methodComboBox.SelectedItem).key + ", " + "\"" + mantraIdTextBox.Text + "\"";
            string method = ((ComboBoxItem)methodComboBox.SelectedItem).key;
            string methodStr = "";
            if (method == ((int)Method.Assign).ToString() || method == ((int)Method.Add).ToString())
            {
                methodStr = "增加";
            }
            else if (method == ((int)Method.Sub).ToString() || method == ((int)Method.Clear).ToString())
            {
                methodStr = "删除";
            }
            else
            {
                methodStr = "错误操作";
            }
            string text = Text + ":" + methodStr + DataManager.getMantraName(mantraIdTextBox.Text);

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
        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, mantraIdTextBox, false);
            form.ShowDialog();
        }
    }
}
