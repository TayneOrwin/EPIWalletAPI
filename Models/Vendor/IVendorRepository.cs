using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Vendor
{
    public interface IVendorRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Vendors>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<Vendors[]> getAllVendorsAsync();
        Task<Vendors> getVendorAsync(int id);
        Task<int> getIdByName(string name);

        Task<string> GetNameByID(int id);

        Task<int> getIdByNameDescription(string name, string description);
    }
}
