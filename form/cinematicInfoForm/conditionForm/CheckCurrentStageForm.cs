using Heluo.Manager;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class CheckCurrentStageForm : Form
    {
        public bool isAdd;
        public TreeNode currentNode;
        public CheckCurrentStageForm()
        {
            InitializeComponent();

            initStageComboBox();
        }
        public CheckCurrentStageForm(TreeNode currentNode, bool isAdd) : this()
        {

            this.currentNode = currentNode;

            string fields = currentNode.Tag.ToString().Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                for (int i = 0; i < stageComboBox.Items.Count; i++)
                {
                    if (((ComboBoxItem)stageComboBox.Items[i]).key == fieldsList[0].Trim())
                    {
                        stageComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.isAdd = isAdd;
        }

        public void initStageComboBox()
        {
            stageComboBox.DisplayMember = "value";
            stageComboBox.ValueMember = "key";
            foreach (TimeStage temp in Enum.GetValues(typeof(TimeStage)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                stageComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (stageComboBox.Text == "")
            {
                MessageBox.Show("请选择时间");
                return;
            }

            currentNode.Tag = "\"CheckCurrentStage\" : " + ((ComboBoxItem)stageComboBox.SelectedItem).key;
            currentNode.Text = Text + ":" + "符合 " + stageComboBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
