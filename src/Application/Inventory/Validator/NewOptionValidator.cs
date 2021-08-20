using FluentValidation;
using Core.Inventory.ViewModels;

namespace Application.Inventory.Validator
{
    public class NewOptionValidator : AbstractValidator<NewOptionDto>
    {
        public NewOptionValidator()
        {
            RuleFor(x => x.Name).MinimumLength(1).MaximumLength(100).NotEmpty().NotNull();
        }
    }
}