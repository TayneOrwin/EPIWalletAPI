using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EPIWalletAPI.Models
{
    public interface IExpenseRequestRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<ExpenseRequest[]> getPendingExpenseRequestsAsync();
        Task<ExpenseRequest[]> getApprovedExpenseRequestsAsync();
        Task<ExpenseRequest[]> getPaidExpenseRequestsAsync();
        Task<ExpenseRequest> getExpenseRequestAsync(int ExpenseID);


    }
}
