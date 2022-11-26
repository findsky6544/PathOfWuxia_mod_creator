using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class GroupTransformActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public GroupTransformActionForm()
        {
            InitializeComponent();
        }
        public GroupTransformActionForm(object obj, bool isAdd) : this()
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

                for (int i = 0; i < fieldsList.Length; i++)
                {
                    ListViewItem lvi2 = new ListViewItem();
                    lvi2.Text = DataManager.getNpcsName(fieldsList[i]);
                    lvi2.SubItems.Add("{" + fieldsList[i + 1] + "," + fieldsList[i + 2] + "," + fieldsList[i + 3] + "}");
                    lvi2.SubItems.Add("{" + fieldsList[i + 4] + "," + fieldsList[i + 5] + "," + fieldsList[i + 6] + "}");
                    lvi2.Tag = "{ \"" + fieldsList[i] + "\", " + lvi2.SubItems[1].Text + ", " + lvi2.SubItems[2].Text + " }";
                    i = i + 6;
                    infosListView.Items.Add(lvi2);
                }
            }

            this.isAdd = isAdd;
        }

        public ListView getInfosListView()
        {
            return infosListView;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (infosListView.Items.Count == 0)
            {
                MessageBox.Show("请至少添加一条数据");
                return;
            }







            string tag = "\"GroupTransformAction\" : [";
            for (int i = 0; i < infosListView.Items.Count; i++)
            {
                ListViewItem lvi2 = infosListView.Items[i];
                tag += lvi2.Tag.ToString() + " , ";
            };
            tag = tag.Substring(0, tag.Length - 2) + " ]";

            string text = Text + ":";
            for (int i = 0; i < infosListView.Items.Count; i++)
            {
                ListViewItem lvi2 = infosListView.Items[i];
                text += lvi2.Text + " 位置" + lvi2.SubItems[1].Text + " 方向 " + lvi2.SubItems[2].Text + ";";
            };

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

        private void addButton_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add("");
            lvi.SubItems.Add("");
            TransformInfoForm npcLocateForm = new TransformInfoForm(lvi, true, this);
            if (npcLocateForm.ShowDialog() == DialogResult.OK)
            {
                infosListView.Items.Add(lvi);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (infosListView.SelectedItems.Count > 0)
            {
                TransformInfoForm npcLocateForm = new TransformInfoForm(infosListView.SelectedItems[0], false, this);
                npcLocateForm.ShowDialog();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (infosListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    infosListView.Items.Remove(infosListView.SelectedItems[0]);
                }
            }
        }
    }
}
