using Domain.DTOs;
using Domain.DTOs.Payloads;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task AddAddressAsync(AddAddressPayload payload, int userId);
        Task<bool> CheckEmailExistedAsync(string email);
        Task<User> GetUserByEmailAsync(string email);
        Task<AddressDto> GetUserAddress(int id);
    }
}
