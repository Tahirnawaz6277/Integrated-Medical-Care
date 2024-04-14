namespace imc_web_api.Dtos.AdminDtos.Order_ItemsDtos
{
    public class OrderItemRequestDto
    {
        public Guid ServiceId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }
    }
}