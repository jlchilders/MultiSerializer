using Models;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Models.CustomerInfo;

namespace ProtoXmlSerializer
{
    public abstract class CustInfoSerializerFactory
    {

        public abstract ISerializer GetSerializer(string serializeTo);
      
    }
}