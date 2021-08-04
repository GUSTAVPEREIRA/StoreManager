using FluentValidation;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.SharedKernel.Validator
{
    public class FunctionValidator : AbstractValidator<FunctionDTO>
    {
        public FunctionValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(5).MaximumLength(150);
            RuleFor(x => x.Admin).NotNull();
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}