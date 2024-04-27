namespace imc_web_api.Dtos.AdminDtos.RevenueDtos
{
    public class RevenueRequestDto
    {
        public int Amount { get; set; } = 0;
        public string PayerId { get; set; }

        public string PaymentMethod { get; set; }

       
    }
}