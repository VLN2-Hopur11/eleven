﻿using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using eleven.Service;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectService service = new ProjectService();

        [Authorize]
        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            ProjectViewModel model = new ProjectViewModel();
            model.project = db.projects.Where(x => x.Id == id).SingleOrDefault();
            model.files = db.files.Where(x => x.project.Id == model.project.Id).ToList();

            if (model.files == null)
            {
                model.files = new List<File>();
            }

            model.activeFile = model.files.First();

            if (model.project == null)
            {
                return View("Error");
            }
            //if (model.project.files)
            //ViewBag.Code = model.project.files.content;
            ViewBag.DocumentID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProjectViewModel changedModel)
        {
            if(changedModel.files == null)
            {
                changedModel.files = new List<File>();
            }

            if (changedModel.activeFile.Id == 0)
            {
                db.files.Add(changedModel.activeFile);
            }
            else
            {
                db.files.Where(x => x.Id == changedModel.activeFile.Id).SingleOrDefault().content = changedModel.activeFile.content;
            }

            db.SaveChanges();

            return View(changedModel);
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            // Get currently logged in user ID
            var userId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.Where(x => x.Id == userId).SingleOrDefault();
            MyProjectViewModel viewModel = new MyProjectViewModel();
            viewModel.projects = user.projects.ToList();

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

        [Authorize]
        [HttpGet]
        public ActionResult NewProject()
        {
            Project project = new Project();

            return View(project);
        }
        [Authorize]
        [HttpPost]
        public ActionResult NewProject(Project project)
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return View("Error");
            }

            int projectId = service.addProject(project, userId);

            if (projectId == 0)
            {
                return View("Error");
            }

            return RedirectToAction("Index", new { id = projectId });
        }

        [HttpPost]
        public ActionResult InviteUser(string email, int projectId)
        {
            if (service.userExists(email))
            {
                if (service.inviteUser(email, projectId))
                {
                    return RedirectToAction("Index", new { id = projectId });
                }
            }

            return View("Error");
        }
    }
}
