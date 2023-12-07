using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace server.Models
{
    public class User: IdentityUser
    {
        [Key]
        public int  Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Contact { get; set; }

        public string Gender { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        //public IdentityRole Role { get; set; }

        [Timestamp]
        public byte[] createdAt { get; set; }

   
    }
}
