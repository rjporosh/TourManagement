using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TourManagementApps.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<TourInquiry> TourInquiries { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AgentInquiry> AgentInquiries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}