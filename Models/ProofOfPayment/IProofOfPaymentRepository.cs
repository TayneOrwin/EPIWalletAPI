using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.ProofOfPayment
{
    public interface IProofOfPaymentRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Entities.ProofOfPayment[]> getAllPOPAsync();
        Task<Entities.ProofOfPayment> getPOPAsync(int id);

        Task<Entities.ProofOfPayment[]> getPOPsForLineAsync(int id);
    }
}
