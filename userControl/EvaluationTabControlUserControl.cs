using Heluo.Data;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 侠之道mod制作器
{
    public partial class EvaluationTabControlUserControl : UserControl
    {
        public int selectIndex = -1;
        public EvaluationTabControlUserControl()
        {
            InitializeComponent();
        }
        public EvaluationTabControlUserControl(Form parent) : this()
        {
            Parent = parent;

            refrashListView();
        }

        public void refrashListView()
        {
            try
            {
                EvaluationListView.Items.Clear();
                EvaluationListView.Items.AddRange(DataManager.allEvaluationLvis.Values.Where(x => (showOriginalEvaluationCheckBox.Checked || x.SubItems[x.SubItems.Count - 1].Text == "1")).ToArray());
                if (EvaluationListView.SelectedItems.Count > 0)
                {
                    EvaluationListView.EnsureVisible(EvaluationListView.SelectedItems[0].Index);
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

        public ListView getEvaluationListView()
        {
            return EvaluationListView;
        }

        private void showOriginalEvaluationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            refrashListView();
        }

        private void newEvaluationButton_Click(object sender, EventArgs e)
        {
            EvaluationInfoForm form = new EvaluationInfoForm((Form)Parent);
            form.ShowDialog();
        }

        private void editEvaluationButton_Click(object sender, EventArgs e)
        {
            editEvaluation();
        }

        public void editEvaluation()
        {
            if (EvaluationListView.SelectedItems.Count > 0)
            {
                ListViewItem lvi = EvaluationListView.SelectedItems[0];

                EvaluationInfoForm form = new EvaluationInfoForm((Form)Parent);
                form.EvaluationId = lvi.SubItems[0].Text;

                /*mainForm.loadDataForm.getTotalProgressBar().Maximum = 0;
                mainForm.loadDataForm.getTotalProgressBar().Value = 0;*/

                MainForm mainForm = (MainForm)ParentForm;

                form.readEvaluationInfo();

                form.ShowDialog();
            }
        }

        private void EvaluationListView_DoubleClick(object sender, EventArgs e)
        {
            editEvaluation();
        }

        private void EvaluationListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editEvaluation();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEvaluation();
        }

        public void searchEvaluation()
        {
            string searchText = searchTextBox.Text;
            if (!DataManager.allEvaluationLvis.ContainsKey(searchText))
            {
                Evaluation Evaluation = DataManager.getData<Evaluation>(searchText);
                if (Evaluation != null)
                {
                    ListViewItem lvi = DataManager.createEvaluationLvi(searchText);
                    EvaluationListView.Items.Add(lvi);
                    DataManager.allEvaluationLvis.Add(searchText, lvi);
                }
            }
            bool isSearched = false;

            if (EvaluationListView.Items.Count != 0)
            {
                int startIndex = 0;

                if (EvaluationListView.SelectedItems != null && EvaluationListView.SelectedItems.Count != 0)
                {
                    startIndex = EvaluationListView.SelectedItems[0].Index + 1;
                }

                if (startIndex == EvaluationListView.Items.Count)
                {
                    startIndex = 0;
                }
                int index = startIndex;

                do
                {
                    ListViewItem lvi = EvaluationListView.Items[index];

                    for (int i = 0; i < lvi.SubItems.Count; i++)
                    {
                        if (lvi.SubItems[i].Text.ToLower().Contains(searchText.ToLower()))
                        {
                            lvi.Selected = true;
                            isSearched = true;
                            EvaluationListView.EnsureVisible(lvi.Index);
                            break;
                        }
                    }
                    if (isSearched)
                    {
                        break;
                    }
                    index++;

                    if (index == EvaluationListView.Items.Count)
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
                searchEvaluation();
            }
        }

        private void EvaluationListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectIndex = -1;
            if (EvaluationListView.SelectedItems.Count > 0)
            {
                selectIndex = EvaluationListView.Items.IndexOf(EvaluationListView.SelectedItems[0]);
                ListViewItem lvi = EvaluationListView.SelectedItems[0];
                if (lvi.SubItems[lvi.SubItems.Count - 1].Text == "1")
                {
                    deleteEvaluationButton.Enabled = true;
                }
                else
                {
                    deleteEvaluationButton.Enabled = false;
                }
            }
        }

        private void deleteEvaluationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EvaluationListView.SelectedItems.Count > 0)
                {
                    string EvaluationId = EvaluationListView.SelectedItems[0].SubItems[0].Text;

                    if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //写文件
                        string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "/Evaluation_modify.txt";
                        string content = "";
                        using (StreamReader sr = new StreamReader(savePath))
                        {
                            content = "\r\n" + sr.ReadToEnd() + "\r\n";
                        }
                        if (content.Contains("\r\n" + EvaluationId + "\t"))
                        {
                            string pattern = "\r\n" + EvaluationId + ".+?\r\n";
                            Regex rgx = new Regex(pattern);
                            content = rgx.Replace(content, "\r\n");
                        }

                        using (StreamWriter sw = new StreamWriter(savePath))
                        {
                            sw.Write(content.Trim());
                        }
                        DataManager.LoadTextfile(typeof(Evaluation), savePath, true);

                        MainForm mainForm = (MainForm)Parent;

                        //如果原配置文件里没有这个buff，则从所有数据里移除这个buff
                        if (!DataManager.dict["Evaluation"].Contains(EvaluationId))
                        {
                            DataManager.allEvaluationLvis.Remove(EvaluationId);
                            EvaluationListView.Items.Remove(EvaluationListView.SelectedItems[0]);
                        }
                        //否则重新读取数据并替换
                        else
                        {
                            Evaluation Evaluation = DataManager.getData<Evaluation>(EvaluationId);

                            ListViewItem lvi = DataManager.createEvaluationLvi(EvaluationId);
                            if (DataManager.allEvaluationLvis.ContainsKey(EvaluationId))
                            {
                                DataManager.allEvaluationLvis[EvaluationId] = lvi;
                            }
                            //如果不显示则删除列表数据
                            if (showOriginalEvaluationCheckBox.Checked)
                            {
                                for (int i = 0; i < EvaluationListView.Items.Count; i++)
                                {
                                    if (EvaluationListView.Items[i].SubItems[0].Text == EvaluationId)
                                    {
                                        EvaluationListView.Items[i] = lvi;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                EvaluationListView.Items.Remove(EvaluationListView.SelectedItems[0]);
                            }

                        }
                        deleteEvaluationButton.Enabled = false;
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

            if (DataManager.dict.ContainsKey("Evaluation"))
            {
                DataManager.dict.Remove("Evaluation");
            }
            DataManager.LoadTextfile("Evaluation");

            DataManager.allEvaluationLvis.Clear();
            DataManager.allEvaluationLvis = DataManager.createEvaluationLvis();

            refrashListView();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Evaluation.txt";

            if (EvaluationListView.SelectedItems.Count > 0 && EvaluationListView.SelectedItems[0].SubItems[EvaluationListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Evaluation_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Evaluation_modify.txt";
            }
            System.Diagnostics.Process.Start(filePath);
        }

        private void OpenFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = DataManager.textFilePath + "\\" + "Evaluation.txt";

            if (EvaluationListView.SelectedItems.Count > 0 && EvaluationListView.SelectedItems[0].SubItems[EvaluationListView.SelectedItems[0].SubItems.Count - 1].Text == "1" && File.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Evaluation_modify.txt"))
            {
                filePath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Evaluation_modify.txt";
            }

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + filePath;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
