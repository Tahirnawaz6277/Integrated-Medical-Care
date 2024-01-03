using IMC_Integrated_Medical_Care_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMC_Integrated_Medical_Care_.DbContext
{
    public class DbContextClass : IdentityDbContext
    {
        public DbContextClass(DbContextOptions options) : base(options) {


        }
        public DbSet<User> User { get; set; }

    }
}
