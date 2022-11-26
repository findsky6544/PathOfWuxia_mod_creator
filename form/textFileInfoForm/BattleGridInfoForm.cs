using Heluo.Battle;
using Heluo.Data;
using Heluo.Hexagon;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UnityEngine;
using BattleGrid = Heluo.Data.BattleGrid;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using Graphics = System.Drawing.Graphics;

namespace 侠之道mod制作器
{
    public partial class BattleGridInfoForm : Form
    {

        public string battleGridId;

        float minX = 0;
        float minZ = 0;
        float maxX = 0;
        float maxZ = 0;

        public string currentCell = "";
        public int selectCellNumber = -1;

        public BattleGridInfoForm()
        {
            InitializeComponent();

            initLayoutTypeComboBox();

            panel2.MouseWheel += new MouseEventHandler(panel2_MouseWheel);
        }

        public BattleGridInfoForm(Form owner) : this()
        {
            Owner = owner;
        }

        public BattleGridInfoForm(string battleGridId) : this()
        {
            this.battleGridId = battleGridId;
        }

        public void initLayoutTypeComboBox()
        {
            LayoutTypeComboBox.DisplayMember = "value";
            LayoutTypeComboBox.ValueMember = "key";


            foreach (WuxiaBattleGrid.LayoutType temp in Enum.GetValues(typeof(WuxiaBattleGrid.LayoutType)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                LayoutTypeComboBox.Items.Add(cbi);
            }
        }

        public void readBattleGridInfo()
        {
            idTextBox.Text = battleGridId;
            idTextBox.Enabled = false;

            BattleGrid battleGrid = DataManager.getData<BattleGrid>(battleGridId);

            MapIdTextBox.Text = battleGrid.MapId;
            RemarkTextBox.Text = battleGrid.Remark;
            for (int i = 0; i < LayoutTypeComboBox.Items.Count; i++)
            {
                if (((ComboBoxItem)LayoutTypeComboBox.Items[i]).key == battleGrid.LayoutType.ToString())
                {
                    LayoutTypeComboBox.SelectedIndex = i;
                    break;
                }
            }
            PositionTextBox.Text = battleGrid.Position.ToString();
            EulerAnglesTextBox.Text = battleGrid.EulerAngles.ToString();
            if (battleGrid.AllCells != null && battleGrid.AllCells.Count > 0)
            {
                for (int i = 0; i < battleGrid.AllCells.Count; i++)
                {
                    CellData cd = battleGrid.AllCells[i];
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = cd.Pos.ToString();
                    lvi.SubItems.Add(cd.Coord.ToString());
                    lvi.SubItems.Add(cd.CellNumber.ToString());
                    lvi.SubItems.Add(cd.Walkable.ToString());
                    lvi.SubItems.Add(cd.InActive.ToString());
                    lvi.SubItems.Add(EnumData.GetDisplayName(cd.Element));
                    lvi.Tag = "{\"Pos\":{\"x\":" + cd.Pos.x
                        + ",\"y\":" + cd.Pos.y
                        + ",\"z\":" + cd.Pos.z
                        + "},\"Coord\":{\"x\":" + cd.Coord.x
                        + ",\"y\":" + cd.Coord.y
                        + "},\"CellNumber\":" + cd.CellNumber
                        + ",\"Walkable\":" + cd.Walkable.ToString().ToLower()
                        + ",\"InActive\":" + cd.InActive.ToString().ToLower()
                        + ",\"Element\":" + ((int)cd.Element).ToString() + "}";
                    AllCellsListView.Items.Add(lvi);
                }
            }

            paintCells();
        }

        public void paintCells()
        {
            minX = 0;
            maxX = 0;
            minZ = 0;
            maxZ = 0;

            Graphics g = cellsPanel.CreateGraphics();
            g.Clear(cellsPanel.BackColor);

            HexOrientation _orientation = HexOrientation.layout_flat;


            for (int i = 0; i < AllCellsListView.Items.Count; i++)
            {
                ListViewItem cellDataLvi = AllCellsListView.Items[i];
                string[] coordStr = Utils.getFieldsList(cellDataLvi.SubItems[1].Text);
                Vector2 coord = new Vector2(float.Parse(coordStr[0]), float.Parse(coordStr[1]));
                HexCoord hexCoord = new HexCoord(coord);
                Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 60);

                if (vector.x < minX)
                {
                    minX = vector.x;
                }
                if (vector.y < minZ)
                {
                    minZ = vector.y;
                }
                if (vector.x > maxX)
                {
                    maxX = vector.x;
                }
                if (vector.y > maxZ)
                {
                    maxZ = vector.y;
                }
            }
            cellsPanel.MinimumSize = panel2.Size;

            cellsPanel.Width = (int)(maxX - minX) + 50;
            cellsPanel.Height = (int)(maxZ - minZ) + 50;

            panel2.AutoScrollMinSize = cellsPanel.Size;

            repaint();
        }

        bool isRepainting = false;
        public void repaint()
        {
            if (!isRepainting)
            {
                isRepainting = true;

                HexOrientation _orientation = HexOrientation.layout_flat;

                Graphics g = cellsPanel.CreateGraphics();

                for (int i = 0; i < AllCellsListView.Items.Count; i++)
                {
                    ListViewItem cellDataLvi = AllCellsListView.Items[i];
                    string[] coordStr = Utils.getFieldsList(cellDataLvi.SubItems[1].Text);
                    Vector2 coord = new Vector2(float.Parse(coordStr[0]), float.Parse(coordStr[1]));
                    HexCoord hexCoord = new HexCoord(coord);
                    Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 50);

                    if (selectCellNumber == int.Parse(cellDataLvi.SubItems[2].Text))
                    {
                        g.DrawEllipse(new Pen(Color.Red), vector.x - minX, vector.y - minZ, 80, 80);
                        //g.DrawString(cellDataLvi.SubItems[2].Text, new Font("宋体", 10), new SolidBrush(Color.Red), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString(hexCoord.Number.ToString(), new Font("宋体", 10), new SolidBrush(Color.Red), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString("(" + hexCoord.X + "," + hexCoord.Y + "," + hexCoord.Z + ")", new Font("宋体", 10), new SolidBrush(Color.Red), vector.x - minX, vector.y - minZ + 40);
                    }
                    else
                    {
                        g.DrawEllipse(new Pen(Color.Black), vector.x - minX, vector.y - minZ, 80, 80);
                        //g.DrawString(cellDataLvi.SubItems[2].Text, new Font("宋体", 10), new SolidBrush(Color.Black), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString(hexCoord.Number.ToString(), new Font("宋体", 10), new SolidBrush(Color.Black), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString("(" + hexCoord.X + "," + hexCoord.Y + "," + hexCoord.Z + ")", new Font("宋体", 10), new SolidBrush(Color.Black), vector.x - minX, vector.y - minZ + 40);
                    }
                }

                isRepainting = false;
            }


        }

        public ListView getAllCellsListView()
        {
            return AllCellsListView;
        }

        private void selectBattleMapButton_Click(object sender, EventArgs e)
        {
            SelectMapForm form = new SelectMapForm(this, MapIdTextBox, false);
            form.ShowDialog();
        }

        private void addCellButton_Click(object sender, EventArgs e)
        {
            CellDataForm form = new CellDataForm(new ListViewItem(), true, this);
            form.ShowDialog();
        }

        private void editCellButton_Click(object sender, EventArgs e)
        {
            if (AllCellsListView.SelectedItems.Count > 0)
            {
                CellDataForm form = new CellDataForm(AllCellsListView.SelectedItems[0], false, this);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择一条数据");
            }
        }

        private void deleteCellButton_Click(object sender, EventArgs e)
        {
            if (AllCellsListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    AllCellsListView.Items.Remove(AllCellsListView.SelectedItems[0]);

                    paintCells();
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
                if (string.IsNullOrEmpty(MapIdTextBox.Text))
                {
                    MessageBox.Show("请输入场景编号");
                    return;
                }
                if (string.IsNullOrEmpty(LayoutTypeComboBox.Text))
                {
                    MessageBox.Show("请输入格子方向");
                    return;
                }
                if (string.IsNullOrEmpty(PositionTextBox.Text))
                {
                    MessageBox.Show("请输入中心点位置");
                    return;
                }
                if (string.IsNullOrEmpty(EulerAnglesTextBox.Text))
                {
                    MessageBox.Show("请输入中心点方向");
                    return;
                }

                //写文件
                string savePath = MainForm.savePath + MainForm.modName + "\\" +DataManager.modTextFilePath + "\\BattleGrid.txt";
                if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                string content = "";
                using (StreamReader sr = new StreamReader(savePath))
                {
                    content = "\r\n" + sr.ReadToEnd() + "\r\n";
                }
                string replacement = idTextBox.Text + "\t" + MapIdTextBox.Text + "\t" + RemarkTextBox.Text + "\t" + ((ComboBoxItem)LayoutTypeComboBox.SelectedItem).key + "\t" + PositionTextBox.Text.Substring(1, PositionTextBox.Text.Length - 2) + "\t" + EulerAnglesTextBox.Text.Substring(1, EulerAnglesTextBox.Text.Length - 2) + "\t";
                if (AllCellsListView.Items.Count > 0)
                {
                    replacement += "[";
                    for (int i = 0; i < AllCellsListView.Items.Count; i++)
                    {
                        replacement += AllCellsListView.Items[i].Tag.ToString() + ",";
                    }
                    replacement = replacement.Substring(0, replacement.Length - 1);
                    replacement += "]";
                }

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

                DataManager.LoadTextfile(typeof(BattleGrid), savePath, true);


                //禁止修改id
                idTextBox.Enabled = false;

                //刷新BattleGrid列表
                //获得列表项
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");


                if (DataManager.allBattleGridLvis.ContainsKey(idTextBox.Text))
                {
                    lvi = DataManager.allBattleGridLvis[idTextBox.Text];
                }

                lvi.Text = idTextBox.Text;
                lvi.SubItems[1].Text = DataManager.getMapsName(MapIdTextBox.Text);
                lvi.SubItems[2].Text = RemarkTextBox.Text;
                lvi.SubItems[3].Text = "1";

                

                BattleGridTabControlUserControl BattleGridTabControlUserControl = (BattleGridTabControlUserControl)MainForm.userControls["BattleGrid"];
                if (DataManager.allBattleGridLvis.ContainsKey(lvi.Text))
                {
                    ListViewItem oldLvi = DataManager.allBattleGridLvis[idTextBox.Text];
                    for (int i = 0; i < oldLvi.SubItems.Count; i++)
                    {
                        oldLvi.SubItems[i].Text = lvi.SubItems[i].Text;
                    }
                }
                else
                {
                    DataManager.allBattleGridLvis.Add(idTextBox.Text, lvi);
                    BattleGridTabControlUserControl.getBattleGridListView().Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cellsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            HexOrientation _orientation = HexOrientation.layout_flat;



            bool isSelectCell = false;
            for (int i = 0; i < AllCellsListView.Items.Count; i++)
            {
                ListViewItem cellDataLvi = AllCellsListView.Items[i];
                string[] coordStr = Utils.getFieldsList(cellDataLvi.SubItems[1].Text);
                Vector2 coord = new Vector2(float.Parse(coordStr[0]), float.Parse(coordStr[1]));
                HexCoord hexCoord = new HexCoord(coord);
                Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 50);

                if (e.X >= vector.x - minX && e.X <= vector.x - minX + 80 && e.Y >= vector.y - minZ && e.Y <= vector.y - minZ + 80)
                {
                    isSelectCell = true;
                    currentCell = cellDataLvi.SubItems[2].Text;
                    break;
                }
            }

            if (isSelectCell)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
                currentCell = "";
            }
            repaint();
        }

        private void SelectCellForm_ResizeEnd(object sender, EventArgs e)
        {
            repaint();
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            if (panel2.VerticalScroll.Value < panel2.VerticalScroll.Maximum
                && panel2.VerticalScroll.Value > panel2.VerticalScroll.Minimum
                && panel2.HorizontalScroll.Value < panel2.HorizontalScroll.Maximum
                && panel2.HorizontalScroll.Value > panel2.HorizontalScroll.Minimum)
            {
                repaint();
            }
        }

        private void panel2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (panel2.VerticalScroll.Value < panel2.VerticalScroll.Maximum
                && panel2.VerticalScroll.Value > panel2.VerticalScroll.Minimum
                && panel2.HorizontalScroll.Value < panel2.HorizontalScroll.Maximum
                && panel2.HorizontalScroll.Value > panel2.HorizontalScroll.Minimum)
            {
                repaint();
            }
        }

        private void cellsPanel_Click(object sender, EventArgs e)
        {
            if (currentCell != "")
            {
                if (selectCellNumber != int.Parse(currentCell))
                {
                    selectCellNumber = int.Parse(currentCell);
                    for (int i = 0; i < AllCellsListView.Items.Count; i++)
                    {
                        if (currentCell == AllCellsListView.Items[i].SubItems[2].Text)
                        {
                            AllCellsListView.Items[i].Selected = true;
                            AllCellsListView.EnsureVisible(i);
                        }
                    }
                }
                else
                {
                    selectCellNumber = -1;
                    AllCellsListView.SelectedItems[0].Selected = false;
                }
            }

            repaint();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            repaint();
        }

        private void AllCellsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AllCellsListView.SelectedItems.Count > 0)
            {
                selectCellNumber = int.Parse(AllCellsListView.SelectedItems[0].SubItems[2].Text);
                repaint();
            }
        }
    }

}
