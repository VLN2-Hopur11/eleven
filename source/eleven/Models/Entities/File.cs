using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    /// <summary>
    /// many files can me created in 
    /// one project. 
    /// </summary>
    public class File
    {
        public string name { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public int Id { get; set; }
        public virtual Project project { get; set; }
    }
}