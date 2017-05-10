using eleven.Models;
using eleven.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eleven.Service
{
    public class ProjectService
    {
        private ApplicationDbContext db;

        public ProjectService()
        {
            db = new ApplicationDbContext();
            db.Configuration.LazyLoadingEnabled = true;
            db.Configuration.ProxyCreationEnabled = true;
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
                db.SaveChanges();

                return newProject.Id;
            }
            return 0;
        }
        //remove project by removing id
        public bool removePojectId(int id)
        {
            Project project = db.projects.Remove(db.projects.Where(x => x.Id == id).FirstOrDefault());

            if (db.projects.Contains(project))
            {
                return false;
            }

            return true;
        }

        // changes file name if requiested by user
        public bool changeFileName( int field, string newName)
        {
            File fileId = db.files.SingleOrDefault(x => x.Id == field);
            if(fileId == null)
            {
                fileId.name = newName;
                return true;
            }
            return false; 
        }
        // adds a new file to existing project, file cannot have the same name as
        // another file 
        public void addFile(string newFilename, string type, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();
            File newFile = new File();
            newFile.name = newFilename;
            newFile.project = project;
            newFile.type = type;
            db.files.Add(newFile);
            db.SaveChanges();
            project.activeFileId = newFile.Id;
        }
        public bool fileNameExists(string filename, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();

            if (project.files.Any(x => x.name.Contains(filename)))
            {
                return true;
            }

            return false;
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
                db.SaveChanges();
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