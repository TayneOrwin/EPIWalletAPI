using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class TopUpRequestRepository:ITopUpRequestRepository
    {
        private readonly AppDbContext _appDbContext;


        public TopUpRequestRepository(AppDbContext appDbContext)
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

        public async Task<IEnumerable<TopUpRequest>> Search(string description)
        {
            IQueryable<TopUpRequest> query = _appDbContext.topUpRequests;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(s => s.Reason.Contains(description));
            }
            return await query.ToListAsync();


        }

        public async Task<TopUpRequest[]> getAllTopUpRequestsAsync()
        {
            IQueryable<TopUpRequest> query = _appDbContext.topUpRequests;
            return await query.ToArrayAsync();
        }


        public async Task<TopUpRequest> getTopUpRequestAsync(string description)
        {
            IQueryable<TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.Reason == description);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
