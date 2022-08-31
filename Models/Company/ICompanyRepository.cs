using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface ICompanyRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<Company>> Search(string name);

        Task<bool> SaveChangesAsync();

        Task<Company[]> getAllCompaniesAsync();

        Task<Company> getCompanyAsync(string name);
    }
}
