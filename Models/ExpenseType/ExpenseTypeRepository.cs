using EPIWalletAPI.Models.Entities;
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

        public async Task<IEnumerable<Models.Entities.ExpenseType>> Search(string name)
        {
            IQueryable<Models.Entities.ExpenseType> query = _appDbContext.ExpenseTypes;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Type.Contains(name));
            }
            return await query.ToListAsync();

        }

        public async Task<Models.Entities.ExpenseType[]> getAllExpenseTypesAsync()
        {
            IQueryable<Models.Entities.ExpenseType> query = _appDbContext.ExpenseTypes;
            return await query.ToArrayAsync();
        }

        public async Task<Models.Entities.ExpenseType> getExpenseType(string ExpenseTypeName)
        {
            IQueryable<Models.Entities.ExpenseType> query = _appDbContext.ExpenseTypes.Where(c => c.Type == ExpenseTypeName);
            return await query.FirstOrDefaultAsync();
        }



        public async Task<string> getExpenseTypeByID(int id)
        {
            IQueryable<Models.Entities.ExpenseType> query = _appDbContext.ExpenseTypes
                .Where(zz => zz.TypeID == id);

            var results = query.Select(zz => zz.Type);

            return await results.FirstOrDefaultAsync();
        }




        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<string[]> getTypeByID(int id)
        {
            IQueryable<Models.Entities.ExpenseType> query = _appDbContext.ExpenseTypes
               .Where(zz => zz.TypeID == id);

            var results = query.Select(zz => zz.Type);

            return await results.ToArrayAsync();
        }
    }
}
