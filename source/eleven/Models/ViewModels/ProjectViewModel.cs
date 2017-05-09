using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.ViewModels
{
    public class ProjectViewModel
    {
        public Project project { get; set; }
        public List<File> files { get; set; }
        public File activeFile { get; set; }
    }
}