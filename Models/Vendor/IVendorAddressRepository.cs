using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Vendor
{
    public interface IVendorAddressRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<VendorAddress>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<VendorAddress[]> getAllVendorAddressAsync();
        Task<VendorAddress> getVendorAddress(string VendorName);
    }
}
