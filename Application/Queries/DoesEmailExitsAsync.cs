using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;


namespace Application.Queries;

public class DoesEmailExitsAsync : IRequest<bool>
{
    public string Email { get; set; }
}


public class IsEmailExistsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DoesEmailExitsAsync, bool>
{
    public async Task<bool> Handle(DoesEmailExitsAsync request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.UserRepository.CheckEmailExistedAsync(request.Email);
        return result;
    }
}