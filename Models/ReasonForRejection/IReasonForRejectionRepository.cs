using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IReasonForRejectionRepository


    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
   
        Task<bool> SaveChangesAsync();

        Task<ReasonForRejection[]> getAllReasonsForRejectionAsync();
        Task<ReasonForRejection> getReasonForRejectionAsync(string reason);
        Task<IEnumerable<ReasonForRejection>> Search(string name);

    }
}
