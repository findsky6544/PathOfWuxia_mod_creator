using Heluo.Data;
using Heluo.Hexagon;
using System;
using System.Windows.Forms;
using UnityEngine;

namespace 侠之道mod制作器
{
    public partial class CellDataForm : Form
    {
        public bool isAdd;
        public CellDataForm()
        {
            InitializeComponent();

            initElementComboBox();
        }
        public CellDataForm(ListViewItem lvi, bool isAdd, Form owner) : this()
        {
            Owner = owner;

            string fields = "";
            if (lvi.Tag != null)
            {
                fields = lvi.Tag.ToString();
            }

            if (!isAdd && !string.IsNullOrEmpty(fields))
            {
                string[] fieldsList = Utils.getFieldsList(fields);

                PosTextBox.Text = "{" + fieldsList[2] + ", " + fieldsList[4] + ", " + fieldsList[6] + "}";
                CoordTextBox.Text = "{" + fieldsList[9] + ", " + fieldsList[11] + "}";
                CellNumberNumericUpDown.Text = fieldsList[13];
                WalkableCheckBox.Checked = fieldsList[15] == "true";
                InActiveCheckBox.Checked = fieldsList[17] == "true";
                ElementComboBox.SelectedIndex = int.Parse(fieldsList[19]);
            }


            this.isAdd = isAdd;

            Text = owner.Text + Text;
        }

        public void initElementComboBox()
        {
            ElementComboBox.DisplayMember = "value";
            ElementComboBox.ValueMember = "key";


            foreach (Element temp in Enum.GetValues(typeof(Element)))
            {
                ComboBoxItem cbi = new ComboBoxItem(((int)temp).ToString(), EnumData.GetDisplayName(temp));
                ElementComboBox.Items.Add(cbi);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PosTextBox.Text == "")
                {
                    MessageBox.Show("请输入格子位置");
                    return;
                }
                if (CoordTextBox.Text == "")
                {
                    MessageBox.Show("请输入格子坐标");
                    return;
                }
                if (CellNumberNumericUpDown.Text == "")
                {
                    MessageBox.Show("请输入格子编号");
                    return;
                }
                if (ElementComboBox.Text == "")
                {
                    MessageBox.Show("请输入五行单位");
                    return;
                }
                ListView AllCellsListView = null;

                BattleGridInfoForm infoForm = (BattleGridInfoForm)Owner;
                AllCellsListView = infoForm.getAllCellsListView();

                string[] PosList = Utils.getFieldsList(PosTextBox.Text);
                string[] CoordList = Utils.getFieldsList(CoordTextBox.Text);

                for (int i = 0; i < AllCellsListView.Items.Count; i++)
                {
                    if (!isAdd && AllCellsListView.Items[i] == AllCellsListView.SelectedItems[0])
                    {
                        continue;
                    }
                    string[] CoordListOld = Utils.getFieldsList(AllCellsListView.Items[i].SubItems[1].Text);
                    if (float.Parse(CoordList[0]) == float.Parse(CoordListOld[0]) && float.Parse(CoordList[1]) == float.Parse(CoordListOld[1]))
                    {
                        MessageBox.Show("该坐标的格子已存在");
                        return;
                    }
                }


                ListViewItem lvi = null;
                if (isAdd)
                {
                    lvi = new ListViewItem();
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    lvi.SubItems.Add("");
                    AllCellsListView.Items.Add(lvi);
                }
                else
                {
                    lvi = AllCellsListView.SelectedItems[0];
                }


                lvi.Tag = "{\"Pos\":{\"x\":" + PosList[0]
                            + ",\"y\":" + PosList[1]
                            + ",\"z\":" + PosList[2]
                            + "},\"Coord\":{\"x\":" + CoordList[0]
                            + ",\"y\":" + CoordList[1]
                            + "},\"CellNumber\":" + CellNumberNumericUpDown.Text
                            + ",\"Walkable\":" + WalkableCheckBox.Checked.ToString().ToLower()
                            + ",\"InActive\":" + InActiveCheckBox.Checked.ToString().ToLower()
                            + ",\"Element\":" + ((ComboBoxItem)ElementComboBox.SelectedItem).key + "}";
                lvi.Text = PosTextBox.Text;
                lvi.SubItems[1].Text = CoordTextBox.Text;
                lvi.SubItems[2].Text = CellNumberNumericUpDown.Text;
                lvi.SubItems[3].Text = WalkableCheckBox.Checked.ToString();
                lvi.SubItems[4].Text = InActiveCheckBox.Checked.ToString();
                lvi.SubItems[5].Text = ElementComboBox.Text;

                infoForm.paintCells();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CoordTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] coordStr = Utils.getFieldsList(CoordTextBox.Text);
                Vector2 coord = new Vector2(float.Parse(coordStr[0]), float.Parse(coordStr[1]));
                HexCoord hexCoord = new HexCoord(coord);
                CellNumberNumericUpDown.Value = hexCoord.Number;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
