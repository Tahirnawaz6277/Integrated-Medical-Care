using System.ComponentModel.DataAnnotations.Schema;

namespace imc_web_api.Models
{
    public class Revenue
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