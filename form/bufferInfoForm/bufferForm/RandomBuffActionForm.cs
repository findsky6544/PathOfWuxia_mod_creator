using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class RandomBuffActionForm : Form
    {
        public bool isAdd;
        public RandomBuffActionForm()
        {
            InitializeComponent();
        }
        public RandomBuffActionForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                bufferIdTextBox.Text = fieldsList[0];
                randomTimeNumericUpDown.Value = int.Parse(fieldsList[1]);
                minAddTimeNumericUpDown.Value = int.Parse(fieldsList[2]);
                maxAddTimeNumericUpDown.Value = int.Parse(fieldsList[3]);
                if (fieldsList[4] == "True")
                {
                    isRepeatCheckBox.Checked = true;
                }
            }

            this.isAdd = isAdd;
        }

        private void selectBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, bufferIdTextBox, true);
            form.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (bufferIdTextBox.Text == "")
            {
                MessageBox.Show("请至少选择一个buffer");
                return;
            }
            if (randomTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入随机几次");
                return;
            }
            if (minAddTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入最少加几次");
                return;
            }
            if (maxAddTimeNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入最多加几次");
                return;
            }


            BufferInfoForm bufferInfoForm = (BufferInfoForm)Owner;
            TreeView bufferNodeTreeView = bufferInfoForm.getBufferNodeTreeView();

            TreeNode currentNode = bufferNodeTreeView.SelectedNode;

            if (isAdd)
            {
                string tag = currentNode.Tag.ToString();
                while (!tag.Contains("BufferEventNode") && !tag.Contains("BufferPriorityNode") && !tag.Contains("BufferSequenceNode"))
                {
                    currentNode = currentNode.Parent;
                    tag = currentNode.Tag.ToString();
                }

                TreeNode addNode = currentNode.Nodes.Add("");
                bufferNodeTreeView.SelectedNode = addNode;

                currentNode = addNode;
            }

            currentNode.Tag = "\"RandomBuffAction\" : \"" + bufferIdTextBox.Text + "\", " + randomTimeNumericUpDown.Value + ", " + minAddTimeNumericUpDown.Value + ", " + maxAddTimeNumericUpDown.Value + ", " + isRepeatCheckBox.Checked;


            currentNode.Text = "随机增加buff或debuff: " + DataManager.getBuffersName(bufferIdTextBox.Text) + " 中的 " + randomTimeNumericUpDown.Value + " 个,每个增加 " + minAddTimeNumericUpDown.Value + "-" + maxAddTimeNumericUpDown.Value + " 次," + (isRepeatCheckBox.Checked ? "" : "不") + "可重复";
            Close();
        }

        /*public string getBufferName(string bufferid)
        {
            List<ListViewItem> lvis = BufferTabControlUserControl.lvis;

            for (int i = 0; i < lvis.Count; i++)
            {
                if (bufferid == lvis[i].SubItems[1].Text)
                {
                    return lvis[i].SubItems[2].Text;
                }
            }
            return "";
        }*/

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
