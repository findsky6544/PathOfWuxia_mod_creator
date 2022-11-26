using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EndingMovie = Heluo.Data.EndingMovie;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class EndingMovieInfoForm : Form
    {

        public string EndingMovieId;
        public EndingMovieInfoForm()
        {
            InitializeComponent();
        }

        public EndingMovieInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public EndingMovieInfoForm(string EndingMovieId) : this()
        {
            this.EndingMovieId = EndingMovieId;
        }

        public void readEndingMovieInfo()
        {
            idTextBox.Text = EndingMovieId;
            idTextBox.Enabled = false;

            EndingMovie EndingMovie = DataManager.getData<EndingMovie>(EndingMovieId);

            RemarkTextBox.Text = EndingMovie.Remark;
            EndGameidTextBox.Text = EndingMovie.EndGameid;
            MusicidTextBox.Text = EndingMovie.Musicid;
            Utils.initFlowTreeView(EndingMovie.ShowCondition, ConditionTreeView);
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
                if (string.IsNullOrEmpty(EndGameidTextBox.Text))
                {
                    MessageBox.Show("请输入结局编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\EndingMovie.txt";
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

                if (ConditionTreeView.Nodes[0].Nodes.Count > 0)
                {
                    replacement += "{" + Utils.BaseFlowGraphTagToStr(ConditionTreeView.Nodes[0]) + "}";
                }
                else
                {
                    replacement += "0";
                }

                replacement += "\t" + RemarkTextBox.Text + "\t" + EndGameidTextBox.Text + "\t" + MusicidTextBox.Text;


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

                DataManager.LoadTextfile(typeof(EndingMovie), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新EndingMovie列表
                //获得列表项
                ListViewItem lvi = DataManager.createEndingMovieLvi(idTextBox.Text);


                

                EndingMovieTabControlUserControl EndingMovieTabControlUserControl = (EndingMovieTabControlUserControl)MainForm.userControls["EndingMovie"];

                if (DataManager.allEndingMovieLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allEndingMovieLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allEndingMovieLvis.Add(idTextBox.Text, lvi);
                    EndingMovieTabControlUserControl.getEndingMovieListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readConditionAddLogicalNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addLogicalNode(ConditionTreeView);
        }

        private void addReadConditionNodeButton_Click(object sender, EventArgs e)
        {
            Utils.addConditionNode(ReadConditionNodeListView, ConditionTreeView);
        }

        private void readConditionEditNodeButton_Click(object sender, EventArgs e)
        {
            Utils.editConditionNode(ConditionTreeView);
        }

        private void readConditionDeleteNodeButton_Click(object sender, EventArgs e)
        {
            Utils.deleteConditionNode(ConditionTreeView);
        }
    }

}
