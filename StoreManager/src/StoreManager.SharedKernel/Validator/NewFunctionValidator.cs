using FluentValidation;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.SharedKernel.Validator
{
    public class NewFunctionValidator : AbstractValidator<NewFunctionDTO>
    {
        public NewFunctionValidator()
        {
            RuleFor(x => x.Description).MinimumLength(5).MaximumLength(150).NotEmpty().NotNull();
            RuleFor(x => x.Admin).NotNull();
        }
    }
}