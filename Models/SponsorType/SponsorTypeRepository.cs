using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class SponsorTypeRepository : ISponsorTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public SponsorTypeRepository(AppDbContext appDbContext)
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

        public async Task<IEnumerable<Models.Entities.SponsorType>> Search(string description)
        {
            IQueryable<Models.Entities.SponsorType> query = _appDbContext.SponsorTypes;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(t => t.Description.Contains(description));
            }
            return await query.ToListAsync();

        }

        public async Task<Models.Entities.SponsorType[]> getAllSponsorTypesAsync()
        {
            IQueryable<Models.Entities.SponsorType> query = _appDbContext.SponsorTypes;
            return await query.ToArrayAsync();
        }

        public async Task<Models.Entities.SponsorType> getSponsorType(string SponsorTypeDescription)
        {
            IQueryable<Models.Entities.SponsorType> query = _appDbContext.SponsorTypes.Where(c => c.Description == SponsorTypeDescription);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
