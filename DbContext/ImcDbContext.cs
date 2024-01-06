using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api
{
    public class ImcDbContext : DbContext
    {
        public ImcDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<user> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var AdminRoleId = "4e050638-06b1-4d94-9462-757e387f70a5";
            var ServiceProviderRoleId = "8fa1d802-1a62-44bb-9f8d-6803a4295c73";
            var CustomerRoleId = "7aa03b52-a1b4-42de-a645-583f99b0eebb";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id=AdminRoleId,
                    ConcurrencyStamp=AdminRoleId,
                    Name="Admin" ,
                    NormalizedName="Admin".ToUpper(),
              } ,
                 new IdentityRole
                {
                    Id=ServiceProviderRoleId,
                    ConcurrencyStamp=ServiceProviderRoleId,
                    Name="ServiceProvider" ,
                    NormalizedName="ServiceProvider".ToUpper(),
              }  ,
                 new IdentityRole
                {
                    Id=CustomerRoleId,
                    ConcurrencyStamp=CustomerRoleId,
                    Name="Customer" ,
                    NormalizedName="Customer".ToUpper(),
              }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // seeding For Admin   User

            var adminUser = new user
            {
                Id = "7da58f98-178a-4bb0-b8fe-f4518ad64d21",
                firstName = "Muhammad",
                lastName = "Talha",
                contact = "03457689432",
                gender = "Male",
                Role = "Admin",
                UserName = "muhammadtalha@gmail.com",
                NormalizedUserName = "muhammadtalha@gmail.com",
                Email = "muhammadtalha@gmail.com",
                NormalizedEmail = "muhammadtalha@gmail.com",
                EmailConfirmed = true
            };

            string adminPassword = "talha@123"; // Replace with a secure password

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, adminPassword);

            builder.Entity<user>().HasData(adminUser);

            // Assign Admin role to the Admin user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = adminUser.Id
            });
        }
    }
}