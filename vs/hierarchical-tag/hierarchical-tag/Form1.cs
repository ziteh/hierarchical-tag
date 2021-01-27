using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace hierarchical_tag
{
    public partial class Form1 : Form
    {
        private const string TagsXmlFilePath = "../../../../../xml/";
        private const string TagsXmlFileName = "tags.xml";

        public Form1()
        {
            InitializeComponent();

            IXmlHandler xml = new XmlHandler();
            var data = xml.Read(TagsXmlFilePath + TagsXmlFileName);

            string showText = $"{data.Count}\n" +
                              $"{data.Item(1).SelectSingleNode("name").InnerText}\n" +
                              $"{data.Item(1).SelectSingleNode("type").InnerText}\n" +
                              $"{data.Item(1).SelectSingleNode("base").InnerText}\n" +
                              $"{data.Item(1).SelectSingleNode("color").SelectSingleNode("font").InnerText}\n"+
                              $"{data.Item(1).SelectSingleNode("color").SelectSingleNode("background").InnerText}\n";

            label_test.Text = showText;
        }
    }
}
