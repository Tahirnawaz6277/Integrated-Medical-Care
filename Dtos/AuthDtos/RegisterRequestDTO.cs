using imc_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.AuthDtos
{
    public class RegisterRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string Role { get; set; }
        public Guid ServiceProvidertypeId { get; set; }

        public Guid? User_QualificationId { get; set; }


    }
}