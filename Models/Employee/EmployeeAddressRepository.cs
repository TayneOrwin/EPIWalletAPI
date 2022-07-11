using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class EmployeeAddressRepository : IEmployeeAddressRepository
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeAddressRepository(AppDbContext appDbContext)
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

        public async Task<EmployeeAddress[]> getAllEmployeeAddress()
        {
            IQueryable<EmployeeAddress> query = _appDbContext.EmployeeAddress;
            return await query.ToArrayAsync();
        }

        public async Task<EmployeeAddress> getEmployeeAddress(string name)
        {
            IQueryable<EmployeeAddress> query = _appDbContext.EmployeeAddress.Where(zz => zz.Province == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
