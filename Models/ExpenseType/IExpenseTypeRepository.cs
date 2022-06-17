using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IExpenseTypeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<ExpenseType[]> getAllExpenseTypesAsync();
        Task<ExpenseType> getExpenseType(string ExpenseTypeName);
    }
}
