using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Suburb
{
    public class SuburbRepository : ISuburbRepository
    {
        private readonly AppDbContext _appDbContext;


        public SuburbRepository(AppDbContext appDbContext)
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

        public async Task<Entities.Suburb[]> getAllSuburbsAsync()
        {
            IQueryable<Entities.Suburb> query = _appDbContext.Suburb;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.Suburb> getSuburbAsync(int suburb)
        {
            IQueryable<Entities.Suburb> query = _appDbContext.Suburb;
            var results = query.Where(zz => zz.SuburbID == suburb);

            return await results.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entities.Suburb>> Search(string description)
        {
            IQueryable<Entities.Suburb> query = _appDbContext.Suburb;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(s => s.SuburbDesctiption.Contains(description));
            }
            return await query.ToListAsync();


        }

        public async Task<Entities.Suburb[]> GetSuburbByCityID(int cityID)
        {
            IQueryable<Entities.Suburb> query = _appDbContext.Suburb;
            var results = query.Where(zz => zz.CityID == cityID);

            return await results.ToArrayAsync();
        }
    }
}
