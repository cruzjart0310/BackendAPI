using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talent.Backend.DataAccessEF.Entities;
using System;

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
        public DbSet<Survey> Survey { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamUser> TeamUser { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.LogTo(Console.WriteLine);
            optionBuilder.UseSqlServer(@"Server=LAPTOP-NOTLMK8N\SQLEXPRESS;Database=backendApi;Integrated Security=True");
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<Survey>()
            //.Property(b => b.UpdatedAt)
            //.IsRequired(false)//optinal case
            //.IsRequired()//required case
            //;

            //builder.Entity<Survey>()
            //.Property(b => b.DeletedAt)
            //.IsRequired(false)//optinal case
            //.IsRequired()//required case
            //;

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.Teams)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
            });

            //builder.Entity<User>(b =>
            //{
            //    b.HasMany(e => e.Teams)
            //    .WithOne(e => e.UserResponsible)
            //    .HasForeignKey(e => e.UserResponsibleId)
            //    .IsRequired();
            //});

            builder.Entity<Team>(b =>
            {
                b.HasMany(e => e.Users)
                .WithOne(e => e.TeamAssigned)
                .HasForeignKey(e => e.TeamAssignedId)
                .IsRequired();
            });

            base.OnModelCreating(builder);
        }
    }
}

