using Models;
using ProtoXmlSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProtoXmlSerializer.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View("Index");
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
                TempData["ErrorMsg"] = ex.Message;
            }

            return View("Index", model);
        }

        //TODO: Add button to revert to plain text

    }
}