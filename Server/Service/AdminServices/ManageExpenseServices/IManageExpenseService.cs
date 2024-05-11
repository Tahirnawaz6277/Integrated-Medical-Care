using imc_web_api.Models;

namespace imc_web_api.Service.AdminServices.ManageExpenseServices
{
    public interface IManageExpenseService
    {

        Task<List<Expense>> GetExpensesAsync();

        Task<Expense?> GetExpenseByIdAsync(Guid id);

        Task<Expense> AddExpenseAsync(Expense expense );

        Task<Expense?> DeleteExpenseAsync(Guid id);

        Task<Expense?>UpdateExpenseAsync(Guid id, Expense expense);
    }
}
