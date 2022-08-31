using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models 
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly AppDbContext _appDbContext;


        public CompanyRepository(AppDbContext appDbContext)
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

        public async Task<Company[]> getAllCompaniesAsync()
        {
            IQueryable<Company> query = _appDbContext.Companies;
            return await query.ToArrayAsync();
        }

        public async Task<Company> getCompanyAsync(string name)
        {
            IQueryable<Company> query = _appDbContext.Companies.Where(c => c.name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Company>> Search(string name)
        {
            IQueryable<Company> query = _appDbContext.Companies;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.name.Contains(name));
            }
            return await query.ToListAsync();

        }
    }
}
