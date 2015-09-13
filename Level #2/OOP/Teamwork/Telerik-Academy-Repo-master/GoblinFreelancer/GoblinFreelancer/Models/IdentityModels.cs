using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GoblinFreelancer.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
            this.Skills = new HashSet<Skill>();
            this.Projects = new HashSet<Project>();
            this.IsDisalbed = false;
        }

        [Required]
        [MaxLength(50)]
        [RegularExpression( "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$" , ErrorMessage = "Invalid email format." )]
        public string Email { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public double Rating { get; set; }
        public int TimesRated { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsDisalbed { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().
              HasMany(c => c.Collaborators).
              WithMany(p => p.Projects).
              Map(
               m =>
               {
                   m.MapLeftKey("ProjectId");
                   m.MapRightKey("UserId");
                   m.ToTable("ProjectsUsers");
               });
        }
    }
}