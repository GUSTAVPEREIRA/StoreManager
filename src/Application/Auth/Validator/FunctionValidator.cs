using FluentValidation;
using Core.Auth.ViewModels;

namespace Application.Auth.Validator
{
    public class FunctionValidator : AbstractValidator<FunctionDto>
    {
        public FunctionValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(5).MaximumLength(150);
            RuleFor(x => x.Admin).NotNull();
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}