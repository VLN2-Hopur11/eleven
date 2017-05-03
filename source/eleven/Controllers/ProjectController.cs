using eleven.Models;
using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(Project model)
        {
            return View(model);
        }
        public ActionResult MyProjects(IndexViewModel model)
        {
            return View(model);
        }
        [HttpGet]
        public ActionResult NewFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewFile(File file)
        {

            return View(file);
        }
        [HttpGet]
        public ActionResult NewProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewProject(Project project)
        {
            return View(project);
        }
    }
}
