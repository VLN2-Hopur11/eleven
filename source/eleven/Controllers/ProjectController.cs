using eleven.DAL;
using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Project
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            ProjectViewModel viewModel = new ProjectViewModel();

            if (userId == null)
            {
                return RedirectToAction("Error");
            }
            else
            {

            }

            return View(viewModel);
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
