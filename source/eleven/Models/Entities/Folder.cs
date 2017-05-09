using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    public class Folder
    {
        //folder that includes grouped files
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual ICollection<File> files { get; set; }
        [Required]
        public virtual Project project { get; set; }
    }
}