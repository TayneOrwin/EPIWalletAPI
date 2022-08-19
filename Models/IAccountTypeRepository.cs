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
        Task<IEnumerable<AccountType>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<AccountType[]> getAllAccountTypesAsync();
        Task<AccountType> getAccountTypeAsync(int id);
    }
}
