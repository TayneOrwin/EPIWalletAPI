using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public interface IActiveLoginRepository
    {
        void Add<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }
}
