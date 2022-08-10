using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class EventRepository : IEventRepository

    {


        private readonly AppDbContext _appDbContext;


        public EventRepository(AppDbContext appDbContext)
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

        public async Task<Event[]> getAllEventsAsync()
        {
            IQueryable<Event> query = _appDbContext.Events;
            return await query.ToArrayAsync();
        }


        public async Task<Event> getEventAsync(string name)
        {
            IQueryable<Event> query = _appDbContext.Events.Where(c => c.name==name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> getIdByName(string EventName)
        {
            IQueryable<Event> query = _appDbContext.Events.Where(zz => zz.name == EventName);
            var results = query.Select(zz => zz.EventID);

            return await results.FirstOrDefaultAsync();
        }

        public async Task<int> getTypeIdByEventId(int EventId)
        {
            IQueryable<Event> query = _appDbContext.Events.Where(zz => zz.EventID == EventId);
            var results = query.Select(zz => zz.TypeID);

            return await results.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Event>> Search(string name)
        {
            IQueryable<Event> query = _appDbContext.Events;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.name.Contains(name) || e.description.Contains(name));
            }
            return await query.ToListAsync();

        }
    }
}
