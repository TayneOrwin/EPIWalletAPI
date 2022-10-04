using System;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IExpenseValueRepository
    {
        Task<bool> SaveChangesAsync();
        Task<Models.Entities.ExpenseValue> getValue(int timer);
    }
}

