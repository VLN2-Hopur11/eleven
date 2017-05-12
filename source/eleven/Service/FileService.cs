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

        // changes file name if requiested by user
        public bool changeFileName(int field, string newName)
        {
            File fileId = db.files.SingleOrDefault(x => x.Id == field);
            if (fileId == null)
            {
                fileId.name = newName;
                return true;
            }
            return false;
        }

        // adds a new file to existing project, file cannot have the same name as
        // another file 
        public void addFile(string newFilename, string fileType, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();
            File newFile = new File();
            newFile.name = newFilename;
            newFile.project = project;
            newFile.fileType = fileType;
            db.files.Add(newFile);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return;
            }
            project.activeFileId = newFile.Id;
        }

        public void setActiveFile(int fileId, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();
            project.activeFileId = fileId;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return;
            }
        }

        public void addFolder(string newFoldername, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();
            Folder newFolder = new Folder();
            newFolder.name = newFoldername;
            newFolder.project = project;
            db.folders.Add(newFolder);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return;
            }
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

        public bool folderNameExists(string filename, int projectId)
        {
            Project project = db.projects.Where(x => x.Id == projectId).SingleOrDefault();

            if (project.folders.Any(x => x.name.Contains(filename)))
            {
                return true;
            }
            return false;
        }
    }
}