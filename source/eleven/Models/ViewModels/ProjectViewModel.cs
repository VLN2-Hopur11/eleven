using eleven.Models.Entities;
using System.Collections.Generic;

namespace eleven.Models.ViewModels
{
    public class ProjectViewModel
    {
        public Project project { get; set; }
        public List<Folder> folders { get; set; }
        public List<File> files { get; set; }
        public File activeFile { get; set; }
    }
}