using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.SponsorType
{
    public interface ISponsorTypeRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Entities.SponsorType>> Search(string name);
        Task<bool> SaveChangesAsync();
        Task<Entities.SponsorType[]> getAllSponsorTypesAsync();
        Task<Entities.SponsorType> getSponsorTypesAsync(int id);
        Task<Entities.SponsorType> getSponsorTypesByNameAsync(string name);
        Task<string[]> getNameById(int id);
    }
}
