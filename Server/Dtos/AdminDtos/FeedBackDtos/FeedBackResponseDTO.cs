using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.FeedBackDtos
{
    public class FeedBackResponseDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }

        public user User { get; set; }

        public service Service { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}