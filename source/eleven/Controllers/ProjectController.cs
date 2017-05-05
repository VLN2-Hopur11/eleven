using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using eleven.Service;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using eleven.Service;

namespace eleven.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectService service = new ProjectService();

        // GET: Project
        /*
        public ActionResult Index()
        {
            // Get ID of logged in user
            var userId = User.Identity.GetUserId();
            
            ProjectViewModel viewModel = new ProjectViewModel();
       
            if (userId == null)
            {
                return RedirectToAction("Error");
            }
<<<<<<< HEAD
=======
            
            viewModel.projects = db.projects.Where(x => x.users.Any(y => y.Id == userId)).ToList();
>>>>>>> 51dfe5a1731b9bb8eec07782998d13d884db8b67

            return View(viewModel);
        }
        */

        public ActionResult Index(ProjectViewModel model)
        {
            return View(model); 
        }
        public ActionResult MyProjects()
        {
            // Get ID of logged in user
            var userId = User.Identity.GetUserId();

            ProjectViewModel viewModel = new ProjectViewModel();
            //viewModel.projects = db.projects.Where(x => x.users.Any(y => y.Id == userId)).ToList();

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

            int projectId = service.addProject(project, userId);

            ProjectViewModel model = new ProjectViewModel();

            model.project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();

            return RedirectToAction("Index", new { viewModel = model });
        }
    }
}
