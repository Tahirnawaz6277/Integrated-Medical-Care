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

        public DbSet<promotion> Promotions { get; set; }

        public DbSet<order> Orders { get; set; }
        public DbSet<feedback> Feedbacks { get; set; }

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

            builder.Entity<user>()
           .HasOne(u => u.order)
           .WithOne(u => u.User)
           .HasForeignKey<user>(u => u.orderId)
            .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<user_qualification>()
               .HasOne(u => u.User)
               .WithOne(u => u.User_Qualification)
               .HasForeignKey<user_qualification>(u => u.userId)

                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<service>()
              .HasOne(s => s.ServiceProviderType)
              .WithMany(s => s.givenServices)
              .HasForeignKey(s => s.CreatedByProviderTypeId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<feedback>()
           .HasOne(f => f.User)
           .WithMany(u => u.User_Feedbacks)
           .HasForeignKey(f => f.ratedById)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<feedback>()
           .HasOne(f => f.Service)
           .WithMany(s => s.User_Feedbacks)
           .HasForeignKey(f => f.ratedToId)
           .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship for PromoteToUser in promotion
            builder.Entity<promotion>()
                .HasOne(p => p.PromoteToUser)
                .WithMany(u => u.PromoteTo)
                .HasForeignKey(p => p.PromoteToId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship for PromoteByUser in promotion
            builder.Entity<promotion>()
                .HasOne(p => p.PromoteByUser)
                .WithMany(u => u.PromoteBy)
                .HasForeignKey(p => p.PromoteById)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship for customer in Order  Table

            builder.Entity<order>()
            .HasOne(o => o.User)
             .WithOne(o => o.order)
           .HasForeignKey<order>(d => d.CustomerId)

            .OnDelete(DeleteBehavior.Restrict);

            // Configure the relationship for Service in Order Table

            builder.Entity<order>()
                .HasOne(o => o.Service)
                .WithOne(s => s.order)
                .HasForeignKey<order>(s => s.ServiceId)
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

            // Data seeding for serviceProviderType

            var providerTypeData = new List<serviceprovidertype>
            {
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Doctor" },
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Pharmacy" },
                new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Ambulance" },
            };

            builder.Entity<serviceprovidertype>().HasData(providerTypeData);

            //--->> Data seeding for Qualification

            var qualification = new List<user_qualification>()
            {
               new user_qualification{
                   Id = Guid.NewGuid(),
                qualification = "MBBS",
                experience = "10 YEAR",
               },
                 new user_qualification{
                   Id = Guid.NewGuid(),
                qualification = "MD",
                experience = "3 YEAR",
               }
                 ,
                   new user_qualification{
                   Id = Guid.NewGuid(),
                qualification = "BDS",
                experience = "1 YEAR",
               }
            };

            //--->> Data seeding for User_Provider_doctor

            var provider_Doctor = new List<user>()
            {
                new user
                {
                   Id = Guid.NewGuid().ToString(),
                FirstName = "Aqib",
                LastName = "nawaz",
                PhoneNumber = "03457689432",
                Gender = "Male",
                Role = "Provider",
                UserName = "Aqib@gmail.com",
                NormalizedUserName = "Aqib@gmail.com",
                Email = "Aqib@gmail.com",
                NormalizedEmail = "Aqib@gmail.com",
                EmailConfirmed = true,
                ServiceProvidertypeId = providerTypeData[0].Id,
                User_QualificationId = qualification[0].Id,
                },
                new user
                {
                   Id = Guid.NewGuid().ToString(),
                FirstName = "Waheed",
                LastName = "Quraishi",
                PhoneNumber = "03457689432",
                Gender = "Male",
                Role = "Provider",
                UserName = "Waheed@gmail.com",
                NormalizedUserName = "Waheed@gmail.com",
                Email = "Waheed@gmail.com",
                NormalizedEmail = "Waheed@gmail.com",
                EmailConfirmed = true,
                ServiceProvidertypeId = providerTypeData[1].Id,
                User_QualificationId = qualification[1] .Id,
                },
                new user
                {
                   Id = Guid.NewGuid().ToString(),
                FirstName = "Hameed",
                LastName = "Khan",
                PhoneNumber = "03457689432",
                Gender = "Male",
                Role = "Provider",
                UserName = "Hameed@gmail.com",
                NormalizedUserName = "Hameed@gmail.com",
                Email = "Hameed@gmail.com",
                NormalizedEmail = "Hameed@gmail.com",
                EmailConfirmed = true,
                ServiceProvidertypeId = providerTypeData[2].Id,
                User_QualificationId = qualification[2].Id,
                }
            };
            qualification[0].userId = provider_Doctor[0].Id.ToString();
            qualification[1].userId = provider_Doctor[1].Id.ToString();
            qualification[2].userId = provider_Doctor[2].Id.ToString();

            builder.Entity<user_qualification>().HasData(qualification);
            string provider_DoctorPass = "Aamir@123"; // Replace with a secure password
            string provider_DoctorPass1 = "Waheed@123"; // Replace with a secure password

            string provider_DoctorPass2 = "Hameed@123"; // Replace with a secure password

            var passHasher = new PasswordHasher<user>();
            provider_Doctor[0].PasswordHash = passwordHasher.HashPassword(provider_Doctor[0], provider_DoctorPass);

            provider_Doctor[1].PasswordHash = passwordHasher.HashPassword(provider_Doctor[1], provider_DoctorPass1);
            provider_Doctor[2].PasswordHash = passwordHasher.HashPassword(provider_Doctor[2], provider_DoctorPass2);

            builder.Entity<user>().HasData(provider_Doctor);
        }
    }
}