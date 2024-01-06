namespace imc_web_api.Dtos
{
    public class RegisterationDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string? contact { get; set; }
        public string? gender { get; set; }
        public string Role { get; set; }
    }
}