using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Vendor
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

        public async Task<Vendors[]> getAllVendorsAsync()
        {
            IQueryable<Vendors> query = _appDbContext.Vendors;
            return await query.ToArrayAsync();
        }

        public async Task<Vendors> getVendorAsync(int id)
        {
            IQueryable<Vendors> query = _appDbContext.Vendors.Where(zz => zz.VendorID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vendors>> Search(string name)
        {
            IQueryable<Vendors> query = _appDbContext.Vendors;

            if (!string.IsNullOrEmpty(name)) // if there is anything
            {
                query = query.Where(e => e.Name.Contains(name) || e.Description.Contains(name));
            }

            return await query.ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<int> getIdByName(string name)
        {
            IQueryable<Vendors> query = _appDbContext.Vendors.Where(zz => zz.Name == name);
            var results = query.Select(zz => zz.VendorID);

            return await results.FirstOrDefaultAsync();
        }



        public async Task<string[]> GetNameByID(int id)
        {
            IQueryable<Vendors> query = _appDbContext.Vendors
            .Where(zz => zz.VendorID == id);

            var results = query.Select(zz => zz.Name);

            return await results.ToArrayAsync();
        }

        public async Task<int> getIdByNameDescription(string name, string description)
        {
            IQueryable<Vendors> query = _appDbContext.Vendors.Where(zz => zz.Name == name && zz.Description == description);
            var results = query.Select(zz => zz.VendorID);

            return await results.FirstOrDefaultAsync();
        }









    }
}
