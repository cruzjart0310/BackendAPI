using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF
{
    public class EFContext : IdentityDbContext<User, IdentityRole, string,
        IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public EFContext()
        {

        }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUser { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.LogTo(Console.WriteLine);
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Server=LAPTOP-NOTLMK8N;Database=backendApi;Integrated Security=True");
            }

            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.Teams)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
            });

            builder.Entity<Team>(b =>
            {
                b.HasMany(e => e.Users)
                .WithOne(e => e.TeamAssigned)
                .HasForeignKey(e => e.TeamAssignedId)
                .IsRequired();
            });

            SeedInit(builder);

            base.OnModelCreating(builder);
        }

        public void SeedInit(ModelBuilder builder)
        {
            //Seed users
            builder.Entity<User>(b =>
            {
                b.HasData(new
                {
                    Id = "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                    FirstName = "Juan",
                    LastName = "Ruiz",
                    Email = "mi_correo@test.com",
                    AccessFailedCount = 0,
                    LockoutEnabled = false,
                    IsMarried = true,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    CreatedAt = DateTime.Now,
                });

                b.OwnsOne(p => p.UserProfile).HasData(new
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Nickname = "juaaan",
                    UserId = "b5dbc387-eed6-42fb-b9d8-525094a171b0"
                });
            });

            //Seed roles
            builder.Entity<IdentityRole>(r =>
            {
                r.HasData(new
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                });

                r.HasData(new
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "SuperUser",
                    NormalizedName = "SuperUser"
                });

                r.HasData(new
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Name = "User",
                    NormalizedName = "User"
                });
            });

            //Seed QuestionTypes
            builder.Entity<QuestionType>(r =>
            {
                r.HasData(new
                {
                    Id = 1,
                    Title = "Select",
                    CreatedAt = DateTime.Now,
                });

                r.HasData(new
                {
                    Id = 2,
                    Title = "Checkbox",
                    CreatedAt = DateTime.Now,
                });

                r.HasData(new
                {
                    Id = 3,
                    Title = "Radio",
                    CreatedAt = DateTime.Now,
                });

                r.HasData(new
                {
                    Id = 4,
                    Title = "Input",
                    CreatedAt = DateTime.Now,
                });
            });
        }
    }
}

