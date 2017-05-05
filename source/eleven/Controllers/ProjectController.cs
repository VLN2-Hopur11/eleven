﻿using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        public ActionResult Index(Project project)
        {
            // Get ID of logged in user
            var userId = User.Identity.GetUserId();

            ProjectViewModel viewModel = new ProjectViewModel();

            /*
            if (userId == null)
            {
                return RedirectToAction("Error");
            }
            */

            viewModel.projects = db.projects.Where(x => x.users.Any(y => y.Id == userId)).ToList();

            return View(viewModel);
        }
        public ActionResult MyProjects()
        {
            // Get ID of logged in user
            var userId = User.Identity.GetUserId();

            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.projects = db.projects.Where(x => x.users.Any(y => y.Id == userId)).ToList();

            return View(viewModel);
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
            db.projects.Add(project);

            return View(project);
        }
    }
}