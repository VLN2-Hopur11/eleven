using eleven.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Service
{
    public class ProjectService
    {
        private ProjectContext db; 

        public ProjectService()
        {
            db = new ProjectContext();
        }

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

        public bool addProjects(ProjectContext project)
        {
            return false; 
        }
            
    }
}