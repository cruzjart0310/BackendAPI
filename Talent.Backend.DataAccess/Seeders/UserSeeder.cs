using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Seeders
{
    internal class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasData(
                new User
                {
                    Id = "b5dbc387-eed6-42fb-b9d8-525094a171b0",
                    FirstName = "Juan",
                    LastName = "Ruiz",
                    Email = "mi_correo@test.com",
                    IsMarried = true,
                    UserProfile = new UserProfile
                    {
                        Id = Guid.NewGuid().ToString().ToLower(),
                        Nickname = "juaaan",
                        UserId = "b5dbc387-eed6-42fb-b9d8-525094a171b0"
                    }
                }
            );

        }
    }
}
