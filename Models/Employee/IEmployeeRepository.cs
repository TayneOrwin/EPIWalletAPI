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
        Task<Employees> getEmployeeAsync(int id);
        Task<Title[]> getTitlesAsync();
        Task<string[]> getTitleByID(int id);
        Task<int> getIdByTitle(string title);
        Task<string[]> GetEmployeeByID(int id);
        Task<int> getIdByFullname(string name, string surname);

    }
}
