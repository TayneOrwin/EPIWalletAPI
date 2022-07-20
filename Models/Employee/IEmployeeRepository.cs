using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public interface IEmployeeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Employees>> Search(string name); 
        Task<bool> SaveChangesAsync();

        Task<Employees[]> getAllEmployeesAsync();
        Task<Employees> getEmployeeAsync(string name);

        //Task<Employees[]> getTitleByID(int id);
    }
}
