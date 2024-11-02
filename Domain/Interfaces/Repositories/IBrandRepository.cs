using Domain.DTOs;

namespace Domain.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> CheckExistenceByIdAsync(int? id);
        Task<List<GetBrandsDto>> GetBrandsDtoAsync();
    }
}
