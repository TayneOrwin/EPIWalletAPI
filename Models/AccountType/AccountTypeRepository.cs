using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public AccountTypeRepository(AppDbContext appDbContext)
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

        public async Task<AccountType> getAccountTypeAsync(int id)
        {
            IQueryable<AccountType> query = _appDbContext.accountType.Where(zz => zz.AccountTypeID  == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<AccountType[]> getAllAccountTypesAsync()
        {
            IQueryable<AccountType> query = _appDbContext.accountType;
            return await query.ToArrayAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<AccountType>> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
