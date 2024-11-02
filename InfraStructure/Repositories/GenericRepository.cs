using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
//this class works with unit of work as it have no save changes methods
namespace InfraStructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcpContext _context;
        public GenericRepository(EcpContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)

        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
