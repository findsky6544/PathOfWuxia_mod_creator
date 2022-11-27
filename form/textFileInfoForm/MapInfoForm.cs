using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;
using Map = Heluo.Data.Map;

namespace 侠之道mod制作器
{
    public partial class MapInfoForm : Form
    {

        public string MapId;

        public string currentCell = "";
        public int selectCellNumber = -1;
        public MapInfoForm()
        {
            InitializeComponent();
        }

        public MapInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public MapInfoForm(string MapId) : this()
        {
            this.MapId = MapId;
        }

        public void readMapInfo()
        {
            idTextBox.Text = MapId;
            idTextBox.Enabled = false;

            Map Map = DataManager.getData<Map>(MapId);

            NameTextBox.Text = Map.Name;
            DefaultPositionTextBox.Text = Map.DefaultPosition.ToString();
            DefaultRotationTextBox.Text = Map.DefaultRotation.ToString();
            ScenesTextBox.Text = Map.Scenes;
            PlaceTextBox.Text = Map.Place;
            MusicTextBox.Text = Map.Music;
            BattleDisNumericUpDown.Text = Map.BattleDis.ToString();

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
                if (string.IsNullOrEmpty(ScenesTextBox.Text))
                {
                    MessageBox.Show("请输入场景编号");
                    return;
                }
                if (string.IsNullOrEmpty(PlaceTextBox.Text))
                {
                    MessageBox.Show("请输入场所编号");
                    return;
                }
                if (string.IsNullOrEmpty(DefaultPositionTextBox.Text))
                {
                    MessageBox.Show("请输入预设位置");
                    return;
                }
                if (string.IsNullOrEmpty(DefaultRotationTextBox.Text))
                {
                    MessageBox.Show("请输入预设旋转值");
                    return;
                }
                if (string.IsNullOrEmpty(BattleDisNumericUpDown.Text))
                {
                    MessageBox.Show("请输入战斗最远距离");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\Map_modify.txt";
                if (!File.Exists(savePath))
                {
                    FileStream fs = File.Create(savePath);fs.Close();
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + NameTextBox.Text + "\t" + ScenesTextBox.Text + "\t" + PlaceTextBox.Text + "\t" + DefaultPositionTextBox.Text.Trim().Substring(1, DefaultPositionTextBox.Text.Trim().Length - 2) + "\t" + DefaultRotationTextBox.Text.Trim().Substring(1, DefaultRotationTextBox.Text.Trim().Length - 2) + "\t" + MusicTextBox.Text + "\t" + BattleDisNumericUpDown.Text;


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

                DataManager.LoadTextfile(typeof(Map), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新Map列表
                //获得列表项
                ListViewItem lvi = DataManager.createMapLvi(idTextBox.Text);


                

                MapTabControlUserControl MapTabControlUserControl = (MapTabControlUserControl)MainForm.userControls["Map"];

                if (DataManager.allMapLvis.ContainsKey(idTextBox.Text))
                {
                    ListViewItem oldLvi = DataManager.allMapLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allMapLvis.Add(idTextBox.Text, lvi);
                    MapTabControlUserControl.getMapListView().Items.Add(lvi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
