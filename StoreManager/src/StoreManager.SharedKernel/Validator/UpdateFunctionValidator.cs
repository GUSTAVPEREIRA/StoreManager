using FluentValidation;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.SharedKernel.Validator
{
    public class UpdateFunctionValidator : AbstractValidator<UpdateFunctionDTO>
    {
        public UpdateFunctionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NewFunctionValidator());
        }
    }
}