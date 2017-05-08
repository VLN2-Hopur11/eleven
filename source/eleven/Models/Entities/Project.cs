using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    /// <summary>
    /// A project are created by user 
    /// which can hold one or more files 
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<File> files { get; set; }
        [Required]
        public virtual ICollection<ApplicationUser> users { get; set; }
    }
}