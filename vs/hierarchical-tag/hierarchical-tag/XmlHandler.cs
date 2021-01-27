using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Drawing;

namespace hierarchical_tag
{
    public struct FileTag
    {
        public string Name;
        public string Type;
        public string Base;
        public Color FontColor;
        public Color BackgroundColor;
    }

    interface IXmlHandler
    {
        XmlNodeList Read(string path);
        void Write(FileTag fileTag);
    }

    class XmlHandler : IXmlHandler
    {
        public XmlNodeList Read(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            StreamReader sr = new StreamReader(path);

            xmlDoc.LoadXml(sr.ReadToEnd());
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root/tag");

            foreach (XmlNode node in xmlNodeList)
            {
                var tagName = node.SelectSingleNode("name").InnerText;
                var tagType = node.SelectSingleNode("type").InnerText;
                var tagBase = node.SelectSingleNode("base").InnerText;
                var tagFontColor = node.SelectSingleNode("color").SelectSingleNode("font").InnerText;
                var tagBackgroundColor = node.SelectSingleNode("color").SelectSingleNode("background").InnerText;
            }

            return xmlNodeList;
        }

        public void Write(FileTag fileTag)
        {
        }
    }
}
