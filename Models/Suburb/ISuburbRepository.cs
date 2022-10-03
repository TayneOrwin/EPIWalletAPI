using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Suburb
{
    public interface ISuburbRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Entities.Suburb>> Search(string description);
        Task<bool> SaveChangesAsync();

        Task<Entities.Suburb[]> getAllSuburbsAsync();
        Task<Entities.Suburb> getSuburbAsync(int id);

        Task<Entities.Suburb[]> GetSuburbByCityID(int id);
    }
}
