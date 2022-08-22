using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IApplicationUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<ApplicationUser[]> getAllManagers();

        Task<ApplicationUser[]> getAllCreditors();
        Task<string> getEmailByID(int id);
    }
}
