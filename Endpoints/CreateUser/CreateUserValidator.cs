using FastEndpoints.Validation;
using TryFastEndpointsApp.Request;

namespace TryFastEndpointsApp.Validators
{
    public class CreateUserValidator : Validator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("your first name is required!")
                .MinimumLength(3).WithMessage("your name is too short!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("your email is required!")
                .EmailAddress().WithMessage("your email is invalid!");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("we need your age!");
        }
    }
}