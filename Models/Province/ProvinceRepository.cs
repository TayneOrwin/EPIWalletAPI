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

        public async Task<Entities.Province[]> getAllProvinceAsync()
        {
            IQueryable<Entities.Province> query = _appDbContext.Province;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.Province> getProvinceAsync(string name)
        {
            IQueryable<Entities.Province> query = _appDbContext.Province.Where(c => c.ProvinceDesctiption == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<string[]> getNameByID(int id)
        {
            IQueryable<Entities.Province> query = _appDbContext.Province.Where(zz => zz.ProvinceID == id);
            var results = query.Select(zz => zz.ProvinceDesctiption);

            return await results.ToArrayAsync();
        }
        public async Task<IEnumerable<Entities.Province>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int[]> getIDByName(string name)
        {
            IQueryable<Entities.Province> query = _appDbContext.Province.Where(p => p.ProvinceDesctiption == name);
            var results = query.Select(z => z.ProvinceID);

            return await results.ToArrayAsync();
        }
    }
}
