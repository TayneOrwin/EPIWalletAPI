using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IAccountTypeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<AccountType>> Search(string description);
        Task<bool> SaveChangesAsync();

        Task<AccountType[]> getAllAccountTypesAsync();
        Task<AccountType> getAccountTypeAsync(string account);
    }
}
