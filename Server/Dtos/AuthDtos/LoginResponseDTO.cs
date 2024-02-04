namespace imc_web_api.Dtos.AuthDtos
{
    public class LoginResponseDTO
    {
        public string JwtToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}