using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using Favorability = Heluo.Data.Favorability;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TextBox = System.Windows.Forms.TextBox;

namespace 侠之道mod制作器
{
    public partial class FavorabilityInfoForm : Form
    {

        public string FavorabilityId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public FavorabilityInfoForm()
        {
            InitializeComponent();

            initButtons();
        }

        public FavorabilityInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public FavorabilityInfoForm(string FavorabilityId) : this()
        {
            this.FavorabilityId = FavorabilityId;
        }

        public void initButtons()
        {
            foreach (Control button in flowLayoutPanel1.Controls)
            {
                if (button is Button)
                {
                    button.Click += (s, e) =>
                    {
                        setText(button.Text, DescriptionTextBox);
                    };

                    if (!button.Name.Contains("Appellation"))
                    {
                        continue;
                    }
                    else
                    {
                        string stringTableName = button.Name.Replace("button", "");
                        button.Text = "{" + DataManager.getStringTableTextRemark(stringTableName) + "}";
                    }
                }
            }
        }

        public void setText(string text, TextBox textBox)
        {
            if (text == "文字变红")
            {
                textBox.SelectedText = "<color=#FF0000>" + textBox.SelectedText + "</color>";
            }
            else
            {
                int index = textBox.SelectionStart;
                textBox.Text = textBox.Text.Insert(index, text);
                textBox.SelectionStart = index + text.Length;
            }
            textBox.Focus();
        }

        public void readFavorabilityInfo()
        {
            idTextBox.Text = FavorabilityId;
            idTextBox.Enabled = false;

            Favorability Favorability = DataManager.getData<Favorability>(FavorabilityId);

            NameTextBox.Text = Favorability.Name;
            RemarkTextBox.Text = Favorability.Remark;
            DescriptionTextBox.Text = Utils.replaceRichTextReadIn(Favorability.Description, flowLayoutPanel1);

        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
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
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("请输入名称");
                    return;
                }
                if (string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    MessageBox.Show("请输入描述");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Favorability.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + Utils.replaceRichTextWriteOut(DescriptionTextBox.Text, flowLayoutPanel1);


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

                DataManager.LoadTextfile(typeof(Favorability), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Favorability列表
                //获得列表项
                ListViewItem lvi = DataManager.createFavorabilityLvi(idTextBox.Text);


                

                FavorabilityTabControlUserControl FavorabilityTabControlUserControl = (FavorabilityTabControlUserControl)MainForm.userControls["Favorability"];

                if (DataManager.allFavorabilityLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allFavorabilityLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allFavorabilityLvis.Add(idTextBox.Text, lvi);
                    FavorabilityTabControlUserControl.getFavorabilityListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
