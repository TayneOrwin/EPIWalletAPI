using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Quotation
{
    public class QuotationRepository : IQuotationRepository
    {

        private readonly AppDbContext _appDbContext;

        public QuotationRepository(AppDbContext appDbContext)
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

        public async Task<Entities.Quotation[]> getAllQuotationsAsync()
        {
            IQueryable<Entities.Quotation> query = _appDbContext.quotation;
            return await query.ToArrayAsync();

        }

        public async Task<Entities.Quotation> getQuotationAsync(int id)
        {
            IQueryable<Entities.Quotation> query = _appDbContext.quotation.Where(c => c.QuotationID == id);
            return await query.FirstOrDefaultAsync();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
