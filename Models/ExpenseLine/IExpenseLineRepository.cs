using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IExpenseLineRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();


        Task<Entities.ExpenseLine[]> getAllExpenseLinesAsync();
        Task<ExpenseLine> getExpenseLineAsync(int id);

        Task<ExpenseLine[]> getExpenseLineByExpenseRequest(int id);


    }
}
