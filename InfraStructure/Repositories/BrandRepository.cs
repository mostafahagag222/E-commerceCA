using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class BrandRepository(EcpContext context) : GenericRepository<Brand>(context), IBrandRepository
    {
        private readonly EcpContext _context = context;

        public async Task<bool> CheckExistenceByIdAsync(int? id) =>
            await _context.Brands
            .AnyAsync(b => b.Id == id);
        public async Task<List<GetBrandsDto>> GetBrandsDtoAsync() =>
            await _context.Brands
            .AsNoTracking()
            .Select(b => new GetBrandsDto() { Id = b.Id, Name = b.Name })
            .ToListAsync();
    }
}
