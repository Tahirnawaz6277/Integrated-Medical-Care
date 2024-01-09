using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class promotion
    {
        [Key]
        public Guid Id { get; set; }

        public string Promotion_Type { get; set; }

        public bool IsSent { get; set; }

        // First foreign key pointing to the User table for PromoteTo
        public string PromoteToId { get; set; }

        [ForeignKey("PromoteToId")]
        public user PromoteToUser { get; set; }

        // Second foreign key pointing to the User table for PromoteBy
        public string PromoteById { get; set; }
        [ForeignKey("PromoteById")]
        public user PromoteByUser { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}