using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class NewModForm : Form
    {
        public NewModForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (modNameTextBox.Text == "")
            {
                MessageBox.Show("请输入mod名称", "提示", MessageBoxButtons.OK);
            }
            else
            {
                if (!Directory.Exists(modNameTextBox.Text))
                {
                    Directory.CreateDirectory(modNameTextBox.Text);
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\battle");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\battle\\buffer");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\battle\\schedule");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\cinematic");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\effect");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\movepath");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\schedule");
                    Directory.CreateDirectory(modNameTextBox.Text + "\\config\\textfiles");

                    for (int i = 0; i < MainForm.textfilesArray.Length; i++)
                    {
                        FileStream fs = File.Create(modNameTextBox.Text + "\\config\\textfiles\\" + MainForm.textfilesArray[i] + "_modify.txt");
                        fs.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("该mod已存在，是否载入？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                MainForm.modName = modNameTextBox.Text;

                MainForm mainForm = (MainForm)Owner;
                mainForm.getConfigTreeView().Nodes.Clear();
                TreeNode modNameNode = mainForm.getConfigTreeView().Nodes.Add(modNameTextBox.Text);
                TreeNode configNode = modNameNode.Nodes.Add("config");
                mainForm.LoadConfigTree("config", configNode);
                mainForm.getConfigTreeView().ExpandAll();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
