using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.RevenueDtos
{
    public class RevenueResponseDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; } = 0;
        public string PayerId { get; set; }

        [ForeignKey("PayerId")]
        public user Payer { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}