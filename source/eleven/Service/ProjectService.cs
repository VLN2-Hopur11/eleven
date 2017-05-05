using eleven.Models;
using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Service
{
    public class ProjectService
    {
        private ApplicationDbContext db;
  
        public ProjectService()
        {
            db = new ApplicationDbContext();
        }

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

        public void addFile()
        {
        
        }

        public bool inviteUser(string email)
        {
            return false;
        }

        public bool userExists(string email)
        {
            var beThereEmail = db.Users.Where(x => x.Email == email);
            if(beThereEmail == null)
            {
                return false;
            }
            else return true; 
        }

        public bool removePojectId(int id)
        {
            return false; 
        }

        public bool addProject(Project project)
        {
            Project id = db.projects.SingleOrDefault(x => x.Id == project.Id);
            if (id != null)
            {
                Project newProject = new Project();
                newProject.Id = project.Id;
                newProject.name = project.name;
                newProject.owners = project.owners;
                newProject.users = project.users;
                newProject.files = project.files;

                db.projects.Add(newProject);
                db.SaveChanges();
    
                return true;
            }
            return false; 
        }
    }
}