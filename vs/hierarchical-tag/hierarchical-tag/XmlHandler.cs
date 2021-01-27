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
        List<FileTag> Read(string path);
        void Write(FileTag fileTag);
    }

    class XmlHandler : IXmlHandler
    {
        public List<FileTag> Read(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            StreamReader sr = new StreamReader(path);

            xmlDoc.LoadXml(sr.ReadToEnd());
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/root/tag");
            List<FileTag> fileTags = new List<FileTag>();

            foreach (XmlNode node in xmlNodeList)
            {
                FileTag fileTag = new FileTag
                {
                    Name = node.SelectSingleNode("name").InnerText.Trim(),
                    Type = node.SelectSingleNode("type").InnerText.Trim(),
                    Base = node.SelectSingleNode("base").InnerText.Trim()
                };

                if (String.IsNullOrEmpty(fileTag.Type))
                {
                    fileTag.Type = "normal";
                }

                if (String.IsNullOrEmpty(fileTag.Base))
                {
                    fileTag.Base = "root";
                }

                try
                {
                   fileTag.FontColor = ColorTranslator.FromHtml(
                        "#" + node.SelectSingleNode("color").SelectSingleNode("font").InnerText.Trim());
                }
                catch
                {
                    fileTag.FontColor = Color.Black;
                }

                try
                {
                    fileTag.BackgroundColor = ColorTranslator.FromHtml(
                         "#" + node.SelectSingleNode("color").SelectSingleNode("background").InnerText.Trim());
                }
                catch
                {
                    fileTag.BackgroundColor = Color.White;
                }

                fileTags.Add(fileTag);
            }

            return fileTags;
        }

        public void Write(FileTag fileTag)
        {
        }
    }
}
