using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IShippingMethodRepository : IGenericRepository<ShippingMethod>
    {
        Task<List<DeliveryMethodDto>> GetDeliveryMethodsDtoAsync();
    }
}
