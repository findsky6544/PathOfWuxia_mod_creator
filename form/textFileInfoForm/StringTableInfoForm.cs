using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using StringTable = Heluo.Data.StringTable;

namespace 侠之道mod制作器
{
    public partial class StringTableInfoForm : Form
    {

        public string StringTableId;

        public StringTableInfoForm()
        {
            InitializeComponent();
        }

        public StringTableInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public StringTableInfoForm(string StringTableId) : this()
        {
            this.StringTableId = StringTableId;
        }

        public void readStringTableInfo()
        {
            idTextBox.Text = StringTableId;
            idTextBox.Enabled = false;

            StringTable StringTable = DataManager.getData<StringTable>(StringTableId);

            if (StringTable != null)
            {
                TextTextBox.Text = StringTable.Text;
                RemarkTextBox.Text = StringTable.Remark;
            }

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
                if (string.IsNullOrEmpty(TextTextBox.Text))
                {
                    MessageBox.Show("请输入文字");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\StringTable.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + TextTextBox.Text;


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

                DataManager.LoadTextfile(typeof(StringTable), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新StringTable列表
                //获得列表项
                ListViewItem lvi = DataManager.createStringTableLvi(idTextBox.Text);


                

                StringTableTabControlUserControl StringTableTabControlUserControl = (StringTableTabControlUserControl)MainForm.userControls["StringTable"];

                if (DataManager.allStringTableLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allStringTableLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allStringTableLvis.Add(idTextBox.Text, lvi);
                    StringTableTabControlUserControl.getStringTableListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
