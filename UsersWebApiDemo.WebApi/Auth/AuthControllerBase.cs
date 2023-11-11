using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UsersWebApiDemo.WebApi.Auth;

[Route($"api/auth")]
[ApiController]
public class AuthControllerBase : ControllerBase
{
    private ISender _mediator = null!;

    /// <summary>
    /// Mediator sender
    /// </summary>
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
}
