namespace imc_web_api.Dtos.AuthDtos
{
    public class RegisterationResponseDto
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}