﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Models.Entities
{
    /* Highlights from news.*/
    public class Highlights
    {
        public string title { get; set; }
        public string content { get; set; }
        public int Id { get; set; }
        public string author { get; set; }
    }
}