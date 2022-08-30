using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ReimbursementRepository:IReimbursementRepository
    {
        private readonly AppDbContext _appDbContext;


        public ReimbursementRepository(AppDbContext appDbContext)
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



        public async Task<Reimbursement[]> getAllReimbursementsAsync()
        {
            IQueryable<Reimbursement> query = _appDbContext.Reimbursements;
            return await query.ToArrayAsync();
        }


        public async Task<Reimbursement> getReimbursementAsync(int id)
        {
            IQueryable<Reimbursement> query = _appDbContext.Reimbursements.Where(c => c.ReimbursementID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }


    }
}
