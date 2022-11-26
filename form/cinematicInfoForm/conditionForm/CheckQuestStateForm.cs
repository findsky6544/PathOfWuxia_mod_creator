using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckQuestStateForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckQuestStateForm()
        {
            InitializeComponent();

            initStateComboBox();
        }
        public CheckQuestStateForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;
            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < stateComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)stateComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        stateComboBox.SelectedIndex = i;
                        break;
                    }
                }
                idTextBox.Text = fieldsList[1].Trim();
            }

            this.isAdd = isAdd;
        }

        public void initStateComboBox()
        {
            stateComboBox.DisplayMember = "value";
            stateComboBox.ValueMember = "key";
            foreach (CheckQuestState.QuestState temp in Enum.GetValues(typeof(CheckQuestState.QuestState)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                stateComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入任务编号");
                return;
            }
            if (stateComboBox.Text == "")
            {
                MessageBox.Show("请选择任务状态");
                return;
            }

            currentNode.Tag = "\"CheckQuestState\" : " + ((ComboBoxItem)stateComboBox.SelectedItem).key + ", \"" + idTextBox.Text + "\"";
            currentNode.Text = Text + ":" + DataManager.getQuestName(idTextBox.Text) + " 的状态为 " + stateComboBox.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectQuestButton_Click(object sender, EventArgs e)
        {
            SelectQuestForm form = new SelectQuestForm(this, idTextBox, false);
            form.ShowDialog();
        }
    }
}
