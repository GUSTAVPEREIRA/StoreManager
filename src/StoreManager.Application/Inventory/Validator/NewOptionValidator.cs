using FluentValidation;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.Application.Inventory.Validator
{
    public class NewOptionValidator : AbstractValidator<NewOptionDto>
    {
        public NewOptionValidator()
        {
            RuleFor(x => x.Name).MinimumLength(1).MaximumLength(100).NotEmpty().NotNull();
        }
    }
}