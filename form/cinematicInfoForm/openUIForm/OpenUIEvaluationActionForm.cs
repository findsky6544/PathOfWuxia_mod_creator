using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class OpenUIEvaluationActionForm : Form
    {
        public bool isAdd;
        public object obj;
        public OpenUIEvaluationActionForm()
        {
            InitializeComponent();
        }
        public OpenUIEvaluationActionForm(object obj, bool isAdd) : this()
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
                movieidTextBox.Text = fieldsList[1].Trim();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text == "")
            {
                MessageBox.Show("请输入整备编号");
                return;
            }
            if (movieidTextBox.Text == "")
            {
                MessageBox.Show("请输入接续的movieID");
                return;
            }

            string tag = "\"OpenUIEvaluationAction\" : \"" + idTextBox.Text + "\", \"" + movieidTextBox.Text + "\"";
            string text = Text + ":" + DataManager.getEvaluationName(idTextBox.Text) + " 接续的movieId:" + DataManager.getCinematicName(movieidTextBox.Text);

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

        private void selectEvaluationButton_Click(object sender, EventArgs e)
        {
            SelectEvaluationForm selectAdjustmentForm = new SelectEvaluationForm(this, idTextBox, false);
            selectAdjustmentForm.ShowDialog();
        }

        private void selectAdjustmentButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm selectAdjustmentForm = new SelectCinematicForm(this, movieidTextBox, false);
            selectAdjustmentForm.ShowDialog();
        }
    }
}
