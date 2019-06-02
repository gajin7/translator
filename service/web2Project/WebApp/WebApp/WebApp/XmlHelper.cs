using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WebApp
{
    public class XmlHelper
    {

        static string filePath = System.AppDomain.CurrentDomain.BaseDirectory + @"db.xml" ;

        public static void WriteTranslatedPairInXML(string originalTxt, string translatedTxt)
        {
            
            XmlWriter writer;
            string id = FindNextId();
            if (id == "")
                id = "1";
            if (CheckInDB(originalTxt))
            {

                if (!File.Exists(filePath))
                {
                    writer = XmlWriter.Create(filePath);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Translations");
                    writer.WriteStartElement("Translate");
                    writer.WriteAttributeString("timestamp", DateTime.Now.ToString());
                    writer.WriteAttributeString("id", id);
                    writer.WriteElementString("From", originalTxt);
                    writer.WriteElementString("To", translatedTxt);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                }
                else
                {
                    XDocument doc = XDocument.Load(filePath);
                    XElement school = doc.Element("Translations");
                    school.Add(new XElement("Translate",
                               new XAttribute("timestamp", DateTime.Now.ToString()),
                               new XAttribute("id", id),
                               new XElement("From", originalTxt),
                               new XElement("To", translatedTxt)));
                    doc.Save(filePath);
                }
            }

            SearchDB("hello people");


        }

        public static bool CheckInDB(string value)
        {

             
            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);
                foreach (var child in doc.Descendants("From"))
                {
                    if (child.Value == value)
                        return false;
                }
            }

            return true;
        }

        public static string SearchDB(string value)
        {
            
            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);
                foreach (var child in doc.Descendants("Translate"))
                {
                    XNode from = child.FirstNode;
                    if(from.ToString() == "<From>"  + value + "</From>" )
                    {
                        string temp =  from.NextNode.ToString();
                        temp = temp.Split('>')[1];
                        temp = temp.Split('<')[0];

                        return temp;
                    }
                    
                }

               
            }
            return "";
        }

        public static string FindNextId()
        {
            string id = "";
            
            if (File.Exists(filePath))
            {
                var doc = XDocument.Load(filePath);
                foreach (var child in doc.Descendants("Translate"))
                {
                    id = child.LastAttribute.Value;
                }

                int temp = Convert.ToInt32(id);
                temp++;
                id = temp.ToString();

            }
            return id;
        }
    }
}
