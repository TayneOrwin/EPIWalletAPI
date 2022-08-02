using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IGuestRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Guest>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<Guest[]> getAllGuestsAsync();
        Task<Guest> getGuestAsync(string name);

    }
}
