using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Models;
using System.Data;


    public class ImcContextClass: IdentityDbContext<User>
    {

        public ImcContextClass(DbContextOptions<ImcContextClass> options):base(options)
        {
            
        }


    //public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        var roles = new[]
            {
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" ,ConcurrencyStamp = "1"},
                new IdentityRole { Id = "2", Name = "Provider", NormalizedName = "PROVIDER",ConcurrencyStamp = "2" },
                new IdentityRole { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER",ConcurrencyStamp = "3" },
            };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }

}



 