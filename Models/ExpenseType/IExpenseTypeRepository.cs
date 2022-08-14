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
        Task<IEnumerable<Models.Entities.ExpenseType>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<Models.Entities.ExpenseType[]> getAllExpenseTypesAsync();
        Task<Models.Entities.ExpenseType> getExpenseType(string ExpenseTypeName);

        Task<string> getExpenseTypeByID(int id);


    }
}
