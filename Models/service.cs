using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class service
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Service name is required.")]
        [StringLength(50, ErrorMessage = "Service name cannot be longer than 30 characters.")]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "Charges are required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Charges must be a non-negative value.")]
        public decimal charges { get; set; }

        public string image { get; set; }

        [Required(ErrorMessage = "Available quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available quantity must be a non-negative value.")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Total quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Total quantity must be a non-negative value.")]
        public int TotalQuantity { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public Guid CreatedByProviderTypeId { get; set; }

        [ForeignKey("CreatedByProviderTypeId")]
        public serviceprovidertype ServiceProviderType { get; set; }

        public List<feedback> User_Feedbacks { get; set; }

        public order order { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}