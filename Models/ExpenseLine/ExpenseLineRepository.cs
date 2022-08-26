using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ExpenseLineRepository:IExpenseLineRepository
    {
        private readonly AppDbContext _appDbContext;


        public ExpenseLineRepository(AppDbContext appDbContext)
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
        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }


        public async Task<Entities.ExpenseLine[]> getAllExpenseLinesAsync()
        {
            IQueryable<Entities.ExpenseLine> query = _appDbContext.expenseLines;
            return await query.ToArrayAsync();


        }


        public async Task<ExpenseLine> getExpenseLineAsync(int id)
        {
            IQueryable<ExpenseLine> query = _appDbContext.expenseLines.Where(zz => zz.ExpenseLineID == id);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<ExpenseLine[]> getExpenseLineByExpenseRequest(int id)
        {
            IQueryable<ExpenseLine> query = _appDbContext.expenseLines.Where(zz => zz.ExpenseRequestID == id);
            return await query.ToArrayAsync();
        }
























    }
}
