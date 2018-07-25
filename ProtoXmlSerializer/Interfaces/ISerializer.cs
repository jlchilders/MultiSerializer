using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSerializer.Interfaces
{
    public interface ISerializer
    {
        string Serialize(CustomerInfo obj);
        CustomerInfo Deserialize(string data);
    }
}
