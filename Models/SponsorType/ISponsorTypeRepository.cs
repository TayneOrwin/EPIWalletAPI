using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface ISponsorTypeRepository
    {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Models.Entities.SponsorType>> Search(string description);
        Task<bool> SaveChangesAsync();
        Task<Models.Entities.SponsorType[]> getAllSponsorTypesAsync();
        Task<Models.Entities.SponsorType> getSponsorType(string SponsorTypeDescription);

        Task<SponsorType> getSponsorTypesByNameAsync(string name);


    }
}
