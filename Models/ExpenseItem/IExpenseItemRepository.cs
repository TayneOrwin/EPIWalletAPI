using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Models
{
    public interface IExpenseItemRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<ExpenseItem>> Search(string itemName);
        Task<bool> SaveChangesAsync();

        Task<ExpenseItem[]> getAllExpenseItemsAsync();
        Task<ExpenseItem> getExpenseItemAsync(string itemName);
        Task<ExpenseItem[]> getExpenseItemlistAsync(int id);


    }
}
