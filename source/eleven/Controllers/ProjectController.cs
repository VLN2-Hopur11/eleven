using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using eleven.Service;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (model.project.activeFileId != 0)
            {
                model.activeFile = model.files.Where(x => x.Id == model.project.activeFileId).SingleOrDefault();
            }
            else
            {
                if (model.files == null)
                {
                    model.files = new List<File>();
                }
                else if (model.files.Count == 0)
                {
                    File file = new File();
                    model.activeFile = file;
                }
                else
                {
                    model.project.activeFileId = model.files.Last().Id;
                    model.activeFile = model.files.Last();
                    db.SaveChanges();
                }
            }

            if (model.project == null)
            {
                return View("Error");
            }

            ViewBag.Code = model.activeFile.content;
            ViewBag.DocumentID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProjectViewModel changedModel)
        {
            if (changedModel.activeFile.Id == 0)
            {
                Project project = db.projects.Where(x => x.Id == changedModel.project.Id).SingleOrDefault();
                changedModel.activeFile.project = project;

                db.files.Add(changedModel.activeFile);
            }
            else
            {
                File file = db.files.Where(x => x.Id == changedModel.activeFile.Id).SingleOrDefault();
                file.content = changedModel.activeFile.content;
            }

            db.SaveChanges();

            return RedirectToAction("Index", new { id = changedModel.project.Id });
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            // Get currently logged in user ID
            ViewBag.UserName = User.Identity.Name;
            var userId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.Where(x => x.Id == userId).SingleOrDefault();
            MyProjectViewModel viewModel = new MyProjectViewModel();
            viewModel.projects = user.projects.ToList();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult NewFile()
        {
            File file = new File();
            return View(file);
        }
        [HttpPost]
        public ActionResult NewFile(string newFilename, string type, int projectId)
        {
            if (service.fileNameExists(newFilename, projectId))
            {
                return View("Error");
            }

            service.addFile(newFilename, type, projectId);

            return RedirectToAction("Index", new { id = projectId });
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
