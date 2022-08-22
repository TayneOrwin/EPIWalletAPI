using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface ITopUpRequestRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Entities.TopUpRequest>> Search(string description);
        Task<bool> SaveChangesAsync();

        Task<Entities.TopUpRequest[]> getAllTopUpRequestsAsync();
        Task<Entities.TopUpRequest> getTopUpRequestAsync(string description);

    }
}
