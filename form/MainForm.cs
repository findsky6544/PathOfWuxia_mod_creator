using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using 侠之道mod制作器.form;
using static Mono.Security.X509.X520;

namespace 侠之道mod制作器
{
    public partial class MainForm : Form
    {
        public static string modName = "";
        public static string savePath = "";
        private static string logPath = "output.log";
        public static string[] textfilesArray = new string[] { "Adjustment", "Alchemy", "AnimationMapping", "BattleArea", "BattleEventCube", "BattleGrid", "Book", "CharacterBehaviour", "CharacterExterior", "CharacterInfo", "Elective", "EndingMovie", "Evaluation", "EventCube", "Favorability", "Forge", "GameFormula", "Help", "HelpDescription", "Mantra", "Map", "Npc", "Nurturance", "Props", "Quest", "RegistrationBonus", "Reward", "Round", "Shop", "Skill", "StringTable", "Talk", "Trait" };

        //public Thread showLoadDataFormThread = null;
        public static LoadDataForm loadDataForm = new LoadDataForm();

        public static Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();



        public MainForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;//干掉检测 不再检测跨线程

            if (File.Exists(logPath))
            {
                StreamWriter sr = new StreamWriter(logPath);

                sr.Write("");
                sr.Close();
            }
            XMLHelper.ReadXml();

            //ConfigTreeView.Nodes.Clear();
            //ConfigTreeView.Nodes.Add(modName);
            //LoadModDictionary(modName, ConfigTreeView.Nodes[0]);
            //LoadEffect();

            //ConfigTreeView.ExpandAll();



            /*MainForm.allScheduleLvis = createScheduleLvis();
            ScheduleTabControlUserControl scheduleTabControlUserControl = new ScheduleTabControlUserControl(this);

            userControls.Add("Schedule", scheduleTabControlUserControl);

            ConfigPageTabControl.TabPages.Add(scheduleTabControlUserControl.GetTabControl().TabPages[0]);*/
        }

        public void showLoadDataForm()
        {
            loadDataForm.getOneProgressBar().Maximum = 1;
            loadDataForm.getOneProgressBar().Value = 0;
            if (!loadDataForm.Visible)
            {
                loadDataForm.ShowDialog();
            }
        }

        public TreeView getConfigTreeView()
        {
            return ConfigTreeView;
        }

        public TabControl getConfigPageTabControl()
        {
            return ConfigPageTabControl;
        }

        private void newModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["NewModForm"];  //查找是否打开过Form1窗体
            if (f == null)  //没打开过
            {
                NewModForm form = new NewModForm();
                form.Owner = this;
                if (form.ShowDialog() == DialogResult.OK)   //重新new一个Show出来
                {
                    DataManager.dict.Clear();
                    userControls.Clear();
                    foreach (TabPage tabPage in ConfigPageTabControl.TabPages)
                    {
                        ConfigPageTabControl.TabPages.Remove(tabPage);
                    }
                }
            }
            else
            {
                f.Focus();   //打开过就让其获得焦点
            }
        }

        private void loadModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FolderPicker();
            dialog.InputPath = @"c:\windows\system32";
            if (dialog.ShowDialog(this.Handle) == true)
            {
                /*}
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择mod文件夹";
                string[] pathArray;
                if (dialog.ShowDialog() == DialogResult.OK)
                {*/
                string[] pathArray;
                pathArray = dialog.ResultPath.Split('\\');
                savePath = dialog.ResultPath.Substring(0, dialog.ResultPath.LastIndexOf("\\")) + "\\";

                modName = pathArray[pathArray.Length - 1];
                DataManager.dict.Clear();
                userControls.Clear();
                foreach (TabPage tabPage in ConfigPageTabControl.TabPages)
                {
                    ConfigPageTabControl.TabPages.Remove(tabPage);
                }
                ConfigTreeView.Nodes.Clear();
                TreeNode modNameNode = ConfigTreeView.Nodes.Add(modName);
                TreeNode configNode = modNameNode.Nodes.Add("config");
                LoadConfigTree("config", configNode);
                ConfigTreeView.ExpandAll();
                //LoadDatas();
            }
        }

        public void LoadConfigTree(string path, TreeNode treeNode)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            List<DirectoryInfo> directoryList = folder.GetDirectories().ToList();
            for (int i = 0; i < directoryList.Count; i++)
            {
                string name = directoryList[i].Name;
                if (name == "chs" || name == "cht")
                {
                    LoadConfigTree(path + '\\' + name, treeNode);
                    continue;
                }
                if (name.ToLower() == "effect" || name.ToLower() == "movepath")
                {
                    continue;
                }
                TreeNode node = treeNode.Nodes.Add(name);
                if (name.ToLower() == "buffer" || name.ToLower() == "schedule" || name.ToLower() == "cinematic")
                {
                    continue;
                }
                LoadConfigTree(path + '\\' + name, node);
            }
            List<FileInfo> fileList = folder.GetFiles().ToList();
            if (fileList != null)
            {
                for (int i = 0; i < fileList.Count; i++)
                {
                    string name = fileList[i].Name;
                    if (folder.Name == "textfiles" && !textfilesArray.Contains(name.Split('.')[0]))
                    {
                        continue;
                    }
                    treeNode.Nodes.Add(name);
                }
            }
        }

        //双击树节点
        private void ConfigTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TabPage tabPage = null;
            for (int i = 0; i < ConfigPageTabControl.TabCount; i++)
            {
                tabPage = ConfigPageTabControl.TabPages[i];
                if (tabPage.Text.ToLower().Trim() == e.Node.Text.ToLower() || tabPage.Text.ToLower().Trim() == (e.Node.Parent.Text + "\\" + e.Node.Text).ToLower())
                {
                    ConfigPageTabControl.SelectedIndex = i;
                    return;
                }
                if (tabPage.Text.ToLower().Trim() + ".txt" == e.Node.Text.ToLower() || tabPage.Text.ToLower().Trim() + ".txt" == e.Node.Parent.Text.ToLower() + "\\" + e.Node.Text.ToLower())
                {
                    ConfigPageTabControl.SelectedIndex = i;
                    return;
                }
            }
            UserControl tabControlUserControl = null;
            if (e.Node.Text == "buffer")
            {
                if (!DataManager.dict.ContainsKey("buffer") || DataManager.dict["buffer"].Count < new DirectoryInfo(DataManager.cinematicPath).GetFiles().ToList().Count)
                {
                    Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                    loadDataFormThread.Start();
                    DataManager.LoadBuffer(false);
                    loadDataForm.getOneProgressBar().Value++;
                    loadDataForm.getOneLabel().Text = loadDataForm.getOneProgressBar().Value + "/" + loadDataForm.getOneProgressBar().Maximum;
                }
                DataManager.allBufferLvis = DataManager.createBufferLvis();

                tabControlUserControl = new BufferTabControlUserControl(this);
                tabPage = ((BufferTabControlUserControl)tabControlUserControl).GetTabControl().TabPages[0];
                userControls.Add(e.Node.Text, tabControlUserControl);
            }
            else if (e.Node.Text == "schedule")
            {
                if (e.Node.Parent.Text == "battle")
                {
                    if (!DataManager.dict.ContainsKey("battle/schedule") || DataManager.dict["battle/schedule"].Count < new DirectoryInfo(DataManager.cinematicPath).GetFiles().ToList().Count)
                    {
                        Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                        loadDataFormThread.Start();
                        DataManager.LoadBattleSchedule(false);
                        loadDataForm.getOneProgressBar().Value++;
                        loadDataForm.getOneLabel().Text = loadDataForm.getOneProgressBar().Value + "/" + loadDataForm.getOneProgressBar().Maximum;
                    }
                    DataManager.allBattleScheduleLvis = DataManager.createBattleScheduleLvis();

                    tabControlUserControl = new BattleScheduleTabControlUserControl(this);
                    tabPage = ((BattleScheduleTabControlUserControl)tabControlUserControl).GetTabControl().TabPages[0];
                }
                else if (e.Node.Parent.Text == "config")
                {
                    if (!DataManager.dict.ContainsKey("config/schedule") || DataManager.dict["config/schedule"].Count < new DirectoryInfo(DataManager.cinematicPath).GetFiles().ToList().Count)
                    {
                        Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                        loadDataFormThread.Start();
                        DataManager.LoadConfigSchedule(false);
                        loadDataForm.getOneProgressBar().Value++;
                        loadDataForm.getOneLabel().Text = loadDataForm.getOneProgressBar().Value + "/" + loadDataForm.getOneProgressBar().Maximum;
                    }
                    DataManager.allConfigScheduleLvis = DataManager.createConfigScheduleLvis();

                    tabControlUserControl = new ConfigScheduleTabControlUserControl(this);
                    tabPage = ((ConfigScheduleTabControlUserControl)tabControlUserControl).GetTabControl().TabPages[0];
                }
                userControls.Add(e.Node.Parent.Text + "\\" + e.Node.Text, tabControlUserControl);

            }
            else if (e.Node.Text == "cinematic")
            {
                if (!DataManager.dict.ContainsKey("cinematic") || DataManager.dict["cinematic"].Count < new DirectoryInfo(DataManager.cinematicPath).GetFiles().ToList().Count)
                {
                    Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                    loadDataFormThread.Start();
                    DataManager.LoadCinematic(false);
                    if (loadDataForm.getOneProgressBar().Value < loadDataForm.getOneProgressBar().Maximum)
                    {
                        loadDataForm.getOneProgressBar().Value++;
                    }
                    loadDataForm.getOneLabel().Text = loadDataForm.getOneProgressBar().Value + "/" + loadDataForm.getOneProgressBar().Maximum;
                }
                DataManager.allCinematicLvis = DataManager.createCinematicLvis();

                tabControlUserControl = new CinematicTabControlUserControl(this);
                tabPage = ((CinematicTabControlUserControl)tabControlUserControl).GetTabControl().TabPages[0];
                userControls.Add(e.Node.Text, tabControlUserControl);
            }
            else if (e.Node.Text.Contains(".txt"))
            {
                string name = e.Node.Text.Split('.')[0];
                if (!DataManager.dict.ContainsKey(name) || DataManager.dict[name].Count == 0)
                {
                    Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                    loadDataFormThread.Start();
                    DataManager.LoadTextfile(name);
                    loadDataForm.getOneProgressBar().Value++;
                    loadDataForm.getOneLabel().Text = loadDataForm.getOneProgressBar().Value + "/" + loadDataForm.getOneProgressBar().Maximum;
                }
                Type clazz = Type.GetType("侠之道mod制作器.DataManager");
                FieldInfo field = clazz.GetField("all" + name + "Lvis");
                if (field == null)
                {
                    MessageBox.Show("未完成");
                    return;
                }
                string methodName = "create" + name + "Lvis";
                if (clazz.GetMethod(methodName) == null)
                {
                    MessageBox.Show("未完成");
                    return;
                }
                field.SetValue(null, clazz.InvokeMember(methodName, BindingFlags.InvokeMethod, null, null, new object[] { }));
                //DataManager.allTalkLvis = DataManager.createTalkLvis();

                clazz = Type.GetType("侠之道mod制作器." + name + "TabControlUserControl");
                if (clazz == null)
                {
                    MessageBox.Show("未完成");
                    return;
                }
                tabControlUserControl = (UserControl)clazz.GetConstructor(new Type[] { typeof(Form) }).Invoke(new Object[] { this });
                TabControl tabControl = (TabControl)clazz.InvokeMember("GetTabControl", BindingFlags.InvokeMethod, null, tabControlUserControl, new object[] { });

                tabPage = tabControl.TabPages[0];
                userControls.Add(e.Node.Text.Split('.')[0], tabControlUserControl);
            }
            if (tabPage != null)
            {
                ConfigPageTabControl.TabPages.Add(tabPage);
                ConfigPageTabControl.SelectedTab = tabPage;
            }


        }

        //页签添加关闭按钮
        int selectCloseButtonIndex = -1;
        bool isMouseDownOnCloseButton = false;
        private void ConfigPageTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Empty), e.Bounds.Right - 16, e.Bounds.Top + 6, 10, 10);
            if (e.Index == selectCloseButtonIndex)
            {
                if (isMouseDownOnCloseButton)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Brown), e.Bounds.Right - 16, e.Bounds.Top + 6, 10, 10);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds.Right - 16, e.Bounds.Top + 6, 10, 10);
                }
            }
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(ConfigPageTabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void ConfigPageTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnCloseButton = false;
            if (selectCloseButtonIndex > -1)
            {
                Rectangle r = ConfigPageTabControl.GetTabRect(selectCloseButtonIndex);
                Rectangle closeButton = new Rectangle(r.Right - 16, r.Top + 6, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    //if (MessageBox.Show("确认关闭"+ ConfigPageTabControl.TabPages[selectCloseButtonIndex].Text.Trim() + "吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        userControls.Remove(userControls.Keys.ToArray()[selectCloseButtonIndex]);
                        ConfigPageTabControl.TabPages.RemoveAt(selectCloseButtonIndex);
                    }
                }
                selectCloseButtonIndex = -1;
                TabControl configPageTabControl = (TabControl)sender;
                configPageTabControl.Refresh();
            }
        }

        public bool inside = false;
        private void ConfigPageTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            bool insideTemp = false;
            selectCloseButtonIndex = -1;
            for (int i = 0; i < ConfigPageTabControl.TabPages.Count; i++)
            {
                Rectangle r = ConfigPageTabControl.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 16, r.Top + 6, 10, 10);
                insideTemp = closeButton.Contains(e.Location);

                if (insideTemp)
                {
                    selectCloseButtonIndex = i;
                    break;
                }
            }
            if (insideTemp != inside)
            {
                inside = insideTemp;

                TabControl configPageTabControl = (TabControl)sender;
                configPageTabControl.Refresh();
            }
        }

        private void ConfigPageTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ConfigPageTabControl.TabPages.Count; i++)
            {
                Rectangle r = ConfigPageTabControl.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 16, r.Top + 6, 10, 10);
                if (closeButton.Contains(e.Location))
                {
                    selectCloseButtonIndex = i;
                    isMouseDownOnCloseButton = true;
                    TabControl configPageTabControl = (TabControl)sender;
                    configPageTabControl.Refresh();
                    break;
                }
            }
        }

        private void ConfigPageTabControl_MouseLeave(object sender, EventArgs e)
        {
            isMouseDownOnCloseButton = false;
            TabControl configPageTabControl = (TabControl)sender;
            configPageTabControl.Refresh();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }
    }
}
