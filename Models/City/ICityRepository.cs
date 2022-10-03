using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.City
{
    public interface ICityRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Entities.City>> Search(string description);
        Task<bool> SaveChangesAsync();

        Task<Entities.City[]> getAllCitiesAsync();
        Task<Entities.City> getCityAsync(int account);
        Task<Entities.City> getCityForDeleteAsync(string account);
        Task<Entities.City[]> GetCityByProvinceID(int provinceID);

        Task<int[]> getIDByName(string name);
    }
}
