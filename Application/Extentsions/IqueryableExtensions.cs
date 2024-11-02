using Domain.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Application.Extentsions
{
    public static class IQueryableExtensions
    {
        public static async Task<PaginationDto<T>> ToPaginationAsync<T>(this IQueryable<T> values, int pageIndex, int pageSize)
        {
            var count = await values.CountAsync();
            var pageItems = await values
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var paginationDTO = new PaginationDto<T>()
            {
                PageNumber = pageIndex,
                Count = count,
                Data = pageItems,
                PageSize = pageSize
            };
            return paginationDTO;
        }
    }
}
