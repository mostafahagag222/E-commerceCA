using Domain.DTOs;
using Domain.DTOs.Payloads;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PaginationDto<GetProductsDto>> GetProductsPageAsync(GetProductsPagePayload payload);
        Task<int> GetUnitsInStockForOneProductAsync(int id);
    }
}
