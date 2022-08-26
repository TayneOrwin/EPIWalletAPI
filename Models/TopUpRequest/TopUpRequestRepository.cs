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

        public async Task<IEnumerable<Entities.TopUpRequest>> Search(string description)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests;

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(s => s.Reason.Contains(description));
            }
            return await query.ToListAsync();


        }

        public async Task<Entities.TopUpRequest[]> getAllTopUpRequestsAsync()
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests;
            return await query.ToArrayAsync();
        }


        public async Task<Entities.TopUpRequest> getTopUpRequestAsync(int id)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.TopUpRequestID == id);
            return await query.FirstOrDefaultAsync();
        }





        public async Task<Entities.TopUpRequest[]> getPendingRequestsAsync()
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 1);
            return await query.ToArrayAsync();

        }



        public async Task<Entities.TopUpRequest[]> getApprovedRequestsAsync()
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 2);
            return await query.ToArrayAsync();

        }

        public async Task<Entities.TopUpRequest[]> getPaidRequestsAsync()
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 3);
            return await query.ToArrayAsync();

        }




        public async Task<Entities.TopUpRequest[]> getUserApprovedRequestsAsync(int id)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 2);
            //query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }





        //return all thhe paid expense requests for that user
        public async Task<Entities.TopUpRequest[]> getUserPaidRequestsAsync(int id)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 3);
           // query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }

        public async Task<Entities.TopUpRequest[]> getUserRejectedRequestsAsync(int id)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 4);
          //  query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }

        public async Task<Entities.TopUpRequest[]> getUserPendingRequestsAsync(int id)
        {
            IQueryable<Entities.TopUpRequest> query = _appDbContext.topUpRequests.Where(c => c.ApprovalStatusID == 1);
           // query = query.Where(c => c.EmployeeID == id);
            return await query.ToArrayAsync();
        }





























        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
