using System;
using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ExpenseRequestRepository:IExpenseRequestRepository
    {

        private readonly AppDbContext _appDbContext;


        public ExpenseRequestRepository(AppDbContext appDbContext)
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


        public async Task<ExpenseRequest[]> getAllExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests;
            return await query.ToArrayAsync();
        }



        public async Task<ExpenseRequest> getExpenseRequestAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ExpenseID == id);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

    









    }
}
