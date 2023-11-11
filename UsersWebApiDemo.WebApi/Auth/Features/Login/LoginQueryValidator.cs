using FluentValidation;

namespace UsersWebApiDemo.WebApi.Auth.Features.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
            .NotEmpty().WithMessage("Email is required.");

        RuleFor(v => v.Password)
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .NotEmpty().WithMessage("Password is required.");
    }
}
