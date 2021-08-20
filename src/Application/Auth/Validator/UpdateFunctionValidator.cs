using FluentValidation;
using Core.Auth.ViewModels;

namespace Application.Auth.Validator
{
    public class UpdateFunctionValidator : AbstractValidator<UpdateFunctionDto>
    {
        public UpdateFunctionValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NewFunctionValidator());
        }
    }
}