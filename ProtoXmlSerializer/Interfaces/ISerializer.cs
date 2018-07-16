using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoXmlSerializer.Interfaces
{
    public interface ISerializer
    {
        string Serialize(CustomerInfo obj);
        CustomerInfo Deserialize(string data);
    }
}
