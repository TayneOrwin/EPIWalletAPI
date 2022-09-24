using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface ITitleRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Title[]> getAllTitleAsync();
        Task<Title> getTitleAsync(string title);
        Task<IEnumerable<Title>> Search(string description);
    }
}
