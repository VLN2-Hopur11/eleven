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
            MainPage mainview = new MainPage();
            mainview.highlights = db.highlights.ToList().GetRange(0,3);
            mainview.pickedprojects = db.pickedprojects.ToList().GetRange(0,3);

            return View(mainview); 
        }

        public ActionResult Highlights()
        {
            MainPage highlightview = new MainPage();
            highlightview.highlights = db.highlights.ToList();

            return View(highlightview);
        }

        public ActionResult PickedProjects()
        {
            MainPage pickedprojectsview = new MainPage();
            pickedprojectsview.pickedprojects = db.pickedprojects.ToList();

            return View(pickedprojectsview);
        }
    }
}