using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    public class File
    {
        private string name { get; set; }
        private string type { get; set; }
        private string content { get; set; }
        private int fileId { get; set; }
    }
}