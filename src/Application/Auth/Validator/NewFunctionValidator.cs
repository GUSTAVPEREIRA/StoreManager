using FluentValidation;
using Core.Auth.ViewModels;

namespace Application.Auth.Validator
{
    public class NewFunctionValidator : AbstractValidator<NewFunctionDto>
    {
        public NewFunctionValidator()
        {
            RuleFor(x => x.Description).MinimumLength(5).MaximumLength(150).NotEmpty().NotNull();
            RuleFor(x => x.Admin).NotNull();
        }
    }
}