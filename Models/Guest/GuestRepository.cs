using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace EPIWalletAPI.Models

{ 
    public class GuestRepository : IGuestRepository

    {


        private readonly AppDbContext _appDbContext;


        public GuestRepository(AppDbContext appDbContext)
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

        public async Task<Guest[]> getAllGuestsAsync()
        {
            IQueryable<Guest> query = _appDbContext.Guests;
            return await query.ToArrayAsync();
        }


        public async Task<Guest> getGuestAsync(string name)
        {
            IQueryable<Guest> query = _appDbContext.Guests.Where(c => c.Name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}