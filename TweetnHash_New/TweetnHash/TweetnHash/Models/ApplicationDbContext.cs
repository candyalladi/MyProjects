using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TweetnHash.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<FaceBookAccount> FaceBookAccounts { get; set; }
        public DbSet<TwitterAccount> TwitterAccounts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}