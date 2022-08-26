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
        Task<Entities.TopUpRequest> getTopUpRequestAsync(int id);




        Task<Entities.TopUpRequest[]> getPendingRequestsAsync();
        Task<Entities.TopUpRequest[]> getApprovedRequestsAsync();
        Task<Entities.TopUpRequest[]> getPaidRequestsAsync();






        Task<Entities.TopUpRequest[]> getUserPaidRequestsAsync(int id);
 
        Task<Entities.TopUpRequest[]> getUserPendingRequestsAsync(int id);
        Task<Entities.TopUpRequest[]> getUserApprovedRequestsAsync(int id);
        Task<Entities.TopUpRequest[]> getUserRejectedRequestsAsync(int id);

















    }
}
