using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Common.Service;

namespace UsersWebApiDemo.WebApi.Auth.Features.Login;

public class LoginController : AuthControllerBase
{
    /// <summary>
    /// Login
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(LoginQuery command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}
