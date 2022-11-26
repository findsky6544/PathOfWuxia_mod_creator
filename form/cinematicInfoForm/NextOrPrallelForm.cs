using System;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NextOrPrallelForm : Form
    {
        public ListViewItem lvi;
        public NextOrPrallelForm()
        {
            InitializeComponent();
        }
        public NextOrPrallelForm(ListViewItem lvi, Form owner) : this()
        {
            this.lvi = lvi;
            Owner = owner;

            nextNumericUpDown.Text = lvi.SubItems[2].Text;
            prallelNumericUpDown.Text = lvi.SubItems[3].Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (nextNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入下一个节点");
                return;
            }
            if (prallelNumericUpDown.Text == "")
            {
                MessageBox.Show("请输入并行处理节点");
                return;
            }

            lvi.SubItems[2].Text = nextNumericUpDown.Text;
            lvi.SubItems[3].Text = prallelNumericUpDown.Text;

            Close();

            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectNextNodeButton_Click(object sender, EventArgs e)
        {
            SelectCinematicNodeForm selectAdjustmentForm = new SelectCinematicNodeForm(this, nextNumericUpDown);
            selectAdjustmentForm.ShowDialog();
        }

        private void selectPrallelNodeButton_Click(object sender, EventArgs e)
        {
            SelectCinematicNodeForm selectAdjustmentForm = new SelectCinematicNodeForm(this, prallelNumericUpDown);
            selectAdjustmentForm.ShowDialog();
        }
    }
}
