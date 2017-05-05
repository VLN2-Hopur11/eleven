using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // BREYTING
            return View(); 
        }

        public ActionResult Highlights()
        {
            MainPage highlightview = new MainPage();
            highlightview.highlights = db.highlights.ToList();

            return View(highlightview);
        }

        public ActionResult PickedProjects()
        {

            return View();
        }
    }
}