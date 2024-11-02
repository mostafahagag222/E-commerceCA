using Domain.DTOs.Payloads;
using FluentValidation;

namespace Application.PayloadsValidations
{
    public class AddressPayloadValidation : AbstractValidator<AddAddressPayload>
    {
        public AddressPayloadValidation()
        {
            RuleFor(a => a.City)
                .NotEmpty();
            RuleFor(a => a.Zipcode)
                .NotEmpty();
            RuleFor(a => a.Street)
                .NotEmpty();
            RuleFor(a => a.State)
                .NotEmpty();
            RuleFor(a => a.FirstName)
                .NotEmpty();
            RuleFor(a => a.LastName)
                .NotEmpty();
        }

    }
}
