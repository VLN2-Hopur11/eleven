using eleven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eleven.Service
{
    public class ProjectService
    {
       private ApplicationDbContext db = new ApplicationDbContext();

        public void dostuff()
        {
            db.Users.Where(x => x.Email == "someEmail");
        }
    }
}