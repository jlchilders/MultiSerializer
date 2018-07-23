using Models;
using Newtonsoft.Json;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoXmlSerializer.Objects
{
    public class JsonSerializer : ISerializer
    {
        public CustomerInfo Deserialize(string value) => JsonConvert.DeserializeObject<CustomerInfo>(value);

        public string Serialize(CustomerInfo value) => JsonConvert.SerializeObject(value, Formatting.Indented);
    }
}