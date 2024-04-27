using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.ExpenseDtos
{
    public class ExpenseResponseDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; } = 0;
        public string PayeeId { get; set; }

        [ForeignKey("PayeeId")]
        public user Payee { get; set; }

        public string ExpenseCategory { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}