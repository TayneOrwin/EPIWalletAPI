﻿using System;
using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ExpenseRequestRepository:IExpenseRequestRepository
    {

        private readonly AppDbContext _appDbContext;


        public ExpenseRequestRepository(AppDbContext appDbContext)
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


        public async Task<ExpenseRequest[]> getPendingExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c=>c.ApprovalID==1);
            return await query.ToArrayAsync();
        }



        public async Task<ExpenseRequest[]> getApprovedExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 2);
            return await query.ToArrayAsync();
        }

        public async Task<ExpenseRequest[]> getPaidExpenseRequestsAsync()
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ApprovalID == 3);
            return await query.ToArrayAsync();
        }






        public async Task<ExpenseRequest> getExpenseRequestAsync(int id)
        {
            IQueryable<ExpenseRequest> query = _appDbContext.ExpenseRequests.Where(c => c.ExpenseID == id);
            return await query.FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

    









    }
}