using Domain;
using Domain.DTOs.Payloads;
using FluentValidation;

namespace Application.PayloadsValidations
{
    public class GetProductsPayloadValidation : AbstractValidator<GetProductsPagePayload>
    {
        public GetProductsPayloadValidation()
        {
            RuleFor(p => p.PageIndex)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(p => p.PageSize)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(p => p.Sort)
                .Must(BeAValidOrEmptySortOption).WithMessage("invalid sort option");
        }
        private bool BeAValidOrEmptySortOption(string sort)
        {
            // Allow null, empty, or whitespace, or valid enum values
            return string.IsNullOrWhiteSpace(sort) || Enum.TryParse<SortOptions>(sort.Trim().ToLower(), true, out _);
        }
    }
}
