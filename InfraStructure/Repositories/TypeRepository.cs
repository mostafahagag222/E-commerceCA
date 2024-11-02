using Domain.DTOs;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class TypeRepository : GenericRepository<Type>, ITypeRepository
    {
        private readonly EcpContext _context;

        public TypeRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<GetTypesDto>> GetTypesDtoAsync() =>
            await _context.Types
            .AsNoTracking()
            .Select(b => new GetTypesDto() { Id = b.Id, Name = b.Name })
            .ToListAsync();
        public async Task<bool> CheckExistenceByIdAsync(int? id) =>
            await _context.Types
            .AnyAsync(t => t.Id == id);
    }
}
