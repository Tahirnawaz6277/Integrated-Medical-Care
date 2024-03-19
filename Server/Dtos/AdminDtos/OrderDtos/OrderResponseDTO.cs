using imc_web_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.AdminDtos.OrderDtos
{
    public class OrderResponseDTO
    {
        
        public Guid Id { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        public bool IsDeleted { get; set; }
        public string OrderByUserId { get; set; }

        [ForeignKey("OrderByUserId")]
        public user OrderBy { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }


        public DateTime OrderDate { get; set; }
    }
}
