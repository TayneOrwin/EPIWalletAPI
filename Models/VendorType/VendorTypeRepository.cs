using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class VendorTypeRepository : IVendorTypeRepository
    {
        private readonly AppDbContext _appDbContext;


        public VendorTypeRepository(AppDbContext appDbContext)
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

        public async Task<Entities.VendorType[]> getAllVendorTypesAsync()
        {
            IQueryable<Entities.VendorType> query = _appDbContext.VendorType;
            return await query.ToArrayAsync();
        }

        public async Task<Entities.VendorType> getVendorTypesAsync(int id)
        {
            IQueryable<Entities.VendorType> query = _appDbContext.VendorType.Where(zz => zz.VendorTypeID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Entities.VendorType>> Search(string name)
        {
            IQueryable<Entities.VendorType> query = _appDbContext.VendorType;

            if (!string.IsNullOrEmpty(name)) // if there is anything
            {
                query = query.Where(e => e.Type.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}
