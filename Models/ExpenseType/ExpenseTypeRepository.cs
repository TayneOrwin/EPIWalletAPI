﻿using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpenseTypeRepository(AppDbContext appDbContext)
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

        public async Task<IEnumerable<ExpenseType>> Search(string name)
        {
            IQueryable<ExpenseType> query = _appDbContext.ExpenseTypes;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Type.Contains(name));
            }
            return await query.ToListAsync();

        }

        public async Task<ExpenseType[]> getAllExpenseTypesAsync()
        {
            IQueryable<ExpenseType> query = _appDbContext.ExpenseTypes;
            return await query.ToArrayAsync();
        }

        public async Task<ExpenseType> getExpenseType(string ExpenseTypeName)
        {
            IQueryable<ExpenseType> query = _appDbContext.ExpenseTypes.Where(c => c.Type == ExpenseTypeName);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
