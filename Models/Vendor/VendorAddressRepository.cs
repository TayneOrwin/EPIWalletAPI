using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Vendor
{
    public class VendorAddressRepository : IVendorAddressRepository
    {
        private readonly AppDbContext _appDbContext;
        public VendorAddressRepository(AppDbContext appDbContext)
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

        public async Task<VendorAddress[]> getAllVendorAddressAsync()
        {
            IQueryable<VendorAddress> query = _appDbContext.VendorAddress;
            return await query.ToArrayAsync();
        }

        public async Task<VendorAddress> getVendorAddress(string Name)
        {
            IQueryable<VendorAddress> query = _appDbContext.VendorAddress.Where(zz => zz.Province == Name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<VendorAddress>> Search(string name)
        {
            IQueryable<VendorAddress> query = _appDbContext.VendorAddress;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Province.Contains(name) || a.Country.Contains(name) || a.Suburb.Contains(name));

                
            }
            return await query.ToListAsync();

        }
    }
}
