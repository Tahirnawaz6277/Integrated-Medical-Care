using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace imc_web_api.Models
{
    public class user : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender Field is required.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        public Guid? ServiceProvidertypeId { get; set; } = null;

        [ForeignKey("ServiceProvidertypeId")]
        public serviceprovidertype ServiceProviderType { get; set; }

        public Guid? User_QualificationId { get; set; } = null;

        [ForeignKey("User_QualificationId")]
        public user_qualification User_Qualification { get; set; }

        public List<feedback> User_Feedbacks { get; set; }
        public List<promotion> PromoteTo { get; set; }
        public List<promotion> PromoteBy { get; set; }

        public agreement ServiceProvidedAgreement { get; set; }
        public agreement AdminAgreement { get; set; }
        public order order { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}