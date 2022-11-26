using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SetNpcSkillEXPForm : Form
    {
        public bool isAdd;
        public object obj;
        public SetNpcSkillEXPForm()
        {
            InitializeComponent();

            initMethodComboBox();
        }
        public SetNpcSkillEXPForm(object obj, bool isAdd) : this()
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
                valueNumericUpDown.Text = fieldsList[1].Trim();
                SkillIdTextBox.Text = fieldsList[2].Trim();
                npcIdTextBox.Text = fieldsList[3].Trim();
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
            if (valueNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入值");
                return;
            }
            if (SkillIdTextBox.Text == "")
            {
                MessageBox.Show("请输入技能编号");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC的character编号");
                return;
            }

            string tag = "\"SetNpcSkillEXP\" : " + ((ComboBoxItem)methodComboBox.SelectedItem).key + ", " + valueNumericUpDown.Text + ", " + "\"" + SkillIdTextBox.Text + "\"" + ", " + "\"" + npcIdTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterInfoRemark(npcIdTextBox.Text) + " 的 " + DataManager.getSkillsName(SkillIdTextBox.Text) + " 的经验" + " " + methodComboBox.Text + (((ComboBoxItem)methodComboBox.SelectedItem).key == ((int)Method.Clear).ToString() ? "" : (" " + valueNumericUpDown.Text));

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

        private void selectSkillButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, SkillIdTextBox, false, SelectSkillForm.selectSkillType.normal);
            form.ShowDialog();
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
