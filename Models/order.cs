using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models.Enums;

namespace imc_web_api.Models
{
    public class order
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Contact is required.")]
        [StringLength(20, ErrorMessage = "Contact cannot be longer than 20 characters.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Order quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order quantity must be at least 1.")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        public OrderStatusEnum.OrderStatus orderStatus { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Payment mode is required.")]
        public string PaymentMode { get; set; }

        [Required(ErrorMessage = "IsDeleted is required.")]
        public bool IsDeleted { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public user User { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}