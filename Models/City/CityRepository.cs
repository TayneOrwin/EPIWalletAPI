using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.City
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;


        public CityRepository(AppDbContext appDbContext)
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

        public async Task<Entities.City[]> getAllCitiesAsync()
        {
            IQueryable<Entities.City> query = _appDbContext.City;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.City> getCityAsync(string city)
        {
            IQueryable<Entities.City> query = _appDbContext.City;
            var results = query.Where(zz => zz.CityDesctiption == city);

            return await results.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entities.City>> Search(string description)
        {
            IQueryable<Entities.City> query = _appDbContext.City;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(s => s.CityDesctiption.Contains(description));
            }
            return await query.ToListAsync();


        }

        public async Task<Entities.City[]> GetCityByProvinceID(int provinceid)
        {
            IQueryable<Entities.City> query = _appDbContext.City;
            var results = query.Where(zz => zz.ProvinceID == provinceid);

            return await results.ToArrayAsync();
        }

        public async Task<int[]> getIDByName(string name)
        {
            IQueryable<Entities.City> query = _appDbContext.City.Where(p => p.CityDesctiption == name);
            var results = query.Select(z => z.ProvinceID);

            return await results.ToArrayAsync();
        }



    }
}
