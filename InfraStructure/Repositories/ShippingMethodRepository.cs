using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class ShippingMethodRepository : GenericRepository<ShippingMethod>, IShippingMethodRepository
    {
        private readonly EcpContext _context;

        public ShippingMethodRepository(EcpContext context) : base(context)
        {
            this._context = context;
        }

        public Task<List<DeliveryMethodDto>> GetDeliveryMethodsDtoAsync()
        {
            return _context.ShippingMethods.Select(s => new DeliveryMethodDto()
            {
                DeliveryTime = s.DeliveryTime,
                Description = s.Description,
                Id = int.Parse(s.Id),
                Price = s.Price,
                ShortName = s.Name
            }).ToListAsync();
        }
    }
}
