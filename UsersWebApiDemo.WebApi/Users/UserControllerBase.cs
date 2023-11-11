using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UsersWebApiDemo.WebApi.Users;

[Route($"api/user")]
[ApiController]
public class UserControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    /// <summary>
    /// Mediator sender
    /// </summary>
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
}
