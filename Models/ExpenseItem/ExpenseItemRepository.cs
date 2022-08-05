using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ExpenseItemRepository: IExpenseItemRepository
    {
        private readonly AppDbContext _appDbContext;


        public ExpenseItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<ExpenseItem[]> getAllExpenseItemsAsync()
        {
            IQueryable<ExpenseItem> query = _appDbContext.ExpenseItems;
            return await query.ToArrayAsync();
        }


        public async Task<ExpenseItem> getExpenseItemAsync(string itemName)
        {
            IQueryable<ExpenseItem> query = _appDbContext.ExpenseItems.Where(c => c.itemName == itemName);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ExpenseItem>> Search(string itemName)
        {
            IQueryable<ExpenseItem> query = _appDbContext.ExpenseItems;

            if (!string.IsNullOrEmpty(itemName))
            {
                query = query.Where(e => e.itemName.Contains(itemName) || e.itemDescription.Contains(itemName));
            }
            return await query.ToListAsync();

        }

     

    }
}
