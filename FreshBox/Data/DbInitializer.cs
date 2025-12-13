using Microsoft.EntityFrameworkCore;
using FreshBox.Models;

namespace FreshBox.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            // Add seed data
            var users = new User[]
            {
                new User { Name = "Admin User", Email = "admin@freshbox.com", PasswordHash = "hashed_password_here" },
                new User { Name = "Test Customer", Email = "customer@freshbox.com", PasswordHash = "hashed_password_here" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // Add more seed data as needed
        }
    }
}