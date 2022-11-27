using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Forge = Heluo.Data.Forge;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace 侠之道mod制作器
{
    public partial class ForgeInfoForm : Form
    {

        public string ForgeId;
        public ForgeInfoForm()
        {
            InitializeComponent();
        }

        public ForgeInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public ForgeInfoForm(string ForgeId) : this()
        {
            this.ForgeId = ForgeId;
        }

        public void readForgeInfo()
        {
            idTextBox.Text = ForgeId;
            idTextBox.Enabled = false;

            Forge Forge = DataManager.getData<Forge>(ForgeId);

            RemarkTextBox.Text = Forge.Remark;
            PropsIdTextBox.Text = Forge.PropsId;
            LevelNumericUpDown.Value = Forge.Level;
            OpenRoundNumericUpDown.Value = Forge.OpenRound;
            IsSpecialCheckBox.Checked = Forge.IsSpecial;
            IsRestrictionCountCheckBox.Checked = Forge.IsRestrictionCount;
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
                if (string.IsNullOrEmpty(RemarkTextBox.Text))
                {
                    MessageBox.Show("请输入名称");
                    return;
                }
                if (string.IsNullOrEmpty(PropsIdTextBox.Text))
                {
                    MessageBox.Show("请输入Prefab名称");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Forge_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + PropsIdTextBox.Text + "\t" + LevelNumericUpDown.Text + "\t" + OpenRoundNumericUpDown.Text + "\t" + IsSpecialCheckBox.Checked + "\t" + IsRestrictionCountCheckBox.Checked;


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

                DataManager.LoadTextfile(typeof(Forge), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Forge列表
                //获得列表项
                ListViewItem lvi = DataManager.createForgeLvi(idTextBox.Text);


                

                ForgeTabControlUserControl ForgeTabControlUserControl = (ForgeTabControlUserControl)MainForm.userControls["Forge"];

                if (DataManager.allForgeLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allForgeLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allForgeLvis.Add(idTextBox.Text, lvi);
                    ForgeTabControlUserControl.getForgeListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectPropsButton_Click(object sender, EventArgs e)
        {
            SelectPropsForm form = new SelectPropsForm(this, PropsIdTextBox, false, new string[] { "all" }, new string[] { "all" });
            form.ShowDialog();
        }
    }

}
