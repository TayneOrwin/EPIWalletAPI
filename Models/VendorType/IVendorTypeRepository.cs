using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Models
{
    public interface IVendorTypeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<VendorType>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<VendorType[]> getAllVendorTypesAsync();
        Task<VendorType> getVendorTypesAsync(int id);
        //Task<int> getIdByName(string name);

        //Task<string> GetNameByID(int id);

        //Task<int> getIdByNameDescription(string name, string description);
    }
}
