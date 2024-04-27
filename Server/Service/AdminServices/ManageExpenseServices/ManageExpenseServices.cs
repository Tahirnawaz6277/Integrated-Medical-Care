using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AdminServices.ManageExpenseServices
{
    public class ManageExpenseServices : IManageExpenseService
    {
        public ImcDbContext _ImcDbContext { get; set; }

        public ManageExpenseServices(ImcDbContext imcDbContext)
        {
            _ImcDbContext = imcDbContext;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense, string CurrentUserId)
        {
            expense.PayeeId = CurrentUserId;
            await _ImcDbContext.Expenses.AddAsync(expense);
            await _ImcDbContext.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> DeleteExpenseAsync(Guid id)
        {
            var expense = await _ImcDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (expense is null)
            {
                return null;
            }

            _ImcDbContext.Expenses.Remove(expense);
            _ImcDbContext.SaveChanges();

            return expense;
        }

        public async Task<Expense?> GetExpenseByIdAsync(Guid id)
        {
            return await _ImcDbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await _ImcDbContext.Expenses.Include(e => e.Payee).ToListAsync();
        }

        public async Task<Expense?> UpdateExpenseAsync(Guid id, Expense expense)
        {
            var ExistingExpense = await _ImcDbContext.Expenses.FindAsync(id);

            if (ExistingExpense != null)
            {
                ExistingExpense.Amount = expense.Amount;
                ExistingExpense.PayeeId = expense.PayeeId;
                ExistingExpense.ExpenseCategory = expense.ExpenseCategory;

                await _ImcDbContext.SaveChangesAsync();
                return ExistingExpense;
            }
            return null;
        }
    }
}