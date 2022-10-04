using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EPIWalletAPI.Models
{
    public class ExpenseValueRepository: IExpenseValueRepository
    {
        private readonly AppDbContext _appDbContext;


        public ExpenseValueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Models.Entities.ExpenseValue> getValue(int timer)
        {
            IQueryable<Models.Entities.ExpenseValue> query = _appDbContext.ExpenseValue.Where(c => c.valueID == timer);
            return await query.FirstOrDefaultAsync();
        }




        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }







    }
}

