using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class TitleRepository : ITitleRepository
    {
        private readonly AppDbContext _appDbContext;


        public TitleRepository(AppDbContext appDbContext)
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



        public async Task<Title[]> getAllTitleAsync()
        {
            IQueryable<Title> query = _appDbContext.Titles;
            return await query.ToArrayAsync();
        }


        public async Task<Title> getTitleAsync(string title)
        {
            IQueryable<Title> query = _appDbContext.Titles.Where(c => c.Description == title);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Title>> Search(string description)
        {
            IQueryable<Title> query = _appDbContext.Titles;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(t => t.Description.Contains(description));
            }
            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }


    }
}
