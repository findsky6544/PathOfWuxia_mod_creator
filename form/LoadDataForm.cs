using System;
using System.Windows.Forms;

namespace 侠之道mod制作器.form
{
    public partial class LoadDataForm : Form
    {
        public LoadDataForm()
        {
            InitializeComponent();
        }

        public Label GetTotalLabel()
        {
            return label1;
        }

        public Label getOneLabel()
        {
            return label2;
        }

        public ProgressBar getOneProgressBar()
        {
            return progressBar1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsHandleCreated && progressBar1.Value == progressBar1.Maximum)
            {
                Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
