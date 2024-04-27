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
        public DbSet<orderItem> OrderItems { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Revenue> Revenues { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<user>()
                .HasOne(u => u.ServiceProviderType)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.ServiceProvidertypeId)
                 .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);

            builder.Entity<user>()
               .HasOne(u => u.User_Qualification)
               .WithOne(u => u.User)
               .HasForeignKey<user>(u => u.User_QualificationId)
              .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired(false);

            builder.Entity<user_qualification>()
              .HasOne(u => u.User)
              .WithOne(u => u.User_Qualification)
              .OnDelete(DeleteBehavior.ClientCascade)
              .IsRequired(false);

            //----------------- Order Relationshipe

            builder.Entity<order>()
            .HasOne(o => o.OrderBy)             // Order has one User
            .WithMany(u => u.OrdersByUser)         // User has many Orders
            .HasForeignKey(o => o.OrderByUserId)
            .OnDelete(DeleteBehavior.ClientCascade);

            // Configure the relationship between orderItem and service
            builder.Entity<orderItem>()
                .HasOne(oi => oi.Service)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(oi => oi.ServiceId)
                .OnDelete(DeleteBehavior.ClientCascade); // Prevent cascade delete

            // Configure the relationship between orderItem and order
            builder.Entity<orderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.ClientCascade);

            //----------------- Service Relationshipe

            builder.Entity<service>()
           .HasOne(s => s.User)
           .WithMany(s => s.services)
           .HasForeignKey(s => s.CreatedById)
           .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired(false);

            //------------------    relationship for feedback

            builder.Entity<feedback>()
              .HasOne(f => f.User)
              .WithMany(u => u.User_Feedbacks)
              .HasForeignKey(f => f.ratedById)
    .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<feedback>()
             .HasOne(f => f.Service)
             .WithMany(u => u.User_Feedbacks)
             .HasForeignKey(f => f.ratedToId)
 .OnDelete(DeleteBehavior.ClientCascade);

            //------------------    relationship for Revenue and User

            builder.Entity<Revenue>()
             .HasOne(e => e.Payer)
               .WithMany(u => u.revenues)
             .HasForeignKey(e => e.PayerId)
               .OnDelete(DeleteBehavior.ClientCascade);

            //------------------    relationship for Expense and User

            builder.Entity<Expense>()
             .HasOne(e => e.Payee)
               .WithMany(u => u.expenses)
             .HasForeignKey(e => e.PayeeId)
               .OnDelete(DeleteBehavior.ClientCascade);

            //------------------    relationship for Promotion

            builder.Entity<promotion>()
                .HasOne(p => p.PromoteToUser)          //has one user
                .WithMany(u => u.PromoteTo)                   //have many Promotion
                .HasForeignKey(p => p.PromoteToId)
    .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<promotion>()
                .HasOne(p => p.PromoteByUser)      //has one user
                .WithMany(u => u.PromoteBy)                    //admin sent many Promotions to user
                .HasForeignKey(p => p.PromoteById)
              .OnDelete(DeleteBehavior.ClientCascade);

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

            //var providerTypeData = new List<serviceprovidertype>
            //{
            //    new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Doctor" },
            //    new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Pharmacy" },
            //    new serviceprovidertype { Id = Guid.NewGuid(), ProviderName = "Ambulance" },
            //};

            //builder.Entity<serviceprovidertype>().HasData(providerTypeData);

            //--->> Data seeding for Qualification

            //var qualification = new List<user_qualification>()
            //{
            //   new user_qualification{
            //       Id = Guid.NewGuid(),
            //    qualification = "MBBS",
            //    experience = "10 YEAR",
            //   },
            //     new user_qualification{
            //       Id = Guid.NewGuid(),
            //    qualification = "MD",
            //    experience = "3 YEAR",
            //   }
            //     ,
            //       new user_qualification{
            //       Id = Guid.NewGuid(),
            //    qualification = "BDS",
            //    experience = "1 YEAR",
            //   }
            //};
        }
    }
}