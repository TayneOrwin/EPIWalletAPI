using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Province
{
    public class ProvinceRepository : IProvinceRepository
    {

        private readonly AppDbContext _appDbContext;


        public ProvinceRepository(AppDbContext appDbContext)
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

        public async Task<Entities.Province[]> getAllSponsorsAsync()
        {
            IQueryable<Entities.Province> query = _appDbContext.Province;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.Province> getSponsorAsync(string name)
        {
            IQueryable<Entities.Province> query = _appDbContext.Province.Where(c => c.ProvinceDesctiption == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entities.Province>> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
