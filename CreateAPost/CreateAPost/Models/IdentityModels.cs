using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CreateAPost.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Friendship> ApplicationUsers { get; set; }
        public ICollection<Friendship> FriendUsers { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ApplicationUser()
        {
            ApplicationUsers = new Collection<Friendship>();
            FriendUsers = new Collection<Friendship>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //tu idu DBSetovi
        public DbSet<Post> Posts { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Comment> Comments { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ApplicationUsers)
                .WithRequired(f => f.FriendUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FriendUsers)
                .WithRequired(f => f.ApplicationUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a=>a.Comments)
                .WithRequired(p=>p.ApplicationUser)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    
    }
}