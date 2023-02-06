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

                //// Remove node
                //XmlNode nodeToRemove = xmlDoc.SelectSingleNode("people/person[@name='Tom']");
                //nodeToRemove.ParentNode.RemoveChild(nodeToRemove);

                //xmlDoc.Save("people_modified.xml");

                if (comboBox1.SelectedIndex >= 0)
                {
                    string selectedName = comboBox1.SelectedItem.ToString();
                    XmlNode nodeToRemove = xmlDoc.SelectSingleNode("/people/person[@name='" + selectedName + "']");
                    nodeToRemove.ParentNode.RemoveChild(nodeToRemove);

                    xmlDoc.Save("people_modified.xml");
                    MessageBox.Show("Node removed successfully.");
                }

                
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\people.xml");

            //XmlNode nodeToReplace = xmlDoc.SelectSingleNode("/people/person[@name='Bob']/company");
            //XmlNode newNode = xmlDoc.CreateElement("company");
            //newNode.InnerText = "Apple";
            //nodeToReplace.ParentNode.ReplaceChild(newNode, nodeToReplace);

            //xmlDoc.Save("people_modified.xml");

            //MessageBox.Show("XML Processing complete.");

            if (comboBox2.SelectedIndex >= 0)
            {
                string selectedName = comboBox2.SelectedItem.ToString();
                XmlNode nodeToReplace = xmlDoc.SelectSingleNode("/people/person[@name='" + selectedName + "']");

                XmlElement newNode = xmlDoc.CreateElement("person");
                newNode.SetAttribute("name", selectedName);

                XmlElement newCompany = xmlDoc.CreateElement("company");
                newCompany.InnerText = company.Text.ToString();
                newNode.AppendChild(newCompany);
                

                XmlElement newAge = xmlDoc.CreateElement("age");
                newAge.InnerText = age.Text.ToString();
                newNode.AppendChild(newAge);

                nodeToReplace.ParentNode.ReplaceChild(newNode, nodeToReplace);

                xmlDoc.Save("people_modified.xml");
                MessageBox.Show("Node replaced successfully.");
            }
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle= ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle= ComboBoxStyle.DropDownList;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\people.xml");

            XmlNode parentNode = xmlDoc.SelectSingleNode("/people");

            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
                comboBox1.Items.Add(childNode.Attributes["name"].Value);
                comboBox2.Items.Add(childNode.Attributes["name"].Value);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
