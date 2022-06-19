using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
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

        public async Task<VendorAddress[]> getAllVendorAddressesAsync()
        {
            IQueryable<VendorAddress> query = _appDbContext.VendorAddresses;
            return await query.ToArrayAsync();
        }

        public async Task<VendorAddress> getVendorAddress(string address1)
        {
            IQueryable<VendorAddress> query = _appDbContext.VendorAddresses.Where(c => c.AddressLine1 == address1);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}