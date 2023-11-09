using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace dz08._11
{
     class Class1
    {
        public static void Main(String[] args)
        {

            String name, company, age;

            name = Console.ReadLine();
            company = Console.ReadLine();
            age = Console.ReadLine();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:\\Project\\dz08.11\\dz08.11\\Person.xml");
            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            // создаем новый элемент person
            XmlElement personElem = xDoc.CreateElement("person");
            // создаем атрибут name
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");

            // создаем элементы company и age
            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");

            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode(name);
            XmlText companyText = xDoc.CreateTextNode(company);
            XmlText ageText = xDoc.CreateTextNode(age);

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);

            // добавляем атрибут name
            personElem.Attributes.Append(nameAttr);
            // добавляем элементы company и age
            personElem.AppendChild(companyElem);
            personElem.AppendChild(ageElem);
            // добавляем в корневой элемент новый элемент person
            xRoot?.AppendChild(personElem);
            // сохраняем изменения xml-документа в файл
            xDoc.Save("D:\\Project\\dz08.11\\dz08.11\\Person.xml");

            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    Console.WriteLine(attr?.Value);

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "company")
                        {
                            Console.WriteLine($"Company: {childnode.InnerText}");
                        }
                        // если узел age
                        if (childnode.Name == "age")
                        {
                            Console.WriteLine($"Age: {childnode.InnerText}");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
