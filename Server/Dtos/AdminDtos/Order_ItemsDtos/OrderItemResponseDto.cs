using imc_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Dtos.AdminDtos.Order_ItemsDtos
{
    public class OrderItemResponseDto
    {
        public Guid ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public service Service { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public order Order { get; set; }

        public int quantity { get; set; }
    }
}
