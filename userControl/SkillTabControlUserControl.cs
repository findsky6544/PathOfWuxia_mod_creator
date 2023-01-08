using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class SkillTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public SkillTabControlUserControl()
        {
            InitializeComponent();
        }
        public SkillTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                SkillListView.Items.Clear();
                SkillListView.Items.AddRange(DataManager.allSkillLvis.Values.Where(x => (showOriginalSkillCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (SkillListView.SelectedItems.Count > 0)
                {
                    SkillListView.EnsureVisible(SkillListView.SelectedItems[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public TabControl GetTabControl()
        {
            return CustomTabControl;
        }

        public ListView getSkillListView()
        {
            return SkillListView;
        }

        private void showOriginalSkillCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newSkillButton_Click(object sender, EventArgs e)
        {
            SkillInfoForm form = new SkillInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editSkillButton_Click(object sender, EventArgs e)
        {
            editSkill();
        }

        public void editSkill()
        {
            if (SkillListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = SkillListView.SelectedItems[0];

                SkillInfoForm form = new SkillInfoForm((Form)Parent);
                form.SkillId = lvi.SubItems[1].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readSkillInfo();

                form.ShowDialog();
            }
        }

        private void SkillListView_DoubleClick(object sender, EventArgs e)
        {
            editSkill();
        }

        private void SkillListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editSkill();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchSkill();
        }

        public void searchSkill()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allSkillLvis.ContainsKey(searchText))
            {
                Skill Skill = DataManager.getData<Skill>(searchText);
                if (Skill != null)
                {
                    ListViewItem lvi = DataManager.createSkillLvi(searchText);
                    SkillListView.Items.Add(lvi);
                    DataManager.allSkillLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (SkillListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (SkillListView.SelectedItems != null && SkillListView.SelectedItems.Count != 0)
                {
                    startIndex = SkillListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == SkillListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = SkillListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            SkillListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == SkillListView.Items.Count)
                    {
                        index = 0;
                    }
                } while (index != startIndex);
            }
            if (!isSearched)
            {
                MessageBox.Show("未找到该数据");

            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchSkill();
            }
        }

        private void SkillListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (SkillListView.SelectedItems.Count > 0)
            {
                selectIndex = SkillListView.Items.IndexOf(SkillListView.SelectedItems[0]);
                ListViewItem lvi = SkillListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteSkillButton.Enabled = true;
                }
                else
                {
                    deleteSkillButton.Enabled = false;
                }
            }
        }

        private void deleteSkillButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SkillListView.SelectedItems.Count > 0)
                {
                    string SkillId = SkillListView.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Skill_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + SkillId + "\t"))
                        {
                            string pattern = "\r\n" + SkillId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Skill), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Skill"].Contains(SkillId))
                        {
                            DataManager.allSkillLvis.Remove(SkillId);
                            SkillListView.Items.Remove(SkillListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Skill Skill = DataManager.getData<Skill>(SkillId);

                            ListViewItem lvi = DataManager.createSkillLvi(SkillId);
                            if (DataManager.allSkillLvis.ContainsKey(SkillId))
                            {
                                DataManager.allSkillLvis[SkillId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalSkillCheckBox.Checked)
                            {
                                for (int i = 0; i < SkillListView.Items.Count; i++)
                                {
                                    if (SkillListView.Items[i].SubItems[1].Text == SkillId)
                                    {
                                        SkillListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                SkillListView.Items.Remove(SkillListView.SelectedItems[0]);
                            }

                        }
                        deleteSkillButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            MainForm mainForm = (MainForm)Parent;

            if (DataManager.dict.ContainsKey("Skill"))
            {
                DataManager.dict.Remove("Skill");
            }
            DataManager.LoadTextfile("Skill");

            DataManager.allSkillLvis.Clear();
            DataManager.allSkillLvis = DataManager.createSkillLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Skill.txt";

            if (SkillListView.SelectedItems.Count > 0 && SkillListView.SelectedItems[0].SubItems[SkillListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Skill_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Skill_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Skill.txt";

            if (SkillListView.SelectedItems.Count > 0 && SkillListView.SelectedItems[0].SubItems[SkillListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Skill_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Skill_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
