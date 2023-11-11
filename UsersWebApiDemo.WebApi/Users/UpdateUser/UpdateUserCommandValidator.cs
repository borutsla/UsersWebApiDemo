using FluentValidation;
using UsersWebApiDemo.WebApi.Users.UpdateUser;

namespace UsersWebApiDemo.WebApi.Auth.Features.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("UserName is required.");

        RuleFor(v => v.Email)
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
            .NotEmpty().WithMessage("Email is required.");

        RuleFor(v => v.Password)
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(v => v.FullName)
            .NotEmpty().WithMessage("FullName is required.");

        RuleFor(v => v.Culture)
            .NotEmpty().WithMessage("Culture is required.");

        RuleFor(v => v.MobileNumber)
            .NotEmpty().WithMessage("MobileNumber is required.");

        RuleFor(v => v.Language)
            .NotEmpty().WithMessage("Language is required.");
    }
}
