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

        [Required(ErrorMessage = "Order status is required.")]
        public OrderStatusEnum.OrderStatus orderStatus { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Payment mode is required.")]
        public string PaymentMode { get; set; }

        [Required(ErrorMessage = "IsDeleted is required.")]
        public bool IsDeleted { get; set; }

        //--> fk for Order By
        public string? OrderByUserId { get; set; }

        [ForeignKey("OrderByUserId")]
        public user OrderBy { get; set; }

        //--> fk for OrderTo
        public string? OrderToUserId { get; set; }

        [ForeignKey("OrderToUserId")]
        public user OrderTo { get; set; }

        public bool IsTransferPayment { get; set; }
    

        public List<orderItem> OrderItems { get; set; }

        public bool Paid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}