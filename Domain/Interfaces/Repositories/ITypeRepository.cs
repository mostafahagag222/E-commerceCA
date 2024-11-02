using Domain.DTOs;

namespace Domain.Interfaces.Repositories
{
    public interface ITypeRepository
    {
        Task<bool> CheckExistenceByIdAsync(int? id);
        Task<List<GetTypesDto>> GetTypesDtoAsync();
    }
}
