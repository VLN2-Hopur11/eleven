using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    public class Project
    {
        public string name { get; set; }
        public int Id { get; set; }
        public virtual ICollection<File> files { get; set; }
        public virtual ICollection<ApplicationUser> users { get; set; }
        public virtual ApplicationUser owner { get; set; }
    }
}