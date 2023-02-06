using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Xml;


namespace laba7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Removee_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("D:\\people.xml");

                // Remove node
                XmlNode nodeToRemove = xmlDoc.SelectSingleNode("people/person[@name='Tom']");
                nodeToRemove.ParentNode.RemoveChild(nodeToRemove);

                xmlDoc.Save("people_modified.xml");

                MessageBox.Show("XML Processing complete.");
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\people.xml");

            XmlNode nodeToReplace = xmlDoc.SelectSingleNode("/people/person[@name='Bob']/company");
            XmlNode newNode = xmlDoc.CreateElement("company");
            newNode.InnerText = "Apple";
            nodeToReplace.ParentNode.ReplaceChild(newNode, nodeToReplace);

            xmlDoc.Save("people_modified.xml");

            MessageBox.Show("XML Processing complete.");
        }
    }
}
