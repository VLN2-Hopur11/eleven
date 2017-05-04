using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    /// <summary>
    /// Highlights from news.
    /// </summary>
    public class Highlights
    {
        public string title { get; set; }
        public string content { get; set; }
        public string Id { get; set; }
        public string author { get; set; }
    }
}