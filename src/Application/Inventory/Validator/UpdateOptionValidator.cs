using FluentValidation;
using Core.Inventory.ViewModels;

namespace Application.Inventory.Validator
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