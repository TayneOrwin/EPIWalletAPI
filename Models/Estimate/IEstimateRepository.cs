using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Estimate
{
    public interface IEstimateRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Estimates[]> getAllEstimatesAsync();
        Task<Estimates> getEstimateAsync(int amount);
    }
}
