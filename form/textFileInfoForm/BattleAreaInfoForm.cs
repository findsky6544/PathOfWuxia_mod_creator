using Heluo.Data;
using Heluo.Utility;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BattleArea = Heluo.Data.BattleArea;

namespace 侠之道mod制作器
{
    public partial class BattleAreaInfoForm : Form
    {

        public string battleAreaId;

        public BattleAreaInfoForm()
        {
            InitializeComponent();
        }

        public BattleAreaInfoForm(string battleAreaId, bool canEdit) : this()
        {
            this.battleAreaId = battleAreaId;

            if (!canEdit)
            {
                idTextBox.Enabled = false;
                battleMapTextBox.Enabled = false;
                scheduleIDTextBox.Enabled = false;
                musicNameTextBox.Enabled = false;
                afterWinMovieTextBox.Enabled = false;
                afterLoseMovieTextBox.Enabled = false;
                remarkTextBox.Enabled = false;
                addDropButton.Enabled = false;
                editDropButton.Enabled = false;
                deleteDropButton.Enabled = false;
                saveButton.Enabled = false;

                selectWinCinematicButton.Text = "查看cinematic";
                selectWinCinematicButton.Click -= selectWinCinematicButton_Click;
                selectWinCinematicButton.Click += new System.EventHandler(jumpToCinematicInfoForm);

                selectLoseCinematicButton.Text = "查看cinematic";
                selectLoseCinematicButton.Click -= selectLoseCinematicButton_Click;
                selectLoseCinematicButton.Click += new System.EventHandler(jumpToCinematicInfoForm);

                selectBattleScheduleButton.Text = "查看schedule";
                selectBattleScheduleButton.Click -= selectBattleScheduleButton_Click;
                selectBattleScheduleButton.Click += new System.EventHandler(jumpToScheduleInfoForm);
            }

            if (!battleAreaId.IsNullOrEmpty())
            {
                this.readBattleAreaInfo();
            }
        }

        public void readBattleAreaInfo()
        {
            idTextBox.Text = battleAreaId;
            idTextBox.Enabled = false;

            BattleArea battleArea = DataManager.getData<BattleArea>(battleAreaId);

            battleMapTextBox.Text = string.IsNullOrEmpty(battleArea.BattleMap) ? "" : battleArea.BattleMap;
            scheduleIDTextBox.Text = string.IsNullOrEmpty(battleArea.ScheduleID) ? "" : battleArea.ScheduleID;

            if (battleArea.DropProps != null)
            {
                for (int i = 0; i < battleArea.DropProps.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DataManager.getPropssName(battleArea.DropProps[i].Id);
                    lvi.SubItems.Add(battleArea.DropProps[i].Amount.ToString());
                    lvi.Tag = "(" + battleArea.DropProps[i].Id + "," + battleArea.DropProps[i].Amount + ")";
                    dropPropsListView.Items.Add(lvi);
                }
            }


            musicNameTextBox.Text = string.IsNullOrEmpty(battleArea.MusicName) ? "" : battleArea.MusicName;
            remarkTextBox.Text = string.IsNullOrEmpty(battleArea.Remark) ? "" : battleArea.Remark;
            afterWinMovieTextBox.Text = string.IsNullOrEmpty(battleArea.AfterWinMovie) ? "" : battleArea.AfterWinMovie;
            afterLoseMovieTextBox.Text = string.IsNullOrEmpty(battleArea.AfterLoseMovie) ? "" : battleArea.AfterLoseMovie;
        }
        public void jumpToCinematicInfoForm(object sender, EventArgs e)
        {
            string cinematicId = "";
            if (((Button)sender).Tag.ToString() == "win")
            {
                cinematicId = afterWinMovieTextBox.Text;
            }
            else
            {
                cinematicId = afterLoseMovieTextBox.Text;
            }

            CinematicInfoForm form = new CinematicInfoForm(cinematicId,false);

            form.Show();
        }
        public void jumpToScheduleInfoForm(object sender, EventArgs e)
        {
            string scheduleId = scheduleIDTextBox.Text;

            ScheduleInfoForm form = new ScheduleInfoForm(scheduleId,false);

            form.Show();
        }

        public ListView getDropPropsListView()
        {
            return dropPropsListView;
        }

        private void selectBattleMapButton_Click(object sender, EventArgs e)
        {
            SelectBattleGridForm form = new SelectBattleGridForm(this, battleMapTextBox, false);
            form.ShowDialog();
        }

        private void selectBattleScheduleButton_Click(object sender, EventArgs e)
        {
            SelectBattleNodeSaveInfoForm form = new SelectBattleNodeSaveInfoForm(this, scheduleIDTextBox, false);
            form.ShowDialog();
        }

        private void selectWinCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, afterWinMovieTextBox, false);
            form.ShowDialog();
        }

        private void selectLoseCinematicButton_Click(object sender, EventArgs e)
        {
            SelectCinematicForm form = new SelectCinematicForm(this, afterLoseMovieTextBox, false);
            form.ShowDialog();
        }

        private void addDropButton_Click(object sender, EventArgs e)
        {
            DropPropsForm form = new DropPropsForm(new ListViewItem(), true, this);
            form.ShowDialog();
        }

        private void editDropButton_Click(object sender, EventArgs e)
        {
            if (dropPropsListView.SelectedItems.Count > 0)
            {
                DropPropsForm form = new DropPropsForm(dropPropsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择一条数据");
            }
        }

        private void deleteDropButton_Click(object sender, EventArgs e)
        {
            if (dropPropsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dropPropsListView.Items.Remove(dropPropsListView.SelectedItems[0]);
                }
            }
            else
            {
                MessageBox.Show("请先选择一条数据");
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
                if (string.IsNullOrEmpty(battleMapTextBox.Text))
                {
                    MessageBox.Show("请输入战斗网格编号");
                    return;
                }
                if (string.IsNullOrEmpty(scheduleIDTextBox.Text))
                {
                    MessageBox.Show("请输入战斗排程编号");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\BattleArea.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + battleMapTextBox.Text + "\t" + scheduleIDTextBox.Text + "\t";
                if (dropPropsListView.Items.Count > 0)
                {
                    for (int i = 0; i < dropPropsListView.Items.Count; i++)
                    {
                        replacement += dropPropsListView.Items[i].Tag.ToString();
                    }
                }

                replacement += "\t" + musicNameTextBox.Text + "\t" + remarkTextBox.Text + "\t" + afterWinMovieTextBox.Text + "\t" + afterLoseMovieTextBox.Text;

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

                DataManager.LoadTextfile(typeof(BattleArea), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新BattleArea列表
                //获得列表项
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");


                if (DataManager.allBattleAreaLvis.ContainsKey(idTextBox.Text))
                {
                    lvi = DataManager.allBattleAreaLvis[idTextBox.Text];
                }

                lvi.Text = idTextBox.Text;
                lvi.SubItems[1].Text = remarkTextBox.Text;
                lvi.SubItems[2].Text = DataManager.getBattleGridRemark(battleMapTextBox.Text);
                lvi.SubItems[3].Text = DataManager.getScheduleName(scheduleIDTextBox.Text);
                string dropProps = "";
                if (dropPropsListView.Items.Count > 0)
                {
                    for (int i = 0; i < dropPropsListView.Items.Count; i++)
                    {
                        dropProps += dropPropsListView.Items[i].Text + "*" + dropPropsListView.Items[i].SubItems[1].Text + ",";
                    }
                    dropProps = dropProps.Substring(0, dropProps.Length - 1);
                }
                lvi.SubItems[4].Text = dropProps;
                lvi.SubItems[5].Text = musicNameTextBox.Text;
                lvi.SubItems[6].Text = DataManager.getCinematicName(afterWinMovieTextBox.Text);
                lvi.SubItems[7].Text = DataManager.getCinematicName(afterLoseMovieTextBox.Text);
                lvi.SubItems[8].Text = "1";

                

                BattleAreaTabControlUserControl BattleAreaTabControlUserControl = (BattleAreaTabControlUserControl)MainForm.userControls["BattleArea"];
                if (DataManager.allBattleAreaLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allBattleAreaLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allBattleAreaLvis.Add(idTextBox.Text, lvi);
                    BattleAreaTabControlUserControl.getBattleAreaListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
