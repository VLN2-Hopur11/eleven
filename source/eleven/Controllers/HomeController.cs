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
            return View();
        }

        //Virkar þetta kv. Godi
<<<<<<< HEAD
        //NEI kv. Tommi
=======
        //yass biaatchhhh 
>>>>>>> 31ed73c8ab7fe344afbc911c2b8b3814935f2922

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}