using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ChangeCharacterProtraitAndModelForm : Form
    {
        public bool isAdd;
        public object obj;
        public ChangeCharacterProtraitAndModelForm()
        {
            InitializeComponent();

            initProtraitComboBox();
        }
        public ChangeCharacterProtraitAndModelForm(object obj, bool isAdd) : this()
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
                isChangeProtraitCheckBox.Checked = fieldsList[1].Trim() == "True";
                protraitComboBox.Text = fieldsList[2].Trim();
                isChangeModelCheckBox.Checked = fieldsList[3].Trim() == "True";
                modelTextBox.Text = fieldsList[4].Trim();
            }
        }

        public void initProtraitComboBox()
        {
            for (int i = 0; i < protraitImageList.Images.Count; i++)
            {
                string imageName = protraitImageList.Images.Keys[i];
                imageName = imageName.Substring(0, imageName.LastIndexOf('_'));
                if (!protraitComboBox.Items.Contains(imageName))
                {
                    protraitComboBox.Items.Add(imageName);
                }
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入Exterior编号");
                return;
            }

            string tag = "\"ChangeCharacterProtraitAndModel\" : " + "\"" + idTextBox.Text + "\"" + ", " + isChangeProtraitCheckBox.Checked + ", " + "\"" + protraitComboBox.Text + "\"" + ", " + isChangeModelCheckBox.Checked + ", " + "\"" + modelTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getCharacterExteriorName(idTextBox.Text) + (isChangeProtraitCheckBox.Checked ? " 立绘变更为 " + protraitComboBox.Text : " 不变更立绘") + (isChangeModelCheckBox.Checked ? " 模型变更为 " + modelTextBox.Text : " 不变更模型");

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

        private void protraitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = protraitComboBox.Text + "_General";
            protraitPictureBox.Image = protraitImageList.Images[protraitImageList.Images.IndexOfKey(text)];
        }
    }
}
