using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    /* many files can me created in one project. */
    public class File
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        [Required]
        public virtual Project project { get; set; }
    }
}