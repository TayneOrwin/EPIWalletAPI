using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class EmployeeBankingDetailsRepository : IEmployeeBankingDetailsRepository
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeBankingDetailsRepository(AppDbContext appDbContext)
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

        public async Task<EmployeeBankingDetails[]> getAllEmployeeBankingDetailsAsync()
        {
            //IQueryable<EmployeeBankingDetails> query = _appDbContext.employeeBankingDetails;
            //return await query.ToArrayAsync();
            throw new NotImplementedException();
        }

        public async Task<EmployeeBankingDetails> getEmployeeBankingDetailsAsync(int empid)
        {
            //IQueryable<EmployeeBankingDetails> query = _appDbContext.employeeBankingDetails.Where(zz => zz.EmployeeID == empid);
            //return await query.FirstOrDefaultAsync();
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<EmployeeBankingDetails>> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
