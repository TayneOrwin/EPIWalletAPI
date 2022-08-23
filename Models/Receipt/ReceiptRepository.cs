using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ReceiptRepository: IReceiptRepository
    {

        private readonly AppDbContext _appDbContext;


        public ReceiptRepository(AppDbContext appDbContext)
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

  

        public async Task<Receipt[]> getAllReceiptsAsync()
        {
            IQueryable<Receipt> query = _appDbContext.receipts;
            return await query.ToArrayAsync();
        }


        public async Task<Receipt> getReceiptAsync(int id)
        {
            IQueryable<Receipt> query = _appDbContext.receipts.Where(c => c.ReceiptID == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }

















}

