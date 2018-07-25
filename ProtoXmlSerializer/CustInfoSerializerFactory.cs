using Models;
using MultiSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Models.CustomerInfo;

namespace MultiSerializer
{
    public abstract class CustInfoSerializerFactory
    {

        public abstract ISerializer GetSerializer(string serializeTo);
      
    }
}