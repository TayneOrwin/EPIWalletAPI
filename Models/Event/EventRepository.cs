using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
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

      // public async Task<ExpenseType[]> GetExpenseTypesByEventID(int eventID)
     // {
            //IQueryable<Event> query = _appDbContext.Events
            //          .Where(e => e.EventID == eventID)
            //          .Select(e => e.ExpenseType.TypeID)
            //          .Where(type => type != 0)
            //          .OrderBy(type => type.type).Distinct();


//
        //    return null;
   // }

    public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
