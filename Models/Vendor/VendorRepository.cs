using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EPIWalletAPI.Models
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _appDbContext;

        public VendorRepository(AppDbContext appDbContext)
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

        public async Task<Vendor[]> getAllVendorsAsync()
        {
            IQueryable<Vendor> query = _appDbContext.Vendors;
            return await query.ToArrayAsync();
        }

        public async Task<Vendor> getVendorAsync(string vendorName)
        {
            IQueryable<Vendor> query = _appDbContext.Vendors.Where(c => c.Name == vendorName);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}