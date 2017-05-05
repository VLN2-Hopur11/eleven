using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // BREYTING
            return View(); 
        }

        public ActionResult Highlights()
        {
            return View();
        }
    }
}