using imc_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.AdminDtos.FeedBackDtos
{
    public class FeedBackResponseDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }

        public Guid ratedById { get; set; }

        [ForeignKey("ratedById")]
        public user User { get; set; }

        public Guid ratedToId { get; set; }

        [ForeignKey("ratedToId")]
        public service Service { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}