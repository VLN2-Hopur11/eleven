using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using eleven.Service;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectService service = new ProjectService(null);
        private FileService fileService = new FileService(null);

        [Authorize]
        public ActionResult Index(int id)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem() { Value = "html", Text = "html" });
            listItem.Add(new SelectListItem() { Value = "js", Text = "js" });
            listItem.Add(new SelectListItem() { Value = "json", Text = "json" });
            listItem.Add(new SelectListItem() { Value = "php", Text = "php" });
            listItem.Add(new SelectListItem() { Value = "xml", Text = "xml" });
            ViewBag.DropDownValues = new SelectList(listItem, "Text", "Value");


            if (id == 0)
            {
                return View("Error");
            }

            ProjectViewModel model = new ProjectViewModel();
            model.project = db.projects.Where(x => x.Id == id).SingleOrDefault();
            model.files = db.files.Where(x => x.project.Id == model.project.Id).ToList();
            model.folders = db.folders.Where(x => x.project.Id == model.project.Id).ToList();

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
            return View(model);
        }

        public ActionResult SidebarPartial(ProjectViewModel viewModel)
        {
            return PartialView("SidebarPartial", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(ProjectViewModel changedModel)
        {
            if(fileService.saveCode(changedModel))
            {
                return RedirectToAction("Index", new { id = changedModel.project.Id });
            }

            return View("Error");
        }

        [Authorize]
        public ActionResult setActiveFile(int fileId, int projectId)
        {
            fileService.setActiveFile(fileId, projectId);

            return RedirectToAction("Index", new { id = projectId });
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.Where(x => x.Id == userId).SingleOrDefault();
            MyProjectViewModel viewModel = new MyProjectViewModel();
            viewModel.projects = user.projects.ToList();
            viewModel.currentUser = user;
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewFile(string newFilename, string fileType, int projectId)
        {
            if (fileService.fileNameExists(newFilename, projectId))
            {
                return View("Error");
            }

            fileService.addFile(newFilename, fileType, projectId);

            return RedirectToAction("Index", new { id = projectId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewFolder(string newFoldername, int projectId)
        {
            if (fileService.folderNameExists(newFoldername, projectId))
            {
                return View("Error");
            }

            fileService.addFolder(newFoldername, projectId);

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

        [HttpPost]
        public ActionResult RemoveProject(int id)
        {
            if (id > 0)
            {
                service.removePoject(id);
            }

            return RedirectToAction("MyProjects");
        }
    }
}
