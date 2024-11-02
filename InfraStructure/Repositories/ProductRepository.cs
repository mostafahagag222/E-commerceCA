using Application.Extentsions;
using Domain;
using Domain.DTOs;
using Domain.DTOs.Payloads;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;


namespace InfraStructure.Repositories
{
    public class ProductRepository(EcpContext context) : GenericRepository<Product>(context), IProductRepository
    {
        private readonly EcpContext _context = context;

        public async Task<PaginationDto<GetProductsDto>> GetProductsPageAsync(GetProductsPagePayload payload)
        {
            var allSelectedProducts = _context.Products
            .AsNoTracking()
            .Where(p => !payload.BrandId.HasValue || p.BrandId == payload.BrandId)
            .Where(p => !payload.TypeId.HasValue || p.TypeId == payload.TypeId)
            .Where(p => string.IsNullOrEmpty(payload.Search) || p.Name.Contains(payload.Search));
            var sortOptions = (SortOptions)Enum.Parse(typeof(SortOptions), payload.Sort, true);
            switch (sortOptions)
            {
                case SortOptions.name:
                    allSelectedProducts = allSelectedProducts.OrderBy(p => p.Name);
                    break;
                case SortOptions.priceAsc:
                    allSelectedProducts = allSelectedProducts.OrderBy(p => p.Price);
                    break;
                case SortOptions.priceDesc:
                    allSelectedProducts = allSelectedProducts.OrderByDescending(p => p.Price);
                    break;
            }
            var allSelectedProductsDto = allSelectedProducts.Select(p => new GetProductsDto()
            {
                BrandId = p.BrandId,
                Description = p.Description,
                Id = p.Id,
                PictureUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price,
                TypeId = p.TypeId,
                UnitsInStock = p.UnitsInStock
            });
            var selectedProductsPage = await allSelectedProductsDto.ToPaginationAsync<GetProductsDto>(payload.PageIndex, payload.PageSize);
            return selectedProductsPage;
        }
        public async Task<int> GetUnitsInStockForOneProductAsync(int id)
        {
            return await (from p in _context.Products
                          where p.Id == id
                          select p.UnitsInStock).FirstOrDefaultAsync();
        }
    }
}
