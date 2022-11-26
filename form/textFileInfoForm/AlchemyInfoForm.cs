using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Alchemy = Heluo.Data.Alchemy;

namespace 侠之道mod制作器
{
    public partial class AlchemyInfoForm : Form
    {

        public string AlchemyId;

        public AlchemyInfoForm()
        {
            InitializeComponent();
        }

        public AlchemyInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public AlchemyInfoForm(string AlchemyId) : this()
        {
            this.AlchemyId = AlchemyId;
        }

        public void readAlchemyInfo()
        {
            idTextBox.Text = AlchemyId;
            idTextBox.Enabled = false;

            Alchemy Alchemy = DataManager.getData<Alchemy>(AlchemyId);

            RemarkTextBox.Text = string.IsNullOrEmpty(Alchemy.Remark) ? "" : Alchemy.Remark;
            PropsIdTextBox.Text = Alchemy.PropsId;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("请输入ID");
                    return;
                }
                if (string.IsNullOrEmpty(PropsIdTextBox.Text))
                {
                    MessageBox.Show("请输入药品编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\Alchemy.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + PropsIdTextBox.Text;
                if (content.Contains("\r\n" + idTextBox.Text + "\t"))
                {
                    string pattern = "\r\n" + idTextBox.Text + ".+?\r\n";
                    Regex rgx = new Regex(pattern);
                    content = rgx.Replace(content, "\r\n" + replacement + "\r\n");
                }
                else
                {
                    content += replacement;
                }
                while (content.StartsWith("\r\n"))
                {
                    content = content.Substring(2, content.Length - 2);
                }
                while (content.EndsWith("\r\n"))
                {
                    content = content.Substring(0, content.Length - 2);
                }

                using (StreamWriter sw = new StreamWriter(savePath))
                {
                    sw.Write(content);
                }

                DataManager.LoadTextfile(typeof(Alchemy), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新adjustment列表
                //获得列表项
                ListViewItem lvi = DataManager.createAlchemyLvi(idTextBox.Text);

                

                AlchemyTabControlUserControl adjustmentTabControlUserControl = (AlchemyTabControlUserControl)MainForm.userControls["Alchemy"];
                if (DataManager.allAlchemyLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allAlchemyLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allAlchemyLvis.Add(idTextBox.Text, lvi);
                    adjustmentTabControlUserControl.getAlchemyListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, PropsIdTextBox, false, new string[] { "Medicine" }, new string[] { "丹藥" });
            form.ShowDialog();
        }
    }

}
