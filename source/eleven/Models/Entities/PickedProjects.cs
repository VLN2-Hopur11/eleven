using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    public class PickedProjects
    {
        public string title { get; set; }
        public string thumbnailUrl { get; set; }
        public string content { get; set; }
        public int Id { get; set; }
        public string author { get; set; }
    }
}