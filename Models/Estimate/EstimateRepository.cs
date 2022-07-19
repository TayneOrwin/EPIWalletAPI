using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models.Estimate;

namespace EPIWalletAPI.Models.Estimate
{
    public class EstimateRepository : IEstimateRepository
    {
        private readonly AppDbContext _appDbContext;

        public EstimateRepository(AppDbContext appDbContext)
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

        public async Task<Estimates[]> getAllEstimatesAsync()
        {
            IQueryable<Estimates> query = _appDbContext.Estimates;
            return await query.ToArrayAsync();
        }

        

        public async Task<Estimates> getEstimateAsync(int amount)
        {
            IQueryable<Estimates> query = _appDbContext.Estimates.Where(zz => zz.Amount == amount);
            return await query.FirstOrDefaultAsync();
        }

        

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        
    }
}
