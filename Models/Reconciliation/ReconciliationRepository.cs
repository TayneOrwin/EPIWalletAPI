using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ReconciliationRepository:IReconciliationRepository
    {

        private readonly AppDbContext _appDbContext;


        public ReconciliationRepository(AppDbContext appDbContext)
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



        public async Task<Reconciliation[]> getAllReconsAsync()
        {
            IQueryable<Reconciliation> query = _appDbContext.Reconciliations;
            return await query.ToArrayAsync();
        }


        public async Task<Reconciliation> getReconAsync(int id)
        {
            IQueryable<Reconciliation> query = _appDbContext.Reconciliations.Where(c => c.ReconID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }






    }
}
