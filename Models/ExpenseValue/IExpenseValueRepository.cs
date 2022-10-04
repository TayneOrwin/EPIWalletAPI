using System;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IAdminTimerRepository
    {
        Task<bool> SaveChangesAsync();
        Task<Models.Entities.AdminTimer> getTimer(int timer);
    }
}

