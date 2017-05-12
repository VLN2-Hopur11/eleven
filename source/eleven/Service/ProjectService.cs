using eleven.Models;
using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace eleven.Service
{
    public class ProjectService
    {

        private readonly IAppDataContext db;

        public ProjectService(IAppDataContext context) 
        {
            db = context ?? new ApplicationDbContext();
        }

        //changes project name if requested
        public bool changeProjectName(int projectID, string newName)
        {
            Project id = db.projects.SingleOrDefault(x => x.Id == projectID);
            if (id != null)
            {
                id.name = newName;
                return true; 
            }
            return false;  
        }
        // adds a new project if there dosent exist project with the same id
        public int addProject(Project project, string userId)
        {
            ApplicationUser owner = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            
            if (userId != null)
            {
                Project newProject = new Project();
                newProject.name = project.name;
                newProject.users = new List<ApplicationUser>();
                newProject.author = owner.UserName;
                newProject.users.Add(owner);
                db.projects.Add(newProject);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return 0;
                }

                return newProject.Id;
            }
            return 0;
        }
        //remove project by removing id
        public bool removePoject(int id)
        {
            Project project = db.projects.Remove(db.projects.Where(x => x.Id == id).FirstOrDefault());
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return false;
            }

            if (db.projects.Any(x => x.Id == id) || project == null)
            {
                return false;
            }
            return true;
        }
        
        //only owner can invite a user to the project and choose if he 
        //wants another owner or a simple user
        public bool inviteUser(string email, int projectId)
        {
            ApplicationUser user = db.Users.Where(x => x.Email == email).SingleOrDefault();
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();

            try
            {
                user.projects.Add(project);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return false;
                }
            }
            catch (NotSupportedException)
            {
                return false;
            }

            return true;
        }

        //checks if a user exists 
        public bool userExists(string email)
        {
            var beThereEmail = db.Users.Where(x => x.Email == email);
            if(beThereEmail == null)
            {
                return false;
            }
            else return true; 
        }
    }
} 