using Models;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtoXmlSerializer.Controllers
{
    public class CustInfoController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(CustomerInfo model)
        {
            try
            {
                //var customerInfo = new CustomerInfo();
                CustInfoSerializerFactory serializationFactory = new ConcreteCustInfoSerializerFactory();

                string serializeTo = model.SerializeDirection.ToString();
                ISerializer direction = serializationFactory.GetSerializer(serializeTo);
                string result = direction.Serialize(model);
                model.Serialized = result;
                ModelState.Clear();


            }
            catch (Exception ex)
            {

            }

            return View("Index", model);
        }

    }
}