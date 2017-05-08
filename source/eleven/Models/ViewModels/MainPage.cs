using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.ViewModels
{
    public class MainPage
    {
        public List<Highlights> highlights { get; set; }
        public List<PickedProjects> pickedprojects { get; set; }
    }
}