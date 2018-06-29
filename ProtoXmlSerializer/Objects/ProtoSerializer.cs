using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProtoXmlSerializer.Objects
{
    public class ProtoSerializer<T> : ISerializer<T>
    {
        public string Serialize(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<T>(stream, obj);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public T Deserialize(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return ProtoBuf.Serializer.Deserialize<T>(stream);
            }
        }
    }
}