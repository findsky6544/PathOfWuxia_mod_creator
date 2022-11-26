using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class ProcessActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public ProcessActionForm()
        {
            InitializeComponent();
        }
        public ProcessActionForm(object obj, bool isAdd) : this()
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

                endgameidTextBox.Text = fieldsList[0].Trim();
                musicTextBox.Text = fieldsList[1].Trim();
                cinematicTextBox.Text = fieldsList[2].Trim();
                movieTextBox.Text = fieldsList[3].Trim();
                isMandatoryStayCheckBox.Checked = fieldsList[4].Trim() == "True";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (endgameidTextBox.Text == "")
            {
                MessageBox.Show("请输入结局编号");
                return;
            }
            if (musicTextBox.Text == "")
            {
                MessageBox.Show("请输入结局音乐");
                return;
            }

            string tag = "\"ProcessAction\" : " + "\"" + endgameidTextBox.Text + "\"" + ", " + "\"" + musicTextBox.Text + "\"" + ", " + "\"" + cinematicTextBox.Text + "\"" + ", " + "\"" + movieTextBox.Text + "\"" + ", " + isMandatoryStayCheckBox.Checked;

            string stayStr = " ";
            if (!string.IsNullOrEmpty(cinematicTextBox.Text))
            {
                stayStr += (isMandatoryStayCheckBox.Checked ? "" : "不") + "强制停留";
            }
            string text = Text + ":" + endgameidTextBox.Text + "; 音乐:" + musicTextBox.Text + "; 接续的cinematic编号:" + DataManager.getCinematicName(cinematicTextBox.Text) + "; 接续的movie编号:" + (movieTextBox.Text == "" ? "(空)" : movieTextBox.Text) + "; " + stayStr;

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

        private void selectCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, cinematicTextBox, false);
            form.ShowDialog();
        }
    }
}
