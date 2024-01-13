using System.ComponentModel.DataAnnotations;
using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.PromotionDtos
{
    public class PromotionResponseDTO
    {
        [Key]
        public Guid Id { get; set; }

        public string Promotion_Type { get; set; }

        public bool IsSent { get; set; }

        public string PromoteToId { get; set; }

        public user PromoteToUser { get; set; }

        public string PromoteById { get; set; }

        public user PromoteByUser { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}