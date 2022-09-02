using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Province
{
    public interface IProvinceRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Entities.Province>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<Entities.Province[]> getAllSponsorsAsync();
        Task<Entities.Province> getSponsorAsync(string name);
    }
}
