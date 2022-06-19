using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
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

        public async Task<Employees[]> getAllEmployeesAsync()
        {
            IQueryable<Employees> query = _appDbContext.Employees;
            return await query.ToArrayAsync();
        }

        public async Task<Employees> getEmployeeAsync(string name)
        {
            IQueryable<Employees> query = _appDbContext.Employees.Where(zz => zz.Name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
