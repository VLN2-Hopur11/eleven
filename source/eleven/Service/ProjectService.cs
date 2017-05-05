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
        public bool addProject(Project project)
        {
            Project id = db.projects.SingleOrDefault(x => x.Id == project.Id);
            if (id == null)
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
        //remove project by removing id
        public bool removePojectId(int id)
        {
            return false;
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