using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EPIWalletAPI.Models
{
    public class AdminTimerRepository:IAdminTimerRepository
    {
        private readonly AppDbContext _appDbContext;


        public AdminTimerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Models.Entities.AdminTimer> getTimer(int timer)
        {
            IQueryable<Models.Entities.AdminTimer> query = _appDbContext.AdminTimer.Where(c => c.timerID == timer);
            return await query.FirstOrDefaultAsync();
        }




        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }







    }
}

