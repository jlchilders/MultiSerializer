using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProtoBuf;

namespace ProtoXmlSerializer.Objects
{
    [ProtoContract]
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            //whatever you need for object here
        }

        //[ProtoMember(1)]
        
        //get; set; items making up object
    }
}