using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Domain.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
           .HasIndex(u => u.Email)
           .IsUnique();

            builder.Entity<User>()
           .HasIndex(u => u.UserName)
           .IsUnique();

            base.OnModelCreating(builder);

            builder.Entity<Domain.Entities.User>().HasData(
                new Domain.Entities.User()
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    Password = new PasswordHasher<string>().HashPassword(null, "admin"),
                    FirstName = "Karim",
                    LastName = "Khairy",
                    Phone = "01112202144"
                },
                 new Domain.Entities.User()
                 {
                     Id = 2,
                     UserName = "admin2",
                     Email = "admin2@example.com",
                     Password = new PasswordHasher<string>().HashPassword(null, "admin2"),
                     FirstName = "Mohamed",
                     LastName = "Gazzar"
                 },
                  new Domain.Entities.User()
                  {
                      Id = 3,
                      UserName = "karim.khairy",
                      Email = "karim.khairy@example.com",
                      Password = new PasswordHasher<string>().HashPassword(null, "123456"),
                      FirstName = "Karim2",
                      LastName = "Khairy2"
                  },
                   new Domain.Entities.User()
                   {
                       Id = 4,
                       UserName = "mohmaed.diaa",
                       Email = "mohmaed.diaa@example.com",
                       Password = new PasswordHasher<string>().HashPassword(null, "123456"),
                       FirstName = "Mohamed",
                       LastName = "Diaa"
                   });

        }
    }
}
