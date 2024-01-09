using imc_web_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api
{
    public class ImcDbContext : IdentityDbContext
    {
        public ImcDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<user> Users { get; set; }
        public DbSet<serviceprovidertype> ServiceProviderTypes { get; set; }
        public DbSet<user_qualification> User_Qualifications { get; set; }

        public DbSet<service> Services { get; set; }

        //public DbSet<promotion> Promotions { get; set; }
        //public DbSet<order> Orders { get; set; }
        //public DbSet<feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<user>()
                .HasOne(u => u.ServiceProviderType)
                .WithOne(u => u.User)
                .HasForeignKey<user>(u => u.ServiceProvidertypeId)
                 .IsRequired(false)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<user>()
               .HasOne(u => u.User_Qualification)
               .WithOne(u => u.User)
               .HasForeignKey<user>(u => u.User_QualificationId)
                    .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<service>()
              .HasOne(s => s.ServiceProviderType)
              .WithMany(s => s.givenServices)
              .HasForeignKey(s => s.CreatedByProviderTypeId)
              .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            var AdminRoleId = Guid.NewGuid().ToString();
            var ServiceProviderRoleId = Guid.NewGuid().ToString();
            var CustomerRoleId = Guid.NewGuid().ToString();

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

            // Data seeding for serviceProviderType

            var providerTypeData = new List<serviceprovidertype>
            {
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Doctor" },
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Pharmacy" },
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Ambulance" },
            };

            builder.Entity<serviceprovidertype>().HasData(providerTypeData);

            // seeding For Admin   User

            var adminUser = new user
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Aamir",
                LastName = "nawaz",
                PhoneNumber = "03457689432",
                Gender = "Male",
                Role = "Admin",
                UserName = "Aamir@gmail.com",
                NormalizedUserName = "Aamir@gmail.com",
                Email = "Aamir@gmail.com",
                NormalizedEmail = "Aamir@gmail.com",
                EmailConfirmed = true,
                ServiceProvidertypeId = null,
                User_QualificationId = null,
            };

            string adminPassword = "Aamir@123"; // Replace with a secure password

            var passwordHasher = new PasswordHasher<user>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, adminPassword);

            builder.Entity<user>().HasData(adminUser);

            // Assign Admin role to the Admin user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = adminUser.Id.ToString()
            });
            builder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.UserId, iur.RoleId });
        }
    }
}