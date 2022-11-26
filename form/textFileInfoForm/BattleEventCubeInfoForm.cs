using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BattleEventCube = Heluo.Data.BattleEventCube;

namespace 侠之道mod制作器
{
    public partial class BattleEventCubeInfoForm : Form
    {

        public string battleEventCubeId;

        public BattleEventCubeInfoForm()
        {
            InitializeComponent();
        }

        public BattleEventCubeInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public BattleEventCubeInfoForm(string battleEventCubeId) : this()
        {
            this.battleEventCubeId = battleEventCubeId;
        }

        public void readBattleEventCubeInfo()
        {
            idTextBox.Text = battleEventCubeId;
            idTextBox.Enabled = false;

            BattleEventCube battleEventCube = DataManager.getData<BattleEventCube>(battleEventCubeId);

            InfoIdTextBox.Text = battleEventCube.InfoId;
            ExteriorIdTextBox.Text = battleEventCube.ExteriorId;
            RemarkTextBox.Text = battleEventCube.Remark;
        }

        private void selectCharacterInfoButton_Click(object sender, EventArgs e)
        {
            SelectCharacterInfoForm form = new SelectCharacterInfoForm(this, InfoIdTextBox, false);
            form.ShowDialog();
        }

        private void selectCharacterExteriorButton_Click(object sender, EventArgs e)
        {
            SelectCharacterExteriorForm form = new SelectCharacterExteriorForm(this, ExteriorIdTextBox, false);
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
                if (string.IsNullOrEmpty(InfoIdTextBox.Text))
                {
                    MessageBox.Show("请输入角色编号");
                    return;
                }
                if (string.IsNullOrEmpty(ExteriorIdTextBox.Text))
                {
                    MessageBox.Show("请输入角色外观编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\BattleEventCube.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + InfoIdTextBox.Text + "\t" + ExteriorIdTextBox.Text + "\t" + RemarkTextBox.Text;

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

                DataManager.LoadTextfile(typeof(BattleEventCube), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新BattleEventCube列表
                //获得列表项
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");


                if (DataManager.allBattleEventCubeLvis.ContainsKey(idTextBox.Text))
                {
                    lvi = DataManager.allBattleEventCubeLvis[idTextBox.Text];
                }

                lvi.Text = idTextBox.Text;
                lvi.SubItems[1].Text = DataManager.getCharacterInfoRemark(InfoIdTextBox.Text);
                lvi.SubItems[2].Text = DataManager.getCharacterExteriorName(ExteriorIdTextBox.Text);
                lvi.SubItems[3].Text = RemarkTextBox.Text;
                lvi.SubItems[4].Text = "1";

                

                BattleEventCubeTabControlUserControl BattleEventCubeTabControlUserControl = (BattleEventCubeTabControlUserControl)MainForm.userControls["BattleEventCube"];
                if (DataManager.allBattleEventCubeLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allBattleEventCubeLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allBattleEventCubeLvis.Add(idTextBox.Text, lvi);
                    BattleEventCubeTabControlUserControl.getBattleEventCubeListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
