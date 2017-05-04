using eleven.DAL;
using eleven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Service
{
    public class ProjectService
    {
        private ProjectContext db;
        private ApplicationDbContext dbMain;

        public ProjectService()
        {
            db = new ProjectContext();
            dbMain = new ApplicationDbContext();

        }

        public bool changeProjectName(int projectID, string newName)
        {
            var projectName = db.projects.SingleOrDefault(x => x.name == newName);
            if (projectName == null)
            {
                return false; 
            }
            return true; 
        }

        public bool changeFileName( int field, string newName)
        {
            var fileName = db.files.SingleOrDefault(x => x.name == newName);
            if(fileName == null)
            {
                return false;
            }
            return true; 
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
            var beThereEmail = dbMain.Users.Where(x => x.Email == email);
            if(beThereEmail == null)
            {
                return false;
            }
            return true; 
        }

        public bool removePojectId(int id)
        {
            return false; 
        }

        public bool addProjects(ProjectContext project)
        {
            return false; 
        }
            
    }
}