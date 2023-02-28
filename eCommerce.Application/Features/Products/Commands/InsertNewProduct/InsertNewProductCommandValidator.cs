using FluentValidation;

namespace eCommerce.Application.Features.Products.Commands.InsertNewProduct;

internal sealed class InsertNewProductCommandValidator : AbstractValidator<InsertNewProductCommand>
{
    public InsertNewProductCommandValidator()
    {
        RuleFor(x => x.dto.Name)
            .NotEmpty().WithMessage(a => $"{a.dto.Name} is empty")
            .NotNull();
    }
}
