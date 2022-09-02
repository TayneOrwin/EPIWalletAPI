using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface ISponsorRepository
    {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Sponsor>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<Sponsor[]> getAllSponsorsAsync();
        Task<Sponsor> getSponsorAsync(string name);
   











    }
}
