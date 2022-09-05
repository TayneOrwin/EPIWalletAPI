using EPIWalletAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IGuestListRepository
    {
        void Add<T>(T entity) where T : class;

        Task<IEnumerable<GuestList>> Search(string name);

        Task<bool> SaveChangesAsync();

        Task<GuestList[]> getAllGuestListsAsync();
    }
}
