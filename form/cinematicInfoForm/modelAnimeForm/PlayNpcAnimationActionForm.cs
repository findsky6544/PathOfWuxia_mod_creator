using Heluo.Flow;
using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class PlayNpcAnimationActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public PlayNpcAnimationActionForm()
        {
            InitializeComponent();
        }
        public PlayNpcAnimationActionForm(object obj, bool isAdd) : this()
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

                for (int i = 0; i < fieldsList.Length - 1; i++)
                {
                    ListViewItem lvi2 = new ListViewItem();
                    foreach (AnimationPlayType temp in Enum.GetValues(typeof(AnimationPlayType)))
                    {
                        if (((int)temp).ToString() == fieldsList[i].Trim())
                        {
                            lvi2.Text = EnumData.GetDisplayName(temp);
                            break;
                        }
                    }
                    lvi2.SubItems.Add(fieldsList[i + 1]);
                    lvi2.SubItems.Add(fieldsList[i + 2]);
                    lvi2.Tag = "{ " + fieldsList[i].Trim() + ", " + "\"" + lvi2.SubItems[1].Text + "\"" + ", " + lvi2.SubItems[2].Text + " }";
                    i = i + 2;
                    animationClipInfosListView.Items.Add(lvi2);
                }
                npcIdTextBox.Text = fieldsList[fieldsList.Length - 1].Trim();
            }
        }

        public ListView getInfosListView()
        {
            return animationClipInfosListView;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (animationClipInfosListView.Items.Count == 0)
            {
                MessageBox.Show("请至少添加一条数据");
                return;
            }
            if (npcIdTextBox.Text == "")
            {
                MessageBox.Show("请输入NPC编号");
                return;
            }

            string tag = "\"PlayNpcAnimationAction\" : [";
            for (int i = 0; i < animationClipInfosListView.Items.Count; i++)
            {
                ListViewItem lvi2 = animationClipInfosListView.Items[i];
                tag += lvi2.Tag.ToString() + " , ";
            };
            tag = tag.Substring(0, tag.Length - 2) + " ]" + ", " + "\"" + npcIdTextBox.Text + "\"";

            string text = Text + ":";
            string animationStr = "";
            for (int i = 0; i < animationClipInfosListView.Items.Count; i++)
            {
                ListViewItem lvi2 = animationClipInfosListView.Items[i];

                string playTypeStr = "";
                switch (lvi2.Text)
                {
                    case "循環":
                        playTypeStr = "循环"; break;
                    case "時間":
                        playTypeStr = lvi2.SubItems[2].Text + " " + "秒"; break;
                    case "次數":
                        playTypeStr = lvi2.SubItems[2].Text + " " + "次"; break;
                }
                animationStr += lvi2.SubItems[1].Text + " " + playTypeStr + ",";
            }


            if (animationStr.Length > 0)
            {
                animationStr = animationStr.Substring(0, animationStr.Length - 1);
            }

            text += DataManager.getNpcsName(npcIdTextBox.Text) + " " + "播放动画 " + animationStr;




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
            AnimationCilpInfoForm npcLocateForm = new AnimationCilpInfoForm(lvi, true, this);
            if (npcLocateForm.ShowDialog() == DialogResult.OK)
            {
                animationClipInfosListView.Items.Add(lvi);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (animationClipInfosListView.SelectedItems.Count > 0)
            {
                AnimationCilpInfoForm npcLocateForm = new AnimationCilpInfoForm(animationClipInfosListView.SelectedItems[0], false, this);
                npcLocateForm.ShowDialog();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (animationClipInfosListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    animationClipInfosListView.Items.Remove(animationClipInfosListView.SelectedItems[0]);
                }
            }
        }

        private void selectNpcButton_Click(object sender, EventArgs e)
        {
            SelectNpcForm form = new SelectNpcForm(this, npcIdTextBox, false);
            form.ShowDialog();
        }
    }
}
