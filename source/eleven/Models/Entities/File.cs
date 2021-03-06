﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string fileType { get; set; }
        public string content { get; set; }
        public virtual Project project { get; set; }
        [ForeignKey("project")]
        [Required]
        public int ProjectId { get; set; }
        public virtual Folder folder { get; set; }
    }
}