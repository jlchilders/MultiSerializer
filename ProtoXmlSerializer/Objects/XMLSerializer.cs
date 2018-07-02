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
    public class XmlSerializer<T> : ISerializer<T>
    {
        private readonly XmlSerializer _serializer = null;
        private readonly XmlSerializerNamespaces _ns = null;

        public XmlSerializer()
        {
            _serializer = new XmlSerializer(typeof(T));
            _ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        }

        public string Serialize(T obj)
        {
            var builder = new StringBuilder();

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.CheckCharacters = false;
            using (var writer = XmlWriter.Create(builder, settings))
            {
                _serializer.Serialize(writer, obj, _ns);
            }

            return builder.ToString();
        }

        public T Deserialize(string data)
        {
            var settings = new XmlReaderSettings { CheckCharacters = false };

            using (var reader = new StringReader(data))
            using (var xmlReader = XmlReader.Create(reader, settings))
            {
                return (T)_serializer.Deserialize(xmlReader);
            }
        }
    }
}