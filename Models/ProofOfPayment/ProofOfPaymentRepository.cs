using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.ProofOfPayment
{
    public class ProofOfPaymentRepository : IProofOfPaymentRepository
    {

        private readonly AppDbContext _appDbContext;


        public ProofOfPaymentRepository(AppDbContext appDbContext)
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

        public async Task<Entities.ProofOfPayment[]> getAllPOPAsync()
        {
            IQueryable<Entities.ProofOfPayment> query = _appDbContext.proofOfPayment;
            return await query.ToArrayAsync();

        }

        public async Task<Entities.ProofOfPayment> getPOPAsync(int id)
        {
            IQueryable<Entities.ProofOfPayment> query = _appDbContext.proofOfPayment.Where(c => c.ProofOfPaymentID == id);
            return await query.FirstOrDefaultAsync();

        }


        public async Task<Entities.ProofOfPayment[]> getPOPsForLineAsync(int id)
        {
            IQueryable<Entities.ProofOfPayment> query = _appDbContext.proofOfPayment.Where(c => c.ExpenseLineID == id);
            return await query.ToArrayAsync();
        }



        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
