using IMC_Integrated_Medical_Care_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMC_Integrated_Medical_Care_.DbContext
{
    public class DbContextClass : IdentityDbContext
    {
        public DbContextClass(DbContextOptions options) : base(options)
        {


        }
        public DbSet<User> User { get; set; }




        // Data Seeding

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
                    Name="Service_Provider" ,
                    NormalizedName="Service_Provider".ToUpper(),

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
        }

    }
}
