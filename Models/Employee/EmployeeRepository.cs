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

        public async Task<IEnumerable<Employees>> Search(string name)
        {
            IQueryable<Employees> query = _appDbContext.Employees;

            if(!string.IsNullOrEmpty(name)) // if there is anything
            {
                query = query.Where(e => e.Name.Contains(name) || e.Surname.Contains(name));
            }

            return await query.ToListAsync();
        }
        
        public async Task<Employees[]> getAllEmployeesAsync()
        {
            IQueryable<Employees> query = _appDbContext.Employees;
            return await query.ToArrayAsync();

            
        }

        public async Task<Employees> getEmployeeAsync(int id)
        {
            IQueryable<Employees> query = _appDbContext.Employees.Where(zz => zz.EmployeeID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Titles[]> getTitlesAsync()
        {
            IQueryable<Titles> query = _appDbContext.Titles;
            return await query.ToArrayAsync();
        }


        public async Task<string[]> getTitleByID(int id)
        {
            IQueryable<Titles> query = _appDbContext.Titles
                .Where(zz => zz.TitlesID == id);

            var results = query.Select(zz => zz.Description);

            return await results.ToArrayAsync();
        }


        public async Task<string[]> GetEmployeeByID(int id)
        {
            IQueryable<Employees> query = _appDbContext.Employees
            .Where(zz => zz.EmployeeID == id);

            var results = query.Select(zz => zz.Name);

            return await results.ToArrayAsync();
        }

    





        public async Task<int> getIdByTitle(string title)
        {
            IQueryable<Titles> query = _appDbContext.Titles.Where(zz => zz.Description == title);
            var results = query.Select(zz => zz.TitlesID);

            return await results.FirstOrDefaultAsync();
        }

        public async Task<int> getIdByFullname(string name, string surname)
        {
            IQueryable<Employees> query = _appDbContext.Employees.Where(zz => zz.Name == name && zz.Surname == surname);
            var results = query.Select(zz => zz.EmployeeID);

            return await results.FirstOrDefaultAsync();
        }

    }
}
