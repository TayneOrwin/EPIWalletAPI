using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ReasonForRejectionRepository: IReasonForRejectionRepository
    {
        private readonly AppDbContext _appDbContext;


        public ReasonForRejectionRepository(AppDbContext appDbContext)
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

    

        public async Task<ReasonForRejection[]> getAllReasonsForRejectionAsync()
        {
            IQueryable<ReasonForRejection> query = _appDbContext.ReasonForRejections;
            return await query.ToArrayAsync();
        }


        public async Task<ReasonForRejection> getReasonForRejectionAsync(string reason)
        {
            IQueryable<ReasonForRejection> query = _appDbContext.ReasonForRejections.Where(c => c.Reason == reason);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ReasonForRejection>> Search(string name)
        {
            IQueryable<ReasonForRejection> query = _appDbContext.ReasonForRejections;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Reason.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }



}

