using eleven.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace eleven.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext") { }
        public DbSet<Project> projects { get; set; }
        public DbSet<File> files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}