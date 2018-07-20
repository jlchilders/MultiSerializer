using Models;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace ProtoXmlSerializer.Objects
{
    public class XmlSerializer : ISerializer
    {

        public string Serialize(CustomerInfo obj)
        {
            var builder = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.CheckCharacters = false;
            settings.Indent = true;
            using (var writer = XmlWriter.Create(builder, settings))
            { 
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(CustomerInfo));
                x.Serialize(writer, obj);
            }
            return builder.ToString();
        }

        
        public CustomerInfo Deserialize(string data)
        {
            var settings = new XmlReaderSettings { CheckCharacters = false };
            XmlSerializer serializer = new XmlSerializer();

            using (var reader = new StringReader(data))
            using (var xmlReader = XmlReader.Create(reader, settings))
            {
                return (CustomerInfo)serializer.Deserialize(xmlReader.ToString());
            }
        }
    }
}