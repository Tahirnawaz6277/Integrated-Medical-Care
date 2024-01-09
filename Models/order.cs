using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class order
    {
        public Guid Id { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public user User { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }

        public DateTime OrderDate { get; set; }
    }
}