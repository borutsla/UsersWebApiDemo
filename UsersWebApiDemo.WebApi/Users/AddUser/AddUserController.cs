using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UsersWebApiDemo.WebApi.Auth.ApiKey;
using UsersWebApiDemo.WebApi.Common.Service;

namespace UsersWebApiDemo.WebApi.Users.AddUser;

public class AddUserController : UserControllerBase
{
    /// <summary>
    /// Add user
    /// </summary>
    /// <param name="command"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("add-user")]
    [ApiKey]
    [SwaggerOperation(Tags = new[] { nameof(User) })]
    public async Task<ActionResult<ServiceResult<bool>>> AddUser(AddUserCommand command, CancellationToken ct)
    {
        return Ok(await Mediator.Send(command, ct));
    }
}
