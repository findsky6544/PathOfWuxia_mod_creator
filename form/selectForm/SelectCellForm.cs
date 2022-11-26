using Heluo.Battle;
using Heluo.Data;
using Heluo.Hexagon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UnityEngine;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using Graphics = System.Drawing.Graphics;

namespace 侠之道mod制作器
{
    public partial class SelectCellForm : Form
    {
        public TextBox textBox;
        public List<int> selectCellNumbers = new List<int>();
        public CellData currentCell = null;
        public bool isMultiSelect = false;

        public float scale = 1f;


        public SelectCellForm()
        {
            InitializeComponent();

            initBattleGridComboBox();

            panel2.MouseWheel += new MouseEventHandler(panel2_MouseWheel);
        }
        public SelectCellForm(Form owner, TextBox textBox, bool isMultiSelect) : this()
        {
            Owner = owner;

            this.textBox = textBox;

            Text = owner.Text + Text;

            this.isMultiSelect = isMultiSelect;

            selectCellNumbersTextBox.Text = textBox.Text;

            Form form = owner;
            while (form.GetType() != typeof(ScheduleInfoForm))
            {
                form = form.Owner;
            }
            ScheduleInfoForm scheduleInfoForm = (ScheduleInfoForm)form;
            string scheduleId = scheduleInfoForm.scheduleId;

            if (!DataManager.dict.ContainsKey("BattleArea"))
            {
                DataManager.LoadTextfile("BattleArea");
            }
            bool hasBattleMap = false;
            if (DataManager.dict["BattleArea_cus"] != null)
            {
                Dictionary<string, BattleArea> dict = (Dictionary<string, BattleArea>)DataManager.dict["BattleArea_cus"];
                foreach (KeyValuePair<string, BattleArea> kv in dict)
                {
                    BattleArea battleArea = kv.Value;
                    if (battleArea.ScheduleID == scheduleId)
                    {
                        hasBattleMap = true;
                        BattleGrid battleGrid = DataManager.getData<BattleGrid>(battleArea.BattleMap);
                        battleGridComboBox.Text = battleGrid.Id + "-" + battleGrid.MapId + "-" + battleGrid.Remark;
                        break;
                    }
                }
            }
            if (!hasBattleMap)
            {
                Dictionary<string, BattleArea> dict = (Dictionary<string, BattleArea>)DataManager.dict["BattleArea"];
                foreach (KeyValuePair<string, BattleArea> kv in dict)
                {
                    BattleArea battleArea = kv.Value;
                    if (battleArea.ScheduleID == scheduleId)
                    {
                        hasBattleMap = true;
                        BattleGrid battleGrid = DataManager.getData<BattleGrid>(battleArea.BattleMap);
                        battleGridComboBox.Text = battleGrid.Id + "-" + battleGrid.MapId + "-" + battleGrid.Remark;
                        break;
                    }
                }
            }
            if (!hasBattleMap)
            {
                MessageBox.Show("请先于battleArea中配置战斗网格编号");
                Close();
            }
        }

        public void initBattleGridComboBox()
        {
            battleGridComboBox.DisplayMember = "value";
            battleGridComboBox.ValueMember = "key";

            if (!DataManager.dict.ContainsKey("BattleGrid"))
            {
                DataManager.LoadTextfile("BattleGrid");
            }
            Dictionary<string, BattleGrid> battleGrid = (Dictionary<string, BattleGrid>)DataManager.dict["BattleGrid"];

            foreach (KeyValuePair<string, BattleGrid> kv in battleGrid)
            {
                ComboBoxItem cbi = new ComboBoxItem(kv.Key, kv.Key + "-" + kv.Value.MapId + "-" + kv.Value.Remark);
                battleGridComboBox.Items.Add(cbi);
            }
            battleGrid = (Dictionary<string, BattleGrid>)DataManager.dict["BattleGrid_cus"];

            foreach (KeyValuePair<string, BattleGrid> kv in battleGrid)
            {
                ComboBoxItem cbi = new ComboBoxItem(kv.Key, kv.Key + "-" + kv.Value.MapId + "-" + kv.Value.Remark);
                battleGridComboBox.Items.Add(cbi);
            }
        }

        private void SelectNpcForm_Shown(object sender, EventArgs e)
        {
            //searchBuffer(textBox.Text, true);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            textBox.Text = selectCellNumbersTextBox.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        float minX = 0;
        float minZ = 0;
        float maxX = 0;
        float maxZ = 0;
        private void battleGridComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            minX = 0;
            maxX = 0;
            minZ = 0;
            maxZ = 0;

            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);


            BattleGrid battleGrid = null;
            if (DataManager.dict["BattleGrid_cus"].Contains(((ComboBoxItem)battleGridComboBox.SelectedItem).key))
            {
                battleGrid = (BattleGrid)DataManager.dict["BattleGrid_cus"][((ComboBoxItem)battleGridComboBox.SelectedItem).key];
            }
            else
            {
                battleGrid = (BattleGrid)DataManager.dict["BattleGrid"][((ComboBoxItem)battleGridComboBox.SelectedItem).key];
            }

            HexOrientation _orientation = (WuxiaBattleGrid.LayoutType)battleGrid.LayoutType != WuxiaBattleGrid.LayoutType.layout_pointy ? HexOrientation.layout_flat : HexOrientation.layout_flat;
            List<CellData> AllCells = battleGrid.AllCells;




            for (int i = 0; i < AllCells.Count; i++)
            {
                CellData cellData = AllCells[i];
                HexCoord hexCoord = new HexCoord(cellData.Coord);
                Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 60);
                Vector3 Pos = cellData.Pos;

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
            panel1.MinimumSize = panel2.Size;

            panel1.Width = (int)(maxX - minX) + 50;
            panel1.Height = (int)(maxZ - minZ) + 50;

            panel2.AutoScrollMinSize = panel1.Size;

            repaint();
        }

        bool isRepainting = false;
        public void repaint()
        {
            if (!isRepainting)
            {
                isRepainting = true;
                BattleGrid battleGrid = (BattleGrid)DataManager.dict["BattleGrid"][((ComboBoxItem)battleGridComboBox.SelectedItem).key];

                HexOrientation _orientation = (WuxiaBattleGrid.LayoutType)battleGrid.LayoutType != WuxiaBattleGrid.LayoutType.layout_pointy ? HexOrientation.layout_flat : HexOrientation.layout_flat;
                List<CellData> AllCells = battleGrid.AllCells;

                Graphics g = panel1.CreateGraphics();

                for (int i = 0; i < AllCells.Count; i++)
                {
                    CellData cellData = AllCells[i];
                    HexCoord hexCoord = new HexCoord(cellData.Coord);
                    Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 50);

                    if (cellData == currentCell)
                    {
                        g.DrawEllipse(new Pen(Color.Red), vector.x - minX, vector.y - minZ, 80, 80);
                        g.DrawString(hexCoord.Number.ToString(), new Font("宋体", 10), new SolidBrush(Color.Red), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString("(" + hexCoord.X + "," + hexCoord.Y + "," + hexCoord.Z + ")", new Font("宋体", 10), new SolidBrush(Color.Red), vector.x - minX, vector.y - minZ + 40);
                    }
                    else
                    {
                        g.DrawEllipse(new Pen(Color.Black), vector.x - minX, vector.y - minZ, 80, 80);
                        g.DrawString(hexCoord.Number.ToString(), new Font("宋体", 10), new SolidBrush(Color.Black), vector.x - minX, vector.y - minZ + 30);
                        g.DrawString("(" + hexCoord.X + "," + hexCoord.Y + "," + hexCoord.Z + ")", new Font("宋体", 10), new SolidBrush(Color.Black), vector.x - minX, vector.y - minZ + 40);
                    }

                    if (selectCellNumbers.Contains(hexCoord.Number))
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), vector.x - minX + 30, vector.y - minZ + 30, 20, 20);
                        g.DrawString((selectCellNumbers.IndexOf(hexCoord.Number) + 1).ToString(), new Font("宋体", 10), new SolidBrush(Color.White), vector.x - minX + 35, vector.y - minZ + 35);
                    }
                }

                isRepainting = false;
            }


        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (battleGridComboBox.SelectedIndex != -1)
            {
                BattleGrid battleGrid = (BattleGrid)DataManager.dict["BattleGrid"][((ComboBoxItem)battleGridComboBox.SelectedItem).key];
                HexOrientation _orientation = (WuxiaBattleGrid.LayoutType)battleGrid.LayoutType != WuxiaBattleGrid.LayoutType.layout_pointy ? HexOrientation.layout_flat : HexOrientation.layout_flat;
                List<CellData> AllCells = battleGrid.AllCells;


                bool isSelectCell = false;
                for (int i = 0; i < AllCells.Count; i++)
                {
                    CellData cellData = AllCells[i];
                    HexCoord hexCoord = new HexCoord(cellData.Coord);
                    Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 50);

                    if (e.X >= vector.x - minX && e.X <= vector.x - minX + 80 && e.Y >= vector.y - minZ && e.Y <= vector.y - minZ + 80)
                    {
                        isSelectCell = true;
                        currentCell = cellData;
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
                    currentCell = null;
                }
                repaint();
            }
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

        private void panel1_Click(object sender, EventArgs e)
        {
            if (currentCell != null)
            {

                HexCoord hexCoord = new HexCoord(currentCell.Coord);
                if (selectCellNumbers.Contains(hexCoord.Number))
                {
                    selectCellNumbers.Remove(hexCoord.Number);
                    BattleGrid battleGrid = (BattleGrid)DataManager.dict["BattleGrid"][((ComboBoxItem)battleGridComboBox.SelectedItem).key];
                    HexOrientation _orientation = (WuxiaBattleGrid.LayoutType)battleGrid.LayoutType != WuxiaBattleGrid.LayoutType.layout_pointy ? HexOrientation.layout_flat : HexOrientation.layout_flat;
                    Vector2 vector = HexCoord.HexToPixel(hexCoord, Vector2.zero, _orientation, 50);

                    Graphics g = panel1.CreateGraphics();
                    g.FillEllipse(new SolidBrush(panel1.BackColor), vector.x - minX + 30, vector.y - minZ + 30, 20, 20);
                }
                else
                {
                    if (!isMultiSelect && selectCellNumbers.Count > 0)
                    {
                        MessageBox.Show("只能选择一个格子");
                        return;
                    }
                    else
                    {
                        selectCellNumbers.Add(hexCoord.Number);
                    }

                }
            }

            string selectCellNumbersStr = "";
            for (int i = 0; i < selectCellNumbers.Count; i++)
            {
                selectCellNumbersStr += selectCellNumbers[i] + ",";
            }
            if (selectCellNumbersStr.Length > 0)
            {
                selectCellNumbersStr = selectCellNumbersStr.Substring(0, selectCellNumbersStr.Length - 1);
            }
            selectCellNumbersTextBox.Text = selectCellNumbersStr;

            repaint();
        }

        private void selectCellNumbersTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                selectCellNumbers.Clear();

                string[] strs = selectCellNumbersTextBox.Text.Split(',');

                for (int i = 0; i < strs.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strs[i]))
                    {
                        selectCellNumbers.Add(int.Parse(strs[i]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectCellNumbersTextBox_Enter(object sender, EventArgs e)
        {
            selectCellNumbersTextBox.Tag = selectCellNumbersTextBox.Text;
        }

        private void selectCellNumbersTextBox_Leave(object sender, EventArgs e)
        {
            if (!isMultiSelect && selectCellNumbersTextBox.Text.Contains(","))
            {
                MessageBox.Show("只能选择一个格子");
                selectCellNumbersTextBox.Text = selectCellNumbersTextBox.Tag.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
