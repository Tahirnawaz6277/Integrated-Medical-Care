using System.ComponentModel.DataAnnotations;

namespace imc_web_api.Dtos
{
    public class LoginRequestDTO

    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}