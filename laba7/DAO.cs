using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Threading.Tasks;

namespace laba7
{
    class DAO
    {
        private String path = "C:\\Users\\admin\\source\\ссп\\ssp_7\\laba7\\laba7\\bin\\Debug\\people.xml";
        private XmlDocument xmlDoc = new XmlDocument();

        public DAO()
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();
            
            try
            {
                xmlDoc.Load(path);
                XmlElement xRoot = xmlDoc.DocumentElement;

                if (xRoot != null)
                {
                    // обход всех узлов в корневом элементе
                    foreach (XmlElement xnode in xRoot)
                    {
                        Person person = new Person();
                        // получаем атрибут name
                        XmlNode attrId = xnode.Attributes.GetNamedItem("id");
                        person.id = int.Parse(attrId.Value);

                        // обходим все дочерние узлы элемента user
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "name")
                            {
                                person.name = childnode.InnerText;
                            }
                            if (childnode.Name == "company")
                            {
                                person.company = childnode.InnerText;
                            }
                            if (childnode.Name == "age")
                            {
                                person.age = int.Parse(childnode.InnerText);
                            }

                        }
                        people.Add(person);
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return people;
        }

        public void Replace(Person updatePerson)
        {
            try
            {
                xmlDoc.Load(path);

                XmlNode companyNodeToReplace = xmlDoc.SelectSingleNode("/people/person[@id='" + updatePerson.id + "']/company");
                XmlNode newCompanyNode = xmlDoc.CreateElement("company");
                newCompanyNode.InnerText = updatePerson.company;
                companyNodeToReplace.ParentNode.ReplaceChild(newCompanyNode, companyNodeToReplace);

                XmlNode nameNodeToReplace = xmlDoc.SelectSingleNode("/people/person[@id='" + updatePerson.id + "']/name");
                XmlNode newNameNode = xmlDoc.CreateElement("name");
                newNameNode.InnerText = updatePerson.name;
                nameNodeToReplace.ParentNode.ReplaceChild(newNameNode, nameNodeToReplace);

                XmlNode ageNodeToReplace = xmlDoc.SelectSingleNode("/people/person[@id='" + updatePerson.id + "']/age");
                XmlNode newAgeNode = xmlDoc.CreateElement("age");
                newAgeNode.InnerText = updatePerson.age.ToString();
                ageNodeToReplace.ParentNode.ReplaceChild(newAgeNode, ageNodeToReplace);

                xmlDoc.Save(path);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Remove(int id)
        {
            try
            {
                xmlDoc.Load(path);
                XmlNode nodeToRemove = xmlDoc.SelectSingleNode("people/person[@id='" + id + "']");
                nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
                xmlDoc.Save("people.xml");

                MessageBox.Show("XML remove processing complete.");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}
