using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class GuestListRepository : IGuestListRepository
    {
        private readonly AppDbContext _appDbContext;


        public GuestListRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public async Task<IEnumerable<GuestList>> Search(string name)
        {
            IQueryable<GuestList> query = _appDbContext.GuestLists;

            if (!string.IsNullOrEmpty(name)) // if there is anything
            {
                query = query.Where(e => e.Event.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<GuestList[]> getAllGuestListsAsync()
        {
            IQueryable<GuestList> query = _appDbContext.GuestLists;
            return await query.ToArrayAsync();
        }
    }
}
