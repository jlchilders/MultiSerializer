using Newtonsoft.Json;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoXmlSerializer.Objects
{
    public sealed class JsonSerializer<T> : ISerializer<T>
    {
        public T Deserialize(string value) => JsonConvert.DeserializeObject<T>(value);

        public string Serialize(T value) => JsonConvert.SerializeObject(value);
    }
}