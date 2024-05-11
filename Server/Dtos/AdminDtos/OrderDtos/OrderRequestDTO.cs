namespace imc_web_api.Dtos.AdminDtos.OrderDtos
{
    public class OrderRequestDTO
    {
        public string Contact { get; set; }
        public string Address { get; set; }

        public int Amount { get; set; }

        public string PaymentMode { get; set; }

        public string? OrderToUserId { get; set; }
        public bool Paid { get; set; }

        
    }
}