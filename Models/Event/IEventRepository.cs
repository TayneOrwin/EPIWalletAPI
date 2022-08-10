using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IEventRepository
    {

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<IEnumerable<Event>> Search(string name);
        Task<bool> SaveChangesAsync();

        Task<Event[]> getAllEventsAsync();
        Task<Event> getEventAsync(string name);

        Task<int> getIdByName(string EventName);
        Task<int> getTypeIdByEventId(int EventId);








    }
}
