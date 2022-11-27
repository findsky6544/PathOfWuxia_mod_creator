
using Heluo.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Book = Heluo.Data.Book;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TextBox = System.Windows.Forms.TextBox;

namespace 侠之道mod制作器
{
    public partial class BookInfoForm : Form
    {

        public string BookId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public BookInfoForm()
        {
            InitializeComponent();

            initBookTabComboBox();
            initIconNameComboBox();

            initButtons();
        }

        public BookInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public BookInfoForm(string BookId) : this()
        {
            this.BookId = BookId;
        }

        public void initBookTabComboBox()
        {
            BookTabComboBox.DisplayMember = "value";
            BookTabComboBox.ValueMember = "key";


            foreach (BookTab temp in Enum.GetValues(typeof(BookTab)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                BookTabComboBox.Items.Add(cbi);
            }
        }

        public void initIconNameComboBox()
        {
            for (int i = 0; i < bookImageList.Images.Count; i++)
            {
                string imageName = bookImageList.Images.Keys[i];
                if (!IconNameComboBox.Items.Contains(imageName))
                {
                    IconNameComboBox.Items.Add(imageName);
                }
            }
        }


        public void initButtons()
        {
            foreach (Control button in flowLayoutPanel1.Controls)
            {
                if (button is Button)
                {
                    button.Click += (s, e) =>
                    {
                        if (tabControl2.SelectedTab.Text == "NPC讯息提示（可阅读）")
                        {
                            setText(button.Text, TipsCanReadTextBox);
                        }
                        else
                        {
                            setText(button.Text, TipsCanNotReadTextBox);
                        }
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

        public void readBookInfo()
        {
            idTextBox.Text = BookId;
            idTextBox.Enabled = false;

            Book Book = DataManager.getData<Book>(BookId);

            NameTextBox.Text = Book.Name;
            RemarkTextBox.Text = Book.Remark;
            IsLibaryCheckBox.Checked = Book.IsLibary;

            for (int i = 0; i < BookTabComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)BookTabComboBox.Items[i]).key == ((int)Book.BookTab).ToString())
                {
                    BookTabComboBox.SelectedIndex = i;
                    break;
                }
            }
            DescriptionTextBox.Text = Book.Description;
            IconNameComboBox.Text = Book.IconName;
            MaxReadTimeNumericUpDown.Value = Book.MaxReadTime;
            string readEffect = "";
            if (Book.ReadEffect != null && Book.ReadEffect.Count > 0)
            {
                for (int i = 0; i < Book.ReadEffect.Count; i++)
                {
                    readEffect += Book.ReadEffect[i] + ",";
                }
                readEffect = readEffect.Substring(0, readEffect.Length - 1);
            }
            ReadEffectTextBox.Text = readEffect;
            LearnSkillTextBox.Text = Book.LearnSkill;
            Utils.initFlowTreeView(Book.ReadCondition, ReadConditionTreeView);
            ReadConditionDescriptionTextBox.Text = Book.ReadConditionDescription;
            Utils.initFlowTreeView(Book.ShowCondition, ShowConditionTreeView);

            string TipsCanRead = "";
            if (Book.TipsCanRead != null && Book.TipsCanRead.Count > 0)
            {
                for (int i = 0; i < Book.TipsCanRead.Count; i++)
                {
                    TipsCanRead += Utils.replaceRichTextReadIn(Book.TipsCanRead[i], flowLayoutPanel1) + "\r\n";
                }
                TipsCanRead = TipsCanRead.Trim();
            }
            TipsCanReadTextBox.Text = TipsCanRead;

            string TipsCanNotRead = "";
            if (Book.TipsCanNotRead != null && Book.TipsCanNotRead.Count > 0)
            {
                for (int i = 0; i < Book.TipsCanNotRead.Count; i++)
                {
                    TipsCanNotRead += Utils.replaceRichTextReadIn(Book.TipsCanNotRead[i], flowLayoutPanel1) + "\r\n";
                }
                TipsCanNotRead = TipsCanNotRead.Trim();
            }
            TipsCanNotReadTextBox.Text = TipsCanNotRead;

            NotReadFinishMovieTextBox.Text = Book.NotReadFinishMovie;
            ReadFinishMovieTextBox.Text = Book.ReadFinishMovie;

        }

        public ListView getAllCellsListView()
        {
            //return AllCellsListView;
            return null;
        }

        private void selectSkillButton_Click(object sender, EventArgs e)
        {
            SelectSkillForm form = new SelectSkillForm(this, LearnSkillTextBox, false, SelectSkillForm.selectSkillType.normal);
            form.ShowDialog();
        }

        private void selectMantraButton_Click(object sender, EventArgs e)
        {
            SelectMantraForm form = new SelectMantraForm(this, LearnSkillTextBox, false);
            form.ShowDialog();
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, LearnSkillTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }

        private void selectRewardsButton_Click(object sender, EventArgs e)
        {
            SelectRewardForm form = new SelectRewardForm(this, ReadEffectTextBox, true);
            form.ShowDialog();
        }

        private void selectNotReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, NotReadFinishMovieTextBox, false);
            form.ShowDialog();
        }

        private void selectReadFinishMovieButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, ReadFinishMovieTextBox, false);
            form.ShowDialog();
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
                    MessageBox.Show("请输入书籍名称");
                    return;
                }
                if (string.IsNullOrEmpty(DescriptionTextBox.Text))
                {
                    MessageBox.Show("请输入书籍描述");
                    return;
                }
                if (string.IsNullOrEmpty(BookTabComboBox.Text))
                {
                    MessageBox.Show("请输入书籍分类");
                    return;
                }
                if (string.IsNullOrEmpty(IconNameComboBox.Text))
                {
                    MessageBox.Show("请输入图标");
                    return;
                }
                if (string.IsNullOrEmpty(MaxReadTimeNumericUpDown.Text))
                {
                    MessageBox.Show("请输入最大阅读次数");
                    return;
                }
                if (string.IsNullOrEmpty(LearnSkillTextBox.Text))
                {
                    MessageBox.Show("请输入获得武学/心法/物品id");
                    return;
                }
                if (string.IsNullOrEmpty(NotReadFinishMovieTextBox.Text))
                {
                    MessageBox.Show("请输入未阅读完毕movie编号");
                    return;
                }
                if (string.IsNullOrEmpty(ReadFinishMovieTextBox.Text))
                {
                    MessageBox.Show("请输入阅读完毕movie编号");
                    return;
                }
                if (string.IsNullOrEmpty(TipsCanReadTextBox.Text))
                {
                    MessageBox.Show("请输入NPC讯息提示（可阅读）");
                    return;
                }
                if (string.IsNullOrEmpty(TipsCanNotReadTextBox.Text))
                {
                    MessageBox.Show("请输入NPC讯息提示（不可阅读）");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Book_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + IsLibaryCheckBox.Checked + "\t" + Enum.Parse(typeof(BookTab), ((ComboBoxItem)BookTabComboBox.SelectedItem).key) + "\t" + DescriptionTextBox.Text + "\t" + IconNameComboBox.Text + "\t" + MaxReadTimeNumericUpDown.Text + "\t" + ReadEffectTextBox.Text + "\t" + LearnSkillTextBox.Text + "\t";


                if (ReadConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ReadConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }
                replacement += "\t" + ReadConditionDescriptionTextBox.Text + "\t";


                if (ShowConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ShowConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }

                replacement += "\t" + Utils.replaceRichTextWriteOut(TipsCanReadTextBox.Text, flowLayoutPanel1) + "\t" + Utils.replaceRichTextWriteOut(TipsCanNotReadTextBox.Text, flowLayoutPanel1) + "\t" + NotReadFinishMovieTextBox.Text + "\t" + ReadFinishMovieTextBox.Text;


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

                DataManager.LoadTextfile(typeof(Book), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Book列表
                //获得列表项
                ListViewItem lvi = DataManager.createBookLvi(idTextBox.Text);


                

                BookTabControlUserControl BookTabControlUserControl = (BookTabControlUserControl)MainForm.userControls["Book"];

                if (DataManager.allBookLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allBookLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allBookLvis.Add(idTextBox.Text, lvi);
                    BookTabControlUserControl.getBookListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IconNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = IconNameComboBox.Text;
            IconPictureBox.Image = bookImageList.Images[bookImageList.Images.IndexOfKey(text)];
        }

        private void changeRedButton_Click(object sender, EventArgs e)
        {
            DescriptionTextBox.SelectedText = "<color=#FF0000>" + DescriptionTextBox.SelectedText + "</color>";
        }

        private void readConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ReadConditionTreeView);
        }

        private void addReadConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ReadConditionNodeListView, ReadConditionTreeView);
        }

        private void readConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ReadConditionTreeView);
        }

        private void readConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ReadConditionTreeView);
        }

        private void showConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ShowConditionTreeView);
        }

        private void addShowConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ShowConditionNodeListView, ShowConditionTreeView);
        }

        private void showConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ShowConditionTreeView);
        }

        private void showConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ShowConditionTreeView);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Text == "NPC讯息提示（可阅读）")
            {
                flowLayoutPanel1.Parent = tabPage6;
            }
            else if (tabControl2.SelectedTab.Text == "NPC讯息提示（不可阅读）")
            {
                flowLayoutPanel1.Parent = tabPage7;
            }
        }
    }

}
