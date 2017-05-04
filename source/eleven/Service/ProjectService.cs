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
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool changeProjectName(int projectID, string newName)
        {
            return false; 
        }

        public bool changeFileName( int field, string newName)
        {
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
            return false; 
        }

        public bool removePojectId(int id)
        {
            return false; 
        }

        public bool addProject(Project project)
        {
            return false; 
        }
    }
}