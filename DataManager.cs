using FileHelpers;
using Heluo;
using Heluo.Animation;
using Heluo.Data;
using Heluo.Data.Converter;
using Heluo.Flow;
using Heluo.Utility;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buffer = Heluo.Data.Buffer;
using Help = Heluo.Data.Help;

namespace 侠之道mod制作器
{

    public class DataManager
    {

        public static string bufferPath = "config\\chs\\battle\\buffer";
        public static string battleSchedulePath = "config\\chs\\battle\\schedule";
        public static string cinematicPath = "config\\chs\\cinematic";
        public static string textFilePath = "config\\chs\\textfiles";
        public static string effectPath = "config\\effect";
        public static string movePathPath = "config\\movepath";
        public static string configSchedulePath = "config\\schedule";

        public static string modBufferPath = "config\\battle\\buffer";
        public static string modBattleSchedulePath = "config\\battle\\schedule";
        public static string modCinematicPath = "config\\cinematic";
        public static string modTextFilePath = "config\\textfiles";
        public static string modEffectPath = "config\\effect";
        public static string modMovePathPath = "config\\movepath";
        public static string modConfigSchedulePath = "config\\schedule";

        public static Dictionary<string, IDictionary> dict = new Dictionary<string, IDictionary>();

        public static Dictionary<string, ListViewItem> allBufferLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allBattleScheduleLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allCinematicLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allAchievementLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allAdjustmentLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allAlchemyLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allAnimationMappingLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allBattleAreaLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allBattleEventCubeLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allBattleGridLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allBookLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allCharacterBehaviourLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allCharacterExteriorLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allCharacterInfoLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allElectiveLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allEndingMovieLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allEvaluationLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allEventCubeLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allFavorabilityLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allForgeLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allGameFormulaLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allHelpLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allHelpDescriptionLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allMantraLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allMapLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allNpcLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allNurturanceLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allPropsLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allQuestLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allRegistrationBonusLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allRewardLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allRoundLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allShopLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allSkillLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allStringTableLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allTalkLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allTraitLvis = new Dictionary<string, ListViewItem>();

        public static Dictionary<string, ListViewItem> allEffectLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allMovePathLvis = new Dictionary<string, ListViewItem>();
        public static Dictionary<string, ListViewItem> allConfigScheduleLvis = new Dictionary<string, ListViewItem>();

        public static Dictionary<string, ListViewItem> allUnitLvis = new Dictionary<string, ListViewItem>();


        public static void showLoadDataForm()
        {
            try
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum = 1;
                MainForm.loadDataForm.getOneProgressBar().Value = 0;
                if (!MainForm.loadDataForm.Visible)
                {
                    MainForm.loadDataForm.ShowDialog();
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public static T getData<T>(string id)
        {
            try
            {
                return getData<T>(typeof(T).Name, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default(T);
            }
        }

        public static T getData<T>(string type, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return default(T);
            }

            if (
                    (!DataManager.dict.ContainsKey(type) && !DataManager.dict.ContainsKey(type + "_cus"))
                || (
                        (type == "buffer" || type == "battle/schedule" || type == "cinematic" || type == "effect" || type == "movepath" || type == "config/schedule")
                         && !DataManager.dict[type].Contains(id)) && !DataManager.dict[type + "_cus"].Contains(id)
               )
            {
                if (!MainForm.loadDataForm.Visible)
                {
                    Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                    loadDataFormThread.Start();
                    MainForm.loadDataForm.getOneProgressBar().Maximum++;
                }

                string tempTypeName = type;
                if (type == "buffer")
                {
                    tempTypeName = "Buffer";
                }
                else if (type == "battle/schedule")
                {
                    tempTypeName = "BattleSchedule";
                }
                else if (type == "cinematic")
                {
                    tempTypeName = "Cinematic";
                }
                else if (type == "effect")
                {
                    tempTypeName = "Effect";
                }
                else if (type == "movepath")
                {
                    tempTypeName = "MovePath";
                }
                else if (type == "config/schedule")
                {
                    tempTypeName = "ConfigSchedule";
                }

                Type clazz = Type.GetType("侠之道mod制作器.DataManager");

                if (clazz != null)
                {

                    if (type == "buffer" || type == "battle/schedule" || type == "cinematic" || type == "effect" || type == "movepath" || type == "config/schedule")
                    {
                        clazz.InvokeMember("Load" + tempTypeName, BindingFlags.InvokeMethod, null, null, new object[] { id });
                    }
                    else
                    {
                        clazz.InvokeMember("LoadTextfile", BindingFlags.InvokeMethod, null, null, new object[] { type });
                    }
                }

                if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
                {
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                }
            }

            if (DataManager.dict.ContainsKey(type + "_cus") && DataManager.dict[type + "_cus"].Contains(id))
            {
                return ((Dictionary<string, T>)DataManager.dict[type + "_cus"])[id];
            }
            else if (DataManager.dict.ContainsKey(type))
            {
                if (dict[type].Contains(id))
                {
                    return ((Dictionary<string, T>)DataManager.dict[type])[id];
                }
                return default(T);
            }
            else
            {
                return default(T);
            }
        }

        public static T loadData<T>(string path, string name) where T : class
        {
            string fileName = path + "\\" + name;

            string source = "";
            if (File.Exists(fileName))
            {
                source = File.ReadAllText(fileName);
            }

            if (File.Exists(MainForm.savePath + MainForm.modName + "\\" + fileName))
            {
                source = File.ReadAllText(MainForm.savePath + MainForm.modName + "\\" + fileName);
            }

            T data = default(T);


            try
            {
                data = loadData<T>(source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取" + fileName + "失败," + ex.InnerException);
            }
            return data;
        }

        public static T loadData<T>(string source) where T : class
        {
            T data = default(T);


            try
            {
                data = new FileHelperEngine<T>(Encoding.UTF8).ReadString(source)[0];
            }
            catch (Exception)
            {
                try
                {
                    data = JsonConvert.DeserializeObject<T>(source, new JsonConverter[] { new OutputNodeJsonConverter(), new ShortVector3JsonConverter() });
                }
                catch (Exception)
                {
                    data = JsonConvert.DeserializeObject<T>(source, AnimatorEventTrack.SerializeSetting);
                }
            }
            return data;
        }

        public static void LoadBuffer(bool loadExist)
        {
            //MainForm.loadDataForm.getTotalProgressBar().Maximum += 2;

            List<FileInfo> fileList = new DirectoryInfo(DataManager.bufferPath).GetFiles().ToList();

            Dictionary<string, Buffer> tempdict = null;

            if (!loadExist && dict.ContainsKey("buffer"))
            {
                tempdict = (Dictionary<string, Buffer>)dict["buffer"];
            }
            else
            {
                tempdict = new Dictionary<string, Buffer>();
            }

            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
            for (int i = 0; i < fileList.Count; i++)
            {
                if (loadExist || !dict.ContainsKey("buffer") || !dict["buffer"].Contains(fileList[i].Name.Split('.')[0]))
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Buffers：" + fileList[i].Name.Split('.')[0] + ".json";
                    Buffer data = loadData<Buffer>(DataManager.bufferPath, fileList[i].Name.Split('.')[0] + ".json");

                    tempdict.Add(fileList[i].Name.Split('.')[0], data);
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }

            if (DataManager.dict.ContainsKey("buffer"))
            {
                DataManager.dict["buffer"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("buffer", tempdict);
            }

            if (!loadExist && dict.ContainsKey("buffer_cus"))
            {
                tempdict = (Dictionary<string, Buffer>)dict["buffer_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, Buffer>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;

                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("buffer_cus") || !dict["buffer_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Buffers：" + fileList[i].Name.Split('.')[0] + ".json";
                        Buffer data = loadData<Buffer>(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath, fileList[i].Name.Split('.')[0] + ".json");

                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }


            if (DataManager.dict.ContainsKey("buffer_cus"))
            {
                DataManager.dict["buffer_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("buffer_cus", tempdict);
            }

        }

        public static void LoadBuffer(string id)
        {

            Dictionary<string, Buffer> tempdict = new Dictionary<string, Buffer>();
            if (DataManager.dict.ContainsKey("buffer"))
            {
                DataManager.dict["buffer"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("buffer", tempdict);
            }

            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
            MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Buffers：" + id + ".json";
            Buffer data = loadData<Buffer>(DataManager.bufferPath, id + ".json");

            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;


            if (data != null)
            {
                if (tempdict.ContainsKey(id))
                {
                    tempdict[id] = data;
                }
                else
                {

                    tempdict.Add(id, data);
                }
            }


            tempdict = new Dictionary<string, Buffer>();

            if (DataManager.dict.ContainsKey("buffer_cus"))
            {
                DataManager.dict["buffer_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("buffer_cus", tempdict);
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;

                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Buffers：" + id + ".json";
                Buffer data1 = loadData<Buffer>(MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath, id + ".json");

                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;


                if (data1 != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data1;
                    }
                    else
                    {
                        tempdict.Add(id, data1);
                    }
                }
            }


        }

        public static void LoadBattleSchedule(bool loadExist)
        {

            List<FileInfo> fileList = new DirectoryInfo(battleSchedulePath).GetFiles().ToList();

            Dictionary<string, BattleScheduleBundle> tempdict = null;

            if (!loadExist && dict.ContainsKey("battle/schedule"))
            {
                tempdict = (Dictionary<string, BattleScheduleBundle>)dict["battle/schedule"];
            }
            else
            {
                tempdict = new Dictionary<string, BattleScheduleBundle>();
            }
            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
            for (int i = 0; i < fileList.Count; i++)
            {
                if (loadExist || !dict.ContainsKey("battle/schedule") || !dict["battle/schedule"].Contains(fileList[i].Name.Split('.')[0]))
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Schedules：" + fileList[i].Name.Split('.')[0] + ".json";
                    BattleScheduleBundle data = loadData<BattleScheduleBundle>(battleSchedulePath, fileList[i].Name.Split('.')[0] + ".json");

                    tempdict.Add(fileList[i].Name.Split('.')[0], data);
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }

            if (DataManager.dict.ContainsKey("battle/schedule"))
            {
                DataManager.dict["battle/schedule"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("battle/schedule", tempdict);
            }


            if (!loadExist && dict.ContainsKey("battle/schedule_cus"))
            {
                tempdict = (Dictionary<string, BattleScheduleBundle>)dict["battle/schedule_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, BattleScheduleBundle>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modBattleSchedulePath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + modBattleSchedulePath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("battle/schedule_cus") || !dict["battle/schedule_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Schedules：" + fileList[i].Name.Split('.')[0] + ".json";
                        BattleScheduleBundle data = loadData<BattleScheduleBundle>(MainForm.savePath + MainForm.modName + "\\" + modBattleSchedulePath, fileList[i].Name.Split('.')[0] + ".json");
                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

                }
            }
            if (DataManager.dict.ContainsKey("battle/schedule_cus"))
            {
                DataManager.dict["battle/schedule_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("battle/schedule_cus", tempdict);
            }
        }

        public static void LoadBattleSchedule(string id)
        {


            Dictionary<string, BattleScheduleBundle> tempdict = new Dictionary<string, BattleScheduleBundle>();
            if (DataManager.dict.ContainsKey("battle/schedule"))
            {
                DataManager.dict["battle/schedule"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("battle/schedule", tempdict);
            }

            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
            MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Schedules：" + id + ".json";
            BattleScheduleBundle data = loadData<BattleScheduleBundle>(battleSchedulePath, id + ".json");

            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;


            if (data != null)
            {
                if (tempdict.ContainsKey(id))
                {
                    tempdict[id] = data;
                }
                else
                {
                    tempdict.Add(id, data);
                }
            }


            tempdict = new Dictionary<string, BattleScheduleBundle>();
            if (DataManager.dict.ContainsKey("battle/schedule_cus"))
            {
                DataManager.dict["battle/schedule_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("battle/schedule_cus", tempdict);
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modBattleSchedulePath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Schedules：" + id + ".json";
                BattleScheduleBundle data1 = loadData<BattleScheduleBundle>(MainForm.savePath + MainForm.modName + "\\" + modBattleSchedulePath, id + ".json");
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

                if (data1 != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data1;
                    }
                    else
                    {
                        tempdict.Add(id, data1);
                    }
                }
            }
        }

        public static void LoadCinematic(bool loadExist)
        {
            /*if (!MainForm.loadDataForm.Visible)
            {
                Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                loadDataFormThread.Start();
            }*/

            List<FileInfo> fileList = new DirectoryInfo(cinematicPath).GetFiles().ToList();

            Dictionary<string, ScheduleGraph.Bundle> tempdict = null;

            if (!loadExist && dict.ContainsKey("cinematic"))
            {
                tempdict = (Dictionary<string, ScheduleGraph.Bundle>)dict["cinematic"];
            }
            else
            {
                tempdict = new Dictionary<string, ScheduleGraph.Bundle>();
            }

            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
            for (int i = 0; i < fileList.Count; i++)
            {
                if (loadExist || !dict.ContainsKey("cinematic") || !dict["cinematic"].Contains(fileList[i].Name.Split('.')[0]))
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取cinematic：" + fileList[i].Name.Split('.')[0] + ".json";
                    ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(cinematicPath, fileList[i].Name.Split('.')[0] + ".json");

                    if (data != null)
                    {
                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                }
                if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
                {
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                }
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }


            if (DataManager.dict.ContainsKey("cinematic"))
            {
                DataManager.dict["cinematic"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("cinematic", tempdict);
            }


            if (!loadExist && dict.ContainsKey("cinematic_cus"))
            {
                tempdict = (Dictionary<string, ScheduleGraph.Bundle>)dict["cinematic_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modCinematicPath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + modCinematicPath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("cinematic_cus") || !dict["cinematic_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取cinematic：" + fileList[i].Name.Split('.')[0] + ".json";
                        ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\" + modCinematicPath, fileList[i].Name.Split('.')[0] + ".json");

                        if (data != null)
                        {
                            tempdict.Add(fileList[i].Name.Split('.')[0], data);
                        }
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

                }
            }

            if (DataManager.dict.ContainsKey("cinematic_cus"))
            {
                DataManager.dict["cinematic_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("cinematic_cus", tempdict);
            }
            if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
            {
                MainForm.loadDataForm.getOneProgressBar().Value++;
            }
        }

        public static void LoadCinematic(string id)
        {

            if (!DataManager.dict.ContainsKey("cinematic"))
            {
                DataManager.dict["cinematic"] = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            Dictionary<string, ScheduleGraph.Bundle> tempdict = (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["cinematic"];

            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
            MainForm.loadDataForm.GetTotalLabel().Text = "正在读取cinematic：" + id + ".json";
            ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(cinematicPath, id + ".json");

            if (data != null)
            {
                if (tempdict.ContainsKey(id))
                {
                    tempdict[id] = data;
                }
                else
                {
                    tempdict.Add(id, data);
                }
            }
            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;




            if (!DataManager.dict.ContainsKey("cinematic_cus"))
            {
                DataManager.dict["cinematic_cus"] = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            tempdict = (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["cinematic_cus"];
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modCinematicPath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取cinematic：" + id + ".json";
                ScheduleGraph.Bundle data1 = loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\" + modCinematicPath, id + ".json");

                if (data1 != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data1;
                    }
                    else
                    {
                        tempdict.Add(id, data1);
                    }
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

            }

        }

        public static void LoadTextfiles()
        {

            Type type = typeof(Item);

            List<FileInfo> fileList = new DirectoryInfo(textFilePath).GetFiles().ToList();

            foreach (FileInfo fileInfo in fileList)
            {

                LoadTextfile(fileInfo.Name);
            }
        }

        public static void LoadTextfile(string fileName)
        {
            Type type = typeof(Item);
            foreach (Type itemType in from t in type.Assembly.GetTypes()
                                      where t.IsSubclassOf(type) && !t.HasAttribute<Hidden>(false)
                                      select t)
            {
                if (itemType.Name == fileName)
                {
                    LoadTextfile(itemType);
                    break;
                }
            }
        }

        public static void LoadTextfile(Type itemType)
        {
            try
            {
                //MainForm.loadDataForm.getOneProgressBar().Maximum++;
                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取Textfiles：" + itemType.Name + ".txt";

                Type typeItemDic = typeof(CsvDataSource<>).MakeGenericType(new Type[]
                {
                    itemType
                });
                string fileName = "";
                try
                {
                    fileName = textFilePath + "\\" + itemType.Name + ".txt";
                    LoadTextfile(itemType, fileName, false);
                    /*if (File.Exists(fileName))
                    {
                        fileData = File.ReadAllBytes(fileName);
                    }
                    itemDic = (Activator.CreateInstance(typeItemDic, new object[] { fileData }) as IDictionary);

                    if (DataManager.dict.ContainsKey(itemType.Name))
                    {
                        DataManager.dict[itemType.Name] = itemDic;
                    }
                    else
                    {
                        DataManager.dict.Add(itemType.Name, itemDic);
                    }*/

                    //Type constructed = typeof(Dictionary<,>).MakeGenericType(new Type[] { typeof(string), itemType });
                    //itemDic = (IDictionary)Activator.CreateInstance(constructed);
                    fileName = MainForm.savePath + MainForm.modName + "\\" + modTextFilePath + "\\" + itemType.Name + "_modify.txt";

                    LoadTextfile(itemType, fileName, true);
                    /*if (File.Exists(fileName))
                    {
                        fileData = File.ReadAllBytes(fileName);
                        itemDic = (Activator.CreateInstance(typeItemDic, new object[] { fileData }) as IDictionary);

                    }
                    if (DataManager.dict.ContainsKey(itemType.Name + "_cus"))
                    {
                        DataManager.dict[itemType.Name + "_cus"] = itemDic;
                    }
                    else
                    {
                        DataManager.dict.Add(itemType.Name + "_cus", itemDic);
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取" + fileName + "失败," + ex.InnerException);
                }
                //MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadTextfile:" + ex.Message);
            }
        }

        public static void LoadTextfile(Type itemType, string fileName, bool isCus)
        {
            try
            {
                Type typeItemDic = typeof(CsvDataSource<>).MakeGenericType(new Type[]
                    {
                    itemType
                    });

                IDictionary itemDic = null;
                byte[] fileData = new byte[] { };

                if (File.Exists(fileName))
                {
                    fileData = File.ReadAllBytes(fileName);
                }
                itemDic = (Activator.CreateInstance(typeItemDic, new object[] { fileData }) as IDictionary);

                if (!isCus)
                {
                    if (DataManager.dict.ContainsKey(itemType.Name))
                    {
                        DataManager.dict[itemType.Name] = itemDic;
                    }
                    else
                    {
                        DataManager.dict.Add(itemType.Name, itemDic);
                    }
                }
                else
                {
                    if (DataManager.dict.ContainsKey(itemType.Name + "_cus"))
                    {
                        DataManager.dict[itemType.Name + "_cus"] = itemDic;
                    }
                    else
                    {
                        DataManager.dict.Add(itemType.Name + "_cus", itemDic);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LoadEffect(bool loadExist)
        {

            List<FileInfo> fileList = new DirectoryInfo(effectPath).GetFiles().ToList();
            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count - 1;

            string path = effectPath + "\\EffectList.txt";
            byte[] array = File.ReadAllBytes(path);
            if (array == null)
            {
                return;
            }
            string @string = Encoding.UTF8.GetString(array);

            Dictionary<string, AnimatorEventTrack> tempdict = null;

            if (!loadExist && dict.ContainsKey("effect"))
            {
                tempdict = (Dictionary<string, AnimatorEventTrack>)dict["effect"];
            }
            else
            {
                tempdict = new Dictionary<string, AnimatorEventTrack>();
            }

            using (StringReader stringReader = new StringReader(@string))
            {
                string text;
                while ((text = stringReader.ReadLine()) != null)
                {
                    if (loadExist || !dict.ContainsKey("effect") || !dict["effect"].Contains(text))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取effects：" + text + ".json";
                        AnimatorEventTrack data = loadData<AnimatorEventTrack>(effectPath, text + ".json");

                        tempdict.Add(text, data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }

            if (DataManager.dict.ContainsKey("effect"))
            {
                DataManager.dict["effect"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("effect", tempdict);
            }


            if (!loadExist && dict.ContainsKey("effect_cus"))
            {
                tempdict = (Dictionary<string, AnimatorEventTrack>)dict["effect_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, AnimatorEventTrack>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modEffectPath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + modEffectPath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;

                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("effect_cus") || !dict["effect_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取effects：" + fileList[i].Name.Split('.')[0] + ".json";
                        AnimatorEventTrack data = loadData<AnimatorEventTrack>(MainForm.savePath + MainForm.modName + "\\" + modEffectPath, fileList[i].Name.Split('.')[0] + ".json");

                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }


            if (DataManager.dict.ContainsKey("effect_cus"))
            {
                DataManager.dict["effect_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("effect_cus", tempdict);
            }


        }

        public static void LoadEffect(string id)
        {


            if (!DataManager.dict.ContainsKey("effect"))
            {
                DataManager.dict["effect"] = new Dictionary<string, AnimatorEventTrack>(); ;
            }
            Dictionary<string, AnimatorEventTrack> tempdict = (Dictionary<string, AnimatorEventTrack>)DataManager.dict["effect"];

            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;

            string path = effectPath + "\\EffectList.txt";
            byte[] array = File.ReadAllBytes(path);
            if (array == null)
            {
                return;
            }
            string @string = Encoding.UTF8.GetString(array);

            using (StringReader stringReader = new StringReader(@string))
            {
                string text;
                while ((text = stringReader.ReadLine()) != null)
                {
                    if (text != id)
                    {
                        continue;
                    }

                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取effects：" + text + ".json";
                    AnimatorEventTrack data = loadData<AnimatorEventTrack>(effectPath, text + ".json");

                    if (data != null)
                    {
                        if (tempdict.ContainsKey(id))
                        {
                            tempdict[id] = data;
                        }
                        else
                        {
                            tempdict.Add(id, data);
                        }
                    }
                    if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
                    {
                        MainForm.loadDataForm.getOneProgressBar().Value++;
                    }
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }


            if (!DataManager.dict.ContainsKey("effect_cus"))
            {
                DataManager.dict["effect_cus"] = new Dictionary<string, AnimatorEventTrack>(); ;
            }
            tempdict = (Dictionary<string, AnimatorEventTrack>)DataManager.dict["effect_cus"];
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modEffectPath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;

                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取effects：" + id + ".json";
                AnimatorEventTrack data = loadData<AnimatorEventTrack>(MainForm.savePath + MainForm.modName + "\\" + modEffectPath, id + ".json");

                if (data != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data;
                    }
                    else
                    {
                        tempdict.Add(id, data);
                    }
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }




        }

        public static void LoadMovePath(bool loadExist)
        {
            List<FileInfo> fileList = new DirectoryInfo(movePathPath).GetFiles().ToList();
            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;


            Dictionary<string, MovePath> tempdict = null;

            if (!loadExist && dict.ContainsKey("movepath"))
            {
                tempdict = (Dictionary<string, MovePath>)dict["movepath"];
            }
            else
            {
                tempdict = new Dictionary<string, MovePath>();
            }


            for (int i = 0; i < fileList.Count; i++)
            {
                if (loadExist || !dict.ContainsKey("movepath") || !dict["movepath"].Contains(fileList[i].Name.Split('.')[0]))
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取movepath：" + fileList[i].Name.Split('.')[0] + ".json";
                    MovePath data = loadData<MovePath>(movePathPath, fileList[i].Name.Split('.')[0] + ".json");

                    tempdict.Add(fileList[i].Name.Split('.')[0], data);
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }

            if (DataManager.dict.ContainsKey("movepath"))
            {
                DataManager.dict["movepath"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("movepath", tempdict);
            }


            if (!loadExist && dict.ContainsKey("movepath_cus"))
            {
                tempdict = (Dictionary<string, MovePath>)dict["movepath_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, MovePath>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modMovePathPath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + modMovePathPath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;

                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("movepath_cus") || !dict["movepath_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取movepath：" + fileList[i].Name.Split('.')[0] + ".json";
                        MovePath data = loadData<MovePath>(MainForm.savePath + MainForm.modName + "\\" + modMovePathPath, fileList[i].Name.Split('.')[0] + ".json");

                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }


            if (DataManager.dict.ContainsKey("movepath_cus"))
            {
                DataManager.dict["movepath_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("movepath_cus", tempdict);
            }

        }

        public static void LoadMovePath(string id)
        {
            if (!DataManager.dict.ContainsKey("movepath"))
            {
                DataManager.dict["movepath"] = new Dictionary<string, MovePath>(); ;
            }
            Dictionary<string, MovePath> tempdict = (Dictionary<string, MovePath>)DataManager.dict["movepath"];


            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;


            MainForm.loadDataForm.GetTotalLabel().Text = "正在读取movepath：" + id + ".json";
            MovePath data = loadData<MovePath>(movePathPath, id + ".json");

            if (data != null)
            {
                if (tempdict.ContainsKey(id))
                {
                    tempdict[id] = data;
                }
                else
                {
                    tempdict.Add(id, data);
                }
            }
            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;




            if (!DataManager.dict.ContainsKey("movepath_cus"))
            {
                DataManager.dict["movepath_cus"] = new Dictionary<string, MovePath>();
            }
            tempdict = (Dictionary<string, MovePath>)DataManager.dict["movepath_cus"];
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modMovePathPath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;

                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取movepath：" + id + ".json";
                MovePath data1 = loadData<MovePath>(MainForm.savePath + MainForm.modName + "\\" + modMovePathPath, id + ".json");

                if (data1 != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data1;
                    }
                    else
                    {
                        tempdict.Add(id, data1);
                    }
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

            }



        }

        public static void LoadConfigSchedule(bool loadExist)
        {
            List<FileInfo> fileList = new DirectoryInfo(configSchedulePath).GetFiles().ToList();

            Dictionary<string, ScheduleGraph.Bundle> tempdict = null;

            if (!loadExist && dict.ContainsKey("config/schedule"))
            {
                tempdict = (Dictionary<string, ScheduleGraph.Bundle>)dict["config/schedule"];
            }
            else
            {
                tempdict = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
            for (int i = 0; i < fileList.Count; i++)
            {
                if (loadExist || !dict.ContainsKey("config/schedule") || !dict["config/schedule"].Contains(fileList[i].Name.Split('.')[0]))
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在读取schedule：" + fileList[i].Name.Split('.')[0] + ".json";
                    ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(configSchedulePath, fileList[i].Name.Split('.')[0] + ".json");

                    tempdict.Add(fileList[i].Name.Split('.')[0], data);
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }


            if (DataManager.dict.ContainsKey("config/schedule"))
            {
                DataManager.dict["config/schedule"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("config/schedule", tempdict);
            }


            if (!loadExist && dict.ContainsKey("config/schedule_cus"))
            {
                tempdict = (Dictionary<string, ScheduleGraph.Bundle>)dict["config/schedule_cus"];
            }
            else
            {
                tempdict = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modConfigSchedulePath))
            {
                fileList = new DirectoryInfo(MainForm.savePath + MainForm.modName + "\\" + modConfigSchedulePath).GetFiles().ToList();
                MainForm.loadDataForm.getOneProgressBar().Maximum += fileList.Count;
                for (int i = 0; i < fileList.Count; i++)
                {
                    if (loadExist || !dict.ContainsKey("config/schedule_cus") || !dict["config/schedule_cus"].Contains(fileList[i].Name.Split('.')[0]))
                    {
                        MainForm.loadDataForm.GetTotalLabel().Text = "正在读取schedule：" + fileList[i].Name.Split('.')[0] + ".json";
                        ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\" + modConfigSchedulePath, fileList[i].Name.Split('.')[0] + ".json");

                        tempdict.Add(fileList[i].Name.Split('.')[0], data);
                    }
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                    MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                }
            }

            if (DataManager.dict.ContainsKey("config/schedule_cus"))
            {
                DataManager.dict["config/schedule_cus"] = tempdict;
            }
            else
            {
                DataManager.dict.Add("config/schedule_cus", tempdict);
            }

        }
        public static void LoadConfigSchedule(string id)
        {
            if (!DataManager.dict.ContainsKey("config/schedule"))
            {
                DataManager.dict["config/schedule"] = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            Dictionary<string, ScheduleGraph.Bundle> tempdict = (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["config/schedule"];


            MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
            MainForm.loadDataForm.GetTotalLabel().Text = "正在读取schedule：" + id + ".json";
            ScheduleGraph.Bundle data = loadData<ScheduleGraph.Bundle>(configSchedulePath, id + ".json");

            if (data != null)
            {
                if (tempdict.ContainsKey(id))
                {
                    tempdict[id] = data;
                }
                else
                {
                    tempdict.Add(id, data);
                }
            }
            MainForm.loadDataForm.getOneProgressBar().Value++;
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;





            if (!DataManager.dict.ContainsKey("config/schedule_cus"))
            {
                DataManager.dict["config/schedule_cus"] = new Dictionary<string, ScheduleGraph.Bundle>();
            }
            tempdict = (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["config/schedule_cus"];
            if (Directory.Exists(MainForm.savePath + MainForm.modName + "\\" + modConfigSchedulePath))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += 1;
                MainForm.loadDataForm.GetTotalLabel().Text = "正在读取schedule：" + id + ".json";
                ScheduleGraph.Bundle data1 = loadData<ScheduleGraph.Bundle>(MainForm.savePath + MainForm.modName + "\\" + modConfigSchedulePath, id + ".json");

                if (data1 != null)
                {
                    if (tempdict.ContainsKey(id))
                    {
                        tempdict[id] = data1;
                    }
                    else
                    {
                        tempdict.Add(id, data1);
                    }
                }
                MainForm.loadDataForm.getOneProgressBar().Value++;
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

            }


        }

        public static Dictionary<string, ListViewItem> createBufferLvis()
        {
            DataManager.LoadBuffer(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Buffer> kv in (Dictionary<string, Buffer>)DataManager.dict["buffer"])
            {
                ListViewItem lvi = createBufferLvi(kv.Key);

                if (lvi != null)
                {
                    lvis.Add(kv.Key, lvi);
                }
            }
            foreach (KeyValuePair<string, Buffer> kv in (Dictionary<string, Buffer>)DataManager.dict["buffer_cus"])
            {
                if (!lvis.ContainsKey(kv.Key))
                {
                    ListViewItem lvi = createBufferLvi(kv.Key);

                    if (lvi != null)
                    {
                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createBufferLvi(string bufferId)
        {
            ListViewItem lvi = new ListViewItem();

            string path = DataManager.bufferPath + "\\" + bufferId + ".json";
            string customPath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBufferPath + "\\" + bufferId + ".json";
            bool isCustom = false;
            if (File.Exists(customPath))
            {
                path = customPath;
                isCustom = true;
            }
            string source = File.ReadAllText(path);

            Buffer buffer = DataManager.getData<Buffer>("buffer", bufferId);

            if (buffer == null)
            {
                return null;
            }


            lvi.ImageKey = buffer.IconName;
            lvi.Text = buffer.IconName;

            lvi.SubItems.Add(bufferId);
            lvi.SubItems.Add(buffer.Name);
            lvi.SubItems.Add(buffer.Desc);
            lvi.SubItems.Add(buffer.Remark);
            lvi.SubItems.Add(buffer.Oriented + "(" + EnumData.GetDisplayName(buffer.Oriented) + ")");
            lvi.SubItems.Add(buffer.Times.ToString());
            lvi.SubItems.Add(buffer.Overlay.ToString());
            lvi.SubItems.Add("");

            if (isCustom)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createBattleScheduleLvis()
        {
            DataManager.LoadBattleSchedule(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, BattleScheduleBundle> kv in (Dictionary<string, BattleScheduleBundle>)DataManager.dict["battle/schedule"])
            {
                ListViewItem lvi = createBattleScheduleLvi(kv.Key);

                if (lvi != null)
                {
                    lvis.Add(kv.Key, lvi);
                }
            }

            foreach (KeyValuePair<string, BattleScheduleBundle> kv in (Dictionary<string, BattleScheduleBundle>)DataManager.dict["battle/schedule_cus"])
            {
                if (!lvis.ContainsKey(kv.Key))
                {
                    ListViewItem lvi = createBattleScheduleLvi(kv.Key);

                    if (lvi != null)
                    {
                        lvis.Add(kv.Key, lvi);
                    }

                }
            }

            return lvis;
        }

        public static ListViewItem createBattleScheduleLvi(string scheduleId)
        {
            ListViewItem lvi = new ListViewItem();

            string path = DataManager.battleSchedulePath + "\\" + scheduleId + ".json";
            string customPath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modBattleSchedulePath + "\\" + scheduleId + ".json";
            bool isCustom = false;
            if (File.Exists(customPath))
            {
                path = customPath;
                isCustom = true;
            }
            string source = File.ReadAllText(path);

            BattleScheduleBundle schedule = DataManager.getData<BattleScheduleBundle>("battle/schedule", scheduleId);

            if (schedule == null || schedule.Infos == null)
            {
                MessageBox.Show("读取" + scheduleId + ".json，失败，请检查");
                return null;
            }
            lvi.Text = scheduleId;

            lvi.SubItems.Add(schedule.Name);
            lvi.SubItems.Add(schedule.Remark);
            lvi.SubItems.Add(schedule.WinTip);
            lvi.SubItems.Add(schedule.LoseTip);

            int index = source.IndexOf("[");
            source = source.Substring(index, source.Length - index);
            index = source.ToLower().IndexOf("\"remark\"");
            source = source.Substring(0, index - 6);

            lvi.SubItems.Add(source);

            if (isCustom)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createCinematicLvis()
        {
            DataManager.LoadCinematic(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, ScheduleGraph.Bundle> kv in (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["cinematic"])
            {
                ListViewItem lvi = createCinematicLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }

            foreach (KeyValuePair<string, ScheduleGraph.Bundle> kv in (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["cinematic_cus"])
            {
                if (!lvis.ContainsKey(kv.Key))
                {
                    ListViewItem lvi = createCinematicLvi(kv.Key);

                    lvis.Add(kv.Key, lvi);
                }
            }

            return lvis;
        }

        public static ListViewItem createCinematicLvi(string cinematicId)
        {
            ListViewItem lvi = new ListViewItem();

            string path = DataManager.cinematicPath + "\\" + cinematicId + ".json";
            string customPath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modCinematicPath + "\\" + cinematicId + ".json";
            bool isCustom = false;
            if (File.Exists(customPath))
            {
                path = customPath;
                isCustom = true;
            }
            string source = File.ReadAllText(path);

            ScheduleGraph.Bundle schedule = DataManager.getData<ScheduleGraph.Bundle>("cinematic", cinematicId);

            if (schedule == null)
            {
                return null;
            }

            lvi.Text = cinematicId;

            lvi.SubItems.Add(schedule.Name);
            lvi.SubItems.Add(schedule.EntryIndex.ToString());

            int index = source.IndexOf("[");
            source = source.Substring(index, source.Length - index);
            index = source.ToLower().IndexOf("\"name\"");
            source = source.Substring(0, index - 4);

            lvi.SubItems.Add(source);

            if (isCustom)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createConfigScheduleLvis()
        {
            DataManager.LoadConfigSchedule(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, ScheduleGraph.Bundle> kv in (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["config/schedule"])
            {
                ListViewItem lvi = createConfigScheduleLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }

            foreach (KeyValuePair<string, ScheduleGraph.Bundle> kv in (Dictionary<string, ScheduleGraph.Bundle>)DataManager.dict["config/schedule_cus"])
            {
                if (!lvis.ContainsKey(kv.Key))
                {
                    ListViewItem lvi = createConfigScheduleLvi(kv.Key);

                    lvis.Add(kv.Key, lvi);
                }
            }

            return lvis;
        }

        public static ListViewItem createConfigScheduleLvi(string cinematicId)
        {
            ListViewItem lvi = new ListViewItem();

            string path = DataManager.configSchedulePath + "\\" + cinematicId + ".json";
            string customPath = MainForm.savePath + MainForm.modName + "\\" + DataManager.modConfigSchedulePath + "\\" + cinematicId + ".json";
            bool isCustom = false;
            if (File.Exists(customPath))
            {
                path = customPath;
                isCustom = true;
            }
            string source = File.ReadAllText(path);

            ScheduleGraph.Bundle schedule = DataManager.getData<ScheduleGraph.Bundle>("config/schedule", cinematicId);


            lvi.Text = cinematicId;

            lvi.SubItems.Add(schedule.Name);
            lvi.SubItems.Add(schedule.EntryIndex.ToString());

            int index = source.IndexOf("[");
            source = source.Substring(index, source.Length - index);
            index = source.ToLower().IndexOf("\"name\"");
            source = source.Substring(0, index - 4);

            lvi.SubItems.Add(source);

            if (isCustom)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createAdjustmentLvis()
        {
            if (!DataManager.dict.ContainsKey("Adjustment"))
            {
                DataManager.LoadTextfile("Adjustment");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Adjustment> kv in (Dictionary<string, Adjustment>)DataManager.dict["Adjustment"])
            {
                ListViewItem lvi = createAdjustmentLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Adjustment_cus"))
            {
                foreach (KeyValuePair<string, Adjustment> kv in (Dictionary<string, Adjustment>)DataManager.dict["Adjustment_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createAdjustmentLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createAdjustmentLvi(string adjustmentId)
        {
            ListViewItem lvi = new ListViewItem();

            Adjustment adjustment = DataManager.getData<Adjustment>(adjustmentId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Adjustment_cus") && DataManager.dict["Adjustment_cus"].Contains(adjustmentId))
            {
                isCus = true;
            }

            lvi.Text = adjustment.Id;

            lvi.SubItems.Add(adjustment.Name);
            lvi.SubItems.Add(adjustment.Remark);
            lvi.SubItems.Add(adjustment.Description);
            lvi.SubItems.Add(EnumData.GetDisplayName(adjustment.RecommendationElement));
            lvi.SubItems.Add(EnumData.GetDisplayName(adjustment.OpposeElement));
            lvi.SubItems.Add(adjustment.MinPartyCount.ToString());
            lvi.SubItems.Add(adjustment.MaxPartyCount.ToString());

            string MustMemberStr = "";
            if (adjustment.MustMember != null)
            {
                for (int i = 0; i < adjustment.MustMember.Count; i++)
                {
                    MustMemberStr += getNpcsName(adjustment.MustMember[i]) + ",";
                }
            }
            if (MustMemberStr.Length > 0)
            {
                MustMemberStr = MustMemberStr.Substring(0, MustMemberStr.Length - 1);
            }
            lvi.SubItems.Add(MustMemberStr);

            string ProhibitMemberStr = "";
            if (adjustment.ProhibitMember != null)
            {
                for (int i = 0; i < adjustment.ProhibitMember.Count; i++)
                {
                    ProhibitMemberStr += getNpcsName(adjustment.ProhibitMember[i]) + ",";
                }
            }
            if (ProhibitMemberStr.Length > 0)
            {
                ProhibitMemberStr = ProhibitMemberStr.Substring(0, ProhibitMemberStr.Length - 1);
            }
            lvi.SubItems.Add(ProhibitMemberStr);

            lvi.SubItems.Add(getCinematicName(adjustment.CinematicId));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createAlchemyLvis()
        {
            if (!DataManager.dict.ContainsKey("Alchemy"))
            {
                DataManager.LoadTextfile("Alchemy");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Alchemy> kv in (Dictionary<string, Alchemy>)DataManager.dict["Alchemy"])
            {
                ListViewItem lvi = createAlchemyLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Alchemy_cus"))
            {
                foreach (KeyValuePair<string, Alchemy> kv in (Dictionary<string, Alchemy>)DataManager.dict["Alchemy_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createAlchemyLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createAlchemyLvi(string alchemyId)
        {
            ListViewItem lvi = new ListViewItem();

            Alchemy alchemy = DataManager.getData<Alchemy>(alchemyId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Alchemy_cus") && DataManager.dict["Alchemy_cus"].Contains(alchemyId))
            {
                isCus = true;
            }

            lvi.Text = alchemy.Id;

            lvi.SubItems.Add(alchemy.Remark);
            lvi.SubItems.Add(getPropssName(alchemy.PropsId));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createAnimationMappingLvis()
        {
            if (!DataManager.dict.ContainsKey("AnimationMapping"))
            {
                DataManager.LoadTextfile("AnimationMapping");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, AnimationMapping> kv in (Dictionary<string, AnimationMapping>)DataManager.dict["AnimationMapping"])
            {
                ListViewItem lvi = createAnimationMappingLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("AnimationMapping_cus"))
            {
                foreach (KeyValuePair<string, AnimationMapping> kv in (Dictionary<string, AnimationMapping>)DataManager.dict["AnimationMapping_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createAnimationMappingLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createAnimationMappingLvi(string AnimationMappingId)
        {
            ListViewItem lvi = new ListViewItem();

            AnimationMapping AnimationMapping = DataManager.getData<AnimationMapping>(AnimationMappingId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("AnimationMapping_cus") && DataManager.dict["AnimationMapping_cus"].Contains(AnimationMappingId))
            {
                isCus = true;
            }

            lvi.Text = AnimationMapping.Id;

            lvi.SubItems.Add(AnimationMapping.Name);
            lvi.SubItems.Add(AnimationMapping.Description);
            lvi.SubItems.Add(AnimationMapping.Stand);
            lvi.SubItems.Add(AnimationMapping.Walk);
            lvi.SubItems.Add(AnimationMapping.BeginWalk);
            lvi.SubItems.Add(AnimationMapping.EndWalk);
            lvi.SubItems.Add(AnimationMapping.Run);
            lvi.SubItems.Add(AnimationMapping.Idle);
            lvi.SubItems.Add(AnimationMapping.Move);
            lvi.SubItems.Add(AnimationMapping.Hurt);
            lvi.SubItems.Add(AnimationMapping.BigHurt);
            lvi.SubItems.Add(AnimationMapping.Daze);
            lvi.SubItems.Add(AnimationMapping.Dodge);
            lvi.SubItems.Add(AnimationMapping.Die);
            lvi.SubItems.Add(AnimationMapping.Block);
            lvi.SubItems.Add(AnimationMapping.Buffer);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createBattleAreaLvis()
        {
            if (!DataManager.dict.ContainsKey("BattleArea"))
            {
                DataManager.LoadTextfile("BattleArea");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, BattleArea> kv in (Dictionary<string, BattleArea>)DataManager.dict["BattleArea"])
            {
                ListViewItem lvi = createBattleAreaLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("BattleArea_cus"))
            {
                foreach (KeyValuePair<string, BattleArea> kv in (Dictionary<string, BattleArea>)DataManager.dict["BattleArea_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createBattleAreaLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createBattleAreaLvi(string battleAreaId)
        {
            ListViewItem lvi = new ListViewItem();

            BattleArea battleArea = DataManager.getData<BattleArea>(battleAreaId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("BattleArea_cus") && DataManager.dict["BattleArea_cus"].Contains(battleAreaId))
            {
                isCus = true;
            }

            lvi.Text = battleArea.Id;

            lvi.SubItems.Add(battleArea.Remark);
            lvi.SubItems.Add(getBattleGridRemark(battleArea.BattleMap));
            lvi.SubItems.Add(getScheduleName(battleArea.ScheduleID));
            string dropProps = "";
            if (battleArea.DropProps != null && battleArea.DropProps.Count > 0)
            {
                for (int i = 0; i < battleArea.DropProps.Count; i++)
                {
                    dropProps += getPropsName(battleArea.DropProps[i].Id) + "*" + battleArea.DropProps[i].Amount + ",";
                }
                dropProps = dropProps.Substring(0, dropProps.Length - 1);
            }
            lvi.SubItems.Add(dropProps);
            lvi.SubItems.Add(battleArea.MusicName);
            lvi.SubItems.Add(getCinematicName(battleArea.AfterWinMovie));
            lvi.SubItems.Add(getCinematicName(battleArea.AfterLoseMovie));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createBattleEventCubeLvis()
        {
            if (!DataManager.dict.ContainsKey("BattleEventCube"))
            {
                DataManager.LoadTextfile("BattleEventCube");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, BattleEventCube> kv in (Dictionary<string, BattleEventCube>)DataManager.dict["BattleEventCube"])
            {
                ListViewItem lvi = createBattleEventCubeLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("BattleEventCube_cus"))
            {
                foreach (KeyValuePair<string, BattleEventCube> kv in (Dictionary<string, BattleEventCube>)DataManager.dict["BattleEventCube_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createBattleEventCubeLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createBattleEventCubeLvi(string battleEventCubeId)
        {
            ListViewItem lvi = new ListViewItem();

            BattleEventCube bec = DataManager.getData<BattleEventCube>(battleEventCubeId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("BattleEventCube_cus") && DataManager.dict["BattleEventCube_cus"].Contains(battleEventCubeId))
            {
                isCus = true;
            }

            lvi.Text = bec.Id;

            lvi.SubItems.Add(getCharacterInfoRemark(bec.InfoId));
            lvi.SubItems.Add(getCharacterExteriorName(bec.ExteriorId));
            lvi.SubItems.Add(bec.Remark);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createBattleGridLvis()
        {
            if (!DataManager.dict.ContainsKey("BattleGrid"))
            {
                DataManager.LoadTextfile("BattleGrid");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, BattleGrid> kv in (Dictionary<string, BattleGrid>)DataManager.dict["BattleGrid"])
            {
                ListViewItem lvi = createBattleGridLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("BattleGrid_cus"))
            {
                foreach (KeyValuePair<string, BattleGrid> kv in (Dictionary<string, BattleGrid>)DataManager.dict["BattleGrid_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createBattleGridLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createBattleGridLvi(string battleGridId)
        {
            ListViewItem lvi = new ListViewItem();

            BattleGrid battleGrid = DataManager.getData<BattleGrid>(battleGridId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("BattleGrid_cus") && DataManager.dict["BattleGrid_cus"].Contains(battleGridId))
            {
                isCus = true;
            }

            lvi.Text = battleGrid.Id;

            lvi.SubItems.Add(getMapsName(battleGrid.MapId));
            lvi.SubItems.Add(battleGrid.Remark);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }
        public static Dictionary<string, ListViewItem> createBookLvis()
        {
            if (!DataManager.dict.ContainsKey("Book"))
            {
                DataManager.LoadTextfile("Book");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Book> kv in (Dictionary<string, Book>)DataManager.dict["Book"])
            {
                ListViewItem lvi = createBookLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            foreach (KeyValuePair<string, Book> kv in (Dictionary<string, Book>)DataManager.dict["Book_cus"])
            {
                if (!lvis.ContainsKey(kv.Key))
                {
                    ListViewItem lvi = createBookLvi(kv.Key);

                    lvis.Add(kv.Key, lvi);
                }
            }

            return lvis;
        }

        public static ListViewItem createBookLvi(string bookId)
        {
            ListViewItem lvi = new ListViewItem();

            Book book = DataManager.getData<Book>(bookId);
            bool isCustom = false;

            if (DataManager.dict.ContainsKey("Book_cus") && DataManager.dict["Book_cus"].Contains(bookId))
            {
                isCustom = true;
            }


            lvi.ImageKey = book.IconName;
            lvi.Text = book.IconName;

            lvi.SubItems.Add(bookId);
            lvi.SubItems.Add(book.Name);
            lvi.SubItems.Add(book.Remark);
            lvi.SubItems.Add(book.IsLibary.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(book.BookTab));
            lvi.SubItems.Add(book.Description);
            lvi.SubItems.Add(book.MaxReadTime.ToString());
            string ReadEffect = "";
            if (book.ReadEffect != null && book.ReadEffect.Count > 0)
            {
                for (int i = 0; i < book.ReadEffect.Count; i++)
                {
                    ReadEffect += getRewardRemark(book.ReadEffect[i]) + ",";
                }
                ReadEffect = ReadEffect.Substring(0, ReadEffect.Length - 1);
            }
            lvi.SubItems.Add(ReadEffect);
            string LearnSkill = "";
            LearnSkill = getSkillsName(book.LearnSkill);
            if (LearnSkill.Contains("未找到"))
            {
                LearnSkill = getMantraName(book.LearnSkill);
                if (LearnSkill.Contains("未找到"))
                {
                    LearnSkill = getPropssName(book.LearnSkill);
                }
            }
            lvi.SubItems.Add(LearnSkill);
            lvi.SubItems.Add(Utils.getFlowNodeStr(book.ReadCondition));
            lvi.SubItems.Add(book.ReadConditionDescription);
            lvi.SubItems.Add(Utils.getFlowNodeStr(book.ShowCondition));
            lvi.SubItems.Add(book.TipsCanRead[0]);
            lvi.SubItems.Add(book.TipsCanNotRead[0]);
            lvi.SubItems.Add(getCinematicName(book.NotReadFinishMovie));
            lvi.SubItems.Add(getCinematicName(book.ReadFinishMovie));



            if (isCustom)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createCharacterBehaviourLvis()
        {
            if (!DataManager.dict.ContainsKey("CharacterBehaviour"))
            {
                DataManager.LoadTextfile("CharacterBehaviour");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, CharacterBehaviour> kv in (Dictionary<string, CharacterBehaviour>)DataManager.dict["CharacterBehaviour"])
            {
                ListViewItem lvi = createCharacterBehaviourLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("CharacterBehaviour_cus"))
            {
                foreach (KeyValuePair<string, CharacterBehaviour> kv in (Dictionary<string, CharacterBehaviour>)DataManager.dict["CharacterBehaviour_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createCharacterBehaviourLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createCharacterBehaviourLvi(string characterBehaviourId)
        {
            ListViewItem lvi = new ListViewItem();

            CharacterBehaviour ci = DataManager.getData<CharacterBehaviour>(characterBehaviourId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("CharacterBehaviour_cus") && DataManager.dict["CharacterBehaviour_cus"].Contains(characterBehaviourId))
            {
                isCus = true;
            }

            lvi.Text = ci.Id;

            lvi.SubItems.Add(ci.Remark);
            lvi.SubItems.Add(ci.Position.ToString());
            lvi.SubItems.Add(ci.Rotation.ToString());
            lvi.SubItems.Add(ci.IsTuen.ToString());
            lvi.SubItems.Add(getTalkMessage(ci.TalkId));
            lvi.SubItems.Add(ci.Animation);
            lvi.SubItems.Add(ci.SchedulerId);
            lvi.SubItems.Add(EnumData.GetDisplayName(ci.ClickType));
            lvi.SubItems.Add(ci.InteractiveName);
            lvi.SubItems.Add(Utils.getFlowNodeStr(ci.InteractiveEvent));
            lvi.SubItems.Add(Utils.getFlowNodeStr(ci.CreateCondition));
            lvi.SubItems.Add(Utils.getFlowNodeStr(ci.AppearCondition));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createCharacterExteriorLvis()
        {
            if (!DataManager.dict.ContainsKey("CharacterExterior"))
            {
                DataManager.LoadTextfile("CharacterExterior");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();

            ListViewItem lvi;
            foreach (KeyValuePair<string, CharacterExterior> kv in (Dictionary<string, CharacterExterior>)DataManager.dict["CharacterExterior"])
            {
                lvi = createCharacterExteriorLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("CharacterExterior_cus"))
            {
                foreach (KeyValuePair<string, CharacterExterior> kv in (Dictionary<string, CharacterExterior>)DataManager.dict["CharacterExterior_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        lvi = createCharacterExteriorLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createCharacterExteriorLvi(string characterExteriorId)
        {
            ListViewItem lvi = new ListViewItem();

            CharacterExterior ci = DataManager.getData<CharacterExterior>(characterExteriorId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("CharacterExterior_cus") && DataManager.dict["CharacterExterior_cus"].Contains(characterExteriorId))
            {
                isCus = true;
            }

            lvi.Text = ci.Id;

            lvi.SubItems.Add(ci.Remark);
            lvi.SubItems.Add(ci.SurName);
            lvi.SubItems.Add(ci.Name);
            lvi.SubItems.Add(ci.Nickname);
            lvi.SubItems.Add(ci.Protrait);
            lvi.SubItems.Add(ci.Description);
            lvi.SubItems.Add(EnumData.GetDisplayName(ci.Gender));
            lvi.SubItems.Add(EnumData.GetDisplayName(ci.Size));
            lvi.SubItems.Add(ci.Model);
            lvi.SubItems.Add(ci.AnimMapId);
            lvi.SubItems.Add(ci.Height.ToString());
            string preferenceType = "";
            if (ci.PreferenceType != null && ci.PreferenceType.Count > 0)
            {
                for (int i = 0; i < ci.PreferenceType.Count; i++)
                {
                    preferenceType += EnumData.GetDisplayName(ci.PreferenceType[i]) + ",";
                }
                preferenceType = preferenceType.Substring(0, preferenceType.Length - 1);
            }
            lvi.SubItems.Add(preferenceType);
            lvi.SubItems.Add(ci.IsShowProtrait.ToString());
            lvi.SubItems.Add(ci.InfoId);
            lvi.SubItems.Add(EnumData.GetDisplayName(ci.AgeGroup));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createCharacterInfoLvis()
        {
            if (!DataManager.dict.ContainsKey("CharacterInfo"))
            {
                DataManager.LoadTextfile("CharacterInfo");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, CharacterInfo> kv in (Dictionary<string, CharacterInfo>)DataManager.dict["CharacterInfo"])
            {
                ListViewItem lvi = createCharacterInfoLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("CharacterInfo_cus"))
            {
                foreach (KeyValuePair<string, CharacterInfo> kv in (Dictionary<string, CharacterInfo>)DataManager.dict["CharacterInfo_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createCharacterInfoLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createCharacterInfoLvi(string characterInfoId)
        {
            ListViewItem lvi = new ListViewItem();

            CharacterInfo ci = DataManager.getData<CharacterInfo>(characterInfoId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("CharacterInfo_cus") && DataManager.dict["CharacterInfo_cus"].Contains(characterInfoId))
            {
                isCus = true;
            }

            lvi.Text = ci.Id;

            lvi.SubItems.Add(ci.Remark);
            lvi.SubItems.Add(ci.Level.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(ci.Element));
            lvi.SubItems.Add(ci.CanChangeElement.ToString());

            string equipStr = "";
            /*if (MainForm.allPropsLvis.Count == 0)
            {
                createPropsLvis();
            }*/
            if (ci.Equip != null)
            {
                foreach (KeyValuePair<EquipType, string> kv in ci.Equip)
                {
                    if (kv.Value != null)
                    {
                        Props prop = DataManager.getData<Props>(kv.Value);
                        equipStr += "(" + EnumData.GetDisplayName(kv.Key) + "," + prop.Name + "),";
                    }
                }
            }
            if (equipStr.Length > 0)
            {
                equipStr = equipStr.Substring(0, equipStr.Length - 1);
            }
            lvi.SubItems.Add(equipStr);

            string propertyStr = "";
            if (ci.Property != null)
            {
                foreach (KeyValuePair<CharacterProperty, int> kv in ci.Property)
                {
                    if (kv.Value != 0)
                    {
                        propertyStr += "(" + EnumData.GetDisplayName(kv.Key) + "," + kv.Value + "),";
                    }
                }
            }
            if (propertyStr.Length > 0)
            {
                propertyStr = propertyStr.Substring(0, propertyStr.Length - 1);
            }
            lvi.SubItems.Add(propertyStr);

            string upgradeablePropertyStr = "";
            if (ci.UpgradeableProperty != null)
            {
                foreach (KeyValuePair<CharacterUpgradableProperty, int> kv in ci.UpgradeableProperty)
                {
                    if (kv.Value != 0)
                    {
                        upgradeablePropertyStr += "(" + EnumData.GetDisplayName(kv.Key) + "," + kv.Value + "),";
                    }
                }
            }
            if (upgradeablePropertyStr.Length > 0)
            {
                upgradeablePropertyStr = upgradeablePropertyStr.Substring(0, upgradeablePropertyStr.Length - 1);
            }
            lvi.SubItems.Add(upgradeablePropertyStr);

            string growPropertyStr = "";
            if (ci.GrowProperty != null)
            {
                foreach (KeyValuePair<CharacterUpgradableProperty, ScopeValue> kv in ci.GrowProperty)
                {
                    if (kv.Value != null)
                    {
                        growPropertyStr += "(" + EnumData.GetDisplayName(kv.Key) + "," + kv.Value.Min + "," + kv.Value.Max + "),";
                    }
                }
            }
            if (growPropertyStr.Length > 0)
            {
                growPropertyStr = growPropertyStr.Substring(0, growPropertyStr.Length - 1);
            }
            lvi.SubItems.Add(growPropertyStr);

            lvi.SubItems.Add(ci.GrowthFactor.ToString());

            string talentsStr = "";
            if (ci.Talents != null)
            {
                for (int i = 0; i < ci.Talents.Count; i++)
                {
                    Trait trait = DataManager.getData<Trait>(ci.Talents[i]);
                    if (trait != null)
                    {
                        talentsStr += trait.Name + ",";
                    }
                }
            }
            if (talentsStr.Length > 0)
            {
                talentsStr = talentsStr.Substring(0, talentsStr.Length - 1);
            }
            lvi.SubItems.Add(talentsStr);

            string SkillsStr = "";
            if (ci.Skills != null)
            {
                for (int i = 0; i < ci.Skills.Count; i++)
                {
                    Skill Skill = DataManager.getData<Skill>(ci.Skills[i].Id);
                    if (Skill != null)
                    {
                        SkillsStr += "(" + EnumData.GetDisplayName(ci.Skills[i].Column) + "," + Skill.Name + "," + ci.Skills[i].Level + "级),";
                    }
                }
            }
            if (SkillsStr.Length > 0)
            {
                SkillsStr = SkillsStr.Substring(0, SkillsStr.Length - 1);
            }
            lvi.SubItems.Add(SkillsStr);

            string mantrastr = "";
            if (ci.Mantras != null)
            {
                for (int i = 0; i < ci.Mantras.Count; i++)
                {
                    Mantra mantra = DataManager.getData<Mantra>(ci.Mantras[i].Id);
                    if (mantra != null)
                    {
                        mantrastr += "(" + mantra.Name + "," + ci.Mantras[i].Level + "级," + (ci.Mantras[i].IsWork ? "运行中" : "未运行") + "),";
                    }
                }
            }
            if (mantrastr.Length > 0)
            {
                mantrastr = mantrastr.Substring(0, mantrastr.Length - 1);
            }
            lvi.SubItems.Add(mantrastr);

            string specialStr = "";
            if (!string.IsNullOrEmpty(ci.Special))
            {
                Skill Skill = DataManager.getData<Skill>(ci.Special);
                specialStr = Skill.Name;
            }
            lvi.SubItems.Add(specialStr);

            string dropRewardsStr = "";
            if (ci.DropRewards != null)
            {
                for (int i = 0; i < ci.DropRewards.Count; i++)
                {
                    Reward reward = DataManager.getData<Reward>(ci.DropRewards[i]);
                    dropRewardsStr += reward.Remark + ",";
                }
            }
            if (dropRewardsStr.Length > 0)
            {
                dropRewardsStr = dropRewardsStr.Substring(0, dropRewardsStr.Length - 1);
            }
            lvi.SubItems.Add(dropRewardsStr);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createElectiveLvis()
        {
            if (!DataManager.dict.ContainsKey("Elective"))
            {
                DataManager.LoadTextfile("Elective");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Elective> kv in (Dictionary<string, Elective>)DataManager.dict["Elective"])
            {
                ListViewItem lvi = createElectiveLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Elective_cus"))
            {
                foreach (KeyValuePair<string, Elective> kv in (Dictionary<string, Elective>)DataManager.dict["Elective_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createElectiveLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createElectiveLvi(string ElectiveId)
        {
            ListViewItem lvi = new ListViewItem();

            Elective Elective = DataManager.getData<Elective>(ElectiveId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Elective_cus") && DataManager.dict["Elective_cus"].Contains(ElectiveId))
            {
                isCus = true;
            }

            lvi.Text = Elective.Id;

            lvi.SubItems.Add(Elective.Name);
            lvi.SubItems.Add(Elective.Remark);
            lvi.SubItems.Add(getCharacterExteriorName(Elective.ExteriorId));
            lvi.SubItems.Add(Elective.Description);
            lvi.SubItems.Add(EnumData.GetDisplayName(Elective.Grade));
            lvi.SubItems.Add(getSkillsName(Elective.LearnableSkillsId));
            lvi.SubItems.Add(Elective.ConditionDescription);
            lvi.SubItems.Add(Utils.getFlowNodeStr(Elective.Condition));
            lvi.SubItems.Add(Elective.IsRepeat.ToString());


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createEndingMovieLvis()
        {
            if (!DataManager.dict.ContainsKey("EndingMovie"))
            {
                DataManager.LoadTextfile("EndingMovie");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, EndingMovie> kv in (Dictionary<string, EndingMovie>)DataManager.dict["EndingMovie"])
            {
                ListViewItem lvi = createEndingMovieLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("EndingMovie_cus"))
            {
                foreach (KeyValuePair<string, EndingMovie> kv in (Dictionary<string, EndingMovie>)DataManager.dict["EndingMovie_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createEndingMovieLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createEndingMovieLvi(string EndingMovieId)
        {
            ListViewItem lvi = new ListViewItem();

            EndingMovie EndingMovie = DataManager.getData<EndingMovie>(EndingMovieId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("EndingMovie_cus") && DataManager.dict["EndingMovie_cus"].Contains(EndingMovieId))
            {
                isCus = true;
            }

            lvi.Text = EndingMovie.Id;

            lvi.SubItems.Add(EndingMovie.Remark);
            lvi.SubItems.Add(EndingMovie.EndGameid);
            lvi.SubItems.Add(EndingMovie.Musicid);
            lvi.SubItems.Add(Utils.getFlowNodeStr(EndingMovie.ShowCondition));


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createEvaluationLvis()
        {
            if (!DataManager.dict.ContainsKey("Evaluation"))
            {
                DataManager.LoadTextfile("Evaluation");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Evaluation> kv in (Dictionary<string, Evaluation>)DataManager.dict["Evaluation"])
            {
                ListViewItem lvi = createEvaluationLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Evaluation_cus"))
            {
                foreach (KeyValuePair<string, Evaluation> kv in (Dictionary<string, Evaluation>)DataManager.dict["Evaluation_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createEvaluationLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createEvaluationLvi(string evaluationId)
        {
            ListViewItem lvi = new ListViewItem();

            Evaluation evaluation = DataManager.getData<Evaluation>(evaluationId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Evaluation_cus") && DataManager.dict["Evaluation_cus"].Contains(evaluationId))
            {
                isCus = true;
            }

            lvi.Text = evaluation.Id;

            lvi.SubItems.Add(evaluation.Name);
            lvi.SubItems.Add(evaluation.Remark);
            lvi.SubItems.Add(evaluation.Description);

            string EvaluationPointInfoStr = "";
            if (evaluation.EvaluationPointInfo != null)
            {
                foreach (KeyValuePair<EvaluationPoint, EvaluationPointInfo> kv in evaluation.EvaluationPointInfo)
                {
                    if (kv.Value != null && !string.IsNullOrEmpty(kv.Value.Description))
                    {
                        EvaluationPointInfoStr += "[" + kv.Value.Description + ":" + kv.Value.Value + "分]";
                    }
                }
            }
            lvi.SubItems.Add(EvaluationPointInfoStr);

            string EvaluationRewardStr = "";
            if (evaluation.EvaluationReward != null)
            {
                foreach (KeyValuePair<EvaluationLevel, EvaluationReward> kv in evaluation.EvaluationReward)
                {
                    if (kv.Value != null && !string.IsNullOrEmpty(kv.Value.Id))
                    {
                        EvaluationRewardStr += "[" + EnumData.GetDisplayName(kv.Key) + ":" + getPropsName(kv.Value.Id) + "*" + kv.Value.Count + "]";
                    }
                }
            }
            lvi.SubItems.Add(EvaluationRewardStr);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createEventCubeLvis()
        {
            if (!DataManager.dict.ContainsKey("EventCube"))
            {
                DataManager.LoadTextfile("EventCube");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, EventCube> kv in (Dictionary<string, EventCube>)DataManager.dict["EventCube"])
            {
                ListViewItem lvi = createEventCubeLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("EventCube_cus"))
            {
                foreach (KeyValuePair<string, EventCube> kv in (Dictionary<string, EventCube>)DataManager.dict["EventCube_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createEventCubeLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createEventCubeLvi(string eventCubeId)
        {
            ListViewItem lvi = new ListViewItem();

            EventCube eventCube = DataManager.getData<EventCube>(eventCubeId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("EventCube_cus") && DataManager.dict["EventCube_cus"].Contains(eventCubeId))
            {
                isCus = true;
            }

            lvi.Text = eventCube.Id;

            lvi.SubItems.Add(eventCube.Name);
            lvi.SubItems.Add(eventCube.PrefabName);
            lvi.SubItems.Add(eventCube.IsRepeat.ToString());
            lvi.SubItems.Add(eventCube.Position.ToString());
            lvi.SubItems.Add(eventCube.Rotation.ToString());
            lvi.SubItems.Add(eventCube.Scale.ToString());
            lvi.SubItems.Add(eventCube.ColliderSize.ToString());
            lvi.SubItems.Add(eventCube.IsOnTerrain.ToString());
            lvi.SubItems.Add(eventCube.IsTrigger.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(eventCube.ClickType));
            lvi.SubItems.Add(eventCube.Remarks);
            lvi.SubItems.Add(eventCube.InteractiveHeight.ToString());
            lvi.SubItems.Add(Utils.getFlowNodeStr(eventCube.InteractiveEvent));
            lvi.SubItems.Add(Utils.getFlowNodeStr(eventCube.CreateCondition));
            lvi.SubItems.Add(Utils.getFlowNodeStr(eventCube.AppearCondition));
            lvi.SubItems.Add(eventCube.IsShowLightPoint.ToString());
            lvi.SubItems.Add(eventCube.Center.ToString());


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createFavorabilityLvis()
        {
            if (!DataManager.dict.ContainsKey("Favorability"))
            {
                DataManager.LoadTextfile("Favorability");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Favorability> kv in (Dictionary<string, Favorability>)DataManager.dict["Favorability"])
            {
                ListViewItem lvi = createFavorabilityLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Favorability_cus"))
            {
                foreach (KeyValuePair<string, Favorability> kv in (Dictionary<string, Favorability>)DataManager.dict["Favorability_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createFavorabilityLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createFavorabilityLvi(string FavorabilityId)
        {
            ListViewItem lvi = new ListViewItem();

            Favorability Favorability = DataManager.getData<Favorability>(FavorabilityId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Favorability_cus") && DataManager.dict["Favorability_cus"].Contains(FavorabilityId))
            {
                isCus = true;
            }

            lvi.Text = Favorability.Id;

            lvi.SubItems.Add(Favorability.Name);
            lvi.SubItems.Add(Favorability.Remark);
            lvi.SubItems.Add(Favorability.Description);



            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createForgeLvis()
        {
            if (!DataManager.dict.ContainsKey("Forge"))
            {
                DataManager.LoadTextfile("Forge");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Forge> kv in (Dictionary<string, Forge>)DataManager.dict["Forge"])
            {
                ListViewItem lvi = createForgeLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Forge_cus"))
            {
                foreach (KeyValuePair<string, Forge> kv in (Dictionary<string, Forge>)DataManager.dict["Forge_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createForgeLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createForgeLvi(string forgeId)
        {
            ListViewItem lvi = new ListViewItem();

            Forge forge = DataManager.getData<Forge>(forgeId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Forge_cus") && DataManager.dict["Forge_cus"].Contains(forgeId))
            {
                isCus = true;
            }

            lvi.Text = forge.Id;

            lvi.SubItems.Add(forge.Remark);
            lvi.SubItems.Add(getPropssName(forge.PropsId));
            lvi.SubItems.Add(forge.Level.ToString());
            lvi.SubItems.Add(getRoundStr(forge.OpenRound));
            lvi.SubItems.Add(forge.IsSpecial.ToString());
            lvi.SubItems.Add(forge.IsRestrictionCount.ToString());



            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createGameFormulaLvis()
        {
            if (!DataManager.dict.ContainsKey("GameFormula"))
            {
                DataManager.LoadTextfile("GameFormula");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, GameFormula> kv in (Dictionary<string, GameFormula>)DataManager.dict["GameFormula"])
            {
                ListViewItem lvi = createGameFormulaLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("GameFormula_cus"))
            {
                foreach (KeyValuePair<string, GameFormula> kv in (Dictionary<string, GameFormula>)DataManager.dict["GameFormula_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createGameFormulaLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createGameFormulaLvi(string GameFormulaId)
        {
            ListViewItem lvi = new ListViewItem();

            GameFormula GameFormula = DataManager.getData<GameFormula>(GameFormulaId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("GameFormula_cus") && DataManager.dict["GameFormula_cus"].Contains(GameFormulaId))
            {
                isCus = true;
            }

            lvi.Text = GameFormula.Id;

            lvi.SubItems.Add(GameFormula.Remark);
            lvi.SubItems.Add(GameFormula.Alias);
            lvi.SubItems.Add(GameFormula.Formula.Expression);



            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createHelpLvis()
        {
            if (!DataManager.dict.ContainsKey("Help"))
            {
                DataManager.LoadTextfile("Help");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Help> kv in (Dictionary<string, Help>)DataManager.dict["Help"])
            {
                ListViewItem lvi = createHelpLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Help_cus"))
            {
                foreach (KeyValuePair<string, Help> kv in (Dictionary<string, Help>)DataManager.dict["Help_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createHelpLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createHelpLvi(string HelpId)
        {
            ListViewItem lvi = new ListViewItem();

            Help Help = DataManager.getData<Help>(HelpId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Help_cus") && DataManager.dict["Help_cus"].Contains(HelpId))
            {
                isCus = true;
            }

            lvi.Text = Help.Id;

            lvi.SubItems.Add(EnumData.GetDisplayName(Help.MainTab));
            lvi.SubItems.Add(Help.IsMainEntry.ToString());
            lvi.SubItems.Add(Help.MainEntryId);
            lvi.SubItems.Add(Help.Name);
            lvi.SubItems.Add(Utils.getFlowNodeStr(Help.ShowCondition));
            lvi.SubItems.Add(Help.ImageName);
            lvi.SubItems.Add(getCharacterExteriorName(Help.ExteriorId));
            string HelpDescriptions = "";
            if (Help.HelpDescriptions != null && Help.HelpDescriptions.Count > 0)
            {
                for (int i = 0; i < Help.HelpDescriptions.Count; i++)
                {
                    HelpDescriptions += Help.HelpDescriptions[i] + ",";
                }
                HelpDescriptions = HelpDescriptions.Substring(0, HelpDescriptions.Length - 1);
            }
            lvi.SubItems.Add(HelpDescriptions);



            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createHelpDescriptionLvis()
        {
            if (!DataManager.dict.ContainsKey("HelpDescription"))
            {
                DataManager.LoadTextfile("HelpDescription");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, HelpDescription> kv in (Dictionary<string, HelpDescription>)DataManager.dict["HelpDescription"])
            {
                ListViewItem lvi = createHelpDescriptionLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("HelpDescription_cus"))
            {
                foreach (KeyValuePair<string, HelpDescription> kv in (Dictionary<string, HelpDescription>)DataManager.dict["HelpDescription_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createHelpDescriptionLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createHelpDescriptionLvi(string HelpDescriptionId)
        {
            ListViewItem lvi = new ListViewItem();

            HelpDescription HelpDescription = DataManager.getData<HelpDescription>(HelpDescriptionId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("HelpDescription_cus") && DataManager.dict["HelpDescription_cus"].Contains(HelpDescriptionId))
            {
                isCus = true;
            }

            lvi.Text = HelpDescription.Id;

            lvi.SubItems.Add(HelpDescription.Description);
            lvi.SubItems.Add(HelpDescription.Order.ToString());
            lvi.SubItems.Add(Utils.getFlowNodeStr(HelpDescription.ShowCondition));



            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createMantraLvis()
        {
            if (!DataManager.dict.ContainsKey("Mantra"))
            {
                DataManager.LoadTextfile("Mantra");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Mantra> kv in (Dictionary<string, Mantra>)DataManager.dict["Mantra"])
            {
                ListViewItem lvi = createMantraLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Mantra_cus"))
            {
                foreach (KeyValuePair<string, Mantra> kv in (Dictionary<string, Mantra>)DataManager.dict["Mantra_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createMantraLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createMantraLvi(string mantraId)
        {
            ListViewItem lvi = new ListViewItem();

            Mantra mantra = DataManager.getData<Mantra>(mantraId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Mantra_cus") && DataManager.dict["Mantra_cus"].Contains(mantraId))
            {
                isCus = true;
            }

            lvi.Text = mantra.IconName;
            lvi.ImageKey = mantra.IconName;

            lvi.SubItems.Add(mantra.Id);
            lvi.SubItems.Add(mantra.Name);
            lvi.SubItems.Add(mantra.Description);
            lvi.SubItems.Add(mantra.Remark);
            lvi.SubItems.Add(EnumData.GetDisplayName(mantra.RequireAttribute));
            lvi.SubItems.Add(mantra.RequireValue.ToString());

            string MantraRunEffectDescriptionStr = "";
            if (mantra.MantraRunEffectDescription != null)
            {
                for (int i = 0; i < mantra.MantraRunEffectDescription.Count; i++)
                {
                    MantraRunEffectDescriptionStr += mantra.MantraRunEffectDescription[i].EffectDescription + ";";
                }
            }
            lvi.SubItems.Add(MantraRunEffectDescriptionStr);

            string MantraPracticeEffectDescriptionStr = "";
            if (mantra.MantraPracticeEffectDescription != null)
            {
                for (int i = 0; i < mantra.MantraPracticeEffectDescription.Count; i++)
                {
                    MantraPracticeEffectDescriptionStr += mantra.MantraPracticeEffectDescription[i].EffectDescription + ";";
                }
            }
            lvi.SubItems.Add(MantraPracticeEffectDescriptionStr);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createMapLvis()
        {
            if (!DataManager.dict.ContainsKey("Map"))
            {
                DataManager.LoadTextfile("Map");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Map> kv in (Dictionary<string, Map>)DataManager.dict["Map"])
            {
                ListViewItem lvi = createMapLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Map_cus"))
            {
                foreach (KeyValuePair<string, Map> kv in (Dictionary<string, Map>)DataManager.dict["Map_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createMapLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createMapLvi(string mapId)
        {
            ListViewItem lvi = new ListViewItem();

            Map map = DataManager.getData<Map>(mapId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Map_cus") && DataManager.dict["Map_cus"].Contains(mapId))
            {
                isCus = true;
            }

            lvi.Text = map.Id;

            lvi.SubItems.Add(map.Name);
            lvi.SubItems.Add(map.Scenes);
            lvi.SubItems.Add(map.Place);
            lvi.SubItems.Add(map.DefaultPosition.ToString());
            lvi.SubItems.Add(map.DefaultRotation.ToString());
            lvi.SubItems.Add(map.Music);
            lvi.SubItems.Add(map.BattleDis.ToString());

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createNpcLvis()
        {
            if (!DataManager.dict.ContainsKey("Npc"))
            {
                DataManager.LoadTextfile("Npc");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Npc> kv in (Dictionary<string, Npc>)DataManager.dict["Npc"])
            {
                ListViewItem lvi = createNpcLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Npc_cus"))
            {
                foreach (KeyValuePair<string, Npc> kv in (Dictionary<string, Npc>)DataManager.dict["Npc_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createNpcLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createNpcLvi(string npcId)
        {
            ListViewItem lvi = new ListViewItem();

            Npc npc = DataManager.getData<Npc>(npcId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Npc_cus") && DataManager.dict["Npc_cus"].Contains(npcId))
            {
                isCus = true;
            }

            lvi.Text = npc.Id;

            lvi.SubItems.Add(npc.Name);
            lvi.SubItems.Add(npc.Remark);
            lvi.SubItems.Add(npc.CharacterInfoId);
            lvi.SubItems.Add(npc.ExteriorId);
            lvi.SubItems.Add(npc.IsTrigger.ToString());
            string behaviourId = "";
            if (npc.BehaviourId != null)
            {
                for (int i = 0; i < npc.BehaviourId.Count; i++)
                {
                    behaviourId = behaviourId + npc.BehaviourId[i] + ",";
                }
                behaviourId = behaviourId.Substring(0, behaviourId.Length - 1);
            }
            lvi.SubItems.Add(behaviourId);
            lvi.SubItems.Add(npc.InteractiveHeight.ToString());

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createNurturanceLvis()
        {
            if (!DataManager.dict.ContainsKey("Nurturance"))
            {
                DataManager.LoadTextfile("Nurturance");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Nurturance> kv in (Dictionary<string, Nurturance>)DataManager.dict["Nurturance"])
            {
                ListViewItem lvi = createNurturanceLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Nurturance_cus"))
            {
                foreach (KeyValuePair<string, Nurturance> kv in (Dictionary<string, Nurturance>)DataManager.dict["Nurturance_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createNurturanceLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createNurturanceLvi(string nurturanceId)
        {
            ListViewItem lvi = new ListViewItem();

            Nurturance nurturance = DataManager.getData<Nurturance>(nurturanceId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Nurturance_cus") && DataManager.dict["Nurturance_cus"].Contains(nurturanceId))
            {
                isCus = true;
            }

            lvi.ImageKey = nurturance.IconName;
            lvi.Text = nurturance.IconName;

            lvi.SubItems.Add(nurturance.Id);
            lvi.SubItems.Add(nurturance.Name);
            lvi.SubItems.Add(nurturance.Description);
            lvi.SubItems.Add(EnumData.GetDisplayName(nurturance.Fuction));
            lvi.SubItems.Add(EnumData.GetDisplayName(nurturance.UIType));
            lvi.SubItems.Add(nurturance.Emotion.ToString());
            lvi.SubItems.Add(Utils.getFlowNodeStr(nurturance.ShowCondition));
            lvi.SubItems.Add(Utils.getFlowNodeStr(nurturance.OpenCondition));
            lvi.SubItems.Add(Utils.getFlowNodeStr(nurturance.AdditionCondition));
            lvi.SubItems.Add(nurturance.AdditionValue.ToString());
            lvi.SubItems.Add(nurturance.AdditionTip);
            lvi.SubItems.Add(nurturance.BackGround);
            lvi.SubItems.Add(nurturance.MovieNumber);
            lvi.SubItems.Add(nurturance.NotOpenTip);
            lvi.SubItems.Add(nurturance.OtherTip);
            lvi.SubItems.Add(nurturance.FacilityTip);
            string RewardsStr = "";
            if (nurturance.Rewards != null && nurturance.Rewards.Count > 0)
            {
                for (int i = 0; i < nurturance.Rewards.Count; i++)
                {
                    switch (nurturance.Rewards[i].Type)
                    {
                        case NurturanceRewardType.UpgradableProperty:
                            NurturanceRewardUpgradableProperty nr = (NurturanceRewardUpgradableProperty)nurturance.Rewards[i];
                            RewardsStr += EnumData.GetDisplayName(nr.Prop) + " 经验增加 " + nr.Value + ",";
                            break;
                        case NurturanceRewardType.CharacterProperty:
                            NurturanceRewardCharacterProperty nr2 = (NurturanceRewardCharacterProperty)nurturance.Rewards[i];
                            RewardsStr += EnumData.GetDisplayName(nr2.Prop) + " 经验增加 " + nr2.Value + ",";
                            break;
                        case NurturanceRewardType.Money:
                            NurturanceRewardMoney nr3 = (NurturanceRewardMoney)nurturance.Rewards[i];
                            RewardsStr += "金钱增加 " + nr3.Value + ",";
                            break;
                    }
                }
                RewardsStr = RewardsStr.Substring(0, RewardsStr.Length - 1);
            }
            lvi.SubItems.Add(RewardsStr);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createPropsLvis()
        {
            if (!DataManager.dict.ContainsKey("Props"))
            {
                DataManager.LoadTextfile("Props");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();

            ListViewItem lvi = new ListViewItem();
            foreach (KeyValuePair<string, Props> kv in (Dictionary<string, Props>)DataManager.dict["Props"])
            {
                lvi = createPropsLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Props_cus"))
            {
                foreach (KeyValuePair<string, Props> kv in (Dictionary<string, Props>)DataManager.dict["Props_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        lvi = createPropsLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createPropsLvi(string propsId)
        {
            ListViewItem lvi = new ListViewItem();

            Props props = DataManager.getData<Props>(propsId);
            bool isCus = false;
            string path = DataManager.textFilePath + "\\Props.txt";

            if (DataManager.dict.ContainsKey("Props_cus") && DataManager.dict["Props_cus"].Contains(propsId))
            {
                path = MainForm.savePath + MainForm.modName + "\\" + DataManager.modTextFilePath + "\\" + "Props.txt";
                isCus = true;
            }

            lvi.Text = string.Format("PropsCategory{0:000}", (int)props.PropsCategory);
            lvi.ImageKey = string.Format("PropsCategory{0:000}", (int)props.PropsCategory);

            lvi.SubItems.Add(props.Id);
            lvi.SubItems.Add(props.Name);
            lvi.SubItems.Add(props.Remark);
            lvi.SubItems.Add(props.Description);
            lvi.SubItems.Add(EnumData.GetDisplayName(props.PropsType));
            lvi.SubItems.Add(EnumData.GetDisplayName(props.PropsCategory));
            lvi.SubItems.Add(props.Model);
            lvi.SubItems.Add(props.Price.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(props.UseTime));
            lvi.SubItems.Add(props.CanDeals.ToString());
            lvi.SubItems.Add(props.IsShow.ToString());
            lvi.SubItems.Add(getBuffersName(props.BuffList));
            lvi.SubItems.Add(props.ConditionDescription);
            lvi.SubItems.Add(props.PropsEffectDescription);
            lvi.SubItems.Add(getNpcsName(props.CanUseID));


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createQuestLvis()
        {
            if (!DataManager.dict.ContainsKey("Quest"))
            {
                DataManager.LoadTextfile("Quest");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Quest> kv in (Dictionary<string, Quest>)DataManager.dict["Quest"])
            {
                ListViewItem lvi = createQuestLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Quest_cus"))
            {
                foreach (KeyValuePair<string, Quest> kv in (Dictionary<string, Quest>)DataManager.dict["Quest_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createQuestLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createQuestLvi(string questId)
        {
            ListViewItem lvi = new ListViewItem();

            Quest quest = DataManager.getData<Quest>(questId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Quest_cus") && DataManager.dict["Quest_cus"].Contains(questId))
            {
                isCus = true;
            }

            lvi.Text = quest.Id;

            lvi.SubItems.Add(quest.Name);

            lvi.SubItems.Add("");
            if (quest.ConsignorId != "")
            {
                Npc npc = DataManager.getData<Npc>(quest.ConsignorId);
                if (npc != null)
                {
                    CharacterExterior ce = DataManager.getData<CharacterExterior>(npc.ExteriorId);
                    if (ce != null)
                    {
                        lvi.SubItems[2].Text = ce.SurName + ce.Name;
                    }
                }
            }
            lvi.SubItems.Add(quest.Remark);
            lvi.SubItems.Add(EnumData.GetDisplayName(quest.Type));
            lvi.SubItems.Add(quest.Brief);
            lvi.SubItems.Add(quest.Description);
            lvi.SubItems.Add(quest.NextQuestId);
            lvi.SubItems.Add(quest.FailQuestId);
            lvi.SubItems.Add(quest.AdjustmentId);
            lvi.SubItems.Add(quest.IsShowHint.ToString());
            lvi.SubItems.Add(Utils.getFlowNodeStr(quest.ShowCondition));
            string PickUpConditionDescription = "";
            if (quest.PickUpConditionDescription != null)
            {
                PickUpConditionDescription = quest.PickUpConditionDescription.ToString();
            }
            lvi.SubItems.Add(PickUpConditionDescription);
            lvi.SubItems.Add(quest.DeadLine);
            lvi.SubItems.Add(EnumData.GetDisplayName((Schedule)quest.Schedule));

            lvi.SubItems.Add("");
            if (quest.EvaluationReward != null)
            {
                string EvaluationRewardStr = "";
                foreach (KeyValuePair<EvaluationLevel, EvaluationReward> kv in quest.EvaluationReward)
                {
                    EvaluationReward er = kv.Value;
                    string valueStr = "";
                    if (er != null && !string.IsNullOrEmpty(er.Id))
                    {
                        valueStr = kv.Value.Id == "Money" ? ("金钱" + kv.Value.Count + ";") : (DataManager.getPropssName(kv.Value.Id) + kv.Value.Count + "个;");
                    }
                    EvaluationRewardStr += valueStr;
                }
                lvi.SubItems[15].Text = EvaluationRewardStr;
            }
            lvi.SubItems.Add(quest.IsRepeat.ToString());

            string NoteDescriptionStr = "";
            if (quest.NoteDescription != null)
            {
                for (int i = 0; i < quest.NoteDescription.Count; i++)
                {
                    NoteDescriptionStr += quest.NoteDescription[i] + ",";
                }
                if (NoteDescriptionStr.Length > 0)
                {
                    NoteDescriptionStr = NoteDescriptionStr.Substring(0, NoteDescriptionStr.Length - 1); ;
                }
            }
            lvi.SubItems.Add(NoteDescriptionStr);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createRegistrationBonusLvis()
        {
            if (!DataManager.dict.ContainsKey("RegistrationBonus"))
            {
                DataManager.LoadTextfile("RegistrationBonus");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, RegistrationBonus> kv in (Dictionary<string, RegistrationBonus>)DataManager.dict["RegistrationBonus"])
            {
                ListViewItem lvi = createRegistrationBonusLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("RegistrationBonus_cus"))
            {
                foreach (KeyValuePair<string, RegistrationBonus> kv in (Dictionary<string, RegistrationBonus>)DataManager.dict["RegistrationBonus_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createRegistrationBonusLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createRegistrationBonusLvi(string RegistrationBonusId)
        {
            ListViewItem lvi = new ListViewItem();

            RegistrationBonus RegistrationBonus = DataManager.getData<RegistrationBonus>(RegistrationBonusId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("RegistrationBonus_cus") && DataManager.dict["RegistrationBonus_cus"].Contains(RegistrationBonusId))
            {
                isCus = true;
            }

            lvi.Text = RegistrationBonus.Id;

            lvi.SubItems.Add(RegistrationBonus.Desc);
            lvi.SubItems.Add(RegistrationBonus.FourAttributesPoint.ToString());
            lvi.SubItems.Add(RegistrationBonus.TraitPoint.ToString());
            string UnLockTraits = "";
            if (RegistrationBonus.UnLockTraits != null)
            {
                for (int i = 0; i < RegistrationBonus.UnLockTraits.Count; i++)
                {
                    UnLockTraits += getTraitName(RegistrationBonus.UnLockTraits[i]) + ",";
                }
                UnLockTraits = UnLockTraits.Substring(0, UnLockTraits.Length - 1);
            }
            lvi.SubItems.Add(UnLockTraits);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createRewardLvis()
        {
            if (!DataManager.dict.ContainsKey("Reward"))
            {
                DataManager.LoadTextfile("Reward");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Reward> kv in (Dictionary<string, Reward>)DataManager.dict["Reward"])
            {
                ListViewItem lvi = createRewardLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Reward_cus"))
            {
                foreach (KeyValuePair<string, Reward> kv in (Dictionary<string, Reward>)DataManager.dict["Reward_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createRewardLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createRewardLvi(string rewardId)
        {
            ListViewItem lvi = new ListViewItem();

            Reward reward = DataManager.getData<Reward>(rewardId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Reward_cus") && DataManager.dict["Reward_cus"].Contains(rewardId))
            {
                isCus = true;
            }

            lvi.Text = reward.Id;

            lvi.SubItems.Add(reward.Remark);
            lvi.SubItems.Add(reward.IsShowMessage.ToString());
            lvi.SubItems.Add(reward.Description);
            lvi.SubItems.Add(Utils.getFlowNodeStr(reward.Rewards));


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createRoundLvis()
        {
            if (!DataManager.dict.ContainsKey("Round"))
            {
                DataManager.LoadTextfile("Round");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Round> kv in (Dictionary<string, Round>)DataManager.dict["Round"])
            {
                ListViewItem lvi = createRoundLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Round_cus"))
            {
                foreach (KeyValuePair<string, Round> kv in (Dictionary<string, Round>)DataManager.dict["Round_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createRoundLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createRoundLvi(string RoundId)
        {
            ListViewItem lvi = new ListViewItem();

            Round Round = DataManager.getData<Round>(RoundId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Round_cus") && DataManager.dict["Round_cus"].Contains(RoundId))
            {
                isCus = true;
            }
            lvi.Text = Round.Id;

            lvi.SubItems.Add(Round.Name);
            lvi.SubItems.Add(Utils.getFlowNodeStr(Round.EventNameCondition));
            lvi.SubItems.Add(Round.EventName);
            lvi.SubItems.Add(Round.Remark);
            lvi.SubItems.Add(EnumData.GetDisplayName(Round.WeatherType));
            lvi.SubItems.Add(Round.FriendMessagingId);
            lvi.SubItems.Add(Round.ToolManMessagingId);
            lvi.SubItems.Add(Round.IsGroupPractice.ToString());
            lvi.SubItems.Add(Round.IsInternalPractice.ToString());
            lvi.SubItems.Add(getMapsName(Round.BeginMapId));
            lvi.SubItems.Add(getCinematicName(Round.BeginCinematicId));
            lvi.SubItems.Add(getMapsName(Round.ForceMapId));
            lvi.SubItems.Add(getCinematicName(Round.ForceCinematicId));
            lvi.SubItems.Add(Utils.getFlowNodeStr(Round.BeginCondition));

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createShopLvis()
        {
            if (!DataManager.dict.ContainsKey("Shop"))
            {
                DataManager.LoadTextfile("Shop");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Shop> kv in (Dictionary<string, Shop>)DataManager.dict["Shop"])
            {
                ListViewItem lvi = createShopLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Shop_cus"))
            {
                foreach (KeyValuePair<string, Shop> kv in (Dictionary<string, Shop>)DataManager.dict["Shop_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createShopLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createShopLvi(string ShopId)
        {
            ListViewItem lvi = new ListViewItem();

            Shop Shop = DataManager.getData<Shop>(ShopId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Shop_cus") && DataManager.dict["Shop_cus"].Contains(ShopId))
            {
                isCus = true;
            }
            lvi.Text = Shop.Id;

            lvi.SubItems.Add(Shop.Remark);
            lvi.SubItems.Add(getPropssName(Shop.PropsId));
            string ShopPeriods = "";
            if (Shop.ShopPeriods != null)
            {
                for (int i = 0; i < Shop.ShopPeriods.Count; i++)
                {
                    ShopPeriods += "(" + getRoundStr(Shop.ShopPeriods[i].OpenRound) + "," + getRoundStr(Shop.ShopPeriods[i].CloseRound) + ")";
                }
            }
            lvi.SubItems.Add(ShopPeriods);
            lvi.SubItems.Add(Utils.getFlowNodeStr(Shop.Condition));
            lvi.SubItems.Add(Shop.IsRepeat.ToString());

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createSkillLvis()
        {
            if (!DataManager.dict.ContainsKey("Skill"))
            {
                DataManager.LoadTextfile("Skill");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Skill> kv in (Dictionary<string, Skill>)DataManager.dict["Skill"])
            {
                ListViewItem lvi = createSkillLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Skill_cus"))
            {
                foreach (KeyValuePair<string, Skill> kv in (Dictionary<string, Skill>)DataManager.dict["Skill_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createSkillLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createSkillLvi(string SkillId)
        {
            ListViewItem lvi = new ListViewItem();

            Skill Skill = DataManager.getData<Skill>(SkillId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Skill_cus") && DataManager.dict["Skill_cus"].Contains(SkillId))
            {
                isCus = true;
            }

            lvi.ImageKey = Skill.IconName;
            lvi.Text = Skill.IconName;

            lvi.SubItems.Add(Skill.Id);
            lvi.SubItems.Add(Skill.Name);
            lvi.SubItems.Add(Skill.Description);
            lvi.SubItems.Add(Skill.Remark);
            lvi.SubItems.Add(Skill.Rank.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.RequireAttribute));
            lvi.SubItems.Add(Skill.RequireValue.ToString());
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.Type));
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.DamageType));
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.TargetType));
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.TargetArea));
            lvi.SubItems.Add(Skill.MaxRange.ToString());
            lvi.SubItems.Add(Skill.MinRange.ToString());
            lvi.SubItems.Add(Skill.AOE.ToString());
            lvi.SubItems.Add(Skill.Damage);
            lvi.SubItems.Add(EnumData.GetDisplayName(Skill.Algorithm));
            lvi.SubItems.Add(Skill.RequestMP.ToString());
            lvi.SubItems.Add(Skill.MaxCD.ToString());
            lvi.SubItems.Add(getBuffersName(Skill.TargetBuffList));
            lvi.SubItems.Add(getBuffersName(Skill.SelfBuffList));
            lvi.SubItems.Add(Skill.Effect);
            lvi.SubItems.Add(Skill.PushDistance.ToString());
            lvi.SubItems.Add(getNpcsName(Skill.Summonid));
            lvi.SubItems.Add(Utils.getFlowNodeStr(Skill.Rewards));
            lvi.SubItems.Add(Skill.FullSkillTransformId);


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createStringTableLvis()
        {
            if (!DataManager.dict.ContainsKey("StringTable"))
            {
                DataManager.LoadTextfile("StringTable");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, StringTable> kv in (Dictionary<string, StringTable>)DataManager.dict["StringTable"])
            {
                ListViewItem lvi = createStringTableLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("StringTable_cus"))
            {
                foreach (KeyValuePair<string, StringTable> kv in (Dictionary<string, StringTable>)DataManager.dict["StringTable_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createStringTableLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createStringTableLvi(string StringTableId)
        {
            ListViewItem lvi = new ListViewItem();

            StringTable StringTable = DataManager.getData<StringTable>(StringTableId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("StringTable_cus") && DataManager.dict["StringTable_cus"].Contains(StringTableId))
            {
                isCus = true;
            }
            lvi.Text = StringTable.Id;

            lvi.SubItems.Add(StringTable.Remark);
            lvi.SubItems.Add(StringTable.Text);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static string talkFileContent = "";
        public static string talkFileContentMod = "";
        public static Dictionary<string, ListViewItem> createTalkLvis()
        {
            if (!MainForm.loadDataForm.Visible)
            {
                Thread loadDataFormThread = new Thread(new ThreadStart(showLoadDataForm));
                loadDataFormThread.Start();
            }
            if (!DataManager.dict.ContainsKey("Talk"))
            {
                DataManager.LoadTextfile("Talk");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            MainForm.loadDataForm.getOneProgressBar().Maximum += DataManager.dict["Talk"].Count;


            string path = DataManager.textFilePath + "\\Talk.txt";
            if (File.Exists(path))
            {
                talkFileContent = File.ReadAllText(path);
            }
            path = MainForm.savePath + MainForm.modName + "\\" + DataManager.textFilePath + "\\Talk.txt";
            if (File.Exists(path))
            {
                talkFileContentMod = File.ReadAllText(path);
            }


            foreach (KeyValuePair<string, Talk> kv in (Dictionary<string, Talk>)DataManager.dict["Talk"])
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum = DataManager.dict["Talk"].Count;
                MainForm.loadDataForm.GetTotalLabel().Text = "正在创建列表:" + kv.Key;
                ListViewItem lvi = createTalkLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
                if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
                {
                    MainForm.loadDataForm.getOneProgressBar().Value++;
                }
                MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
            }
            if (DataManager.dict.ContainsKey("Talk_cus"))
            {
                MainForm.loadDataForm.getOneProgressBar().Maximum += DataManager.dict["Talk_cus"].Count;
                foreach (KeyValuePair<string, Talk> kv in (Dictionary<string, Talk>)DataManager.dict["Talk_cus"])
                {
                    MainForm.loadDataForm.GetTotalLabel().Text = "正在创建列表:" + kv.Key;
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createTalkLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                        MainForm.loadDataForm.getOneProgressBar().Value++;
                        MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;
                    }
                }
            }
            if (MainForm.loadDataForm.getOneProgressBar().Value < MainForm.loadDataForm.getOneProgressBar().Maximum)
            {
                MainForm.loadDataForm.getOneProgressBar().Value++;
            }
            MainForm.loadDataForm.getOneLabel().Text = MainForm.loadDataForm.getOneProgressBar().Value + "/" +MainForm.loadDataForm.getOneProgressBar().Maximum;

            return lvis;
        }

        public static ListViewItem createTalkLvi(string id)
        {
            ListViewItem lvi = new ListViewItem();

            Talk talk = DataManager.getData<Talk>(id);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Talk_cus") && DataManager.dict["Talk_cus"].Contains(id))
            {
                isCus = true;
            }


            /*int startIndex = isCus? talkFileContentMod.IndexOf("\n" + id):talkFileContent.IndexOf("\n" + id);
            if (startIndex == -1)
            {
                startIndex = isCus ? talkFileContentMod.IndexOf(id) : talkFileContent.IndexOf(id);
            }
            int endIndex = isCus ? talkFileContentMod.IndexOf("\r\n", startIndex) : talkFileContent.IndexOf("\r\n", startIndex);
            int length = endIndex - startIndex;

            string talkStr = isCus ? talkFileContentMod.Substring(startIndex, length) : talkFileContent.Substring(startIndex, length);
            //talkStr = talkStr.Substring(0, talkStr.IndexOf('\n'));
            string[] talkField = talkStr.Split('\t');*/

            lvi.Text = talk.Id;

            lvi.SubItems.Add(getNpcsName(talk.TalkerId));
            lvi.SubItems.Add(EnumData.GetDisplayName(talk.EmotionType));
            lvi.SubItems.Add(EnumData.GetDisplayName(talk.MessageType));
            lvi.SubItems.Add(talk.Message);
            lvi.SubItems.Add(talk.FailTalkId);
            lvi.SubItems.Add(EnumData.GetDisplayName(talk.NextTalkType));
            lvi.SubItems.Add(talk.NextTalkId);
            lvi.SubItems.Add(talk.Animation);
            //lvi.SubItems.Add(talkField[9]);
            //lvi.SubItems.Add(talkField[10]);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createTraitLvis()
        {
            if (!DataManager.dict.ContainsKey("Trait"))
            {
                DataManager.LoadTextfile("Trait");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, Trait> kv in (Dictionary<string, Trait>)DataManager.dict["Trait"])
            {
                ListViewItem lvi = createTraitLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Trait_cus"))
            {
                foreach (KeyValuePair<string, Trait> kv in (Dictionary<string, Trait>)DataManager.dict["Trait_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createTraitLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createTraitLvi(string traitId)
        {
            ListViewItem lvi = new ListViewItem();

            Trait trait = DataManager.getData<Trait>(traitId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("Trait_cus") && DataManager.dict["Trait_cus"].Contains(traitId))
            {
                isCus = true;
            }

            lvi.Text = trait.Id;

            lvi.SubItems.Add(trait.Name);
            lvi.SubItems.Add(trait.Description);
            lvi.SubItems.Add(trait.Remark);
            lvi.SubItems.Add(trait.IsInitial.ToString());
            lvi.SubItems.Add(trait.Point.ToString());

            string CheckChainTraitListStr = "";
            if (trait.CheckChainTraitList != null)
            {
                for (int i = 0; i < trait.CheckChainTraitList.Count; i++)
                {
                    CheckChainTraitListStr += trait.CheckChainTraitList[i] + ",";
                }
            }
            if (CheckChainTraitListStr.Length > 0)
            {
                CheckChainTraitListStr = CheckChainTraitListStr.Substring(0, CheckChainTraitListStr.Length - 1);
            }
            lvi.SubItems.Add(CheckChainTraitListStr);

            string AddChainTraitListStr = "";
            if (trait.AddChainTraitList != null)
            {
                for (int i = 0; i < trait.AddChainTraitList.Count; i++)
                {
                    AddChainTraitListStr += trait.AddChainTraitList[i] + ",";
                }
            }
            if (AddChainTraitListStr.Length > 0)
            {
                AddChainTraitListStr = AddChainTraitListStr.Substring(0, AddChainTraitListStr.Length - 1);
            }
            lvi.SubItems.Add(AddChainTraitListStr);

            string InitialRewardsStr = "";
            if (trait.InitialRewards != null)
            {
                for (int i = 0; i < trait.InitialRewards.Count; i++)
                {
                    InitialRewardsStr += getRewardRemark(trait.InitialRewards[i]) + ",";
                }
            }
            if (InitialRewardsStr.Length > 0)
            {
                InitialRewardsStr = InitialRewardsStr.Substring(0, InitialRewardsStr.Length - 1);
            }
            lvi.SubItems.Add(InitialRewardsStr);


            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createEffectLvis()
        {
            DataManager.LoadEffect(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, AnimatorEventTrack> kv in (Dictionary<string, AnimatorEventTrack>)DataManager.dict["effect"])
            {
                ListViewItem lvi = createEffectLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("effect_cus"))
            {
                foreach (KeyValuePair<string, AnimatorEventTrack> kv in (Dictionary<string, AnimatorEventTrack>)DataManager.dict["effect_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createEffectLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createEffectLvi(string effectId)
        {
            ListViewItem lvi = new ListViewItem();

            AnimatorEventTrack effect = DataManager.getData<AnimatorEventTrack>(effectId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("effect_cus") && DataManager.dict["effect_cus"].Contains(effectId))
            {
                isCus = true;
            }


            lvi.Text = effectId;

            lvi.SubItems.Add(effect.Description);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createMovePathLvis()
        {
            DataManager.LoadMovePath(false);

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();
            foreach (KeyValuePair<string, MovePath> kv in (Dictionary<string, MovePath>)DataManager.dict["movepath"])
            {
                ListViewItem lvi = createMovePathLvi(kv.Key);

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("movepath_cus"))
            {
                foreach (KeyValuePair<string, MovePath> kv in (Dictionary<string, MovePath>)DataManager.dict["movepath_cus"])
                {
                    if (!lvis.ContainsKey(kv.Key))
                    {
                        ListViewItem lvi = createMovePathLvi(kv.Key);

                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createMovePathLvi(string movePathId)
        {
            ListViewItem lvi = new ListViewItem();

            MovePath movePath = DataManager.getData<MovePath>("movepath", movePathId);
            bool isCus = false;

            if (DataManager.dict.ContainsKey("movepath_cus") && DataManager.dict["movepath_cus"].Contains(movePathId))
            {
                isCus = true;
            }


            lvi.Text = movePathId;

            lvi.SubItems.Add(movePath.Description);

            if (isCus)
            {
                lvi.SubItems.Add("1");
            }
            else
            {
                lvi.SubItems.Add("0");
            }

            return lvi;
        }

        public static Dictionary<string, ListViewItem> createUnitLvis()
        {
            if (!DataManager.dict.ContainsKey("Npc"))
            {
                DataManager.LoadTextfile("Npc");
            }
            if (!DataManager.dict.ContainsKey("BattleEventCube"))
            {
                DataManager.LoadTextfile("BattleEventCube");
            }

            Dictionary<string, ListViewItem> lvis = new Dictionary<string, ListViewItem>();

            ListViewItem lvi = new ListViewItem();
            lvi.Text = "Player";
            lvi.SubItems.Add("玩家");
            lvis.Add(lvi.Text, lvi);

            lvi = new ListViewItem();
            lvi.Text = "party00";
            lvi.SubItems.Add("00号队友");
            lvis.Add(lvi.Text, lvi);

            lvi = new ListViewItem();
            lvi.Text = "party01";
            lvi.SubItems.Add("01号队友");
            lvis.Add(lvi.Text, lvi);

            lvi = new ListViewItem();
            lvi.Text = "party02";
            lvi.SubItems.Add("02号队友");
            lvis.Add(lvi.Text, lvi);

            lvi = new ListViewItem();
            lvi.Text = "party03";
            lvi.SubItems.Add("03号队友");
            lvis.Add(lvi.Text, lvi);

            foreach (KeyValuePair<string, Npc> kv in (Dictionary<string, Npc>)DataManager.dict["Npc"])
            {
                lvi = createUnitLvi(kv.Key);
                if (lvi == null)
                {
                    continue;
                }

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("Npc_cus"))
            {
                foreach (KeyValuePair<string, Npc> kv in (Dictionary<string, Npc>)DataManager.dict["Npc_cus"])
                {
                    lvi = createUnitLvi(kv.Key);
                    if (lvi == null)
                    {
                        continue;
                    }

                    if (lvis.ContainsKey(kv.Key))
                    {
                        lvis[kv.Key] = lvi;
                    }
                    else
                    {
                        lvis.Add(kv.Key, lvi);
                    }
                }
            }
            foreach (KeyValuePair<string, BattleEventCube> kv in (Dictionary<string, BattleEventCube>)DataManager.dict["BattleEventCube"])
            {
                lvi = createUnitLvi(kv.Key);
                if (lvi == null)
                {
                    continue;
                }

                lvis.Add(kv.Key, lvi);
            }
            if (DataManager.dict.ContainsKey("BattleEventCube_cus"))
            {
                foreach (KeyValuePair<string, BattleEventCube> kv in (Dictionary<string, BattleEventCube>)DataManager.dict["BattleEventCube_cus"])
                {
                    lvi = createUnitLvi(kv.Key);

                    if (lvi == null)
                    {
                        continue;
                    }

                    if (lvis.ContainsKey(kv.Key))
                    {
                        lvis[kv.Key] = lvi;
                    }
                    else
                    {
                        lvis.Add(kv.Key, lvi);
                    }
                }
            }

            return lvis;
        }

        public static ListViewItem createUnitLvi(string npcId)
        {
            string characterExteriorId = "";
            string characterInfoId = "";

            ListViewItem lvi = new ListViewItem();

            lvi.Text = npcId;

            if (npcId.Contains("bec"))
            {
                BattleEventCube bec = DataManager.getData<BattleEventCube>(npcId);

                lvi.SubItems.Add("");
                lvi.SubItems.Add(bec.Remark);

                characterExteriorId = bec.ExteriorId;
                characterInfoId = bec.InfoId;
            }
            else
            {
                Npc npc = DataManager.getData<Npc>(npcId);

                if(npc != null)
                {
                    lvi.SubItems.Add(npc.Name);
                    lvi.SubItems.Add(npc.Remark);

                    characterExteriorId = npc.ExteriorId;
                    characterInfoId = npc.CharacterInfoId;
                }

            }

            CharacterExterior ce = DataManager.getData<CharacterExterior>(characterExteriorId);
            CharacterInfo ci = DataManager.getData<CharacterInfo>(characterInfoId);

            if (ce == null || ci == null)
            {
                return null;
            }

            lvi.SubItems.Add(ce.SurName + ce.Name);
            lvi.SubItems.Add(ce.Remark);
            lvi.SubItems.Add(ci.Remark);

            return lvi;
        }

        public static string getBuffersName(string id)
        {
            string name = "";
            string[] bufferIds = id.Split(',');
            for (int i = 0; i < bufferIds.Length; i++)
            {
                name += DataManager.getBufferName(bufferIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getBuffersName(List<string> ids)
        {
            string name = "";
            if (ids != null)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    name += DataManager.getBufferName(ids[i]) + ",";
                }
            }
            if (name.Length > 0)
            {
                name = name.Substring(0, name.Length - 1);
            }

            return name;
        }

        public static string getBufferName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Buffer buffer = DataManager.getData<Buffer>("buffer", id);
                if (buffer == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = buffer.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getScheduleName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                BattleScheduleBundle schedule = DataManager.getData<BattleScheduleBundle>("battle/schedule", id);
                if (schedule == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = schedule.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getCinematicName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                ScheduleGraph.Bundle cinematic = DataManager.getData<ScheduleGraph.Bundle>("cinematic", id);
                if (cinematic == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = cinematic.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getAchievementName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Achievement achievement = DataManager.getData<Achievement>(id);
                if (achievement == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = achievement.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getAdjustmentName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Adjustment adjustment = DataManager.getData<Adjustment>(id);
                if (adjustment == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = adjustment.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getBattleAreaRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                BattleArea battleArea = DataManager.getData<BattleArea>(id);
                if (battleArea == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = battleArea.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getBattleEventCubesName(string id)
        {
            string name = "";
            string[] becIds = id.Split(',');
            for (int i = 0; i < becIds.Length; i++)
            {
                name += DataManager.getBattleEventCubeName(becIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getBattleEventCubeName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                BattleEventCube bec = DataManager.getData<BattleEventCube>(id);
                if (bec == null)
                {
                    name = "未找到";
                }
                else
                {
                    CharacterExterior ce = DataManager.getData<CharacterExterior>(bec.ExteriorId);
                    if (ce == null)
                    {
                        name = "未找到";
                    }
                    else
                    {
                        name = ce.SurName + ce.Name;
                    }
                }
            }
            return id + "(" + name + ")";
        }

        public static string getBattleGridRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                BattleGrid battleGrid = DataManager.getData<BattleGrid>(id);
                if (battleGrid == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = battleGrid.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getBooksName(string id)
        {
            string name = "";
            string[] bookIds = id.Split(',');
            for (int i = 0; i < bookIds.Length; i++)
            {
                name += DataManager.getBookName(bookIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getBookName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Book book = DataManager.getData<Book>(id);
                if (book == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = book.Name;
                }
            }
            return id + "(" + name + ")";
        }


        public static string getCharacterBehaviourRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                CharacterBehaviour characterBehavior = DataManager.getData<CharacterBehaviour>(id);
                if (characterBehavior == null)
                {
                    return "未找到";
                }
                else
                {
                    remark = characterBehavior.InteractiveName + "\\" +characterBehavior.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getCharacterExteriorName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else if (id == "Player")
            {
                name = "玩家";
            }
            else
            {
                CharacterExterior characterExterior = DataManager.getData<CharacterExterior>(id);
                if (characterExterior == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = characterExterior.SurName + characterExterior.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getCharacterInfoRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else if (id == "Player")
            {
                remark = "玩家";
            }
            else
            {
                CharacterInfo characterInfo = DataManager.getData<CharacterInfo>(id);
                if (characterInfo == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = characterInfo.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getEndingMovieRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                EndingMovie endingMovie = DataManager.getData<EndingMovie>(id);
                if (endingMovie == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = endingMovie.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getEvaluationName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Evaluation forge = DataManager.getData<Evaluation>(id);
                if (forge == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = forge.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getEvaluationPointInfo(string id, EvaluationPoint point)
        {
            string info = "";
            if (id == "")
            {
                info = "空";
            }
            else
            {
                Evaluation evaluation = DataManager.getData<Evaluation>(id);
                if (evaluation == null)
                {
                    info = "未找到";
                }
                else
                {
                    if (evaluation.EvaluationPointInfo[point] != null)
                    {
                        info = evaluation.EvaluationPointInfo[point].Description;
                    }
                    else
                    {
                        info = "无";
                    }
                }
            }
            return "(" + info + ")";
        }

        public static string getEventCubesName(string id)
        {
            string name = "";
            string[] eventCubeIds = id.Split(',');
            for (int i = 0; i < eventCubeIds.Length; i++)
            {
                name += DataManager.getEventCubeName(eventCubeIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getEventCubeName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                EventCube eventCube = DataManager.getData<EventCube>(id);
                if (eventCube == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = eventCube.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getForgesRemark(string id)
        {
            string name = "";
            string[] forgeIds = id.Split(',');
            for (int i = 0; i < forgeIds.Length; i++)
            {
                name += DataManager.getForgeRemark(forgeIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getForgeRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                Forge forge = DataManager.getData<Forge>(id);
                if (forge == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = forge.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getPropssName(string id)
        {
            string name = "";
            string[] propsIds = id.Split(',');
            for (int i = 0; i < propsIds.Length; i++)
            {
                name += DataManager.getPropsName(propsIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getPropsName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else if (id == "Money")
            {
                name = "金钱";
            }
            else
            {
                Props props = DataManager.getData<Props>(id);
                if (props == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = props.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getMantraName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Mantra mantra = DataManager.getData<Mantra>(id);
                if (mantra == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = mantra.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getMapsName(string id)
        {
            string name = "";
            string[] npcIds = id.Split(',');
            for (int i = 0; i < npcIds.Length; i++)
            {
                name += DataManager.getMapName(npcIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getMapName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Map map = DataManager.getData<Map>(id);
                if (map == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = map.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getNpcsName(string id)
        {
            string name = "";
            string[] npcIds = id.Split(',');
            for (int i = 0; i < npcIds.Length; i++)
            {
                name += DataManager.getNpcName(npcIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getNpcsName(List<string> ids)
        {
            string name = "";
            if (ids != null)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    name += DataManager.getNpcName(ids[i]) + ",";
                }
            }
            if (name.Length > 0)
            {
                name = name.Substring(0, name.Length - 1);
            }

            return name;
        }

        public static string getNpcName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else if (id == "Player")
            {
                name = "玩家";
            }
            else if (id.Contains("party"))
            {
                string s = id.Substring("party".Length, id.Length - "party".Length);
                name = s + "号队友";
            }
            else
            {
                Npc npc = DataManager.getData<Npc>(id);
                if (npc == null)
                {
                    name = "未找到";
                }
                else
                {
                    CharacterExterior ce = DataManager.getData<CharacterExterior>(npc.ExteriorId);
                    if (ce == null)
                    {
                        name = "未找到";
                    }
                    else
                    {
                        name = ce.SurName + ce.Name;
                    }
                }
            }
            return id + "(" + name + ")";
        }

        public static string getNurturancesName(string id)
        {
            string name = "";
            string[] nurturanceIds = id.Split(',');
            for (int i = 0; i < nurturanceIds.Length; i++)
            {
                name += DataManager.getNurturanceName(nurturanceIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getNurturanceName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Nurturance nurturance = DataManager.getData<Nurturance>(id);
                if (nurturance == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = nurturance.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getQuestName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Quest quest = DataManager.getData<Quest>(id);
                if (quest == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = quest.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getRewardsRemark(string id)
        {
            string remark = "";
            string[] rewardids = id.Split(',');
            for (int i = 0; i < rewardids.Length; i++)
            {
                remark += DataManager.getRewardRemark(rewardids[i]) + ",";
            }
            remark = remark.Substring(0, remark.Length - 1);

            return remark;
        }

        public static string getRewardRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                Reward reward = DataManager.getData<Reward>(id);
                if (reward == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = reward.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getRewardsStr(string ids, int deep)
        {
            string name = "";
            string[] rewardIds = ids.Split(',');
            for (int i = 0; i < rewardIds.Length; i++)
            {
                name += DataManager.getRewardStr(rewardIds[i], deep) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getRewardStr(string id, int deep)
        {
            string str = "";
            if (id == "")
            {
                str = "空";
            }
            else
            {
                Reward reward = DataManager.getData<Reward>(id);
                if (reward == null)
                {
                    str = "未找到";
                }
                else
                {

                    LogicalNode node = (LogicalNode)reward.Rewards.Output;
                    List<OutputNode<bool>> listNodes = node.inputListNode;
                    for (int i = 0; i < listNodes.Count; i++)
                    {
                        DescriptionAttribute description = (DescriptionAttribute)listNodes[i].GetType().GetCustomAttribute(typeof(DescriptionAttribute));
                        string[] discriptionArray = description.Value.Split('/');
                        str += Utils.getFlowNodeStr(discriptionArray, listNodes[i], deep + 1) + ",";
                    }
                    str = str.Substring(0, str.Length - 1);
                }
            }
            return id + "(" + str + ")";
        }

        public static string getRoundStr(int round)
        {
            string name = "";
            int year = (round - 1) / 60 + 1;
            int month = ((round - 1) % 60) / 5 + 1;
            int day = (round - 1) % 5 + 1;

            name = round + "(第" + year + "年" + month + "月";
            switch (day)
            {
                case 1: name += "月初"; break;
                case 2: name += "上旬"; break;
                case 3: name += "中旬"; break;
                case 4: name += "下旬"; break;
                case 5: name += "月底"; break;
            }
            name += ")";

            return name;
        }

        public static string getAlchemysRemark(string ids)
        {
            string name = "";
            string[] alchemyIds = ids.Split(',');
            for (int i = 0; i < alchemyIds.Length; i++)
            {
                name += DataManager.getAlchemyRemark(alchemyIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getAlchemyRemark(string id)
        {
            string remark = "";
            if (id == "")
            {
                remark = "空";
            }
            else
            {
                Alchemy alchemy = DataManager.getData<Alchemy>(id);
                if (alchemy == null)
                {
                    remark = "未找到";
                }
                else
                {
                    remark = alchemy.Remark;
                }
            }
            return id + "(" + remark + ")";
        }

        public static string getSkillsName(string ids)
        {
            string name = "";
            string[] SkillIds = ids.Split(',');
            for (int i = 0; i < SkillIds.Length; i++)
            {
                name += DataManager.getSkillName(SkillIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getSkillName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                Skill Skill = DataManager.getData<Skill>(id);
                if (Skill == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = Skill.Name;
                }
            }
            return id + "(" + name + ")";
        }

        public static string getStringTableTextRemark(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                StringTable st = DataManager.getData<StringTable>(id);
                if (st == null)
                {
                    name = "未找到";
                }
                else
                {
                    name = st.Text + "(" + st.Remark + ")";
                }
            }
            return name;
        }

        public static string getTalkMessage(string id)
        {
            string message = "";
            if (id == "")
            {
                message = "空";
            }
            Talk talk = DataManager.getData<Talk>(id);
            if (talk == null)
            {
                message = "未找到";
            }
            else
            {
                message = getNpcsName(talk.TalkerId) + ":" + talk.Message;
            }
            return id + "(" + message + ")";
        }

        public static string getTraitName(string id)
        {
            if (id == "")
            {
                return "空";
            }
            Trait trait = DataManager.getData<Trait>(id);
            if (trait == null)
            {
                return "未找到";
            }
            return id + "(" + trait.Name + ")";
        }

        public static string getEffectName(string id)
        {
            if (id == "")
            {
                return "空";
            }
            AnimatorEventTrack effect = DataManager.getData<AnimatorEventTrack>("effect", id);
            if (effect == null)
            {
                return "未找到";
            }
            return id + "(" + effect.Description + ")";
        }

        public static string getMovePathDescription(string id)
        {
            if (id == "")
            {
                return "空";
            }
            MovePath movePath = DataManager.getData<MovePath>("movepath", id);
            if (movePath == null)
            {
                return "未找到";
            }
            return id + "(" + movePath.Description + ")";
        }

        public static string getConfigScheduleName(string id)
        {
            if (id == "")
            {
                return "空";
            }
            ScheduleGraph.Bundle configSchedule = DataManager.getData<ScheduleGraph.Bundle>("config/schedule", id);
            if (configSchedule == null)
            {
                return "未找到";
            }
            return id + "(" + configSchedule.Name + ")";
        }

        public static string getUnitsName(string id)
        {
            string name = "";
            string[] unitIds = id.Split(',');
            for (int i = 0; i < unitIds.Length; i++)
            {
                name += DataManager.getUnitName(unitIds[i]) + ",";
            }
            name = name.Substring(0, name.Length - 1);

            return name;
        }

        public static string getUnitName(string id)
        {
            string name = "";
            if (id == "")
            {
                name = "空";
            }
            else
            {
                if (id.Contains("bec"))
                {
                    name = getBattleEventCubesName(id);
                }
                else
                {
                    name = getNpcsName(id);
                }
            }
            return name;
        }
    }
}
