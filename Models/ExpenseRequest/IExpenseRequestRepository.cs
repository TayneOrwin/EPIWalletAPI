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
        Task<ExpenseRequest[]> getAllRequests();
        Task<ExpenseRequest[]> getPendingExpenseRequestsAsync();
        Task<ExpenseRequest[]> getApprovedExpenseRequestsAsync();
        Task<ExpenseRequest[]> getAllPaidExpenseRequestsAsync();

        Task<ExpenseRequest[]> getUserPaidExpenseRequestsAsync(int id);
        Task<ExpenseRequest> getExpenseRequestAsync(int ExpenseID);
        Task<ExpenseRequest[]> getExpenseRequestForEmployee(int EmployeeID);

        Task<ExpenseRequest[]> getUserPendingExpenseRequestsAsync(int id);

        Task<ExpenseRequest[]> getUserApprovedExpenseRequestsAsync(int id);

        Task<ExpenseRequest[]> getUserRejectedExpenseRequestsAsync(int id);

        Task<ExpenseItem[]> GetExpenseItemsByID(int id);
        Task<ExpenseLine[]> getExpenseLineByTopUp(int id);


        


    }
}
