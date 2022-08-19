using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Identity
{
    public class ApplicationUserRepository :IApplicationUserRepository
    {

        private readonly AppDbContext _appDbContext;

        public ApplicationUserRepository(AppDbContext appDbContext)
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

  

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }


        public async Task<ApplicationUser[]> getAllManagers()
        {
            IQueryable<ApplicationUser> query = _appDbContext.ApplicationUsers.Where(zz => zz.AccessRoleID == 2);

            return await query.ToArrayAsync();
        }

        public async Task<ApplicationUser[]> getAllCreditors()
        {
            IQueryable<ApplicationUser> query = _appDbContext.ApplicationUsers.Where(zz => zz.AccessRoleID == 3);
            return await query.ToArrayAsync();
        }





        public async Task<string> getEmailByID(int id)
        {
            IQueryable<ApplicationUser> query = _appDbContext.ApplicationUsers.Where(zz => zz.EmployeeID == id);
            var results = query.Select(zz => zz.Email);
                return await results.FirstOrDefaultAsync();
        }


     




    }



















}

