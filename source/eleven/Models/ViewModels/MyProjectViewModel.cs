using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.ViewModels
{
    public class MyProjectViewModel
    {
        public List<Project> projects { get; set; }
        public ApplicationUser currentUser { get; set; }
    }
}