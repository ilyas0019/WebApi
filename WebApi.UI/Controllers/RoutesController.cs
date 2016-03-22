using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.UI.Controllers
{
    public class RoutesController : Controller
    {

        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts=100)
        {
            ViewBag.Donuts = donuts;
            
            return View();
        }

        [Authorize]
        public ActionResult Three()
        {
            return View();
        }

    }
}
