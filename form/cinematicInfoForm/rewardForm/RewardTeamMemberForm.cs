using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RewardTeamMemberForm : Form
    {
        public bool isAdd;
        public object obj;
        public RewardTeamMemberForm()
        {
            InitializeComponent();

            initMethodComboBox();
        }
        public RewardTeamMemberForm(object obj, bool isAdd) : this()
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
                memberidTextBox.Text = fieldsList[1].Trim();
                isNeedCheckBox.Checked = fieldsList[2].Trim() == "True";
            }

            this.isAdd = isAdd;
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
            if (memberidTextBox.Text == "")
            {
                MessageBox.Show("请输入队友编号");
                return;
            }

            string tag = "\"RewardTeamMember\" : " + ((ComboBoxItem)methodComboBox.SelectedItem).key + ", " + "\"" + memberidTextBox.Text + "\"" + ", " + isNeedCheckBox.Checked;
            string methodStr = "";
            if ((Method)Enum.Parse(typeof(Method), ((ComboBoxItem)methodComboBox.SelectedItem).key) > Method.Add)
            {
                if ((Method)Enum.Parse(typeof(Method), ((ComboBoxItem)methodComboBox.SelectedItem).key) - Method.Sub <= 1)
                {
                    methodStr = "退出队伍";
                }
                else
                {
                    methodStr = "修改方式错误";
                }

            }
            else
            {
                methodStr = "加入队伍";
            }
            string text = Text + ":" + DataManager.getNpcsName(memberidTextBox.Text) + " " + methodStr + (isNeedCheckBox.Checked ? " 必带" : "");


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
            SelectNpcForm form = new SelectNpcForm(this, memberidTextBox, false);
            form.ShowDialog();
        }
    }
}
