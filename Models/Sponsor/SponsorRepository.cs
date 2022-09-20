using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Sponsor>> Search(string name)
        {
            IQueryable<Sponsor> query = _appDbContext.Sponsors;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.name.Contains(name) || s.Surname.Contains(name) || s.Company.Contains(name) || s.Email.Contains(name));
            }
            return await query.ToListAsync();


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
