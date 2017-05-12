using FakeDbSet;
using System.Data.Entity;
using eleven.Models;
using eleven.Models.Entities;

namespace eleven.Tests
{
    /// <summary>
    /// This is an example of how we'd create a fake database by implementing the 
    /// same interface that the BookeStoreEntities class implements.
    /// </summary>
    public class MockDatabase : IAppDataContext
    {
        /// <summary>
        /// Sets up the fake database.
        /// </summary>
        public MockDatabase()
        {
            // We're setting our DbSets to be InMemoryDbSets rather than using SQL Server.
            this.projects = new InMemoryDbSet<Project>();
            this.files = new InMemoryDbSet<File>();
            this.folders = new InMemoryDbSet<Folder>();
            this.highlights = new InMemoryDbSet<Highlights>();
            this.pickedprojects = new InMemoryDbSet<PickedProjects>();
            //
            //this.users = new InMemoryDbSet<ApplicationUser>();
        }

        public IDbSet<ApplicationUser> Users { get; set; }
        public IDbSet<Project> projects { get; set; }
        public IDbSet<File> files { get; set; }
        public IDbSet<Folder> folders { get; set; }
        public IDbSet<Highlights> highlights { get; set; }
        public IDbSet<PickedProjects> pickedprojects { get; set; }

        public int SaveChanges()
        {
            // Pretend that each entity gets a database id when we hit save.
            int changes = 0;
 //           changes += DbSetHelper.IncrementPrimaryKey<Author>(x => x.AuthorId, this.Authors);
 //           changes += DbSetHelper.IncrementPrimaryKey<Book>(x => x.BookId, this.Books);

            return changes;
        }

        public void Dispose()
        {
            // Do nothing!
        }
    }
}