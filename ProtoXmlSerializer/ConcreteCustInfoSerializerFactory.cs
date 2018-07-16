using ProtoXmlSerializer.Interfaces;
using ProtoXmlSerializer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Models.CustomerInfo;

namespace ProtoXmlSerializer
{
    public class ConcreteCustInfoSerializerFactory : CustInfoSerializerFactory
    {


        public override ISerializer GetSerializer(string serializeTo)
        {
  
            switch(serializeTo)
            {
                case "Protobuf":
                    return new ProtoSerializer();
                case "XML":
                    return new XmlSerializer();
                case "Json":
                    return new JsonSerializer();
                default:
                    throw new Exception("Invalid option specified");
            }
        }

    }
}