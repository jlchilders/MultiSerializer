using Models;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProtoXmlSerializer.Objects
{
    public class ProtoSerializer : ISerializer
    {

        public string Serialize(CustomerInfo obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, obj);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public CustomerInfo Deserialize(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return ProtoBuf.Serializer.Deserialize<CustomerInfo>(stream);
            }
        }
    }
}