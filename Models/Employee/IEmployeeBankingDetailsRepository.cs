using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
     public interface IEmployeeBankingDetailsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<EmployeeBankingDetails>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<EmployeeBankingDetails[]> getAllEmployeeBankingDetailsAsync();
        Task<EmployeeBankingDetails> getEmployeeBankingDetailsAsync(int id);
    }
}
