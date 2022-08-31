using EPIWalletAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class ProjectCodeRepository : IProjectCodeRepository
    {
        private readonly AppDbContext _appDbContext;


        public ProjectCodeRepository(AppDbContext appDbContext)
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

        public async Task<ProjectCode[]> getAllProjectCodesAsync()
        {
            IQueryable<ProjectCode> query = _appDbContext.ProjectCodes;
            return await query.ToArrayAsync();
        }

        public async Task<ProjectCode> getProjectCodeAsync(string projectcode)
        {
            IQueryable<ProjectCode> query = _appDbContext.ProjectCodes.Where(c => c.code == projectcode);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProjectCode>> Search(string projectcode)
        {
            IQueryable<ProjectCode> query = _appDbContext.ProjectCodes;

            if (!string.IsNullOrEmpty(projectcode))
            {
                query = query.Where(e => e.code.Contains(projectcode));
            }
            return await query.ToListAsync();

        }
    }
}
