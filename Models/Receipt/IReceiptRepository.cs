using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IReceiptRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
  
        Task<bool> SaveChangesAsync();

        Task<Receipt[]> getAllReceiptsAsync();
        Task<Receipt> getReceiptAsync(int id);





    }
}
