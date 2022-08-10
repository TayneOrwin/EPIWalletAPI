using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.AccessRole
{
    public interface IAccessRoleRepository
    {
      
            void Add<T>(T entity) where T : class;
            void Delete<T>(T entity) where T : class;
            Task<IEnumerable<EPIWalletAPI.Models.Entities.AccessRole>> Search(string name);
            Task<bool> SaveChangesAsync();

            Task<EPIWalletAPI.Models.Entities.AccessRole[]> getAllRolesAsync();
            Task<EPIWalletAPI.Models.Entities.AccessRole> getRoleAsync(string name);

        
    }
}
