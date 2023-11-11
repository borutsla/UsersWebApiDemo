using FluentValidation;

namespace UsersWebApiDemo.WebApi.Users.GetUser;

public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
{
    public GetUserRequestValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}
