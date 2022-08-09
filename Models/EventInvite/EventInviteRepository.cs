using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models.Entities;
using System.Collections.Generic;

namespace EPIWalletAPI.Models
{
    public class EventInviteRepository : IEventInviteRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventInviteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<EventInvite[]> getAllEventInvitesAsync()
        {
            IQueryable<EventInvite> query = _appDbContext.EventInvites;
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
