using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using eleven.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Linq;

namespace eleven.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Project> projects { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // New interface, fake one for testing, should look like the one beeneath
    public interface IAppDataContext
    {
        //IDbSet<ApplicationUser> users { get; set; }

        IDbSet<Project> projects { get; set; }
        IDbSet<File> files { get; set; }
        IDbSet<Folder> folders { get; set; }
        IDbSet<Highlights> highlights { get; set; }
        IDbSet<PickedProjects> pickedprojects { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDataContext
    {
        //public DbSet<FriendConnection> FriendConnections { get; set; }
        //public IDbSet<ApplicationUser> Users { get; set; }

        public IDbSet<Project> projects { get; set; }
        
        public IDbSet<File> files { get; set; }
        public IDbSet<Folder> folders { get; set; }
        public IDbSet<Highlights> highlights { get; set; }
        public IDbSet<PickedProjects> pickedprojects { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}