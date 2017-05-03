using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    public class File
    {
        public string name { get; set; }
        public string type { get; set; }
        public string content { get; set; }
        public int Id { get; set; }
        public virtual Project project { get; set; }
    }
}