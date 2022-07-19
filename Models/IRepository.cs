using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IRepository
    {
        Task<bool> SaveChangesAsync();

    }
}
