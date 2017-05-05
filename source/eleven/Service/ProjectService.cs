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

            //Project id = db.projects.SingleOrDefault(x => x.Id == project.Id);
            if (userId != null)
            {
                Project newProject = new Project();
                newProject.name = project.name;
                newProject.owners = new List<ApplicationUser>();
                newProject.owners.Add(owner);
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
        public bool addFile(File file)
        {
            File name  = db.files.SingleOrDefault(x => x.name == file.name);
            if (name == null)
            {
                File newFile = new File();
                newFile.Id = file.Id;
                newFile.name = file.name;
                newFile.project = file.project;
                newFile.type = file.type;
                newFile.content = file.content;

                db.files.Add(newFile);
                db.SaveChanges();

                return true;
            }
            return false;
        }
        //only owner can invite a user to the project and choose if he 
        //wants another owner or a simple user
        public bool inviteUser(string email)
        {
            return false;
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