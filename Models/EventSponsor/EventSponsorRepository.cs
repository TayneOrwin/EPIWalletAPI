using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.EventSponsor
{
    public class EventSponsorRepository : IEventSponsorRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<Entities.EventSponsor[]> getAllReceiptsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.EventSponsor> getReceiptAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
