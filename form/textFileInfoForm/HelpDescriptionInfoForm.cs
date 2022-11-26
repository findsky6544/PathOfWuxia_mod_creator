using Heluo.Flow;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using HelpDescription = Heluo.Data.HelpDescription;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TextBox = System.Windows.Forms.TextBox;

namespace 侠之道mod制作器
{
    public partial class HelpDescriptionInfoForm : Form
    {

        public string HelpDescriptionId;
        public HelpDescriptionInfoForm()
        {
            InitializeComponent();

            initButtons();
        }

        public HelpDescriptionInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public HelpDescriptionInfoForm(string HelpDescriptionId) : this()
        {
            this.HelpDescriptionId = HelpDescriptionId;
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

        public void readHelpDescriptionInfo()
        {
            idTextBox.Text = HelpDescriptionId;
            idTextBox.Enabled = false;

            HelpDescription HelpDescription = DataManager.getData<HelpDescription>(HelpDescriptionId);

            OrderNumericUpDown.Value = HelpDescription.Order;
            DescriptionTextBox.Text = Utils.replaceRichTextReadIn(HelpDescription.Description, flowLayoutPanel1);

            Utils.initFlowTreeView(HelpDescription.ShowCondition, ShowConditionTreeView);
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
                if (string.IsNullOrEmpty(OrderNumericUpDown.Text))
                {
                    MessageBox.Show("请输入显示顺位");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\HelpDescription.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t";

                if (ShowConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ShowConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + Utils.replaceRichTextWriteOut(DescriptionTextBox.Text, flowLayoutPanel1) + "\t" + OrderNumericUpDown.Text;


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

                DataManager.LoadTextfile(typeof(HelpDescription), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新HelpDescription列表
                //获得列表项
                ListViewItem lvi = DataManager.createHelpDescriptionLvi(idTextBox.Text);


                

                HelpDescriptionTabControlUserControl HelpDescriptionTabControlUserControl = (HelpDescriptionTabControlUserControl)MainForm.userControls["HelpDescription"];

                if (DataManager.allHelpDescriptionLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allHelpDescriptionLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allHelpDescriptionLvis.Add(idTextBox.Text, lvi);
                    HelpDescriptionTabControlUserControl.getHelpDescriptionListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addShowConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void ShowConditionNodeListView_DoubleClick(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void showConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ShowConditionTreeView);
        }

        private void showConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ShowConditionTreeView);
        }

        private void showConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ShowConditionTreeView);
        }
    }

}
