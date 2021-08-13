using FluentValidation;
using StoreManager.Core.Inventory.ViewModels;

namespace StoreManager.Application.Inventory.Validator
{
    public class UpdateOptionValidator :  AbstractValidator<UpdateOptionDto>
    {
        public UpdateOptionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            Include(new NewOptionValidator());
        }
    }
}