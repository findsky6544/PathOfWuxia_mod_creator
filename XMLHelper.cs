using System;
using System.IO;
using System.Xml;
using static 侠之道mod制作器.Parameter;

namespace 侠之道mod制作器
{
    class XMLHelper
    {
        public static void ReadXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml"));
                var node = doc.SelectSingleNode("appSettings");
                Parameter.LogLevel = (LogLevelEnum)Enum.Parse(typeof(LogLevelEnum), node.SelectSingleNode("LogLevel").InnerText);
                Parameter.LogFilePath = node.SelectSingleNode("LogFilePath").InnerText;
                Parameter.LogFileExistDay = int.Parse(node.SelectSingleNode("LogFileExistDay").InnerText);

                LogHelper.Debug("XML文件读取成功。");
            }
            catch (Exception ex)
            {
                LogHelper.log.Error(string.Format("XML文件读取失败。{0}", ex));
            }
        }
    }
}
