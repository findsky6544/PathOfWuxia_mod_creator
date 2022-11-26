using Heluo.Battle;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using GameFormula = Heluo.Data.GameFormula;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;
using TextBox = System.Windows.Forms.TextBox;

namespace 侠之道mod制作器
{
    public partial class GameFormulaInfoForm : Form
    {

        public string GameFormulaId;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public GameFormulaInfoForm()
        {
            InitializeComponent();

            initButtons();
        }

        public GameFormulaInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public GameFormulaInfoForm(string GameFormulaId) : this()
        {
            this.GameFormulaId = GameFormulaId;
        }

        public void initButtons()
        {
            foreach (NurturanceProperty temp in Enum.GetValues(typeof(NurturanceProperty)))
            {
                Button button = new Button();
                button.Text = "{攻击者_" + EnumData.GetDisplayName(temp) + "}";
                button.Tag = temp.ToString().ToLower();
                button.AutoSize = true;
                flowLayoutPanel1.Controls.Add(button);
            }
            foreach (BattleProperty temp in Enum.GetValues(typeof(BattleProperty)))
            {
                if (temp <= BattleProperty.Element)
                {
                    Button button = new Button();
                    button.Text = "{攻击者_" + EnumData.GetDisplayName(temp) + "}";
                    button.Tag = "attacker_" + temp.ToString().ToLower();
                    button.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
            foreach (NurturanceProperty temp in Enum.GetValues(typeof(NurturanceProperty)))
            {
                Button button = new Button();
                button.Text = "{防御者_" + EnumData.GetDisplayName(temp) + "}";
                button.Tag = "defender_" + temp.ToString().ToLower();
                button.AutoSize = true;
                flowLayoutPanel1.Controls.Add(button);
            }
            foreach (BattleProperty temp in Enum.GetValues(typeof(BattleProperty)))
            {
                if (temp <= BattleProperty.Element)
                {
                    Button button = new Button();
                    button.Text = "{防御者_" + EnumData.GetDisplayName(temp) + "}";
                    button.Tag = "defender_" + temp.ToString().ToLower();
                    button.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }


            foreach (Control button in flowLayoutPanel1.Controls)
            {
                if (button is Button)
                {
                    button.Click += (s, e) =>
                    {
                        setText(button.Text, FormulaTextBox);
                    };
                }
            }
        }

        public void setText(string text, TextBox textBox)
        {
            int index = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(index, text);
            textBox.SelectionStart = index + text.Length;
            textBox.Focus();
        }

        public void readGameFormulaInfo()
        {
            idTextBox.Text = GameFormulaId;
            idTextBox.Enabled = false;

            GameFormula GameFormula = DataManager.getData<GameFormula>(GameFormulaId);

            RemarkTextBox.Text = GameFormula.Remark;
            AliasTextBox.Text = GameFormula.Alias;
            FormulaTextBox.Text = Utils.replaceFormulaTextReadIn(GameFormula.Formula.Expression, flowLayoutPanel1);

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
                if (string.IsNullOrEmpty(FormulaTextBox.Text))
                {
                    MessageBox.Show("请输入公式");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\GameFormula.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + AliasTextBox.Text + "\t" + Utils.replaceFormulaTextWriteOut(FormulaTextBox.Text, flowLayoutPanel1);


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

                DataManager.LoadTextfile(typeof(GameFormula), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新GameFormula列表
                //获得列表项
                ListViewItem lvi = DataManager.createGameFormulaLvi(idTextBox.Text);


                

                GameFormulaTabControlUserControl GameFormulaTabControlUserControl = (GameFormulaTabControlUserControl)MainForm.userControls["GameFormula"];

                if (DataManager.allGameFormulaLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allGameFormulaLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allGameFormulaLvis.Add(idTextBox.Text, lvi);
                    GameFormulaTabControlUserControl.getGameFormulaListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
