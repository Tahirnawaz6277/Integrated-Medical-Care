using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class promotion
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Promotion type is required.")]
        [StringLength(50, ErrorMessage = "Promotion type cannot be longer than 50 characters.")]
        public string Promotion_Type { get; set; }

        [Required(ErrorMessage = "Promotion Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "IsSent is required.")]
        public bool IsSent { get; set; }

        // First foreign key pointing to the User table for PromoteTo
        public string PromoteToId { get; set; }

        [ForeignKey("PromoteToId")]
        public user PromoteToUser { get; set; }

        // Second foreign key pointing to the User table for PromoteBy
        public string PromoteById { get; set; }

        [ForeignKey("PromoteById")]
        public user PromoteByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}