using Domain.DTOs;
using Domain.DTOs.Payloads;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Repositories
{
    public class UserRepository(EcpContext context) : GenericRepository<User>(context), IUserRepository
    {
        private readonly EcpContext _context = context;

        public async Task AddAddressAsync(AddAddressPayload addAddressPayload, int userId)
        {
            var toBeAddedAddress = new Address()
            {
                City = addAddressPayload.City,
                FirstName = addAddressPayload.FirstName,
                LastName = addAddressPayload.LastName,
                State = addAddressPayload.State,
                Street = addAddressPayload.Street,
                ZipCode = addAddressPayload.Zipcode,
                UserId = userId
            };
            await _context.Addresses.AddAsync(toBeAddedAddress);
        }
        public async Task<bool> CheckEmailExistedAsync(string email) => await _context.Users
            .AnyAsync(u => u.Email == email);
        public async Task<User> GetUserByEmailAsync(string email) => await _context.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
        public async Task<AddressDto> GetUserAddress(int id) => await _context.Addresses
                .Where(a => a.UserId == id)
                .Select(a => new AddressDto()
                {
                    City = a.City,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    State = a.State,
                    Street = a.Street,
                    ZipCode = a.ZipCode
                }).FirstOrDefaultAsync();
    }
}
