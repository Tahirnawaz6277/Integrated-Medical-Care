using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IMC_Integrated_Medical_Care_.Models
{
    public class User : IdentityUser
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        
        public string? password { get; set; }
        public string? contact { get; set; }
        public string? gender { get; set; }
        //public string roleId { get; set; }
        //[ForeignKey("RoleId")] 
                             

    }
}
