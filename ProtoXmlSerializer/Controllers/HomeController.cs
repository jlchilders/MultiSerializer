using Models;
using MultiSerializer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiSerializer.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Submit(CustomerInfo model)
        {
            if (ModelState.IsValid)
            { 
            try
            {
                model.Serialized = null;
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
            }

            return View("Index", model);
        }

        public ActionResult Clear(CustomerInfo model)
        {
            ModelState.Clear();

            return View("Index", new CustomerInfo());
        }
       
        [HttpPost]
        public ActionResult Revert(CustomerInfo model)
        {
            try
            {
                //var customerInfo = new CustomerInfo();
                CustInfoSerializerFactory serializationFactory = new ConcreteCustInfoSerializerFactory();

                string serializeTo = model.SerializeDirection.ToString();
                ISerializer direction = serializationFactory.GetSerializer(serializeTo);
                string toRevert = model.Serialized;
                var result = direction.Deserialize(toRevert);
                model.Serialized = result.ToString();
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = ex.Message;
            }

            return View("Index", model);
        }
    }
}