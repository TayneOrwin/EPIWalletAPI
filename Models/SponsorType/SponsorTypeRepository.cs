using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.SponsorType
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

        public async Task<Entities.SponsorType[]> getAllSponsorTypesAsync()
        {
            IQueryable<Entities.SponsorType> query = _appDbContext.SponsorType;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.SponsorType> getSponsorTypesAsync(int id)
        {
            IQueryable<Entities.SponsorType> query = _appDbContext.SponsorType.Where(zz => zz.SponsorTypeID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Entities.SponsorType> getSponsorTypesByNameAsync(string name)
        {
            IQueryable<Entities.SponsorType> query = _appDbContext.SponsorType.Where(zz => zz.Description == name);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entities.SponsorType>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<string[]> getNameById(int id)
        {
            IQueryable<Entities.SponsorType> query = _appDbContext.SponsorType.Where(zz => zz.SponsorTypeID == id);
            var results = query.Select(zz => zz.Description);

            return await results.ToArrayAsync();
        }

       
    }
}
