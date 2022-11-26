using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class AttackerElementAddBuffForm : Form
    {
        public bool isAdd;
        public AttackerElementAddBuffForm()
        {
            InitializeComponent();
        }
        public AttackerElementAddBuffForm(string tag, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = tag.Split(':')[1];
            if (!string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                noneIdTextBox.Text = fieldsList[0];
                metalIdTextBox.Text = fieldsList[1];
                woodIdTextBox.Text = fieldsList[2];
                waterIdTextBox.Text = fieldsList[3];
                fireIdTextBox.Text = fieldsList[4];
                earthIdTextBox.Text = fieldsList[5];
            }

            this.isAdd = isAdd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
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

            currentNode.Tag = "\"AttackerElementAddBuff\" : "
                + "\"" + noneIdTextBox.Text + "\", "
                + "\"" + metalIdTextBox.Text + "\", "
                + "\"" + woodIdTextBox.Text + "\", "
                + "\"" + waterIdTextBox.Text + "\", "
                + "\"" + fireIdTextBox.Text + "\", "
                + "\"" + earthIdTextBox.Text + "\"";
            currentNode.Text = "依攻击者属性加入Buff: "
                + "无:" + DataManager.getBuffersName(noneIdTextBox.Text) + ";"
                + "金:" + DataManager.getBuffersName(metalIdTextBox.Text) + ";"
                + "木:" + DataManager.getBuffersName(woodIdTextBox.Text) + ";"
                + "水:" + DataManager.getBuffersName(waterIdTextBox.Text) + ";"
                + "火:" + DataManager.getBuffersName(fireIdTextBox.Text) + ";"
                + "土:" + DataManager.getBuffersName(earthIdTextBox.Text) + ";";
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectNoneBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, noneIdTextBox, false);
            form.ShowDialog();
        }

        private void selectMetalBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, metalIdTextBox, false);
            form.ShowDialog();
        }

        private void selectWoodBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, woodIdTextBox, false);
            form.ShowDialog();
        }

        private void selectWaterBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, waterIdTextBox, false);
            form.ShowDialog();
        }

        private void selectFireBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, fireIdTextBox, false);
            form.ShowDialog();
        }

        private void selectEarthBufferButton_Click(object sender, EventArgs e)
        {
            SelectBufferForm form = new SelectBufferForm(this, earthIdTextBox, false);
            form.ShowDialog();
        }
    }
}
