using FluentValidation;
using UsersWebApiDemo.WebApi.Users.DeleteUser;

namespace UsersWebApiDemo.WebApi.Auth.Features.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}
