using FluentValidation;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.SharedKernel.Validator
{
    public class NewFunctionValidator : AbstractValidator<NewFunctionDTO>
    {
        public NewFunctionValidator()
        {
            RuleFor(x => x.Description).MinimumLength(10).MaximumLength(150).NotEmpty().NotNull();
            RuleFor(x => x.Admin).NotEmpty().NotNull();            
        }
    }
}