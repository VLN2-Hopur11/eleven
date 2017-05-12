using eleven.Models;
using eleven.Models.Entities;
using eleven.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace eleven.Service
{
    public class FileService
    {
        private readonly IAppDataContext db; //For testing use

        public FileService(IAppDataContext context) //For testing use
        {
            db = context ?? new ApplicationDbContext();
        }
        public bool saveCode(ProjectViewModel changedModel)
        {
            if (changedModel.activeFile.Id == 0)
            {
                Project project = db.projects.Where(x => x.Id == changedModel.project.Id).SingleOrDefault();
                changedModel.activeFile.project = project;

                db.files.Add(changedModel.activeFile);
            }
            else
            {
                File file = db.files.Where(x => x.Id == changedModel.activeFile.Id).SingleOrDefault();
                file.content = changedModel.activeFile.content;
                if (changedModel.activeFile.fileType != null)
                {
                    file.fileType = changedModel.activeFile.fileType;
                }
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return false;
            }

            return true;
        }
    }
}