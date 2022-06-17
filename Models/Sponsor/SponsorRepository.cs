using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class SponsorRepository : ISponsorRepository

    {


        private readonly AppDbContext _appDbContext;


        public SponsorRepository(AppDbContext appDbContext)
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

        public async Task<Sponsor[]> getAllSponsorsAsync()
        {
            IQueryable<Sponsor> query = _appDbContext.Sponsors;
            return await query.ToArrayAsync();
        }


        public async Task<Sponsor> getSponsorAsync(string name)
        {
            IQueryable<Sponsor> query = _appDbContext.Sponsors.Where(c => c.name == name);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
