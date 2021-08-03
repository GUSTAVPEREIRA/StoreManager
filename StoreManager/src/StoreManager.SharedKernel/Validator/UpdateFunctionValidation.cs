using FluentValidation;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.SharedKernel.Validator
{
    public class UpdateFunctionValidation : AbstractValidator<UpdateFunctionDTO>
    {
        public UpdateFunctionValidation()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}