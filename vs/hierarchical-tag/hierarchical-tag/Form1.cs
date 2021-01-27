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

            StreamReader sr = new StreamReader(TagsXmlFilePath + TagsXmlFileName);
            IXmlHandler xml = new XmlHandler();
            var data = xml.Read(sr.ReadToEnd());

            string showText = $"{data.Count}\n\n" +
                              $"{data[2].Name}\n" +
                              $"{data[2].Type}\n" +
                              $"{data[2].Base}\n" +
                              $"{data[2].FontColor}\n"+
                              $"{data[2].BackgroundColor}\n";

            label_test.Text = showText;
        }
    }
}
