using imc_web_api.Models.Enums;

namespace imc_web_api.Dtos.AdminDtos.OrderDtos
{
    public class OrderRequestDTO
    {
        public string Contact { get; set; }
        public string Address { get; set; }
        public int OrderQuantity { get; set; }
        //public OrderStatusEnum.OrderStatus OrderStatus { get; set; }
        public int Amount { get; set; }
        public string PaymentMode { get; set; }
        //public bool IsDeleted { get; set; }

        public Guid ServiceId { get; set; }
    }
}