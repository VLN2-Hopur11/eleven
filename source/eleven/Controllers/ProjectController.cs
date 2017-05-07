using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using eleven.Service;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectService service = new ProjectService();

        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                return View("Error");
            }

            ProjectViewModel model = new ProjectViewModel();

            model.project = db.projects.Where(x => x.Id == id).SingleOrDefault();
            if (model.project == null)
            {
                return View("Error");
            }
            //ViewBag.Code = model.project.files.content;

            return View(model); 
        }

        [HttpPost]
        public ActionResult SaveCode(ProjectViewModel model)
        {
            return View("Project");
        }

        public ActionResult MyProjects()
        {
            // Get currently logged in user
            ApplicationUser currentUser = db.Users.Where(x => x.Id == User.Identity.GetUserId()).FirstOrDefault();

            MyProjectViewModel viewModel = new MyProjectViewModel();
            viewModel.projects = db.projects.Where(x => x.users.Contains(currentUser)).ToList();

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
            Project project = new Project();

            return View(project);
        }
        [HttpPost]
        public ActionResult NewProject(Project project)
        {
            var userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return View("Error");
            }

            int projectId = service.addProject(project, userId);

            return RedirectToAction("Index", new { id = projectId });
        }
    }
}
