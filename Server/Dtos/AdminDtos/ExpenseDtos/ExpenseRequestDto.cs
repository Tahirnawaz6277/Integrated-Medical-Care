using System.ComponentModel.DataAnnotations.Schema;
using imc_web_api.Models;

namespace imc_web_api.Dtos.AdminDtos.ExpenseDtos
{
    public class ExpenseRequestDto
    {
        public int Amount { get; set; } = 0;
        public string PayeeId { get; set; }

        [ForeignKey("PayeeId")]
     
        public string ExpenseCategory { get; set; }
    }
}