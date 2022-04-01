using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class EFContext : IdentityDbContext<User, IdentityRole, string,
        IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public EFContext()
        {

        }

        public EFContext(DbContextOptions<EFContext> options): base(options)
        {
                
        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=LAPTOP-NOTLMK8N\SQLEXPRESS;Database=backendApi;Integrated Security=True");
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
