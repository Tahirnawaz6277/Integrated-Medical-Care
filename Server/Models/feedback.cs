using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class feedback
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Feedback Description is Required.")]
        [StringLength(150, ErrorMessage = "Description cannot be longer than 150 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        [Column(TypeName ="decimal(19, 4)")]
        public decimal Rating { get; set; }

        public string ratedById { get; set; }

        [ForeignKey("ratedById")]
        public user User { get; set; }

        public Guid ratedToId { get; set; }

        [ForeignKey("ratedToId")]
        public service Service { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}